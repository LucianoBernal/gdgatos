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
insert into SKYNET.Consumibles (codigo,nombre,precio)
select m.Consumible_Codigo,m.Consumible_Descripcion,m.Consumible_Precio
from gd_esquema.Maestra m
where m.Consumible_Codigo is not null
group by m.Consumible_Codigo,m.Consumible_Descripcion,m.Consumible_Precio

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
OR f.descripcion = 'REGISTRAR ESTADIA'
		
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

/*------------------------------------------------------------------------------*/
/*migro estadias*/
insert into SKYNET.Estadias (reserva,cantNoches,precioPorNocheEstadia)
select distinct m.Reserva_Codigo,m.Estadia_Cant_Noches,(
		select m2.Item_Factura_Monto 
		from gd_esquema.Maestra m2
		where m.Reserva_Codigo=m2.Reserva_Codigo and
		m2.Item_Factura_Monto is not null and
		m2.Consumible_Codigo is null)
from gd_esquema.Maestra m
where(m.Estadia_Cant_Noches is not null)


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
insert into SKYNET.Facturas(facturaNumero,estadia,fecha,tipoPago,monto,diferenciaInconsistencia)
select m.Factura_Nro,m.Reserva_Codigo,m.Factura_Fecha,1,m.Factura_Total,m.Factura_Total-SUM(m.Item_Factura_Cantidad*m.Item_Factura_Monto)
from gd_esquema.Maestra m
where m.Factura_Nro is not null and m.Item_Factura_Cantidad is not null and m.Item_Factura_Monto is not null
group by m.Factura_Nro,m.Reserva_Codigo,m.Factura_Fecha,m.Factura_Total

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
insert into SKYNET.ConsumiblesEstadias(estadia,consumible,precioTotal,cantidad)
select m.Reserva_Codigo,m.Consumible_Codigo,m.Item_Factura_Monto*m.Item_Factura_Cantidad,
		m.Item_Factura_Cantidad
from gd_esquema.Maestra m
where (m.Consumible_Codigo is not null)

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

  
