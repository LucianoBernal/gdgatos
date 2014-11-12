USE [GD2C2014]
GO
CREATE SCHEMA [SKYNET] AUTHORIZATION [dbo]
GO

CREATE TABLE [SKYNET].[TiposHabitacion](
	[codigo] [numeric](18, 0) NOT NULL,
	[descripcion] [nvarchar](255) NULL,
	[porcentual] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_TipoHabitacion] PRIMARY KEY CLUSTERED 
(	[codigo] ASC
	)ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[TiposDoc](
	[idTipoDoc] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoDoc] PRIMARY KEY CLUSTERED 
(
	[idTipoDoc] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[Roles](
	[idRol] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[EstadosReserva](
	[idEstado] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoReserva] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [SKYNET].[Consumibles](
	[codigo] [numeric](18, 0) NOT NULL,
	[nombre] [nvarchar](255) NULL,
	[precio] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Consumible] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [SKYNET].[DatosTarjeta](
	[idDatosTarjeta] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[numTarjeta] [numeric](18, 0) NOT NULL,
	[datosTarjeta] [nvarchar](255) NULL,
 CONSTRAINT [PK_DatosPago] PRIMARY KEY CLUSTERED 
(
	[idDatosTarjeta] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [SKYNET].[Cadenas](
	[idCadena] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[cadena] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Cadena] PRIMARY KEY CLUSTERED 
(
	[idCadena] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[Regimenes](
	[idRegimen] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[precioBase] [numeric](18, 2) NOT NULL,
	[descripcion] [nvarchar](255) NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Regimen] PRIMARY KEY CLUSTERED 
(
	[idRegimen] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[RecargaEstrellas](
	[recarga] [numeric](18, 0) NULL
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[Paises](
	[idPais] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[pais] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_pais] PRIMARY KEY CLUSTERED 
(
	[idPais] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[Nacionalidades](
	[idNacionalidad] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nacionalidad] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Nacionalidad] PRIMARY KEY CLUSTERED 
(
	[idNacionalidad] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[Funciones](
	[idFuncion] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Funcion] PRIMARY KEY CLUSTERED 
(
	[idFuncion] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[Habitaciones](
	[hotel] [numeric](18, 0) NOT NULL,
	[numero] [numeric](18, 0) NOT NULL,
	[piso] [numeric](18, 0) NULL,
	[tipo] [numeric](18, 0) NOT NULL,
	[ubicacion] [nvarchar](50) NULL,
	[descripcion] [nvarchar](50) NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Habitacion] PRIMARY KEY CLUSTERED 
(
	[hotel] ASC,
	[numero] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[Hoteles](
	[idHotel] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[calle] [varchar](255) NOT NULL,
	[numCalle] [numeric](18, 0) NOT NULL,
	[mail] [varchar](50) NULL,
	[cantidadEstrellas] [numeric](18, 0) NOT NULL,
	[ciudad] [nvarchar](255) NULL,
	[pais] [numeric](18, 0) NULL,
	[fechaCreacion] [datetime] NULL,
	[cadena] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[idHotel] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[Clientes](
	[idCliente] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[apellido] [nvarchar](255) NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[tipoDoc] [numeric](18, 0) NOT NULL,
	[numDoc] [numeric](18, 0) NOT NULL,
	[mail] [nvarchar](255) NOT NULL,
	[telefono] [numeric](18, 0) NULL,
	[calle] [nvarchar](255) NULL,
	[piso] [numeric](18, 0) NULL,
	[depto] [nvarchar](50) NULL,
	[nacionalidad] [numeric](18, 0) NULL,
	[numCalle] [numeric](18, 0) NULL,
	[fechaNac] [datetime] NULL,
	[baja] [bit] NULL,
	[rol] [numeric](18, 0) NULL,
	[paisDeOrigen] [numeric](18, 0) NULL,
	[inconsistencia] [bit] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[TiposPago](
	[idTipoPago] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[idDatosTarjeta] [numeric](18, 0) NULL,
 CONSTRAINT [PK_TipoPago] PRIMARY KEY CLUSTERED 
(
	[idTipoPago] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[Reservas](
	[codigoReserva] [numeric](18, 0) NOT NULL,
	[hotel] [numeric](18, 0) NULL,
	[regimen] [numeric](18, 0) NULL,
	[fechaReserva] [datetime] NULL,
	[fechaDesde] [datetime] NULL,
	[cantNoches] [numeric](18, 0) NULL,
	[estado] [numeric](18, 0) NULL,
	[cliente] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[codigoReserva] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [SKYNET].[RolFunciones](
	[rol] [numeric](18, 0) NOT NULL,
	[funcion] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_RolFunciones] PRIMARY KEY CLUSTERED 
(
	[rol] ASC,
	[funcion] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[Usuarios](
	[idUser] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[pass] [char](64) NOT NULL,
	[apellido] [varchar](50) NULL,
	[nombre] [varchar](50) NULL,
	[tipoDoc] [numeric](18, 0) NULL,
	[numDoc] [numeric](18, 2) NULL,
	[mail] [nvarchar](50) NULL,
	[telefono] [numeric](18, 2) NULL,
	[calle] [nvarchar](50) NULL,
	[numCalle] [numeric](18, 2) NULL,
	[fechaNac] [date] NULL,
	[habilitado] [bit] NOT NULL,
	[fallasPassword] [tinyint] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
) ON [PRIMARY],
 CONSTRAINT [IX_Usuarios] UNIQUE  
(
	[username] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[UsuarioRolHotel](
	[usuario] [numeric](18, 0) NOT NULL,
	[hotel] [numeric](18, 0) NOT NULL,
	[rol] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_UsuarioRolHotel] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC,
	[hotel] ASC,
	[rol] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[ReservasPorTipoHabitacion](
	[idReserva] [numeric](18, 0) NOT NULL,
	[idTipoHabitacion] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_ReseravasPorTipoHabitacion] PRIMARY KEY CLUSTERED 
(
	[idReserva] ASC,
	[idTipoHabitacion] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[Cancelaciones](
	[reserva] [numeric](18, 0) NOT NULL,
	[motivo] [nvarchar](50) NULL,
	[fechaCancel] [datetime] NOT NULL,
 CONSTRAINT [PK_Cancelaciones] PRIMARY KEY CLUSTERED 
(
	[reserva] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[Estadias](
	[reserva] [numeric](18, 0) NOT NULL,
	[usuarioIngreso] [numeric](18, 0) NULL,
	[cantNoches] [numeric](18, 0) NOT NULL,
	[usuarioEgreso] [numeric](18, 0) NULL,
	[precioPorNocheEstadia] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Estadia] PRIMARY KEY CLUSTERED 
(
	[reserva] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[HotelesRegimenes](
	[hotel] [numeric](18, 0) NOT NULL,
	[regimen] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_HotelRegimen] PRIMARY KEY CLUSTERED 
(
	[hotel] ASC,
	[regimen] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[HistorialHoteles](
	[hotel] [numeric](18, 0) NOT NULL,
	[fechaBaja] [datetime] NOT NULL,
	[duracion] [numeric](18, 0) NOT NULL,
	[motivo] [nvarchar](255) NULL,
 CONSTRAINT [PK_HistorialHotel] PRIMARY KEY CLUSTERED 
(
	[hotel] ASC,
	[fechaBaja] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[Facturas](
	[facturaNumero] [numeric](18, 0) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[tipoPago] [numeric](18, 0) NOT NULL,
	[monto] [numeric](18, 2) NOT NULL,
	[estadia] [numeric](18, 0) NOT NULL,
	[diferenciaInconsistencia] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[facturaNumero] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[EstadiaPorHabitacion](
	[idEstadia] [numeric](18, 0) NOT NULL,
	[idHabitacion] [numeric](18, 0) NOT NULL,
	[idHotel] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_EstadiaPorHabitacion] PRIMARY KEY CLUSTERED 
(
	[idEstadia] ASC,
	[idHabitacion] ASC,
	[idHotel] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [SKYNET].[ConsumiblesEstadias](
	[estadia] [numeric](18, 0) NOT NULL,
	[consumible] [numeric](18, 0) NOT NULL,
	[precioTotal] [numeric](18, 2) NULL,
	[cantidad] [numeric](18, 0) NULL,
 CONSTRAINT [PK_ConsumibleEstadia] PRIMARY KEY CLUSTERED 
(
	[estadia] ASC,
	[consumible] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [SKYNET].[ClientesPorEstadia](
	[idCliente] [numeric](18, 0) NOT NULL,
	[idEstadia] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_ClientesPorEstadia] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC,
	[idEstadia] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

/*Agregamos FKs y valores default*/

ALTER TABLE [SKYNET].[Clientes] ADD  CONSTRAINT [DF_Clientes_baja]  DEFAULT ((0)) FOR [baja]
GO
ALTER TABLE [SKYNET].[Clientes] ADD  CONSTRAINT [DF_Clientes_inconsistencia]  DEFAULT ((0)) FOR [inconsistencia]
GO
ALTER TABLE [SKYNET].[Habitaciones] ADD  CONSTRAINT [DF_Habitaciones_baja]  DEFAULT ((0)) FOR [baja]
GO
ALTER TABLE [SKYNET].[Regimenes] ADD  CONSTRAINT [DF_Regimenes_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO
ALTER TABLE [SKYNET].[Roles] ADD  CONSTRAINT [DF_Roles_baja]  DEFAULT ((0)) FOR [baja]
GO
ALTER TABLE [SKYNET].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO
ALTER TABLE [SKYNET].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_fallasPassword]  DEFAULT ((0)) FOR [fallasPassword]
GO
ALTER TABLE [SKYNET].[Cancelaciones]  WITH CHECK ADD  CONSTRAINT [FK_Cancelaciones_Reservas] FOREIGN KEY([reserva])
REFERENCES [SKYNET].[Reservas] ([codigoReserva])
GO
ALTER TABLE [SKYNET].[Cancelaciones] CHECK CONSTRAINT [FK_Cancelaciones_Reservas]
GO
ALTER TABLE [SKYNET].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Nacionalidades] FOREIGN KEY([nacionalidad])
REFERENCES [SKYNET].[Nacionalidades] ([idNacionalidad])
GO
ALTER TABLE [SKYNET].[Clientes] CHECK CONSTRAINT [FK_Clientes_Nacionalidades]
GO
ALTER TABLE [SKYNET].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Paises] FOREIGN KEY([paisDeOrigen])
REFERENCES [SKYNET].[Paises] ([idPais])
GO
ALTER TABLE [SKYNET].[Clientes] CHECK CONSTRAINT [FK_Clientes_Paises]
GO
ALTER TABLE [SKYNET].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Roles] FOREIGN KEY([rol])
REFERENCES [SKYNET].[Roles] ([idRol])
GO
ALTER TABLE [SKYNET].[Clientes] CHECK CONSTRAINT [FK_Clientes_Roles]
GO
ALTER TABLE [SKYNET].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_TiposDoc] FOREIGN KEY([tipoDoc])
REFERENCES [SKYNET].[TiposDoc] ([idTipoDoc])
GO
ALTER TABLE [SKYNET].[Clientes] CHECK CONSTRAINT [FK_Clientes_TiposDoc]
GO
ALTER TABLE [SKYNET].[ClientesPorEstadia]  WITH CHECK ADD  CONSTRAINT [FK_ClientesPorEstadia_Clientes] FOREIGN KEY([idCliente])
REFERENCES [SKYNET].[Clientes] ([idCliente])
GO
ALTER TABLE [SKYNET].[ClientesPorEstadia] CHECK CONSTRAINT [FK_ClientesPorEstadia_Clientes]
GO
ALTER TABLE [SKYNET].[ClientesPorEstadia]  WITH CHECK ADD  CONSTRAINT [FK_ClientesPorEstadia_Estadias] FOREIGN KEY([idEstadia])
REFERENCES [SKYNET].[Estadias] ([reserva])
GO
ALTER TABLE [SKYNET].[ClientesPorEstadia] CHECK CONSTRAINT [FK_ClientesPorEstadia_Estadias]
GO
ALTER TABLE [SKYNET].[ConsumiblesEstadias]  WITH CHECK ADD  CONSTRAINT [FK_ConsumiblesEstadias_Consumibles] FOREIGN KEY([consumible])
REFERENCES [SKYNET].[Consumibles] ([codigo])
GO
ALTER TABLE [SKYNET].[ConsumiblesEstadias] CHECK CONSTRAINT [FK_ConsumiblesEstadias_Consumibles]
GO
ALTER TABLE [SKYNET].[ConsumiblesEstadias]  WITH CHECK ADD  CONSTRAINT [FK_ConsumiblesEstadias_Estadias] FOREIGN KEY([estadia])
REFERENCES [SKYNET].[Estadias] ([reserva])
GO
ALTER TABLE [SKYNET].[ConsumiblesEstadias] CHECK CONSTRAINT [FK_ConsumiblesEstadias_Estadias]
GO
ALTER TABLE [SKYNET].[EstadiaPorHabitacion]  WITH CHECK ADD  CONSTRAINT [FK_EstadiaPorHabitacion_Estadias] FOREIGN KEY([idEstadia])
REFERENCES [SKYNET].[Estadias] ([reserva])
GO
ALTER TABLE [SKYNET].[EstadiaPorHabitacion] CHECK CONSTRAINT [FK_EstadiaPorHabitacion_Estadias]
GO
ALTER TABLE [SKYNET].[EstadiaPorHabitacion]  WITH CHECK ADD  CONSTRAINT [FK_EstadiaPorHabitacion_Habitaciones] FOREIGN KEY([idHotel], [idHabitacion])
REFERENCES [SKYNET].[Habitaciones] ([hotel], [numero])
GO
ALTER TABLE [SKYNET].[EstadiaPorHabitacion] CHECK CONSTRAINT [FK_EstadiaPorHabitacion_Habitaciones]
GO
ALTER TABLE [SKYNET].[Estadias]  WITH CHECK ADD  CONSTRAINT [FK_Estadias_Reservas] FOREIGN KEY([reserva])
REFERENCES [SKYNET].[Reservas] ([codigoReserva])
GO
ALTER TABLE [SKYNET].[Estadias] CHECK CONSTRAINT [FK_Estadias_Reservas]
GO
ALTER TABLE [SKYNET].[Estadias]  WITH CHECK ADD  CONSTRAINT [FK_Estadias_UsuariosEgreso] FOREIGN KEY([usuarioEgreso])
REFERENCES [SKYNET].[Usuarios] ([idUser])
GO
ALTER TABLE [SKYNET].[Estadias] CHECK CONSTRAINT [FK_Estadias_UsuariosEgreso]
GO
ALTER TABLE [SKYNET].[Estadias]  WITH CHECK ADD  CONSTRAINT [FK_Estadias_UsuariosIngreso] FOREIGN KEY([usuarioIngreso])
REFERENCES [SKYNET].[Usuarios] ([idUser])
GO
ALTER TABLE [SKYNET].[Estadias] CHECK CONSTRAINT [FK_Estadias_UsuariosIngreso]
GO
ALTER TABLE [SKYNET].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Estadias] FOREIGN KEY([estadia])
REFERENCES [SKYNET].[Estadias] ([reserva])
GO
ALTER TABLE [SKYNET].[Facturas] CHECK CONSTRAINT [FK_Facturas_Estadias]
GO
ALTER TABLE [SKYNET].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_TiposPago] FOREIGN KEY([tipoPago])
REFERENCES [SKYNET].[TiposPago] ([idTipoPago])
GO
ALTER TABLE [SKYNET].[Facturas] CHECK CONSTRAINT [FK_Facturas_TiposPago]
GO
ALTER TABLE [SKYNET].[Habitaciones]  WITH CHECK ADD  CONSTRAINT [FK_Habitaciones_TiposHabitacion] FOREIGN KEY([tipo])
REFERENCES [SKYNET].[TiposHabitacion] ([codigo])
GO
ALTER TABLE [SKYNET].[Habitaciones] CHECK CONSTRAINT [FK_Habitaciones_TiposHabitacion]
GO
ALTER TABLE [SKYNET].[HistorialHoteles]  WITH CHECK ADD  CONSTRAINT [FK_HistorialHoteles_Hoteles] FOREIGN KEY([hotel])
REFERENCES [SKYNET].[Hoteles] ([idHotel])
GO
ALTER TABLE [SKYNET].[HistorialHoteles] CHECK CONSTRAINT [FK_HistorialHoteles_Hoteles]
GO
ALTER TABLE [SKYNET].[Hoteles]  WITH CHECK ADD  CONSTRAINT [FK_Hoteles_Cadenas] FOREIGN KEY([cadena])
REFERENCES [SKYNET].[Cadenas] ([idCadena])
GO
ALTER TABLE [SKYNET].[Hoteles] CHECK CONSTRAINT [FK_Hoteles_Cadenas]
GO
ALTER TABLE [SKYNET].[Hoteles]  WITH CHECK ADD  CONSTRAINT [FK_Hoteles_Paises] FOREIGN KEY([pais])
REFERENCES [SKYNET].[Paises] ([idPais])
GO
ALTER TABLE [SKYNET].[Hoteles] CHECK CONSTRAINT [FK_Hoteles_Paises]
GO
ALTER TABLE [SKYNET].[HotelesRegimenes]  WITH CHECK ADD  CONSTRAINT [FK_HotelesRegimen_Hoteles] FOREIGN KEY([hotel])
REFERENCES [SKYNET].[Hoteles] ([idHotel])
GO
ALTER TABLE [SKYNET].[HotelesRegimenes] CHECK CONSTRAINT [FK_HotelesRegimen_Hoteles]
GO
ALTER TABLE [SKYNET].[HotelesRegimenes]  WITH CHECK ADD  CONSTRAINT [FK_HotelesRegimen_Regimenes] FOREIGN KEY([regimen])
REFERENCES [SKYNET].[Regimenes] ([idRegimen])
GO
ALTER TABLE [SKYNET].[HotelesRegimenes] CHECK CONSTRAINT [FK_HotelesRegimen_Regimenes]
GO
ALTER TABLE [SKYNET].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Reservas] FOREIGN KEY([estado])
REFERENCES [SKYNET].[EstadosReserva] ([idEstado])
GO
ALTER TABLE [SKYNET].[Reservas] CHECK CONSTRAINT [FK_Reservas_Reservas]
GO
ALTER TABLE [SKYNET].[ReservasPorTipoHabitacion]  WITH CHECK ADD  CONSTRAINT [FK_ReservasPorTipoHabitacion_Reservas] FOREIGN KEY([idReserva])
REFERENCES [SKYNET].[Reservas] ([codigoReserva])
GO
ALTER TABLE [SKYNET].[ReservasPorTipoHabitacion] CHECK CONSTRAINT [FK_ReservasPorTipoHabitacion_Reservas]
GO
ALTER TABLE [SKYNET].[ReservasPorTipoHabitacion]  WITH CHECK ADD  CONSTRAINT [FK_ReservasPorTipoHabitacion_TiposHabitacion] FOREIGN KEY([idTipoHabitacion])
REFERENCES [SKYNET].[TiposHabitacion] ([codigo])
GO
ALTER TABLE [SKYNET].[ReservasPorTipoHabitacion] CHECK CONSTRAINT [FK_ReservasPorTipoHabitacion_TiposHabitacion]
GO
ALTER TABLE [SKYNET].[RolFunciones]  WITH CHECK ADD  CONSTRAINT [FK_RolFunciones_Funciones] FOREIGN KEY([funcion])
REFERENCES [SKYNET].[Funciones] ([idFuncion])
GO
ALTER TABLE [SKYNET].[RolFunciones] CHECK CONSTRAINT [FK_RolFunciones_Funciones]
GO
ALTER TABLE [SKYNET].[RolFunciones]  WITH CHECK ADD  CONSTRAINT [FK_RolFunciones_Roles] FOREIGN KEY([rol])
REFERENCES [SKYNET].[Roles] ([idRol])
GO
ALTER TABLE [SKYNET].[RolFunciones] CHECK CONSTRAINT [FK_RolFunciones_Roles]
GO
ALTER TABLE [SKYNET].[TiposPago]  WITH CHECK ADD  CONSTRAINT [FK_TiposPago_DatosTarjeta] FOREIGN KEY([idDatosTarjeta])
REFERENCES [SKYNET].[DatosTarjeta] ([idDatosTarjeta])
GO
ALTER TABLE [SKYNET].[TiposPago] CHECK CONSTRAINT [FK_TiposPago_DatosTarjeta]
GO
ALTER TABLE [SKYNET].[UsuarioRolHotel]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolHotel_Hoteles] FOREIGN KEY([hotel])
REFERENCES [SKYNET].[Hoteles] ([idHotel])
GO
ALTER TABLE [SKYNET].[UsuarioRolHotel] CHECK CONSTRAINT [FK_UsuarioRolHotel_Hoteles]
GO
ALTER TABLE [SKYNET].[UsuarioRolHotel]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolHotel_Roles] FOREIGN KEY([rol])
REFERENCES [SKYNET].[Roles] ([idRol])
GO
ALTER TABLE [SKYNET].[UsuarioRolHotel] CHECK CONSTRAINT [FK_UsuarioRolHotel_Roles]
GO
ALTER TABLE [SKYNET].[UsuarioRolHotel]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolHotel_Usuarios] FOREIGN KEY([usuario])
REFERENCES [SKYNET].[Usuarios] ([idUser])
GO
ALTER TABLE [SKYNET].[UsuarioRolHotel] CHECK CONSTRAINT [FK_UsuarioRolHotel_Usuarios]
GO
ALTER TABLE [SKYNET].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_TiposDoc] FOREIGN KEY([tipoDoc])
REFERENCES [SKYNET].[TiposDoc] ([idTipoDoc])
GO
ALTER TABLE [SKYNET].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_TiposDoc]
GO