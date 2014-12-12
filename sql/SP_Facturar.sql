create procedure SKYNET.facturarUnaEstadia(@estadia numeric (18,0),@fecha datetime,
										   @nombreTipoPago nvarchar(255),@numTarjeta numeric(18,0),
										   @datosTarjeta nvarchar(255))
as
declare @numeroFactura numeric(18,0)
if(@estadia is null)
begin
RAISERROR('IngreseEstadia',14,1)
return
end
else
begin
if (not exists(select 1 from SKYNET.Facturas f where f.estadia=@estadia))/*
	begin ME ROMPE EL PROGRAMITA
	raiserror('Ya se facturo dicha estadia',14,1)
	return
	end
	else*/
	begin
	if (@numTarjeta is null)
		begin
		insert SKYNET.Facturas(diferenciaInconsistencia,estadia,fecha,monto,tipoPago) 
		values(0,@estadia,coalesce(@fecha,(select top 1 fecha from SKYNET.Config)),0,1)
		set @numeroFactura=(select f.facturaNumero
			   from SKYNET.Facturas f
			   where f.estadia=@estadia)
		end
		else
		begin
		insert SKYNET.Facturas(diferenciaInconsistencia,estadia,fecha,monto,tipoPago) 
		values(0,@estadia,coalesce(@fecha,(select top 1 fecha from SKYNET.Config)),0,(select top 1 t.idTipoPago
															from SKYNET.TiposPago t
															where t.nombre=@nombreTipoPago))
		set @numeroFactura=(select f.facturaNumero
			   from SKYNET.Facturas f
			   where f.estadia=@estadia)
		insert SKYNET.DatosTarjeta(nroFactura,numTarjeta,datosTarjeta)
		values(@numeroFactura,@numTarjeta,@datosTarjeta) 
		end
	insert into SKYNET.ItemsFactura(numeroFactura,item,detalle,cantidad,precioUnitario) (select @numeroFactura,1,'Estadia efectiva de '+convert(nvarchar(4),coalesce(e.cantNoches,0))+case when(e.cantNoches=1)then' dia' else ' dias'end+' sobre una reserva de '
			+convert(nvarchar(4),r.cantNoches)+case when(r.cantNoches=1)then' dia' else ' dias'end ,1,(e.precioPorNocheEstadia *  r.cantNoches)	from Skynet.Estadias e,Skynet.Reservas r
																	where e.reserva=r.codigoReserva
																	and e.reserva=@estadia)
	update SKYNET.Estadias set numeroFactura=@numeroFactura,itemFactura=1
	where reserva=@estadia
	create table #consumiblesDeLaEstadia(
				idTemporal numeric(18,0) identity(0,1),
				idConsumibleEstadia numeric(18,0),
				nombreConsumible nvarchar(255),
				cantidad numeric(18,0),
				precioUnitario numeric(18,0))
	insert into #consumiblesDeLaEstadia(idConsumibleEstadia,nombreConsumible,cantidad,precioUnitario)
	(select ce.idConsumibleEstadia,(select c.nombre from Consumibles c
								 where c.codigo=ce.consumible),ce.cantidad,ce.precioTotal/ce.cantidad
	from SKYNET.ConsumiblesEstadias ce
	where ce.estadia=@estadia)
	declare @contador int,@cantFilas int,@item int,@idConsumibleEstadia numeric(18,0),@nombreConsumible nvarchar(255)
	declare @cantidad numeric(18,0),@precioUnitario numeric(18,2)
	set @contador=0
	set @cantFilas= (select COUNT(*) from #consumiblesDeLaEstadia)
	set @item=2
	ALTER TABLE SKYNET.ConsumiblesEstadias
	NOCHECK CONSTRAINT FK_ConsumiblesEstadias_ItemsFactura
	while @contador<@cantFilas
	begin
	select @idConsumibleEstadia=idConsumibleEstadia,@nombreConsumible=nombreConsumible,
	@cantidad=cantidad,@precioUnitario=precioUnitario
	from #consumiblesDeLaEstadia
	where idTemporal=@contador
	update SKYNET.ConsumiblesEstadias set numeroFactura=@numeroFactura,itemFactura=@item
	where idConsumibleEstadia= @idConsumibleEstadia
	insert SKYNET.ItemsFactura(numeroFactura,item,detalle,cantidad,precioUnitario)
	values (@numeroFactura,@item,@nombreConsumible,@cantidad,@precioUnitario)
	set @item=@item+1
	set @contador=@contador+1
	end
	ALTER TABLE SKYNET.ConsumiblesEstadias
	CHECK CONSTRAINT FK_ConsumiblesEstadias_ItemsFactura
	declare @inconsistencia numeric(18,2),@monto numeric(18,2)
	select @inconsistencia=f.diferenciaInconsistencia,@monto=f.monto from SKYNET.Facturas f where f.facturaNumero=@numeroFactura
	;DISABLE TRIGGER calculo_monto_factura on SKYNET.ItemsFactura
	if(@inconsistencia=0)
	begin	
	insert SKYNET.ItemsFactura(numeroFactura,item,detalle,cantidad,precioUnitario) 
		   values(@numeroFactura,@item,'Descuento por regimen '+(select reg.descripcion from SKYNET.Reservas r,SKYNET.Regimenes reg
												  where r.codigoReserva=@estadia
												  and r.regimen=reg.idRegimen),1,(@monto-(select sum(cantidad*precioUnitario) from SKYNET.ItemsFactura itf
																						where itf.numeroFactura=@numeroFactura)))
	end
	;ENABLE TRIGGER calculo_monto_factura on SKYNET.ItemsFactura
	end
end
/* Emitir factura*/
go
create procedure SKYNET.registrarCheckOut(@estadia numeric(18,0),@usuarioEgreso numeric(18,0))
as
begin
update SKYNET.Estadias set cantNoches = DATEDIFF(day, (SELECT fechaDesde FROM SKYNET.Reservas WHERE codigoReserva = @estadia), (select top 1 fecha from SKYNET.Config)),usuarioEgreso = @usuarioEgreso WHERE reserva = @estadia
end
go
create function SKYNET.emitirFactura(@estadia numeric(18,0))
returns @retorno table (
		NumeroDeFactura nvarchar(18),
		Item			nvarchar(18),
		Detalle		    nvarchar(255),
		Cantidad	    nvarchar(18),
		PrecioUnitario  nvarchar(18),
		SubTotal	    numeric(18,2)
		)
as
begin
if(not exists(select 1 from SKYNET.Facturas f where f.estadia=@estadia))
	begin
	insert @retorno(Detalle) values('Error, primero debe facturarse la estadia')
	end
	else
	begin
	declare @cantidad numeric(18,0)
	insert into @retorno(NumeroDeFactura,Item,Detalle,Cantidad,PrecioUnitario,SubTotal)
		 	(select f.facturaNumero,itf.item,itf.detalle,itf.cantidad,itf.precioUnitario,itf.cantidad*itf.precioUnitario
			from Skynet.Facturas f,SKYNET.ItemsFactura itf
			 where f.estadia=@estadia
			 and itf.numeroFactura=f.facturaNumero)
			 order by 2
	 declare @inconsistencia numeric (18,2),@monto numeric(18,2)
	 select @monto=f.monto,@inconsistencia=f.diferenciaInconsistencia from SKYNET.Facturas f where f.estadia=@estadia
	insert @retorno(NumeroDeFactura,Item,Detalle,Cantidad,PrecioUnitario,SubTotal) 
		   values('','','Total','','',@monto)
	 if(@inconsistencia!=0)
		begin
		insert @retorno(NumeroDeFactura,Item,Detalle,Cantidad,PrecioUnitario,SubTotal) 
		   values('','','Diferencia Inconsistencia de la migracion','','',@inconsistencia)
		end
    
	end
return
end
go

  go
  create function SKYNET.validarBajaHotel (@hotel numeric(18,0),@fechaDesde datetime,@duracion int)
  returns int as
  begin/*
  return (select 1 from SKYNET.HistorialHoteles where hotel = @hotel and 
  (@fechaDesde between fechaBaja and dateadd(dd,duracion,fechaBaja) or 
  dateadd(dd,@duracion,@fechaDesde) between fechaBaja and dateadd(dd,duracion,fechaBaja) ))*/
  declare @i int, @problemas int, @deboHacerElWhile int
  set @i = 0
  set @problemas = 0
  set @deboHacerElWhile = (select count(*) from SKYNET.HistorialHoteles where hotel = @hotel)
  if(@deboHacerElWhile>0) begin
  while (@i<@duracion) begin
  set @problemas =(select count(*) from SKYNET.HistorialHoteles where hotel = @hotel and 
  (dateadd(dd, @i, @fechaDesde) between dateadd(dd, -1, fechaBaja) and dateadd(dd,duracion,fechaBaja)))
  if (@problemas > 0)
  begin
  set @i = @duracion
  end
  set @i=@i+1
  end
  end
  return @problemas
  end
  go




