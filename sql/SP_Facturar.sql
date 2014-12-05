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
if (exists(select 1 from SKYNET.Facturas f where f.estadia=@estadia))
	begin
	raiserror('Ya se facturo dicha estadia',14,1)
	return
	end
	else
	begin
	if (@numTarjeta is null)
		begin
		insert SKYNET.Facturas(diferenciaInconsistencia,estadia,fecha,monto,tipoPago) 
		values(0,@estadia,coalesce(@fecha,sysdatetime()),0,1)
		set @numeroFactura=(select f.facturaNumero
			   from SKYNET.Facturas f
			   where f.estadia=@estadia)
		end
		else
		begin
		insert SKYNET.Facturas(diferenciaInconsistencia,estadia,fecha,monto,tipoPago) 
		values(0,@estadia,coalesce(@fecha,sysdatetime()),0,(select top 1 t.idTipoPago
															from SKYNET.TiposPago t
															where t.nombre=@nombreTipoPago))
		set @numeroFactura=(select f.facturaNumero
			   from SKYNET.Facturas f
			   where f.estadia=@estadia)
		insert SKYNET.DatosTarjeta(nroFactura,numTarjeta,datosTarjeta)
		values(@numeroFactura,@numTarjeta,@datosTarjeta) 
		end
	insert SKYNET.ItemsFactura(numeroFactura,item,detalle) values(@numeroFactura,1,'Estadia')
	update SKYNET.Estadias set numeroFactura=@numeroFactura,itemFactura=1
	where reserva=@estadia
	create table #consumiblesDeLaEstadia(
				idTemporal numeric(18,0) identity(0,1),
				idConsumibleEstadia numeric(18,0),
				nombreConsumible nvarchar(255))
	insert into #consumiblesDeLaEstadia(idConsumibleEstadia,nombreConsumible)
	(select ce.idConsumibleEstadia,(select c.nombre from Consumibles c
								 where c.codigo=ce.consumible)
	from SKYNET.ConsumiblesEstadias ce
	where ce.estadia=@estadia)
	declare @contador int,@cantFilas int,@item int,@idConsumibleEstadia numeric(18,0),@nombreConsumible nvarchar(255)
	set @contador=0
	set @cantFilas= (select COUNT(*) from #consumiblesDeLaEstadia)
	set @item=2
	ALTER TABLE SKYNET.ConsumiblesEstadias
	NOCHECK CONSTRAINT FK_ConsumiblesEstadias_ItemsFactura
	while @contador<@cantFilas
	begin
	select @idConsumibleEstadia=idConsumibleEstadia,@nombreConsumible=nombreConsumible
	from #consumiblesDeLaEstadia
	where idTemporal=@contador
	update SKYNET.ConsumiblesEstadias set numeroFactura=@numeroFactura,itemFactura=@item
	where idConsumibleEstadia= @idConsumibleEstadia
	insert SKYNET.ItemsFactura(numeroFactura,item,detalle)
	values (@numeroFactura,@item,@nombreConsumible)
	set @item=@item+1
	set @contador=@contador+1
	end
	ALTER TABLE SKYNET.ConsumiblesEstadias
	CHECK CONSTRAINT FK_ConsumiblesEstadias_ItemsFactura
	end
end
/* Emitir factura*/
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
declare @cantidad numeric(18,0)
insert into @retorno(NumeroDeFactura,Item,Detalle,Cantidad,PrecioUnitario,SubTotal)
       (select e.numeroFactura,e.itemFactura,'Estadia efectiva de '+convert(nvarchar(4),e.cantNoches)+case when(e.cantNoches=1)then' dia' else ' dias'end,r.cantNoches,e.precioPorNocheEstadia,(e.precioPorNocheEstadia *  r.cantNoches)
        from Skynet.Estadias e,Skynet.Reservas r
        where e.reserva=r.codigoReserva
        and e.reserva=@estadia)
        union
        (select f.facturaNumero,itf.item,itf.detalle,(select ce.cantidad from 
														 Skynet.ConsumiblesEstadias ce where ce.estadia=@estadia 
														 and ce.itemFactura=itf.item),(select c.precio from 
														 Skynet.ConsumiblesEstadias ce, SKYNET.Consumibles c where ce.estadia=@estadia 
														 and ce.itemFactura=itf.item and ce.consumible=c.codigo),(select ce.precioTotal from 
														 Skynet.ConsumiblesEstadias ce where ce.estadia=@estadia 
														 and ce.itemFactura=itf.item)
		from Skynet.Facturas f,SKYNET.ItemsFactura itf
         where itf.detalle!='Estadia' and f.estadia=@estadia
         and itf.numeroFactura=f.facturaNumero)
         order by 2
insert @retorno(NumeroDeFactura,Item,Detalle,Cantidad,PrecioUnitario,SubTotal) 
	   values('','','Total','','',(select sum(SubTotal)from @retorno))
return
end
go

drop function SKYNET.emitirFactura
drop proc SKYNET.facturarUnaEstadia

select *
from SKYNET.emitirFactura(10002)



/* ------ unit test------*/

insert SKYNET.Reservas(hotel,cliente)values(1,(select top 1 c.idCliente from SKYNET.Clientes c))
insert SKYNET.Estadias(reserva,cantNoches) values((select MAX(r.codigoReserva) from SKYNET.Reservas r),5)
insert SKYNET.ConsumiblesEstadias(estadia,consumible) values((select MAX(r.codigoReserva) from SKYNET.Reservas r),2324)
insert SKYNET.ConsumiblesEstadias(estadia,consumible) values((select MAX(r.codigoReserva) from SKYNET.Reservas r),2325)

(select MAX(r.codigoReserva) from SKYNET.Reservas r)

exec SKYNET.facturarUnaEstadia @estadia=110746, @fecha=null
								,@nombreTipoPago='Tarjeta Credito',	
								@numTarjeta=123456,@datosTarjeta='pepe'
