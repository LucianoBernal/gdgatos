/*Trigger instead of insert para validar habitaciones de la estadia segun reserva*/
go
create trigger estadiaPorHabitacion_Validacion_Insert on SKYNET.EstadiaPorHabitacion
instead of insert
as
begin transaction
	if(exists(select 1
			  from inserted ins,SKYNET.Reservas r
			  where ins.idEstadia=r.codigoReserva
			  and ins.idHotel!=r.hotel))
	begin
	raiserror('El hotel de la habitacion no corresponde con el de la reserva',14,1)
	end
	else
	begin
		if(exists(select 1
		from inserted ins,SKYNET.Habitaciones h
		where ins.idHotel=h.hotel and
		ins.idHabitacion=h.numero and
		not exists(select 1
		from SKYNET.ReservasPorTipoHabitacion rth
		where rth.idReserva=ins.idEstadia and rth.idTipoHabitacion=h.tipo)))
			begin
			raiserror('El tipo de la habitacion no corresponde con el de la reserva',14,1)
			end				 
			else
			begin
			if(exists(select 1
			from inserted ins
			group by ins.idEstadia
			having count(*)>(select sum(rth.cantidad) from SKYNET.ReservasPorTipoHabitacion rth
							where rth.idReserva=ins.idEstadia )-(select count(*)from
																SKYNET.EstadiaPorHabitacion eh
																where eh.idEstadia=ins.idEstadia)))
			begin
			raiserror('Se superaron la cantidad de habitaciones de la reserva',14,1)
			end
			else
			begin
			insert into	SKYNET.EstadiaPorHabitacion(idEstadia,idHabitacion,idHotel)
			(select idEstadia,idHabitacion,idHotel  from inserted)
			end
			end
	end
commit		


go




/*------ unit Test  -------------*/

insert SKYNET.Reservas(hotel, cliente, regimen, cantNoches)values(1,(select top 1 c.idCliente from SKYNET.Clientes c), 2, 5)
insert SKYNET.ReservasPorTipoHabitacion(idReserva, idTipoHabitacion, cantidad) values ((select MAX(codigoReserva) from SKYNET.Reservas), 1003, 2)
insert SKYNET.Estadias(reserva,cantNoches) values((select MAX(r.codigoReserva) from SKYNET.Reservas r),3)
insert SKYNET.EstadiaPorHabitacion(idEstadia,idHabitacion,idHotel) values((select MAX(r.codigoReserva) from SKYNET.Reservas r),6,1)




