
/*migro hoteles*/
INSERT INTO SKYNET.Hoteles (calle,numCalle,ciudad,cantidadEstrellas)
SELECT DISTINCT Hotel_Calle,Hotel_Nro_Calle,Hotel_Ciudad,Hotel_CantEstrella
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
insert into SKYNET.Clientes(apellido, nombre, tipoDoc, numDoc, mail, calle,
			 piso, depto, nacionalidad, numCalle, fechaNac, baja, inconsistencia)
select Cliente_Apellido, Cliente_Nombre, 1, Cliente_Pasaporte_Nro, Cliente_Mail,
		 Cliente_Dom_Calle, Cliente_Piso, Cliente_Depto, 
		 (select idNacionalidad from SKYNET.Nacionalidades 
			where nacionalidad=Cliente_Nacionalidad)
		 ,Cliente_Nro_Calle, Cliente_Fecha_Nac, 0, 0 
from gd_esquema.Maestra
GROUP BY Cliente_Pasaporte_Nro, Cliente_Apellido, Cliente_Nombre,
		 Cliente_Mail, Cliente_Dom_Calle, Cliente_Piso, Cliente_Depto,
		 Cliente_Nacionalidad, Cliente_Nro_Calle, Cliente_Fecha_Nac
GO

update C1 set inconsistencia = 1
from SKYNET.Clientes C1
where EXISTS (SELECT 1 FROM SKYNET.Clientes C2 
				WHERE C1.mail = C2.mail AND C1.numDoc <> C2.numDoc)
/*
update SKYNET.Clientes set inconsistencia=1
where mail IN (SELECT mail
FROM SKYNET.Clientes
group by mail
having count(mail) > 1)
*/
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
insert into SKYNET.Regimenes(nombre,precioBase,estado)
select distinct m.Regimen_Descripcion,m.Regimen_Precio,0
from gd_esquema.Maestra m
/*------------------------------------------------------------------------------*/
/*migro facturas*/
insert into SKYNET.Facturas(facturaNumero,estadia,fechaPago,tipoPago,monto)
select distinct m.Factura_Nro,m.Reserva_Codigo,m.Factura_Fecha,0,m.Factura_Total
from gd_esquema.Maestra m
where m.Factura_Nro is not null
/*------------------------------------------------------------------------------*/