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

drop function SKYNET.hotelesMayorCantidadDeReservasCanceladas

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

SELECT SKYNET.obtenerTrimestre(DATEADD(mm, -8, getdate()))


SELECT *
from SKYNET.hotelesMayorCantidadDeReservasCanceladas(2014,5)