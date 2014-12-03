ALTER TABLE SKYNET.Hoteles DROP CONSTRAINT FK_Hoteles_Cadenas
GO
ALTER TABLE SKYNET.Cancelaciones DROP CONSTRAINT FK_Cancelaciones_Reservas
GO
ALTER TABLE SKYNET.Clientes DROP CONSTRAINT FK_Clientes_Nacionalidades
GO
ALTER TABLE SKYNET.Clientes DROP CONSTRAINT FK_Clientes_Paises
GO
ALTER TABLE SKYNET.Clientes DROP CONSTRAINT FK_Clientes_Roles
GO
ALTER TABLE SKYNET.Clientes DROP CONSTRAINT FK_Clientes_TiposDoc
GO
ALTER TABLE SKYNET.ClientesPorEstadia DROP CONSTRAINT FK_ClientesPorEstadia_Clientes
GO
ALTER TABLE SKYNET.ClientesPorEstadia DROP CONSTRAINT FK_ClientesPorEstadia_Estadias
GO
ALTER TABLE SKYNET.ConsumiblesEstadias DROP CONSTRAINT FK_ConsumiblesEstadias_Estadias
GO
ALTER TABLE SKYNET.ConsumiblesEstadias DROP CONSTRAINT FK_ConsumiblesEstadias_Consumibles
GO
ALTER TABLE SKYNET.EstadiaPorHabitacion DROP CONSTRAINT FK_EstadiaPorHabitacion_Estadias
GO
ALTER TABLE SKYNET.EstadiaPorHabitacion DROP CONSTRAINT FK_EstadiaPorHabitacion_Habitaciones
GO
ALTER TABLE SKYNET.Estadias DROP CONSTRAINT FK_Estadias_Reservas
GO
ALTER TABLE SKYNET.Estadias DROP CONSTRAINT FK_Estadias_UsuariosEgreso
GO
ALTER TABLE SKYNET.Facturas DROP CONSTRAINT FK_Facturas_Estadias
GO
ALTER TABLE SKYNET.Facturas DROP CONSTRAINT FK_Facturas_TiposPago
GO
ALTER TABLE SKYNET.Habitaciones DROP CONSTRAINT FK_Habitaciones_TiposHabitacion
GO
ALTER TABLE SKYNET.HistorialHoteles DROP CONSTRAINT FK_HistorialHoteles_Hoteles
GO
ALTER TABLE SKYNET.Hoteles DROP CONSTRAINT FK_Hoteles_Paises
GO
ALTER TABLE SKYNET.HotelesRegimenes DROP CONSTRAINT FK_HotelesRegimen_Hoteles
GO
ALTER TABLE SKYNET.ReservasPorTipoHabitacion DROP CONSTRAINT FK_ReservasPorTipoHabitacion_Reservas
GO
ALTER TABLE SKYNET.ReservasPorTipoHabitacion DROP CONSTRAINT FK_ReservasPorTipoHabitacion_TiposHabitacion
GO
ALTER TABLE SKYNET.RolFunciones DROP CONSTRAINT FK_RolFunciones_Funciones
GO
ALTER TABLE SKYNET.RolFunciones DROP CONSTRAINT FK_Rolfunciones_Roles
GO
ALTER TABLE SKYNET.TiposPago DROP CONSTRAINT FK_TiposPago_DatosTarjeta
GO
ALTER TABLE SKYNET.UsuarioRolHotel DROP CONSTRAINT FK_UsuarioRolHotel_Hoteles
GO
ALTER TABLE SKYNET.UsuarioRolHotel DROP CONSTRAINT FK_UsuarioRolHotel_Roles
GO
ALTER TABLE SKYNET.UsuarioRolHotel DROP CONSTRAINT FK_UsuarioRolHotel_Usuarios
GO
ALTER TABLE SKYNET.Usuarios DROP CONSTRAINT FK_Usuarios_TiposDoc
GO
ALTER TABLE SKYNET.ItemsFactura DROP CONSTRAINT FK_ItemsFactura_Facturas
GO
DROP TABLE SKYNET.RecargaEstrellas
DROP TABLE SKYNET.Cancelaciones
DROP TABLE SKYNET.Cadenas
DROP TABLE SKYNET.Clientes
DROP TABLE SKYNET.ClientesPorEstadia
DROP TABLE SKYNET.Consumibles
DROP TABLE SKYNET.ConsumiblesEstadias
DROP TABLE SKYNET.DatosTarjeta
DROP TABLE SKYNET.EstadiaPorHabitacion
DROP TABLE SKYNET.Estadias
DROP TABLE SKYNET.Facturas
DROP TABLE SKYNET.Funciones
DROP TABLE SKYNET.Habitaciones
DROP TABLE SKYNET.HistorialHoteles
DROP TABLE SKYNET.Hoteles
DROP TABLE SKYNET.HotelesRegimenes
DROP TABLE SKYNET.Nacionalidades
DROP TABLE SKYNET.Paises
DROP TABLE SKYNET.Regimenes
DROP TABLE SKYNET.Reservas
DROP TABLE SKYNET.ReservasPorTipoHabitacion
DROP TABLE SKYNET.Roles
DROP TABLE SKYNET.RolFunciones
DROP TABLE SKYNET.TiposDoc
DROP TABLE SKYNET.TiposHabitacion
DROP TABLE SKYNET.TiposPago
DROP TABLE SKYNET.UsuarioRolHotel
DROP TABLE SKYNET.Usuarios
DROP TABLE SKYNET.EstadosReserva
DROP TABLE SKYNET.ItemsFactura
drop function SKYNET.Hotelesconmayorcantidaddereservascanceladas
DROP FUNCTION SKYNET.Hotelesconmayorcantidaddeconsumiblesfacturados
drop function SKYNET.Hotelesconmayorcantidaddediasfueradeservicio
drop function SKYNET.Habitacionesconmayorcantidaddediasocupados
drop function SKYNET.Habitacionesconmayorcantidaddevecesocupadas
drop function SKYNET.Clientesconmayorcantidaddepuntos
DROP FUNCTION SKYNET.obtenerTrimestre
drop function SKYNET.obtenerDisponibilidad
DROP SCHEMA SKYNET