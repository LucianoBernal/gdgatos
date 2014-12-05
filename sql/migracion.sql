/*agrego cadena migracion*/
Insert  SKYNET.Cadenas(cadena)
values('Cadena Migracion')

/* agrego paises*/
Insert SKYNET.Paises(pais)
values('Argentina')
Insert SKYNET.Paises(pais)
values('Brasil')
Insert SKYNET.Paises(pais)
values('Uruguay')
Insert SKYNET.Paises(pais)
values('Paraguay')
Insert SKYNET.Paises(pais)
values('Bolivia')
Insert SKYNET.Paises(pais)
values('Chile')
/*migro hoteles*/
INSERT INTO SKYNET.Hoteles (calle,numCalle,ciudad,cantidadEstrellas,cadena,pais)
SELECT DISTINCT Hotel_Calle,Hotel_Nro_Calle,Hotel_Ciudad,Hotel_CantEstrella,1,1
FROM gd_esquema.Maestra
UPDATE SKYNET.Hoteles SET nombre = calle
/*------------------------------------------------------------------------------*/
/*migro tiposhabitacion*/
set identity_insert [SKYNET].[TiposHabitacion] ON
INSERT INTO SKYNET.TiposHabitacion (codigo,descripcion,porcentual,capacidad)
SELECT m.Habitacion_Tipo_Codigo,m.Habitacion_Tipo_Descripcion,
	   m.Habitacion_Tipo_Porcentual,m.Habitacion_Tipo_Codigo-1000
FROM gd_esquema.Maestra m
GROUP BY m.Habitacion_Tipo_Codigo,m.Habitacion_Tipo_Descripcion,
	   m.Habitacion_Tipo_Porcentual
set identity_insert [SKYNET].[TiposHabitacion] OFF
	   
/*------------------------------------------------------------------------------*/
/*migro habitacion*/
insert into SKYNET.Habitaciones(hotel,numero,piso,tipo,ubicacion)
select distinct h.idHotel,m.Habitacion_Numero,m.Habitacion_Piso,
				m.Habitacion_Tipo_Codigo,m.Habitacion_Frente 
from gd_esquema.Maestra m,SKYNET.Hoteles h
where m.Hotel_Calle=h.calle and m.Hotel_Nro_Calle=h.numCalle and 
		m.Hotel_Ciudad=h.ciudad

/*------------------------------------------------------------------------------*/
/*migro nacionalidades*/

insert into skynet.Nacionalidades(Nacionalidad)
SELECT DISTINCT Cliente_Nacionalidad FROM gd_esquema.Maestra

/*------------------------------------------------------------------------------*/
/*Inserto tipos Documento*/
insert SKYNET.TiposDoc(nombre)
values('Pasaporte')
insert SKYNET.TiposDoc(nombre)
values('DNI')
insert SKYNET.TiposDoc(nombre)
values('LE')
insert SKYNET.TiposDoc(nombre)
values('LC')
/*Inserto roles*/
insert into SKYNET.Roles (nombre)
	values ('ADMINISTRADOR')
insert into SKYNET.Roles (nombre)
	values ('RECEPCIONISTA')
insert into SKYNET.Roles (nombre)
	values ('GUEST')
/*migro clientes*/
insert into SKYNET.Clientes(apellido, nombre, tipoDoc, numDoc, mail, calle,
			 piso, depto, nacionalidad, numCalle, fechaNac, baja, inconsistencia,rol)
select Cliente_Apellido, Cliente_Nombre, 1, Cliente_Pasaporte_Nro, Cliente_Mail,
		 Cliente_Dom_Calle, Cliente_Piso, Cliente_Depto, 
		 (select idNacionalidad from SKYNET.Nacionalidades 
			where nacionalidad=Cliente_Nacionalidad)
		 ,Cliente_Nro_Calle, Cliente_Fecha_Nac, 0, 0,3 
from gd_esquema.Maestra
GROUP BY Cliente_Pasaporte_Nro, Cliente_Apellido, Cliente_Nombre,
		 Cliente_Mail, Cliente_Dom_Calle, Cliente_Piso, Cliente_Depto,
		 Cliente_Nacionalidad, Cliente_Nro_Calle, Cliente_Fecha_Nac
GO

update C1 set inconsistencia = 1
from SKYNET.Clientes C1
where EXISTS (SELECT 1 FROM SKYNET.Clientes C2 
				WHERE C1.mail = C2.mail AND C1.numDoc <> C2.numDoc)

/*------------------------------------------------------------------------------*/
/*migro consumibles*/
set identity_insert [SKYNET].[Consumibles] ON
insert into SKYNET.Consumibles (codigo,nombre,precio)
select m.Consumible_Codigo,m.Consumible_Descripcion,m.Consumible_Precio
from gd_esquema.Maestra m
where m.Consumible_Codigo is not null
group by m.Consumible_Codigo,m.Consumible_Descripcion,m.Consumible_Precio
set identity_insert [SKYNET].[Consumibles] OFF
/*------------------------------------------------------------------------------*/
/*migro regimenes*/
insert into SKYNET.Regimenes(descripcion,precioBase,habilitado)
select distinct m.Regimen_Descripcion,m.Regimen_Precio,1
from gd_esquema.Maestra m
/*------------------------------------------------------------------------------*/
/*migro recargaEstrellas*/
insert into SKYNET.RecargaEstrellas (recarga)
select m.Hotel_Recarga_Estrella
from gd_esquema.Maestra m
group by m.Hotel_Recarga_Estrella
/*------------------------------------------------------------------------------*/
/*Inserto funciones*/
insert into SKYNET.Funciones (descripcion)
	values ('ABM ROL')
insert into SKYNET.Funciones (descripcion)
	values ('ABM USUARIO')
insert into SKYNET.Funciones (descripcion)
	values ('ABM CLIENTES')
insert into SKYNET.Funciones (descripcion)
	values ('ABM HOTEL')
insert into SKYNET.Funciones (descripcion)
	values ('ABM HABITACION')
insert into SKYNET.Funciones (descripcion)
	values ('ABM REGIMEN DE ESTADIA')
insert into SKYNET.Funciones (descripcion)
	values ('GENERAR O MODIFICAR RESERVA')
insert into SKYNET.Funciones (descripcion)
	values ('CANCELAR RESERVA')
insert into SKYNET.Funciones (descripcion)
	values ('REGISTRAR ESTADIA')
insert into SKYNET.Funciones (descripcion)
	values ('REGISTRAR CONSUMIBLES')
insert into SKYNET.Funciones (descripcion)
	values ('FACTURAR')
	
/*------------------------------------------------------------------------------*/
/*migro RolFunciones*/
insert into skynet.rolFunciones(rol,funcion)
select (select idRol from SKYNET.Roles where nombre='ADMINISTRADOR'), f.idFuncion
		from SKYNET.Funciones f
		where f.descripcion = 'ABM ROL' OR f.descripcion = 'ABM USUARIO'
		OR f.descripcion = 'ABM CLIENTES' OR f.descripcion = 'ABM HOTEL'
		OR f.descripcion = 'ABM HABITACION' 
		OR f.descripcion = 'ABM REGIMEN DE ESTADIA'

insert into skynet.rolFunciones(rol,funcion)
select (select idRol from SKYNET.Roles where nombre='RECEPCIONISTA'), f.idFuncion
		from SKYNET.Funciones f
		where f.descripcion = 'ABM USUARIO' OR f.descripcion = 'ABM CLIENTES'
		OR f.descripcion = 'GENERAR O MODIFICAR RESERVA' 
		OR f.descripcion = 'REGISTRAR ESTADIA'
		OR f.descripcion = 'REGISTRAR CONSUMIBLES' OR f.descripcion = 'FACTURAR PUBLICACIONES'


insert into skynet.rolFunciones(rol,funcion)
select (select idRol from SKYNET.Roles where nombre='GUEST'), f.idFuncion
from SKYNET.Funciones f		
where f.descripcion = 'GENERAR O MODIFICAR RESERVA' 

		
/*inserto usuario admin*/
INSERT INTO SKYNET.Usuarios
(username,pass,habilitado,fallasPassword)
VALUES ('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',1,0)

INSERT INTO SKYNET.UsuarioRolHotel
(usuario ,rol, hotel)
SELECT(select idUser from SKYNET.Usuarios where username='admin'), 
(select idRol from SKYNET.Roles where nombre='ADMINISTRADOR'),
h.idHotel FROM SKYNET.Hoteles h		
		
/*------------------------------------------------------------------------------*/
/*Migro Reservas*/
insert into SKYNET.EstadosReserva (nombre)
values('CANCELADA POR NO-SHOW')
insert into SKYNET.EstadosReserva (nombre)
values('EFECTIVIZADA')
insert into SKYNET.EstadosReserva (nombre)
values ('CORRECTA')
insert into SKYNET.EstadosReserva (nombre)
values('MODIFICADA')
insert into SKYNET.EstadosReserva (nombre)
values('CANCELADA POR RECEPCION')
insert into SKYNET.EstadosReserva (nombre)
values ('CANCELADA POR CLIENTE')

set identity_insert [SKYNET].[Reservas] ON

insert into SKYNET.Reservas(codigoReserva, hotel, regimen, fechaDesde, cantNoches, estado, cliente)
SELECT DISTINCT Reserva_Codigo, (SELECT idHotel 
FROM SKYNET.Hoteles S1 WHERE S1.calle = G1.Hotel_Calle AND S1.numCalle = G1.Hotel_Nro_Calle),
(SELECT idRegimen FROM SKYNET.Regimenes R1 WHERE R1.Descripcion = G1.Regimen_Descripcion),
 Reserva_Fecha_Inicio, Reserva_Cant_Noches, 1/*CODIGO NO COMPLETADA*/,
 (SELECT idCliente FROM SKYNET.Clientes C1 WHERE C1.numDoc = G1.Cliente_Pasaporte_Nro AND C1.mail=G1.Cliente_Mail) FROM gd_esquema.Maestra G1
 

UPDATE R2 SET estado = 2 /*ESTADO EFECTIVIZADA*/
FROM SKYNET.Reservas R2
WHERE EXISTS(SELECT 1 FROM gd_esquema.Maestra G1
WHERE R2.codigoReserva=G1.Reserva_Codigo AND
G1.Estadia_Cant_Noches is not NULL)


/*ACTUALIZO LAS CORRECTAS*/
UPDATE R3 SET estado = 3
FROM SKYNET.Reservas R3
WHERE estado = 1 AND fechaDesde > SYSDATETIME()

/*ACTUALIZO CANCELADAS POR NO-SHOW*/
insert into SKYNET.Cancelaciones(reserva,motivo,fechaCancel)
select r.codigoReserva,'NO-SHOW',r.fechaDesde
from SKYNET.Reservas r
where r.estado=1/*cancelada*/

set identity_insert [SKYNET].[Reservas] OFF

/*------------------------------------------------------------------------------*/
/*migro estadias*/

GO
ALTER TABLE SKYNET.Estadias
NOCHECK CONSTRAINT FK_Estadias_ItemsFactura; 
GO

insert into SKYNET.Estadias (reserva,cantNoches,precioPorNocheEstadia,numeroFactura,itemFactura)
select distinct m.Reserva_Codigo,m.Estadia_Cant_Noches,(
		select m2.Item_Factura_Monto 
		from gd_esquema.Maestra m2
		where m.Reserva_Codigo=m2.Reserva_Codigo and
		m2.Item_Factura_Monto is not null and
		m2.Consumible_Codigo is null),(select m3.Factura_Nro
from gd_esquema.Maestra m3
where m3.Factura_Nro is not null and m3.Reserva_Codigo=m.Reserva_Codigo
group by m3.Factura_Nro)
,1
		from gd_esquema.Maestra m
where(m.Estadia_Cant_Noches is not null)

GO
ALTER TABLE SKYNET.Estadias
CHECK CONSTRAINT FK_Estadias_ItemsFactura; 
GO

/*------------------------------------------------------------------------------*/
/*migro tipoPago*/
insert SKYNET.TiposPago(nombre)
values('Efectivo')
insert SKYNET.TiposPago(nombre)
values('Tarjeta Debito')
insert SKYNET.TiposPago(nombre)
values('Tarjeta Credito')
/*------------------------------------------------------------------------------*/
/*migro facturas poner despues de las estadias*/
set identity_insert [SKYNET].[Facturas] ON
insert into SKYNET.Facturas(facturaNumero,estadia,fecha,tipoPago,monto,diferenciaInconsistencia)
select m.Factura_Nro,m.Reserva_Codigo,m.Factura_Fecha,1,m.Factura_Total,m.Factura_Total-SUM(m.Item_Factura_Cantidad*m.Item_Factura_Monto)
from gd_esquema.Maestra m
where m.Factura_Nro is not null and m.Item_Factura_Cantidad is not null and m.Item_Factura_Monto is not null
group by m.Factura_Nro,m.Reserva_Codigo,m.Factura_Fecha,m.Factura_Total
set identity_insert [SKYNET].[Facturas] OFF

/*------------------------------------------------------------------------------*/
/*migro reservasPorTipoHabitacion*/
insert into SKYNET.ReservasPorTipoHabitacion(idReserva,idTipoHabitacion)
select m.Reserva_Codigo,m.Habitacion_Tipo_Codigo
from gd_esquema.Maestra m
group by m.Reserva_Codigo,m.Habitacion_Tipo_Codigo
/*------------------------------------------------------------------------------*/
insert into SKYNET.ClientesPorEstadia(idCliente,idEstadia)
select   r.cliente,r.codigoReserva
from SKYNET.Reservas r
where r.estado=2 /*estado efectivizado*/
/*------------------------------------------------------------------------------*/
GO
ALTER TABLE SKYNET.ConsumiblesEstadias
NOCHECK CONSTRAINT FK_ConsumiblesEstadias_ItemsFactura; 
GO

go
Create trigger SKYNET.triggerMigrarConsumiblesEstadias on SKYNET.ConsumiblesEstadias 
instead of insert
AS
begin transaction
declare @numeroFactura numeric(18,0),@item numeric(18,0),@numeroFacturaAnt numeric(18,0)
declare @estadia numeric(18,0),@consumible numeric(18,0),@precioTotal numeric(18,2),@cantidad numeric(18,0)
declare cursor_consumibles cursor for
		 select estadia,consumible,precioTotal,cantidad,numeroFactura
		 from inserted
		 order by numeroFactura
		 
open cursor_consumibles
fetch next from cursor_consumibles into @estadia,@consumible,@precioTotal,@cantidad,@numeroFactura
set @numeroFacturaAnt=-1
while @@fetch_status=0
begin
if (@numeroFactura=@numeroFacturaAnt)
set @item=@item+1
else begin
	set @item=2
	set @numeroFacturaAnt=@numeroFactura
	end
insert SKYNET.ConsumiblesEstadias(estadia,consumible,precioTotal,cantidad,numeroFactura,itemFactura) values(@estadia,@consumible,@precioTotal,@cantidad,@numeroFactura,@item)
fetch next from cursor_consumibles into @estadia,@consumible,@precioTotal,@cantidad,@numeroFactura
end
close cursor_consumibles
deallocate cursor_consumibles
commit
go

insert into SKYNET.ConsumiblesEstadias(estadia,consumible,precioTotal,cantidad,numeroFactura)
select m.Reserva_Codigo,m.Consumible_Codigo,m.Item_Factura_Monto*m.Item_Factura_Cantidad,
		m.Item_Factura_Cantidad,m.Factura_Nro
from gd_esquema.Maestra m
where (m.Consumible_Codigo is not null)


drop trigger SKYNET.triggerMigrarConsumiblesEstadias
GO
ALTER TABLE SKYNET.ConsumiblesEstadias
CHECK CONSTRAINT FK_ConsumiblesEstadias_ItemsFactura; 
GO

/*------------------------------------------------------------------------------*/
/*Migro estadiasPorHabitacion*/
insert into SKYNET.EstadiaPorHabitacion(idHotel,idHabitacion,idEstadia)
select distinct h.idHotel,m.Habitacion_Numero,m.Reserva_Codigo as idEstadia
from gd_esquema.Maestra m,SKYNET.Hoteles h
where m.Hotel_Calle=h.calle and
	  m.Hotel_Nro_Calle=h.numCalle and
	  m.Estadia_Cant_Noches is not null
	  
/*------------------------------------------------------------------------------*/
/*Migro HotelesRegimenes*/
insert into SKYNET.HotelesRegimenes(hotel,regimen)
select distinct h.idHotel,r.idRegimen
from gd_esquema.Maestra m,SKYNET.Hoteles h,SKYNET.Regimenes r
where m.Hotel_Calle=h.calle and
	  m.Hotel_Nro_Calle=h.numCalle and
	  m.Regimen_Descripcion is not null and
	  m.Regimen_Descripcion=r.descripcion

/*------------------------------------------------------------------------------*/
/*Migro ItemsFactura*/ 
Insert into SKYNET.ItemsFactura(numeroFactura,item,detalle)
select e.numeroFactura,e.itemFactura,'Estadia'
from SKYNET.Estadias e

Insert into SKYNET.ItemsFactura(numeroFactura,item,detalle)
select ce.numeroFactura,ce.itemFactura,c.nombre
from SKYNET.ConsumiblesEstadias ce,SKYNET.Consumibles c
where ce.consumible=c.codigo

/*obtener disponibles*/
go

create function SKYNET.habitacionesOcupadas(@fecha datetime, @tipoHabitacion numeric(18, 0), @hotel numeric(18, 0))
returns int
begin
declare @ocupadas int
set @ocupadas = 
((select COALESCE(SUM(COALESCE(rh.cantidad, 0)),0) from SKYNET.Reservas r,SKYNET.ReservasPorTipoHabitacion rh
where rh.idReserva=r.codigoReserva and
	  rh.idTipoHabitacion=@tipoHabitacion and
	  r.hotel = @hotel and
	  r.estado between 3 and 4 and
	  @fecha between r.fechaDesde and DATEADD(dd,r.cantNoches-1,r.fechaDesde))+
(select COALESCE(SUM(COALESCE(rh.cantidad,0)), 0) from SKYNET.Reservas r,SKYNET.ReservasPorTipoHabitacion rh, SKYNET.Estadias e
where rh.idReserva=r.codigoReserva and e.reserva= r.codigoReserva and
	  rh.idTipoHabitacion=@tipoHabitacion and
	  r.hotel = @hotel
	  and
	  r.estado = 2 and
	  @fecha between r.fechaDesde and DATEADD(dd,e.cantNoches-1,r.fechaDesde)))
return @ocupadas
end
go
create function SKYNET.habitacionesTotales(@hotel numeric(18, 0), @tipoHabitacion numeric(18,0))
returns int
begin
declare @retorno int
set @retorno = (SELECT COUNT(*) FROM SKYNET.Habitaciones WHERE @hotel = hotel AND @tipoHabitacion = tipo)
return @retorno
end
go
create function SKYNET.habitacionesDisponibles(@fecha datetime, @hotel numeric(18, 0), @tipoHabitacion numeric(18, 0), @cantNoches int)
returns int
begin
declare @i int, @max int, @aux int
set @i = 0
set @max = 0
while (@i<@cantNoches)
begin
set @aux =(SELECT SKYNET.habitacionesOcupadas(DATEADD(dd, @i, @fecha), @tipoHabitacion, @hotel))
if(@max<@aux)
begin
	set @max = @aux
end
set @i = @i + 1
end
return ((SELECT SKYNET.habitacionesTotales(@hotel, @tipoHabitacion)) - @max)
end
go


/*Mayor cantidad reservas canceladas*/
go
CREATE FUNCTION SKYNET.Hotelesconmayorcantidaddereservascanceladas(@anio int,@trimestre smallint )
RETURNS @retorno TABLE
   (
    Hotel     varchar(50),
    CantidadDeReservasCanceladas   numeric(18,0)
    )
AS
BEGIN
	Insert into @retorno 
	select top 5 h.calle+' '+convert(nvarchar(20),h.numCalle),COUNT(*) as CantidadCancelaciones
	from SKYNET.Hoteles h,SKYNET.Reservas r,SKYNET.Cancelaciones c
	where r.hotel=h.idHotel and c.reserva=r.codigoReserva and c.reserva is not null and
	YEAR(c.fechaCancel)=@anio and SKYNET.obtenerTrimestre(c.fechaCancel)=@trimestre
	group by h.idHotel,h.nombre,h.calle,h.numCalle
	order by 2 DESC
	return
     
END
go

/* hoteles con mayor consumibles facturados*/
go
CREATE FUNCTION SKYNET.Hotelesconmayorcantidaddeconsumiblesfacturados(@anio int,@trimestre smallint )
RETURNS @retorno TABLE
   (
    Hotel     varchar(50),
    CantidadDeConsumiblesFacturados   numeric(18,0)
    )
AS
BEGIN
	Insert into @retorno 
	select top 5 h.calle+' '+convert(nvarchar(20),h.numCalle),SUM(ce.cantidad) as CantidadConsumibles
	from SKYNET.Hoteles h,SKYNET.Reservas r,SKYNET.Estadias e,SKYNET.ConsumiblesEstadias ce
	where r.hotel=h.idHotel and e.reserva=r.codigoReserva and ce.estadia=e.reserva and e.cantNoches is not null and
	YEAR(DATEADD(DD, e.cantNoches, r.fechaDesde))=@anio and SKYNET.obtenerTrimestre(DATEADD(DD, e.cantNoches, r.fechaDesde))=@trimestre
	and ce.itemFactura is not null
	group by h.idHotel,h.nombre,h.calle,h.numCalle
	order by 2 DESC
	return
     
END
go

/* hoteles con mayor dias fuera de servicio*/
go
CREATE FUNCTION SKYNET.Hotelesconmayorcantidaddediasfueradeservicio(@anio int,@trimestre smallint )
RETURNS @retorno TABLE
   (
    Hotel     varchar(50),
    CantidadDeDiasFueraDeServicio  numeric(18,0)
    )
AS
BEGIN
	Insert into @retorno 
	select top 5 h.calle+' '+convert(nvarchar(20),h.numCalle),SUM(hist.duracion) as CantidadDeDiasFueraDeServicio
	from SKYNET.Hoteles h,SKYNET.HistorialHoteles hist
	where hist.hotel=h.idHotel and 
	YEAR(DATEADD(DD, hist.duracion, hist.fechaBaja))=@anio and SKYNET.obtenerTrimestre(DATEADD(DD, hist.duracion, hist.fechaBaja))=@trimestre
	group by h.idHotel,h.nombre,h.calle,h.numCalle
	order by 2 DESC
	return
     
END
go


/* Habitaciones mayor cantidad de dias ocupadas*/
go
CREATE FUNCTION SKYNET.Habitacionesconmayorcantidaddediasocupados(@anio int,@trimestre smallint )
RETURNS @retorno TABLE
   (
    Hotel     varchar(50),
    Habitacion numeric(18,0),
    CantidadDeDiasOcupada  numeric(18,0)
    )
AS
BEGIN
	Insert into @retorno 
	select top 5 h.calle+' '+convert(nvarchar(20),h.numCalle),eh.idHabitacion,SUM(e.cantNoches) as CantidadDeDiasOcupada
	from SKYNET.Hoteles h,SKYNET.EstadiaPorHabitacion eh,SKYNET.Estadias e, SKYNET.Reservas r
	where eh.idHotel =h.idHotel and eh.idEstadia=e.reserva and e.reserva=r.codigoReserva and
	YEAR(DATEADD(DD, e.cantNoches, r.fechaDesde))=@anio and SKYNET.obtenerTrimestre(DATEADD(DD, e.cantNoches, r.fechaDesde))=@trimestre
	group by h.idHotel,h.nombre,h.calle,h.numCalle,eh.idHabitacion
	order by 3 DESC
	return
     
END
go


/* Habitaciones mayor cantidad de veces ocupada*/
go
CREATE FUNCTION SKYNET.Habitacionesconmayorcantidaddevecesocupadas(@anio int,@trimestre smallint )
RETURNS @retorno TABLE
   (
    Hotel     varchar(50),
    Habitacion numeric(18,0),
    CantidadDeVecesOcupada  numeric(18,0)
    )
AS
BEGIN
	Insert into @retorno 
	select top 5 h.calle+' '+convert(nvarchar(20),h.numCalle),eh.idHabitacion,count(eh.idEstadia) as CantidadDeVecesOcupada
	from SKYNET.Hoteles h,SKYNET.EstadiaPorHabitacion eh,SKYNET.Estadias e, SKYNET.Reservas r
	where eh.idHotel =h.idHotel and eh.idEstadia=e.reserva and e.reserva=r.codigoReserva and
	YEAR(DATEADD(DD, e.cantNoches, r.fechaDesde))=@anio and SKYNET.obtenerTrimestre(DATEADD(DD, e.cantNoches, r.fechaDesde))=@trimestre
	group by h.idHotel,h.nombre,h.calle,h.numCalle,eh.idHabitacion
	order by 3 DESC
	return
     
END
go


/* Clientes mayor cantidad de Puntos*/
go
CREATE FUNCTION SKYNET.Clientesconmayorcantidaddepuntos(@anio int,@trimestre smallint )
RETURNS @retorno TABLE
   (
    idCliente numeric(18,0),
    Nombre    varchar(255),
    CantidadDePuntos  numeric(18,0)
    )
AS
BEGIN
	Insert into @retorno 
	select top 5 c.idCliente,c.apellido+','+c.nombre as 'Apellido,nombre',floor(sum(e.precioPorNocheEstadia*r.cantNoches)/10)+ floor((select sum(ce.precioTotal)/5
																	   from SKYNET.ConsumiblesEstadias ce,SKYNET.Estadias e2,SKYNET.Reservas r2
																	   where ce.estadia=e2.reserva and
																	   e2.reserva=r2.codigoReserva  and
																	   YEAR(DATEADD(DD, e2.cantNoches, r2.fechaDesde))=@anio and SKYNET.obtenerTrimestre(DATEADD(DD, e2.cantNoches, r2.fechaDesde))=@trimestre 
																	   and r2.cliente=c.idCliente and ce.numeroFactura is not null and ce.itemFactura is not null
																	   ))as CantidadDePuntos
	from SKYNET.Clientes c,SKYNET.Reservas r,SKYNET.Estadias e
	where r.cliente=c.idCliente and e.reserva=r.codigoReserva and e.numeroFactura is not null and e.itemFactura is not null and
	YEAR(DATEADD(DD, e.cantNoches, r.fechaDesde))=@anio and SKYNET.obtenerTrimestre(DATEADD(DD, e.cantNoches, r.fechaDesde))=@trimestre
	group by c.idCliente,c.apellido,c.nombre
	order by 3 DESC
	return
     
END
go


/* ------ funciones auxiliares-----*/
GO
CREATE FUNCTION SKYNET.obtenerTrimestre(@fecha datetime)
returns smallint
begin
return (select case when month(@fecha)<=3 then 1
				   when month(@fecha)<=6 then 2
				   when month(@fecha)<=9 then 3
				   when month(@fecha)<=12 then 4
				   end)
end
go



/* Trigger al insertar cancelaciones cambia estado de la reserva*/
create trigger tr_cancelaciones_ins on SKYNET.Cancelaciones
for Insert
as
begin transaction
declare @reserva numeric(18,0),@motivo nvarchar(50)
declare cancelaciones_nuevas cursor for 
		select reserva,motivo
		from Inserted
open cancelaciones_nuevas
fetch next from cancelaciones_nuevas into @reserva,@motivo
while @@fetch_status=0
begin
if(coalesce((select r.estado
   from SKYNET.Reservas r
   where r.codigoReserva=@reserva),3)between 2 and 4 )
   begin
   update SKYNET.Reservas set estado=( select case  when @motivo like '%cliente%' then 6
												 when @motivo like '%recepcion%' then  5
										    	 else 1 end	)
   where codigoReserva=@reserva
   end
fetch next from cancelaciones_nuevas into @reserva,@motivo
end	
close cancelaciones_nuevas
deallocate cancelaciones_nuevas
commit 

/* trigger verifica que no se supere maximos de huespedes para una reserva*/

create trigger tr_clientesEstadias on SKYNET.ClientesPorEstadia
for Insert,Update
as
begin transaction
if(exists(select 1
		  from Inserted i,SKYNET.ClientesPorEstadia ce
		  where i.idEstadia=ce.idEstadia
		  group by i.idEstadia
		  having count(*)>(select sum(h.cantidad*th.capacidad)
						   from SKYNET.ReservasPorTipoHabitacion h,SKYNET.TiposHabitacion th
						   where h.idReserva=i.idEstadia and 
						   h.idTipoHabitacion=th.codigo)))
						   begin
						   RAISERROR('Se ingresaron más huespedes que los posibles de albergar',14,1)
						   rollback
						   end
else	
commit


/* Trigger al insertar estadia cambia estado de la reserva a efectivizada*/
create trigger insert_estadias_cambiarEstadoReserva on SKYNET.Estadias
for Insert
as
declare cursor_reservasACambiar cursor for
		select reserva
		from Inserted
declare @reserva numeric(18,0)
open cursor_reservasACambiar
fetch next from cursor_reservasACambiar into @reserva
while @@fetch_status=0
begin
update SKYNET.Reservas set estado=2
where codigoReserva=@reserva
fetch next from cursor_reservasACambiar into @reserva
end
close cursor_reservasACambiar
deallocate cursor_reservasACambiar
begin transaction
commit


/* Trigger calcular PrecioTotal en ConsumiblesEstadias para insert y update*/
create trigger calcultar_precioTotal_ConsumiblesEstadias on SKYNET.ConsumiblesEstadias
for Insert,Update
as
begin transaction
if(update(consumible) or update(cantidad))
begin
declare cursor_consumiblesEstadias cursor for
			select distinct idConsumibleEstadia
			from Inserted
declare @idConsumibleEstadia numeric(18,0)
open cursor_consumiblesEstadias
fetch next from cursor_consumiblesEstadias into @idConsumibleEstadia
while @@fetch_status=0
begin
update SKYNET.ConsumiblesEstadias set precioTotal=(select c.precio*ce.cantidad
												   from SKYNET.ConsumiblesEstadias ce,SKYNET.Consumibles c
												   where ce.idConsumibleEstadia=@idConsumibleEstadia and
												   ce.consumible=c.codigo)
where idConsumibleEstadia=@idConsumibleEstadia
fetch next from cursor_consumiblesEstadias into @idConsumibleEstadia
end
close cursor_consumiblesEstadias
deallocate cursor_consumiblesEstadias
end
commit


/* Trigger calcular PrecioPorNoche en EstadiaPorHabitacion*/
create trigger insert_EstadiaPorHabitacion_CalculoPrecioPorNoche on SKYNET.EstadiaPorHabitacion
for insert
as
begin transaction
declare cursor_ids_Estadias cursor for
			select distinct idEstadia
			from Inserted
declare @idEstadia numeric(18,0),@precioPorNoche numeric(18,2),@recargaEstrella numeric(18,2)
set @recargaEstrella=(select top 1 recarga from SKYNET.RecargaEstrellas)
open cursor_ids_Estadias
fetch next from cursor_ids_Estadias into @idEstadia
while @@fetch_status=0
begin
set @precioPorNoche = (select sum(hot.cantidadEstrellas*@recargaEstrella
													+reg.precioBase*th.porcentual)
												  from SKYNET.EstadiaPorHabitacion eh,
													   SKYNET.Habitaciones h,
													   SKYNET.TiposHabitacion th,
													   SKYNET.Hoteles hot, SKYNET.Reservas r,
													   SKYNET.Regimenes reg
												  where eh.idEstadia=@idEstadia and
												  eh.idHabitacion=h.numero and
												  eh.idHotel=h.hotel and
												  h.tipo=th.codigo and
												  hot.idHotel=h.hotel and
												  eh.idEstadia=r.codigoReserva and 
												  r.regimen=reg.idRegimen)		
update SKYNET.Estadias set precioPorNocheEstadia=@precioPorNoche										  
where reserva=@idEstadia
fetch next from cursor_ids_Estadias into @idEstadia
end
close cursor_ids_Estadias
deallocate cursor_ids_Estadias
commit



