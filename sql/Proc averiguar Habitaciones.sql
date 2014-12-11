/* Procedure asignar Habitaciones a una estadia*/
go
create procedure SKYNET.asignarHabitaciones(@estadia numeric(18,0))
as
begin
declare @cantidad int,@tipoHabitacion numeric(18,0),@hotel numeric(18,0),@fecha datetime
declare cursor_TiposHabitaciones cursor for
	select rth.cantidad,rth.idTipoHabitacion
	from SKYNET.ReservasPorTipoHabitacion rth where rth.idReserva=@estadia
select @hotel=r.hotel,@fecha=r.fechaDesde from SKYNET.Reservas r where r.codigoReserva=@estadia
open cursor_TiposHabitaciones
fetch next from cursor_TiposHabitaciones into @cantidad,@tipoHabitacion
while @@FETCH_STATUS=0
begin
insert into SKYNET.EstadiaPorHabitacion(idEstadia,idHotel,idHabitacion) (
select top(@cantidad) @estadia,@hotel,h.numero
from SKYNET.Habitaciones h
where h.hotel=@hotel and h.tipo=@tipoHabitacion and h.baja=0 and
not exists(select 1 from SKYNET.Reservas r, SKYNET.EstadiaPorHabitacion eh
where eh.idEstadia=r.codigoReserva and eh.idHotel=@hotel
and eh.idHabitacion=h.numero and @fecha between r.fechaDesde and DATEADD(dd,r.cantNoches,r.fechaDesde)))
fetch next from cursor_TiposHabitaciones into @cantidad,@tipoHabitacion
end
close cursor_TiposHabitaciones
deallocate cursor_TiposHabitaciones
end
go

/*Mostrar Habitaciones de una estadia*/

go
create function SKYNET.mostrarHabitaciones(@estadia numeric(18,0))
returns @retorno table(
	numeroHabitacion	numeric(18,0),
	piso				numeric(18,0),
	tipo				nvarchar(255),
	ubicacion			nvarchar(50),
	descripcion			nvarchar(50)
	)
as
begin
insert into @retorno(numeroHabitacion,piso,tipo,ubicacion,descripcion)
(select eh.idHabitacion,h.piso,th.descripcion,h.ubicacion,h.descripcion from SKYNET.EstadiaPorHabitacion eh,
SKYNET.Habitaciones h,SKYNET.TiposHabitacion th
where eh.idEstadia=@estadia and h.hotel=eh.idHotel and h.numero=eh.idHabitacion
and h.tipo=th.codigo )
return 
end
go


