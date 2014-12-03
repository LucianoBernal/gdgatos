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

/* --------- ---*/
drop function SKYNET.Hotelesconmayorcantidaddereservascanceladas

/*----- ---*/

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

/* --------- ---*/
drop function SKYNET.Hotelesconmayorcantidaddeconsumiblesfacturados

/*----- ---*/

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

/* --------- ---*/
drop function SKYNET.Hotelesconmayorcantidaddediasfueradeservicio

/*----- ---*/



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

/* --------- ---*/
drop function SKYNET.Habitacionesconmayorcantidaddediasocupados

/*----- ---*/


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

/* --------- ---*/
drop function SKYNET.Habitacionesconmayorcantidaddevecesocupadas

/*----- ---*/



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

/* --------- ---*/
drop function SKYNET.Clientesconmayorcantidaddepuntos

/*----- ---*/





	





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






/* unit test(??????? */
SELECT SKYNET.obtenerTrimestre(DATEADD(mm, 2, getdate()))


SELECT *
from SKYNET.Hotelesconmayorcantidaddereservascanceladas(2014,1)


SELECT *
from SKYNET.Hotelesconmayorcantidaddeconsumiblesfacturados(2013,1)

SELECT *
from SKYNET.Hotelesconmayorcantidaddediasfueradeservicio(2013,1)

SELECT *
from SKYNET.Habitacionesconmayorcantidaddediasocupados(2013,1)

SELECT *
from SKYNET.Habitacionesconmayorcantidaddevecesocupadas(2013,1)

SELECT *
from SKYNET.Clientesconmayorcantidaddepuntos(2013,1)

