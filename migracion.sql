/*agrego cadena migracion*/
Insert  SKYNET.Cadenas(cadena)
values('Cadena Migracion')

/* agrego pais argentina*/
Insert SKYNET.Paises(pais)
values('Argentina')

/*migro hoteles*/
INSERT INTO SKYNET.Hoteles (calle,numCalle,ciudad,cantidadEstrellas,cadena,pais)
SELECT DISTINCT Hotel_Calle,Hotel_Nro_Calle,Hotel_Ciudad,Hotel_CantEstrella,1,1
FROM gd_esquema.Maestra
/*------------------------------------------------------------------------------*/
/*migro tiposhabitacion*/
INSERT INTO SKYNET.TiposHabitacion (codigo,descripcion,porcentual)
SELECT m.Habitacion_Tipo_Codigo,m.Habitacion_Tipo_Descripcion,
	   m.Habitacion_Tipo_Porcentual
FROM gd_esquema.Maestra m
GROUP BY m.Habitacion_Tipo_Codigo,m.Habitacion_Tipo_Descripcion,
	   m.Habitacion_Tipo_Porcentual
/*------------------------------------------------------------------------------*/
/*migro habitacion*/
insert into SKYNET.Habitaciones(hotel,numero,piso,tipo,ubicacion)
select distinct h.idHotel,m.Habitacion_Numero,m.Habitacion_Piso,
				m.Habitacion_Tipo_Codigo,m.Habitacion_Frente 
from gd_esquema.Maestra m,SKYNET.Hoteles h
where m.Hotel_Calle=h.calle and m.Hotel_Nro_Calle=h.numCalle and 
		m.Hotel_Ciudad=h.ciudad
order by idHotel, Habitacion_Numero
/*------------------------------------------------------------------------------*/
/*migro nacionalidades*/
insert into skynet.Nacionalidades(Nacionalidad)
SELECT DISTINCT Cliente_Nacionalidad FROM gd_esquema.Maestra
/*------------------------------------------------------------------------------*/
/*migro clientes*/
insert SKYNET.TiposDoc(nombre)
values('Pasaporte')

insert into SKYNET.Roles (nombre)
	values ('ADMINISTRADOR')
insert into SKYNET.Roles (nombre)
	values ('RECEPCIONISTA')
insert into SKYNET.Roles (nombre)
	values ('GUEST')

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
insert into SKYNET.Consumibles (codigo,nombre,precio)
select m.Consumible_Codigo,m.Consumible_Descripcion,m.Consumible_Precio
from gd_esquema.Maestra m
where m.Consumible_Codigo is not null
group by m.Consumible_Codigo,m.Consumible_Descripcion,m.Consumible_Precio
order by m.Consumible_Codigo
/*------------------------------------------------------------------------------*/
/*migro regimenes*/
insert into SKYNET.Regimenes(nombre,precioBase,habilitado)
select distinct m.Regimen_Descripcion,m.Regimen_Precio,1
from gd_esquema.Maestra m
/*------------------------------------------------------------------------------*/
/*migro recargaEstrellas*/
insert into SKYNET.RecargaEstrellas (recarga)
select m.Hotel_Recarga_Estrella
from gd_esquema.Maestra m
group by m.Hotel_Recarga_Estrella
/*------------------------------------------------------------------------------*/

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
	
/*FALTARIAN LAS FUNCIONES DE BAJA*/

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
OR f.descripcion = 'REGISTRAR ESTADIA'
		
/*------------------------------------------------------------------------------*/
insert into SKYNET.EstadosReserva (nombre)
values('CANCELADA POR NO-SHOW')
insert into SKYNET.EstadosReserva (nombre)
values('EFECTIVIZADA')
insert into SKYNET.EstadosReserva (nombre)
values ('CORRECTA')

insert into SKYNET.Reservas(codigoReserva, hotel, regimen, fechaDesde, cantNoches, estado, cliente)
SELECT DISTINCT Reserva_Codigo, (SELECT idHotel FROM SKYNET.Hoteles S1 WHERE S1.calle = G1.Hotel_Calle AND S1.numCalle = G1.Hotel_Nro_Calle), (SELECT idRegimen FROM SKYNET.Regimenes R1 WHERE R1.Descripcion = G1.Regimen_Descripcion), Reserva_Fecha_Inicio, Reserva_Cant_Noches, 1/*CODIGO NO COMPLETADA*/, (SELECT idCliente FROM SKYNET.Clientes C1 WHERE C1.numDoc = G1.Cliente_Pasaporte_Nro AND C1.mail=G1.Cliente_Mail) FROM gd_esquema.Maestra G1
/*LA IDEA SERIA HACER UN UPDATE AL ESTADO DE RESERVA AL ENCONTRAR ESTADIAS PARA ESA RESERVA*/
/*YO DIRIA QUE ASUMAMOS NO-SHOW*/
/*ME EXTRAÑA QUE HAYA TANTAS RESERVAS*/

UPDATE R2 SET estado = 2 /*ESTADO CORRECTA*/
FROM SKYNET.Reservas R2
WHERE EXISTS(SELECT 1 FROM gd_esquema.Maestra G1
WHERE R2.codigoReserva=G1.Reserva_Codigo AND
G1.Estadia_Cant_Noches is not NULL)
/*SIN EMBARGO PARECE NO HABER ESTADIAS REGISTRADAS*/

/*ACTUALIZO LAS CORRECTAS*/
UPDATE R3 SET estado = 3
FROM SKYNET.Reservas R3
WHERE estado = 1 AND fechaDesde > SYSDATETIME()

/*------------------------------------------------------------------------------*/
/*migro estadias*/
insert into SKYNET.Estadias (reserva,cantNoches)
select m.Reserva_Codigo,m.Estadia_Cant_Noches
from gd_esquema.Maestra m
where(m.Estadia_Cant_Noches is not null)
group by m.Reserva_Codigo,m.Estadia_Cant_Noches

/*------------------------------------------------------------------------------*/
/*migro tipoPago*/
insert SKYNET.TiposPago(nombre)
values('Efectivo')
/*------------------------------------------------------------------------------*/
/*migro facturas poner despues de las estadias*/
insert into SKYNET.Facturas(facturaNumero,estadia,fechaPago,tipoPago,monto)
select distinct m.Factura_Nro,m.Reserva_Codigo,m.Factura_Fecha,1,m.Factura_Total
from gd_esquema.Maestra m
where m.Factura_Nro is not null
/*------------------------------------------------------------------------------*/
/*migro reservasPorTipoHabitacion*/
insert into SKYNET.ReservasPorTipoHabitacion(idReserva,idTipoHabitacion)
select m.Reserva_Codigo,m.Habitacion_Tipo_Codigo
from gd_esquema.Maestra m
group by m.Reserva_Codigo,m.Habitacion_Tipo_Codigo
/*------------------------------------------------------------------------------*/
/*migro clientesPorEstadia*/
insert into SKYNET.ClientesPorEstadia(idCliente,idEstadia)
select c.idCliente, m.Reserva_Codigo
from	gd_esquema.Maestra m, SKYNET.Clientes c

where m.Cliente_Pasaporte_Nro =.idCliente not in
(select distinct s.idCliente from SKYNET.Clientes s 
		where not exists(select 1 from gd_esquema.Maestra r 
			where r.Estadia_Cant_Noches is not null and 
				r.Cliente_Pasaporte_Nro = s.numDoc)) 
	
		
select COUNT(*) as B,m.Cliente_Mail,m.Cliente_Pasaporte_Nro,m.Reserva_Codigo
from gd_esquema.Maestra m
group by m.Reserva_Codigo,m.Cliente_Pasaporte_Nro,m.Cliente_Mail
order by 4

select distinct m.Cliente_Mail,m.Cliente_Pasaporte_Nro
from gd_esquema.Maestra 


select distinct s.idCliente from SKYNET.Clientes s where not exists(select 1 from gd_esquema.Maestra r where r.Estadia_Cant_Noches is not null and r.Cliente_Pasaporte_Nro = s.numDoc) order by idCliente