/*Mayor cantidad reservas canceladas*/
go
CREATE FUNCTION SKYNET.hotelesMayorCantidadDeReservasCanceladas(@anio int,@trimestre smallint )
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
drop function SKYNET.hotelesMayorCantidadDeReservasCanceladas

/*----- ---*/

/* hoteles con mayor consumibles facturados*/
go
CREATE FUNCTION SKYNET.hotelesMayorCantidadDeConsumiblesFacturados(@anio int,@trimestre smallint )
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
drop function SKYNET.hotelesMayorCantidadDeConsumiblesFacturados

/*----- ---*/

/* hoteles con mayor dias fuera de servicio*/
go
CREATE FUNCTION SKYNET.hotelesMayorCantidadDiasFueraDeServicio(@anio int,@trimestre smallint )
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
drop function SKYNET.hotelesMayorCantidadDiasFueraDeServicio

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
from SKYNET.hotelesMayorCantidadDeReservasCanceladas(2014,4)


SELECT *
from SKYNET.hotelesMayorCantidadDeConsumiblesFacturados(2013,1)

SELECT *
from SKYNET.hotelesMayorCantidadDiasFueraDeServicio(2013,1)



