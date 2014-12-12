/*-----CREACION DE TABLAS---------*/

USE [GD2C2014]
GO
/****** Object:  Schema [SKYNET]    Script Date: 12/12/2014 05:21:36 ******/
CREATE SCHEMA [SKYNET] AUTHORIZATION [dbo]
GO
/****** Object:  Table [SKYNET].[TiposPago]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[TiposPago](
	[idTipoPago] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_TipoPago] PRIMARY KEY CLUSTERED 
(
	[idTipoPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Facturas]    Script Date: 12/12/2014 05:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Facturas](
	[facturaNumero] [numeric](18, 0) IDENTITY(2486348,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[tipoPago] [numeric](18, 0) NOT NULL,
	[monto] [numeric](18, 2) NOT NULL,
	[estadia] [numeric](18, 0) NOT NULL,
	[diferenciaInconsistencia] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[facturaNumero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[DatosTarjeta]    Script Date: 12/12/2014 05:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[DatosTarjeta](
	[idDatosTarjeta] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[numTarjeta] [numeric](18, 0) NOT NULL,
	[datosTarjeta] [nvarchar](255) NULL,
	[nroFactura] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_DatosPago] PRIMARY KEY CLUSTERED 
(
	[idDatosTarjeta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Regimenes]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Regimenes](
	[idRegimen] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[precioBase] [numeric](18, 2) NOT NULL,
	[descripcion] [nvarchar](255) NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Regimen] PRIMARY KEY CLUSTERED 
(
	[idRegimen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Consumibles]    Script Date: 12/12/2014 05:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Consumibles](
	[codigo] [numeric](18, 0) IDENTITY(2328,1) NOT NULL,
	[nombre] [nvarchar](255) NULL,
	[precio] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Consumible] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[TiposDoc]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [SKYNET].[TiposDoc](
	[idTipoDoc] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoDoc] PRIMARY KEY CLUSTERED 
(
	[idTipoDoc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [SKYNET].[Roles]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [SKYNET].[Roles](
	[idRol] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[baja] [bit] NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [SKYNET].[Nacionalidades]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Nacionalidades](
	[idNacionalidad] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nacionalidad] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Nacionalidad] PRIMARY KEY CLUSTERED 
(
	[idNacionalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Paises]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Paises](
	[idPais] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[pais] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_pais] PRIMARY KEY CLUSTERED 
(
	[idPais] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Clientes]    Script Date: 12/12/2014 05:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[EstadosReserva]    Script Date: 12/12/2014 05:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [SKYNET].[EstadosReserva](
	[idEstado] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoReserva] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [SKYNET].[Reservas]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Reservas](
	[codigoReserva] [numeric](18, 0) IDENTITY(110741,1) NOT NULL,
	[hotel] [numeric](18, 0) NOT NULL,
	[regimen] [numeric](18, 0) NOT NULL,
	[fechaReserva] [datetime] NULL,
	[fechaDesde] [datetime] NULL,
	[cantNoches] [numeric](18, 0) NOT NULL,
	[estado] [numeric](18, 0) NULL,
	[cliente] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[codigoReserva] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Usuarios]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [SKYNET].[Usuarios](
	[idUser] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[pass] [char](64) NOT NULL,
	[apellido] [varchar](50) NULL,
	[nombre] [varchar](50) NULL,
	[tipoDoc] [numeric](18, 0) NULL,
	[numDoc] [numeric](18, 0) NULL,
	[mail] [nvarchar](50) NULL,
	[telefono] [numeric](18, 0) NULL,
	[calle] [nvarchar](50) NULL,
	[numCalle] [numeric](18, 0) NULL,
	[fechaNac] [date] NULL,
	[habilitado] [bit] NOT NULL,
	[fallasPassword] [tinyint] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Usuarios] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [SKYNET].[Estadias]    Script Date: 12/12/2014 05:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Estadias](
	[reserva] [numeric](18, 0) NOT NULL,
	[usuarioIngreso] [numeric](18, 0) NULL,
	[usuarioEgreso] [numeric](18, 0) NULL,
	[cantNoches] [numeric](18, 0) NULL,
	[precioPorNocheEstadia] [numeric](18, 2) NULL,
	[numeroFactura] [numeric](18, 0) NULL,
	[itemFactura] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Estadia] PRIMARY KEY CLUSTERED 
(
	[reserva] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[ConsumiblesPorRegimenes]    Script Date: 12/12/2014 05:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[ConsumiblesPorRegimenes](
	[idRegimen] [numeric](18, 0) NOT NULL,
	[idConsumible] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_ConsumiblesPorRegimenes] PRIMARY KEY CLUSTERED 
(
	[idRegimen] ASC,
	[idConsumible] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[ItemsFactura]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[ItemsFactura](
	[numeroFactura] [numeric](18, 0) NOT NULL,
	[item] [numeric](18, 0) NOT NULL,
	[detalle] [nvarchar](255) NULL,
	[cantidad] [numeric](18, 0) NOT NULL,
	[precioUnitario] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_ItemsFactura] PRIMARY KEY CLUSTERED 
(
	[numeroFactura] ASC,
	[item] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[ConsumiblesEstadias]    Script Date: 12/12/2014 05:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[ConsumiblesEstadias](
	[idConsumibleEstadia] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[estadia] [numeric](18, 0) NOT NULL,
	[consumible] [numeric](18, 0) NOT NULL,
	[precioTotal] [numeric](18, 2) NULL,
	[cantidad] [numeric](18, 0) NOT NULL,
	[numeroFactura] [numeric](18, 0) NULL,
	[itemFactura] [numeric](18, 0) NULL,
 CONSTRAINT [PK_ConsumibleEstadia] PRIMARY KEY CLUSTERED 
(
	[idConsumibleEstadia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Config]    Script Date: 12/12/2014 05:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Config](
	[fecha] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Funciones]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [SKYNET].[Funciones](
	[idFuncion] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Funcion] PRIMARY KEY CLUSTERED 
(
	[idFuncion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [SKYNET].[Cadenas]    Script Date: 12/12/2014 05:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Cadenas](
	[idCadena] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[cadena] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Cadena] PRIMARY KEY CLUSTERED 
(
	[idCadena] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[RecargaEstrellas]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[RecargaEstrellas](
	[recarga] [numeric](18, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[TiposHabitacion]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[TiposHabitacion](
	[codigo] [numeric](18, 0) IDENTITY(1006,1) NOT NULL,
	[descripcion] [nvarchar](255) NULL,
	[porcentual] [numeric](18, 2) NOT NULL,
	[capacidad] [numeric](2, 0) NULL,
 CONSTRAINT [PK_TipoHabitacion] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Habitaciones]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[RolFunciones]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[RolFunciones](
	[rol] [numeric](18, 0) NOT NULL,
	[funcion] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_RolFunciones] PRIMARY KEY CLUSTERED 
(
	[rol] ASC,
	[funcion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Hoteles]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
	[telefono] [varchar](30) NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[idHotel] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [SKYNET].[HistorialHoteles]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[HotelesRegimenes]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[HotelesRegimenes](
	[hotel] [numeric](18, 0) NOT NULL,
	[regimen] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_HotelRegimen] PRIMARY KEY CLUSTERED 
(
	[hotel] ASC,
	[regimen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[UsuarioRolHotel]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[ReservasPorTipoHabitacion]    Script Date: 12/12/2014 05:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[ReservasPorTipoHabitacion](
	[idReserva] [numeric](18, 0) NOT NULL,
	[idTipoHabitacion] [numeric](18, 0) NOT NULL,
	[cantidad] [numeric](18, 0) NULL,
 CONSTRAINT [PK_ReseravasPorTipoHabitacion] PRIMARY KEY CLUSTERED 
(
	[idReserva] ASC,
	[idTipoHabitacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[EstadiaPorHabitacion]    Script Date: 12/12/2014 05:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[ClientesPorEstadia]    Script Date: 12/12/2014 05:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[ClientesPorEstadia](
	[idCliente] [numeric](18, 0) NOT NULL,
	[idEstadia] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_ClientesPorEstadia] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC,
	[idEstadia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Cancelaciones]    Script Date: 12/12/2014 05:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Cancelaciones](
	[reserva] [numeric](18, 0) NOT NULL,
	[motivo] [nvarchar](50) NULL,
	[fechaCancel] [datetime] NOT NULL,
 CONSTRAINT [PK_Cancelaciones] PRIMARY KEY CLUSTERED 
(
	[reserva] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Clientes_baja]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[Clientes] ADD  CONSTRAINT [DF_Clientes_baja]  DEFAULT ((0)) FOR [baja]
GO
/****** Object:  Default [DF_Clientes_rol]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[Clientes] ADD  CONSTRAINT [DF_Clientes_rol]  DEFAULT ((3)) FOR [rol]
GO
/****** Object:  Default [DF_Clientes_inconsistencia]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[Clientes] ADD  CONSTRAINT [DF_Clientes_inconsistencia]  DEFAULT ((0)) FOR [inconsistencia]
GO
/****** Object:  Default [DF_ConsumiblesEstadias_cantidad]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[ConsumiblesEstadias] ADD  CONSTRAINT [DF_ConsumiblesEstadias_cantidad]  DEFAULT ((1)) FOR [cantidad]
GO
/****** Object:  Default [DF_Facturas_diferenciaInconsistencia]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[Facturas] ADD  CONSTRAINT [DF_Facturas_diferenciaInconsistencia]  DEFAULT ((0)) FOR [diferenciaInconsistencia]
GO
/****** Object:  Default [DF_Habitaciones_baja]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[Habitaciones] ADD  CONSTRAINT [DF_Habitaciones_baja]  DEFAULT ((0)) FOR [baja]
GO
/****** Object:  Default [DF_Regimenes_habilitado]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[Regimenes] ADD  CONSTRAINT [DF_Regimenes_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO
/****** Object:  Default [DF_ReservasPorTipoHabitacion_cantidad]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[ReservasPorTipoHabitacion] ADD  CONSTRAINT [DF_ReservasPorTipoHabitacion_cantidad]  DEFAULT ((1)) FOR [cantidad]
GO
/****** Object:  Default [DF_Roles_baja]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[Roles] ADD  CONSTRAINT [DF_Roles_baja]  DEFAULT ((0)) FOR [baja]
GO
/****** Object:  Default [DF_Usuarios_habilitado]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO
/****** Object:  Default [DF_Usuarios_fallasPassword]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_fallasPassword]  DEFAULT ((0)) FOR [fallasPassword]
GO
/****** Object:  ForeignKey [FK_Cancelaciones_Reservas]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[Cancelaciones]  WITH CHECK ADD  CONSTRAINT [FK_Cancelaciones_Reservas] FOREIGN KEY([reserva])
REFERENCES [SKYNET].[Reservas] ([codigoReserva])
GO
ALTER TABLE [SKYNET].[Cancelaciones] CHECK CONSTRAINT [FK_Cancelaciones_Reservas]
GO
/****** Object:  ForeignKey [FK_Clientes_Nacionalidades]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Nacionalidades] FOREIGN KEY([nacionalidad])
REFERENCES [SKYNET].[Nacionalidades] ([idNacionalidad])
GO
ALTER TABLE [SKYNET].[Clientes] CHECK CONSTRAINT [FK_Clientes_Nacionalidades]
GO
/****** Object:  ForeignKey [FK_Clientes_Paises]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Paises] FOREIGN KEY([paisDeOrigen])
REFERENCES [SKYNET].[Paises] ([idPais])
GO
ALTER TABLE [SKYNET].[Clientes] CHECK CONSTRAINT [FK_Clientes_Paises]
GO
/****** Object:  ForeignKey [FK_Clientes_Roles]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Roles] FOREIGN KEY([rol])
REFERENCES [SKYNET].[Roles] ([idRol])
GO
ALTER TABLE [SKYNET].[Clientes] CHECK CONSTRAINT [FK_Clientes_Roles]
GO
/****** Object:  ForeignKey [FK_Clientes_TiposDoc]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_TiposDoc] FOREIGN KEY([tipoDoc])
REFERENCES [SKYNET].[TiposDoc] ([idTipoDoc])
GO
ALTER TABLE [SKYNET].[Clientes] CHECK CONSTRAINT [FK_Clientes_TiposDoc]
GO
/****** Object:  ForeignKey [FK_ClientesPorEstadia_Clientes]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[ClientesPorEstadia]  WITH CHECK ADD  CONSTRAINT [FK_ClientesPorEstadia_Clientes] FOREIGN KEY([idCliente])
REFERENCES [SKYNET].[Clientes] ([idCliente])
GO
ALTER TABLE [SKYNET].[ClientesPorEstadia] CHECK CONSTRAINT [FK_ClientesPorEstadia_Clientes]
GO
/****** Object:  ForeignKey [FK_ClientesPorEstadia_Estadias]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[ClientesPorEstadia]  WITH CHECK ADD  CONSTRAINT [FK_ClientesPorEstadia_Estadias] FOREIGN KEY([idEstadia])
REFERENCES [SKYNET].[Estadias] ([reserva])
GO
ALTER TABLE [SKYNET].[ClientesPorEstadia] CHECK CONSTRAINT [FK_ClientesPorEstadia_Estadias]
GO
/****** Object:  ForeignKey [FK_ConsumiblesEstadias_Consumibles]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[ConsumiblesEstadias]  WITH CHECK ADD  CONSTRAINT [FK_ConsumiblesEstadias_Consumibles] FOREIGN KEY([consumible])
REFERENCES [SKYNET].[Consumibles] ([codigo])
GO
ALTER TABLE [SKYNET].[ConsumiblesEstadias] CHECK CONSTRAINT [FK_ConsumiblesEstadias_Consumibles]
GO
/****** Object:  ForeignKey [FK_ConsumiblesEstadias_Estadias]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[ConsumiblesEstadias]  WITH CHECK ADD  CONSTRAINT [FK_ConsumiblesEstadias_Estadias] FOREIGN KEY([estadia])
REFERENCES [SKYNET].[Estadias] ([reserva])
GO
ALTER TABLE [SKYNET].[ConsumiblesEstadias] CHECK CONSTRAINT [FK_ConsumiblesEstadias_Estadias]
GO
/****** Object:  ForeignKey [FK_ConsumiblesEstadias_ItemsFactura]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[ConsumiblesEstadias]  WITH NOCHECK ADD  CONSTRAINT [FK_ConsumiblesEstadias_ItemsFactura] FOREIGN KEY([numeroFactura], [itemFactura])
REFERENCES [SKYNET].[ItemsFactura] ([numeroFactura], [item])
GO
ALTER TABLE [SKYNET].[ConsumiblesEstadias] CHECK CONSTRAINT [FK_ConsumiblesEstadias_ItemsFactura]
GO
/****** Object:  ForeignKey [FK_ConsumiblesPorRegimenes_Consumibles]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[ConsumiblesPorRegimenes]  WITH CHECK ADD  CONSTRAINT [FK_ConsumiblesPorRegimenes_Consumibles] FOREIGN KEY([idConsumible])
REFERENCES [SKYNET].[Consumibles] ([codigo])
GO
ALTER TABLE [SKYNET].[ConsumiblesPorRegimenes] CHECK CONSTRAINT [FK_ConsumiblesPorRegimenes_Consumibles]
GO
/****** Object:  ForeignKey [FK_ConsumiblesPorRegimenes_Regimenes]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[ConsumiblesPorRegimenes]  WITH CHECK ADD  CONSTRAINT [FK_ConsumiblesPorRegimenes_Regimenes] FOREIGN KEY([idRegimen])
REFERENCES [SKYNET].[Regimenes] ([idRegimen])
GO
ALTER TABLE [SKYNET].[ConsumiblesPorRegimenes] CHECK CONSTRAINT [FK_ConsumiblesPorRegimenes_Regimenes]
GO
/****** Object:  ForeignKey [FK_DatosTarjeta_Facturas]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[DatosTarjeta]  WITH CHECK ADD  CONSTRAINT [FK_DatosTarjeta_Facturas] FOREIGN KEY([nroFactura])
REFERENCES [SKYNET].[Facturas] ([facturaNumero])
GO
ALTER TABLE [SKYNET].[DatosTarjeta] CHECK CONSTRAINT [FK_DatosTarjeta_Facturas]
GO
/****** Object:  ForeignKey [FK_EstadiaPorHabitacion_Estadias]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[EstadiaPorHabitacion]  WITH CHECK ADD  CONSTRAINT [FK_EstadiaPorHabitacion_Estadias] FOREIGN KEY([idEstadia])
REFERENCES [SKYNET].[Estadias] ([reserva])
GO
ALTER TABLE [SKYNET].[EstadiaPorHabitacion] CHECK CONSTRAINT [FK_EstadiaPorHabitacion_Estadias]
GO
/****** Object:  ForeignKey [FK_EstadiaPorHabitacion_Habitaciones]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[EstadiaPorHabitacion]  WITH CHECK ADD  CONSTRAINT [FK_EstadiaPorHabitacion_Habitaciones] FOREIGN KEY([idHotel], [idHabitacion])
REFERENCES [SKYNET].[Habitaciones] ([hotel], [numero])
GO
ALTER TABLE [SKYNET].[EstadiaPorHabitacion] CHECK CONSTRAINT [FK_EstadiaPorHabitacion_Habitaciones]
GO
/****** Object:  ForeignKey [FK_Estadias_ItemsFactura]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[Estadias]  WITH NOCHECK ADD  CONSTRAINT [FK_Estadias_ItemsFactura] FOREIGN KEY([numeroFactura], [itemFactura])
REFERENCES [SKYNET].[ItemsFactura] ([numeroFactura], [item])
GO
ALTER TABLE [SKYNET].[Estadias] CHECK CONSTRAINT [FK_Estadias_ItemsFactura]
GO
/****** Object:  ForeignKey [FK_Estadias_Reservas]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[Estadias]  WITH CHECK ADD  CONSTRAINT [FK_Estadias_Reservas] FOREIGN KEY([reserva])
REFERENCES [SKYNET].[Reservas] ([codigoReserva])
GO
ALTER TABLE [SKYNET].[Estadias] CHECK CONSTRAINT [FK_Estadias_Reservas]
GO
/****** Object:  ForeignKey [FK_Estadias_UsuariosEgreso]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[Estadias]  WITH CHECK ADD  CONSTRAINT [FK_Estadias_UsuariosEgreso] FOREIGN KEY([usuarioEgreso])
REFERENCES [SKYNET].[Usuarios] ([idUser])
GO
ALTER TABLE [SKYNET].[Estadias] CHECK CONSTRAINT [FK_Estadias_UsuariosEgreso]
GO
/****** Object:  ForeignKey [FK_Estadias_UsuariosIngreso]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[Estadias]  WITH CHECK ADD  CONSTRAINT [FK_Estadias_UsuariosIngreso] FOREIGN KEY([usuarioIngreso])
REFERENCES [SKYNET].[Usuarios] ([idUser])
GO
ALTER TABLE [SKYNET].[Estadias] CHECK CONSTRAINT [FK_Estadias_UsuariosIngreso]
GO
/****** Object:  ForeignKey [FK_Facturas_Estadias]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Estadias] FOREIGN KEY([estadia])
REFERENCES [SKYNET].[Estadias] ([reserva])
GO
ALTER TABLE [SKYNET].[Facturas] CHECK CONSTRAINT [FK_Facturas_Estadias]
GO
/****** Object:  ForeignKey [FK_Facturas_TiposPago]    Script Date: 12/12/2014 05:21:37 ******/
ALTER TABLE [SKYNET].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_TiposPago] FOREIGN KEY([tipoPago])
REFERENCES [SKYNET].[TiposPago] ([idTipoPago])
GO
ALTER TABLE [SKYNET].[Facturas] CHECK CONSTRAINT [FK_Facturas_TiposPago]
GO
/****** Object:  ForeignKey [FK_Habitaciones_TiposHabitacion]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[Habitaciones]  WITH CHECK ADD  CONSTRAINT [FK_Habitaciones_TiposHabitacion] FOREIGN KEY([tipo])
REFERENCES [SKYNET].[TiposHabitacion] ([codigo])
GO
ALTER TABLE [SKYNET].[Habitaciones] CHECK CONSTRAINT [FK_Habitaciones_TiposHabitacion]
GO
/****** Object:  ForeignKey [FK_HistorialHoteles_Hoteles]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[HistorialHoteles]  WITH CHECK ADD  CONSTRAINT [FK_HistorialHoteles_Hoteles] FOREIGN KEY([hotel])
REFERENCES [SKYNET].[Hoteles] ([idHotel])
GO
ALTER TABLE [SKYNET].[HistorialHoteles] CHECK CONSTRAINT [FK_HistorialHoteles_Hoteles]
GO
/****** Object:  ForeignKey [FK_Hoteles_Cadenas]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[Hoteles]  WITH CHECK ADD  CONSTRAINT [FK_Hoteles_Cadenas] FOREIGN KEY([cadena])
REFERENCES [SKYNET].[Cadenas] ([idCadena])
GO
ALTER TABLE [SKYNET].[Hoteles] CHECK CONSTRAINT [FK_Hoteles_Cadenas]
GO
/****** Object:  ForeignKey [FK_Hoteles_Paises]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[Hoteles]  WITH CHECK ADD  CONSTRAINT [FK_Hoteles_Paises] FOREIGN KEY([pais])
REFERENCES [SKYNET].[Paises] ([idPais])
GO
ALTER TABLE [SKYNET].[Hoteles] CHECK CONSTRAINT [FK_Hoteles_Paises]
GO
/****** Object:  ForeignKey [FK_HotelesRegimen_Hoteles]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[HotelesRegimenes]  WITH CHECK ADD  CONSTRAINT [FK_HotelesRegimen_Hoteles] FOREIGN KEY([hotel])
REFERENCES [SKYNET].[Hoteles] ([idHotel])
GO
ALTER TABLE [SKYNET].[HotelesRegimenes] CHECK CONSTRAINT [FK_HotelesRegimen_Hoteles]
GO
/****** Object:  ForeignKey [FK_HotelesRegimen_Regimenes]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[HotelesRegimenes]  WITH CHECK ADD  CONSTRAINT [FK_HotelesRegimen_Regimenes] FOREIGN KEY([regimen])
REFERENCES [SKYNET].[Regimenes] ([idRegimen])
GO
ALTER TABLE [SKYNET].[HotelesRegimenes] CHECK CONSTRAINT [FK_HotelesRegimen_Regimenes]
GO
/****** Object:  ForeignKey [FK_ItemsFactura_Facturas]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[ItemsFactura]  WITH CHECK ADD  CONSTRAINT [FK_ItemsFactura_Facturas] FOREIGN KEY([numeroFactura])
REFERENCES [SKYNET].[Facturas] ([facturaNumero])
GO
ALTER TABLE [SKYNET].[ItemsFactura] CHECK CONSTRAINT [FK_ItemsFactura_Facturas]
GO
/****** Object:  ForeignKey [FK_Reservas_Clientes]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Clientes] FOREIGN KEY([cliente])
REFERENCES [SKYNET].[Clientes] ([idCliente])
GO
ALTER TABLE [SKYNET].[Reservas] CHECK CONSTRAINT [FK_Reservas_Clientes]
GO
/****** Object:  ForeignKey [FK_Reservas_EstadosReservas]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_EstadosReservas] FOREIGN KEY([estado])
REFERENCES [SKYNET].[EstadosReserva] ([idEstado])
GO
ALTER TABLE [SKYNET].[Reservas] CHECK CONSTRAINT [FK_Reservas_EstadosReservas]
GO
/****** Object:  ForeignKey [FK_Reservas_Regimenes]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Regimenes] FOREIGN KEY([regimen])
REFERENCES [SKYNET].[Regimenes] ([idRegimen])
GO
ALTER TABLE [SKYNET].[Reservas] CHECK CONSTRAINT [FK_Reservas_Regimenes]
GO
/****** Object:  ForeignKey [FK_ReservasPorTipoHabitacion_Reservas]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[ReservasPorTipoHabitacion]  WITH CHECK ADD  CONSTRAINT [FK_ReservasPorTipoHabitacion_Reservas] FOREIGN KEY([idReserva])
REFERENCES [SKYNET].[Reservas] ([codigoReserva])
GO
ALTER TABLE [SKYNET].[ReservasPorTipoHabitacion] CHECK CONSTRAINT [FK_ReservasPorTipoHabitacion_Reservas]
GO
/****** Object:  ForeignKey [FK_ReservasPorTipoHabitacion_TiposHabitacion]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[ReservasPorTipoHabitacion]  WITH CHECK ADD  CONSTRAINT [FK_ReservasPorTipoHabitacion_TiposHabitacion] FOREIGN KEY([idTipoHabitacion])
REFERENCES [SKYNET].[TiposHabitacion] ([codigo])
GO
ALTER TABLE [SKYNET].[ReservasPorTipoHabitacion] CHECK CONSTRAINT [FK_ReservasPorTipoHabitacion_TiposHabitacion]
GO
/****** Object:  ForeignKey [FK_RolFunciones_Funciones]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[RolFunciones]  WITH CHECK ADD  CONSTRAINT [FK_RolFunciones_Funciones] FOREIGN KEY([funcion])
REFERENCES [SKYNET].[Funciones] ([idFuncion])
GO
ALTER TABLE [SKYNET].[RolFunciones] CHECK CONSTRAINT [FK_RolFunciones_Funciones]
GO
/****** Object:  ForeignKey [FK_RolFunciones_Roles]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[RolFunciones]  WITH CHECK ADD  CONSTRAINT [FK_RolFunciones_Roles] FOREIGN KEY([rol])
REFERENCES [SKYNET].[Roles] ([idRol])
GO
ALTER TABLE [SKYNET].[RolFunciones] CHECK CONSTRAINT [FK_RolFunciones_Roles]
GO
/****** Object:  ForeignKey [FK_UsuarioRolHotel_Hoteles]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[UsuarioRolHotel]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolHotel_Hoteles] FOREIGN KEY([hotel])
REFERENCES [SKYNET].[Hoteles] ([idHotel])
GO
ALTER TABLE [SKYNET].[UsuarioRolHotel] CHECK CONSTRAINT [FK_UsuarioRolHotel_Hoteles]
GO
/****** Object:  ForeignKey [FK_UsuarioRolHotel_Roles]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[UsuarioRolHotel]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolHotel_Roles] FOREIGN KEY([rol])
REFERENCES [SKYNET].[Roles] ([idRol])
GO
ALTER TABLE [SKYNET].[UsuarioRolHotel] CHECK CONSTRAINT [FK_UsuarioRolHotel_Roles]
GO
/****** Object:  ForeignKey [FK_UsuarioRolHotel_Usuarios]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[UsuarioRolHotel]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolHotel_Usuarios] FOREIGN KEY([usuario])
REFERENCES [SKYNET].[Usuarios] ([idUser])
GO
ALTER TABLE [SKYNET].[UsuarioRolHotel] CHECK CONSTRAINT [FK_UsuarioRolHotel_Usuarios]
GO
/****** Object:  ForeignKey [FK_Usuarios_TiposDoc]    Script Date: 12/12/2014 05:21:38 ******/
ALTER TABLE [SKYNET].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_TiposDoc] FOREIGN KEY([tipoDoc])
REFERENCES [SKYNET].[TiposDoc] ([idTipoDoc])
GO
ALTER TABLE [SKYNET].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_TiposDoc]
GO


/*--------MIGRACION---------*/


/*Inserto fecha migracion */
Insert into SKYNET.Config(fecha)(select MAX(Factura_Fecha) from gd_esquema.Maestra
								where Factura_Fecha is not null)

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
UPDATE SKYNET.Hoteles SET nombre = calle
/*------------------------------------------------------------------------------*/
/*migro tiposhabitacion*/
set identity_insert [SKYNET].[TiposHabitacion] ON
INSERT INTO SKYNET.TiposHabitacion (codigo,descripcion,porcentual,capacidad)
SELECT m.Habitacion_Tipo_Codigo,m.Habitacion_Tipo_Descripcion,
	   m.Habitacion_Tipo_Porcentual,m.Habitacion_Tipo_Codigo-1000
FROM gd_esquema.Maestra m
GROUP BY m.Habitacion_Tipo_Codigo,m.Habitacion_Tipo_Descripcion,
	   m.Habitacion_Tipo_Porcentual
set identity_insert [SKYNET].[TiposHabitacion] OFF
	   
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
set identity_insert [SKYNET].[Consumibles] ON
insert into SKYNET.Consumibles (codigo,nombre,precio)
select m.Consumible_Codigo,m.Consumible_Descripcion,m.Consumible_Precio
from gd_esquema.Maestra m
where m.Consumible_Codigo is not null
group by m.Consumible_Codigo,m.Consumible_Descripcion,m.Consumible_Precio
set identity_insert [SKYNET].[Consumibles] OFF
/*------------------------------------------------------------------------------*/
/*migro regimenes*/
insert into SKYNET.Regimenes(descripcion,precioBase,habilitado)
select distinct m.Regimen_Descripcion,m.Regimen_Precio,1
from gd_esquema.Maestra m
/*------------------------------------------------------------------------------*/
/*Inserto ConsumiblesPorRegimenes*/
insert into SKYNET.ConsumiblesPorRegimenes(idRegimen,idConsumible)
select r.idRegimen,c.codigo
from SKYNET.Consumibles c, SKYNET.Regimenes r
where r.descripcion like 'All Inclusive' 
union 
select r.idRegimen,c.codigo
from SKYNET.Consumibles c, SKYNET.Regimenes r
where r.descripcion like 'All Inclusive moderado' and(
c.nombre like 'Agua Mineral' or c.nombre like 'Coca Cola')


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
insert into SKYNET.Funciones (descripcion)
	VALUES ('LISTADO ESTADISTICO')
	
/*------------------------------------------------------------------------------*/
/*migro RolFunciones*/
insert into skynet.rolFunciones(rol,funcion)
select (select idRol from SKYNET.Roles where nombre='ADMINISTRADOR'), f.idFuncion
		from SKYNET.Funciones f
		where f.descripcion = 'ABM ROL' OR f.descripcion = 'ABM USUARIO'
		OR f.descripcion = 'ABM CLIENTES' OR f.descripcion = 'ABM HOTEL'
		OR f.descripcion = 'ABM HABITACION' 
		OR f.descripcion = 'ABM REGIMEN DE ESTADIA' OR f.descripcion = 'LISTADO ESTADISTICO'
		OR f.descripcion = 'FACTURAR'
insert into skynet.rolFunciones(rol,funcion)
select (select idRol from SKYNET.Roles where nombre='RECEPCIONISTA'), f.idFuncion
		from SKYNET.Funciones f
		where f.descripcion = 'ABM CLIENTES'
		OR f.descripcion = 'GENERAR O MODIFICAR RESERVA' 
		OR f.descripcion = 'REGISTRAR ESTADIA' or f.descripcion= 'CANCELAR RESERVA'
		OR f.descripcion = 'REGISTRAR CONSUMIBLES' OR f.descripcion = 'FACTURAR'


insert into skynet.rolFunciones(rol,funcion)
select (select idRol from SKYNET.Roles where nombre='GUEST'), f.idFuncion
from SKYNET.Funciones f		
where f.descripcion = 'GENERAR O MODIFICAR RESERVA' OR f.descripcion = 'CANCELAR RESERVA' 

		
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

set identity_insert [SKYNET].[Reservas] ON

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
WHERE estado = 1 AND fechaDesde > (select top 1 fecha from SKYNET.Config)

/*ACTUALIZO CANCELADAS POR NO-SHOW*/
insert into SKYNET.Cancelaciones(reserva,motivo,fechaCancel)
select r.codigoReserva,'NO-SHOW',r.fechaDesde
from SKYNET.Reservas r
where r.estado=1/*cancelada*/

set identity_insert [SKYNET].[Reservas] OFF

/*------------------------------------------------------------------------------*/
/*migro estadias*/

GO
ALTER TABLE SKYNET.Estadias
NOCHECK CONSTRAINT FK_Estadias_ItemsFactura; 
GO

insert into SKYNET.Estadias (reserva,cantNoches,precioPorNocheEstadia,numeroFactura,itemFactura)
select distinct m.Reserva_Codigo,m.Estadia_Cant_Noches,(
		select m2.Item_Factura_Monto 
		from gd_esquema.Maestra m2
		where m.Reserva_Codigo=m2.Reserva_Codigo and
		m2.Item_Factura_Monto is not null and
		m2.Consumible_Codigo is null),(select m3.Factura_Nro
from gd_esquema.Maestra m3
where m3.Factura_Nro is not null and m3.Reserva_Codigo=m.Reserva_Codigo
group by m3.Factura_Nro)
,1
		from gd_esquema.Maestra m
where(m.Estadia_Cant_Noches is not null)

GO
ALTER TABLE SKYNET.Estadias
CHECK CONSTRAINT FK_Estadias_ItemsFactura; 
GO

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
set identity_insert [SKYNET].[Facturas] ON
insert into SKYNET.Facturas(facturaNumero,estadia,fecha,tipoPago,monto,diferenciaInconsistencia)
select m.Factura_Nro,m.Reserva_Codigo,m.Factura_Fecha,1,m.Factura_Total,m.Factura_Total-SUM(case when m.Consumible_Codigo is not null then  m.Item_Factura_Cantidad*m.Item_Factura_Monto
																							else m.Item_Factura_Monto*m.Reserva_Cant_Noches end)
from gd_esquema.Maestra m
where m.Factura_Nro is not null and m.Item_Factura_Cantidad is not null and m.Item_Factura_Monto is not null
group by m.Factura_Nro,m.Reserva_Codigo,m.Factura_Fecha,m.Factura_Total
set identity_insert [SKYNET].[Facturas] OFF

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
GO
ALTER TABLE SKYNET.ConsumiblesEstadias
NOCHECK CONSTRAINT FK_ConsumiblesEstadias_ItemsFactura; 
GO

go
Create trigger SKYNET.triggerMigrarConsumiblesEstadias on SKYNET.ConsumiblesEstadias 
instead of insert
AS
begin transaction
declare @numeroFactura numeric(18,0),@item numeric(18,0),@numeroFacturaAnt numeric(18,0)
declare @estadia numeric(18,0),@consumible numeric(18,0),@precioTotal numeric(18,2),@cantidad numeric(18,0)
declare cursor_consumibles cursor for
		 select estadia,consumible,precioTotal,cantidad,numeroFactura
		 from inserted
		 order by numeroFactura
		 
open cursor_consumibles
fetch next from cursor_consumibles into @estadia,@consumible,@precioTotal,@cantidad,@numeroFactura
set @numeroFacturaAnt=-1
while @@fetch_status=0
begin
if (@numeroFactura=@numeroFacturaAnt)
set @item=@item+1
else begin
	set @item=2
	set @numeroFacturaAnt=@numeroFactura
	end
insert SKYNET.ConsumiblesEstadias(estadia,consumible,precioTotal,cantidad,numeroFactura,itemFactura) values(@estadia,@consumible,@precioTotal,@cantidad,@numeroFactura,@item)
fetch next from cursor_consumibles into @estadia,@consumible,@precioTotal,@cantidad,@numeroFactura
end
close cursor_consumibles
deallocate cursor_consumibles
commit
go

insert into SKYNET.ConsumiblesEstadias(estadia,consumible,precioTotal,cantidad,numeroFactura)
select m.Reserva_Codigo,m.Consumible_Codigo,m.Item_Factura_Monto*m.Item_Factura_Cantidad,
		m.Item_Factura_Cantidad,m.Factura_Nro
from gd_esquema.Maestra m
where (m.Consumible_Codigo is not null)


drop trigger SKYNET.triggerMigrarConsumiblesEstadias
GO
ALTER TABLE SKYNET.ConsumiblesEstadias
CHECK CONSTRAINT FK_ConsumiblesEstadias_ItemsFactura; 
GO

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

/*------------------------------------------------------------------------------*/
/*Migro ItemsFactura*/ 
Insert into SKYNET.ItemsFactura(numeroFactura,item,detalle,cantidad,precioUnitario)
select e.numeroFactura,e.itemFactura,'Estadia',1,e.precioPorNocheEstadia
from SKYNET.Estadias e

Insert into SKYNET.ItemsFactura(numeroFactura,item,detalle,cantidad,precioUnitario)
select ce.numeroFactura,ce.itemFactura,c.nombre,ce.cantidad,c.precio
from SKYNET.ConsumiblesEstadias ce,SKYNET.Consumibles c
where ce.consumible=c.codigo

/*obtener disponibles*/
go

create function SKYNET.habitacionesOcupadas(@reserva numeric(18,2), @fecha datetime, @tipoHabitacion numeric(18, 0), @hotel numeric(18, 0))
returns int
begin
declare @ocupadas int
set @ocupadas = 
((select COALESCE(SUM(COALESCE(rh.cantidad, 0)),0) from SKYNET.Reservas r,SKYNET.ReservasPorTipoHabitacion rh
where rh.idReserva=r.codigoReserva and
	  r.codigoReserva!=@reserva and
	  rh.idTipoHabitacion=@tipoHabitacion and
	  r.hotel = @hotel and
	  r.estado between 3 and 4 and
	  @fecha between r.fechaDesde and DATEADD(dd,r.cantNoches-1,r.fechaDesde))+
(select COALESCE(SUM(COALESCE(rh.cantidad,0)), 0) from SKYNET.Reservas r,SKYNET.ReservasPorTipoHabitacion rh, SKYNET.Estadias e
where rh.idReserva=r.codigoReserva and e.reserva= r.codigoReserva and
	  rh.idTipoHabitacion=@tipoHabitacion and
	  r.hotel = @hotel
	  and
	  r.estado = 2 and
	  @fecha between r.fechaDesde and DATEADD(dd,e.cantNoches-1,r.fechaDesde)))
return @ocupadas
end
go
create function SKYNET.habitacionesTotales(@hotel numeric(18, 0), @tipoHabitacion numeric(18,0))
returns int
begin
declare @retorno int
set @retorno = (SELECT COUNT(*) FROM SKYNET.Habitaciones WHERE @hotel = hotel AND @tipoHabitacion = tipo AND baja = 0)
return @retorno
end
go
create function SKYNET.habitacionesDisponibles(@reserva numeric(18,2), @fecha datetime, @hotel numeric(18, 0), @tipoHabitacion numeric(18, 0), @cantNoches int)
returns int
begin
declare @i int, @max int, @aux int
set @i = 0
set @max = 0
while (@i<@cantNoches)
begin
set @aux =(SELECT SKYNET.habitacionesOcupadas(@reserva, DATEADD(dd, @i, @fecha), @tipoHabitacion, @hotel))
if(@max<@aux)
begin
	set @max = @aux
end
set @i = @i + 1
end
return ((SELECT SKYNET.habitacionesTotales(@hotel, @tipoHabitacion)) - @max)
end
go


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



/* Trigger al insertar cancelaciones cambia estado de la reserva*/
go
create trigger tr_cancelaciones_ins on SKYNET.Cancelaciones
for Insert
as
begin transaction
declare @reserva numeric(18,0),@motivo nvarchar(50)
declare cancelaciones_nuevas cursor for 
		select reserva,motivo
		from Inserted
open cancelaciones_nuevas
fetch next from cancelaciones_nuevas into @reserva,@motivo
while @@fetch_status=0
begin
if(coalesce((select r.estado
   from SKYNET.Reservas r
   where r.codigoReserva=@reserva),3)between 2 and 4 )
   begin
   update SKYNET.Reservas set estado=( select case  when @motivo like '%cliente%' then 6
												 when @motivo like '%recepcion%' then  5
										    	 else 1 end	)
   where codigoReserva=@reserva
   end
fetch next from cancelaciones_nuevas into @reserva,@motivo
end	
close cancelaciones_nuevas
deallocate cancelaciones_nuevas
commit 
go

/* trigger verifica que no se supere maximos de huespedes para una reserva*/
go
create trigger tr_clientesEstadias on SKYNET.ClientesPorEstadia
for Insert,Update
as
begin transaction
if(exists(select 1
		  from Inserted i,SKYNET.ClientesPorEstadia ce
		  where i.idEstadia=ce.idEstadia
		  group by i.idEstadia
		  having count(*)>(select sum(h.cantidad*th.capacidad)
						   from SKYNET.ReservasPorTipoHabitacion h,SKYNET.TiposHabitacion th
						   where h.idReserva=i.idEstadia and 
						   h.idTipoHabitacion=th.codigo)))
						   begin
						   RAISERROR('Se ingresaron más huespedes que los posibles de albergar',14,1)
						   rollback
						   end
else	
commit
go

/* Trigger al insertar estadia cambia estado de la reserva a efectivizada*/
go
create trigger insert_estadias_cambiarEstadoReserva on SKYNET.Estadias
for Insert
as
declare cursor_reservasACambiar cursor for
		select reserva
		from Inserted
declare @reserva numeric(18,0)
open cursor_reservasACambiar
fetch next from cursor_reservasACambiar into @reserva
while @@fetch_status=0
begin
update SKYNET.Reservas set estado=2
where codigoReserva=@reserva
fetch next from cursor_reservasACambiar into @reserva
end
close cursor_reservasACambiar
deallocate cursor_reservasACambiar
begin transaction
commit
go

/* Trigger calcular PrecioTotal en ConsumiblesEstadias para insert y update*/
go
create trigger calcultar_precioTotal_ConsumiblesEstadias on SKYNET.ConsumiblesEstadias
for Insert,Update
as
begin transaction
if(update(consumible) or update(cantidad))
begin
declare cursor_consumiblesEstadias cursor for
			select distinct idConsumibleEstadia
			from Inserted
declare @idConsumibleEstadia numeric(18,0)
open cursor_consumiblesEstadias
fetch next from cursor_consumiblesEstadias into @idConsumibleEstadia
while @@fetch_status=0
begin
update SKYNET.ConsumiblesEstadias set precioTotal=(select c.precio*ce.cantidad
												   from SKYNET.ConsumiblesEstadias ce,SKYNET.Consumibles c
												   where ce.idConsumibleEstadia=@idConsumibleEstadia and
												   ce.consumible=c.codigo)
where idConsumibleEstadia=@idConsumibleEstadia
fetch next from cursor_consumiblesEstadias into @idConsumibleEstadia
end
close cursor_consumiblesEstadias
deallocate cursor_consumiblesEstadias
end
commit
go


/* Trigger calcular PrecioPorNoche en EstadiaPorHabitacion*/
go
create trigger estadiaPorHabitacion_CalculoPrecioPorNoche on SKYNET.EstadiaPorHabitacion
for insert,update,delete
as
begin transaction
declare cursor_ids_Estadias cursor for
			select distinct idEstadia
			from Inserted
			union 
			select distinct idEstadia
			from Deleted
declare @idEstadia numeric(18,0),@precioPorNoche numeric(18,2),@recargaEstrella numeric(18,2)
set @recargaEstrella=(select top 1 recarga from SKYNET.RecargaEstrellas)
open cursor_ids_Estadias
fetch next from cursor_ids_Estadias into @idEstadia
while @@fetch_status=0
begin
set @precioPorNoche = (select sum(hot.cantidadEstrellas*@recargaEstrella
													+reg.precioBase*th.porcentual)
												  from SKYNET.EstadiaPorHabitacion eh,
													   SKYNET.Habitaciones h,
													   SKYNET.TiposHabitacion th,
													   SKYNET.Hoteles hot, SKYNET.Reservas r,
													   SKYNET.Regimenes reg
												  where eh.idEstadia=@idEstadia and
												  eh.idHabitacion=h.numero and
												  eh.idHotel=h.hotel and
												  h.tipo=th.codigo and
												  hot.idHotel=h.hotel and
												  eh.idEstadia=r.codigoReserva and 
												  r.regimen=reg.idRegimen)		
update SKYNET.Estadias set precioPorNocheEstadia=@precioPorNoche										  
where reserva=@idEstadia
fetch next from cursor_ids_Estadias into @idEstadia
end
close cursor_ids_Estadias
deallocate cursor_ids_Estadias
commit
go


/* trigger mantener actualizado el monto en Factura*/

go
create trigger calculo_monto_factura on SKYNET.ItemsFactura
for insert,update,delete
as
begin transaction
declare cursor_ids_Facturas cursor for
			select distinct numeroFactura
			from Inserted
			union 
			select distinct numeroFactura
			from Deleted
declare @numeroFactura numeric(18,0),@monto numeric(18,2)
open cursor_ids_Facturas
fetch next from cursor_ids_Facturas into @numeroFactura
while @@fetch_status=0
begin
set @monto = (select e.precioPorNocheEstadia*r.cantNoches from SKYNET.Estadias e,SKYNET.Reservas r 
			 where e.reserva=r.codigoReserva and 
			 e.reserva=(select f.estadia from SKYNET.Facturas f
			 where f.facturaNumero=@numeroFactura))
set @monto=@monto+(coalesce((select sum(ce.precioTotal)
				   from SKYNET.ItemsFactura itf,SKYNET.ConsumiblesEstadias ce,SKYNET.Reservas r
				   where itf.numeroFactura=@numeroFactura and
				   (itf.detalle is null or itf.detalle not like '%Estadia%') and
				   ce.numeroFactura=itf.numeroFactura and ce.itemFactura=itf.item and
				   r.codigoReserva=ce.estadia and not exists(
				   select 1 from SKYNET.ConsumiblesPorRegimenes cr where
				   cr.idRegimen=r.regimen and cr.idConsumible=ce.consumible)
				   ),0))
				   
update SKYNET.Facturas set monto=@monto										  
where facturaNumero=@numeroFactura
fetch next from cursor_ids_Facturas into @numeroFactura
end
close cursor_ids_Facturas
deallocate cursor_ids_Facturas
commit
go


/* trigger agregar nuevos consumibles a all inclusive*/
go
create trigger agregar_consumibles_nuevos_a_AllInclusive on SKYNET.Consumibles
for insert
as
begin transaction
insert into SKYNET.ConsumiblesPorRegimenes(idRegimen,idConsumible)
(select r.idRegimen,i.codigo from SKYNET.Regimenes r,Inserted i
 where r.descripcion like 'All inclusive') 
commit
go

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


create procedure SKYNET.facturarUnaEstadia(@estadia numeric (18,0),@fecha datetime,
										   @nombreTipoPago nvarchar(255),@numTarjeta numeric(18,0),
										   @datosTarjeta nvarchar(255))
as
declare @numeroFactura numeric(18,0)
if(@estadia is null)
begin
RAISERROR('IngreseEstadia',14,1)
return
end
else
begin
if (not exists(select 1 from SKYNET.Facturas f where f.estadia=@estadia))
	begin
	if (@numTarjeta is null)
		begin
		insert SKYNET.Facturas(diferenciaInconsistencia,estadia,fecha,monto,tipoPago) 
		values(0,@estadia,coalesce(@fecha,(select top 1 fecha from SKYNET.Config)),0,1)
		set @numeroFactura=(select f.facturaNumero
			   from SKYNET.Facturas f
			   where f.estadia=@estadia)
		end
		else
		begin
		insert SKYNET.Facturas(diferenciaInconsistencia,estadia,fecha,monto,tipoPago) 
		values(0,@estadia,coalesce(@fecha,(select top 1 fecha from SKYNET.Config)),0,(select top 1 t.idTipoPago
															from SKYNET.TiposPago t
															where t.nombre=@nombreTipoPago))
		set @numeroFactura=(select f.facturaNumero
			   from SKYNET.Facturas f
			   where f.estadia=@estadia)
		insert SKYNET.DatosTarjeta(nroFactura,numTarjeta,datosTarjeta)
		values(@numeroFactura,@numTarjeta,@datosTarjeta) 
		end
	insert into SKYNET.ItemsFactura(numeroFactura,item,detalle,cantidad,precioUnitario) (select @numeroFactura,1,'Estadia efectiva de '+convert(nvarchar(4),coalesce(e.cantNoches,0))+case when(e.cantNoches=1)then' dia' else ' dias'end+' sobre una reserva de '
			+convert(nvarchar(4),r.cantNoches)+case when(r.cantNoches=1)then' dia' else ' dias'end ,1,(e.precioPorNocheEstadia *  r.cantNoches)	from Skynet.Estadias e,Skynet.Reservas r
																	where e.reserva=r.codigoReserva
																	and e.reserva=@estadia)
	update SKYNET.Estadias set numeroFactura=@numeroFactura,itemFactura=1
	where reserva=@estadia
	create table #consumiblesDeLaEstadia(
				idTemporal numeric(18,0) identity(0,1),
				idConsumibleEstadia numeric(18,0),
				nombreConsumible nvarchar(255),
				cantidad numeric(18,0),
				precioUnitario numeric(18,0))
	insert into #consumiblesDeLaEstadia(idConsumibleEstadia,nombreConsumible,cantidad,precioUnitario)
	(select ce.idConsumibleEstadia,(select c.nombre from Consumibles c
								 where c.codigo=ce.consumible),ce.cantidad,ce.precioTotal/ce.cantidad
	from SKYNET.ConsumiblesEstadias ce
	where ce.estadia=@estadia)
	declare @contador int,@cantFilas int,@item int,@idConsumibleEstadia numeric(18,0),@nombreConsumible nvarchar(255)
	declare @cantidad numeric(18,0),@precioUnitario numeric(18,2)
	set @contador=0
	set @cantFilas= (select COUNT(*) from #consumiblesDeLaEstadia)
	set @item=2
	ALTER TABLE SKYNET.ConsumiblesEstadias
	NOCHECK CONSTRAINT FK_ConsumiblesEstadias_ItemsFactura
	while @contador<@cantFilas
	begin
	select @idConsumibleEstadia=idConsumibleEstadia,@nombreConsumible=nombreConsumible,
	@cantidad=cantidad,@precioUnitario=precioUnitario
	from #consumiblesDeLaEstadia
	where idTemporal=@contador
	update SKYNET.ConsumiblesEstadias set numeroFactura=@numeroFactura,itemFactura=@item
	where idConsumibleEstadia= @idConsumibleEstadia
	insert SKYNET.ItemsFactura(numeroFactura,item,detalle,cantidad,precioUnitario)
	values (@numeroFactura,@item,@nombreConsumible,@cantidad,@precioUnitario)
	set @item=@item+1
	set @contador=@contador+1
	end
	ALTER TABLE SKYNET.ConsumiblesEstadias
	CHECK CONSTRAINT FK_ConsumiblesEstadias_ItemsFactura
	declare @inconsistencia numeric(18,2),@monto numeric(18,2)
	select @inconsistencia=f.diferenciaInconsistencia,@monto=f.monto from SKYNET.Facturas f where f.facturaNumero=@numeroFactura
	;DISABLE TRIGGER calculo_monto_factura on SKYNET.ItemsFactura
	if(@inconsistencia=0)
	begin	
	insert SKYNET.ItemsFactura(numeroFactura,item,detalle,cantidad,precioUnitario) 
		   values(@numeroFactura,@item,'Descuento por regimen '+(select reg.descripcion from SKYNET.Reservas r,SKYNET.Regimenes reg
												  where r.codigoReserva=@estadia
												  and r.regimen=reg.idRegimen),1,(@monto-(select sum(cantidad*precioUnitario) from SKYNET.ItemsFactura itf
																						where itf.numeroFactura=@numeroFactura)))
	end
	;ENABLE TRIGGER calculo_monto_factura on SKYNET.ItemsFactura
	end
end
go

/* Emitir factura*/
go
create procedure SKYNET.registrarCheckOut(@estadia numeric(18,0),@usuarioEgreso numeric(18,0))
as
begin
update SKYNET.Estadias set cantNoches = DATEDIFF(day, (SELECT fechaDesde FROM SKYNET.Reservas WHERE codigoReserva = @estadia), (select top 1 fecha from SKYNET.Config)),usuarioEgreso = @usuarioEgreso WHERE reserva = @estadia
end
go
create function SKYNET.emitirFactura(@estadia numeric(18,0))
returns @retorno table (
		NumeroDeFactura nvarchar(18),
		Item			nvarchar(18),
		Detalle		    nvarchar(255),
		Cantidad	    nvarchar(18),
		PrecioUnitario  nvarchar(18),
		SubTotal	    numeric(18,2)
		)
as
begin
if(not exists(select 1 from SKYNET.Facturas f where f.estadia=@estadia))
	begin
	insert @retorno(Detalle) values('Error, primero debe facturarse la estadia')
	end
	else
	begin
	declare @cantidad numeric(18,0)
	insert into @retorno(NumeroDeFactura,Item,Detalle,Cantidad,PrecioUnitario,SubTotal)
		 	(select f.facturaNumero,itf.item,itf.detalle,itf.cantidad,itf.precioUnitario,itf.cantidad*itf.precioUnitario
			from Skynet.Facturas f,SKYNET.ItemsFactura itf
			 where f.estadia=@estadia
			 and itf.numeroFactura=f.facturaNumero)
			 order by 2
	 declare @inconsistencia numeric (18,2),@monto numeric(18,2)
	 select @monto=f.monto,@inconsistencia=f.diferenciaInconsistencia from SKYNET.Facturas f where f.estadia=@estadia
	insert @retorno(NumeroDeFactura,Item,Detalle,Cantidad,PrecioUnitario,SubTotal) 
		   values('','','Total','','',@monto)
	 if(@inconsistencia!=0)
		begin
		insert @retorno(NumeroDeFactura,Item,Detalle,Cantidad,PrecioUnitario,SubTotal) 
		   values('','','Diferencia Inconsistencia de la migracion','','',@inconsistencia)
		end
    
	end
return
end
go

  go
  create function SKYNET.validarBajaHotel (@hotel numeric(18,0),@fechaDesde datetime,@duracion int)
  returns int as
  begin/*
  return (select 1 from SKYNET.HistorialHoteles where hotel = @hotel and 
  (@fechaDesde between fechaBaja and dateadd(dd,duracion,fechaBaja) or 
  dateadd(dd,@duracion,@fechaDesde) between fechaBaja and dateadd(dd,duracion,fechaBaja) ))*/
  declare @i int, @problemas int, @deboHacerElWhile int
  set @i = 0
  set @problemas = 0
  set @deboHacerElWhile = (select count(*) from SKYNET.HistorialHoteles where hotel = @hotel)
  if(@deboHacerElWhile>0) begin
  while (@i<@duracion) begin
  set @problemas =(select count(*) from SKYNET.HistorialHoteles where hotel = @hotel and 
  (dateadd(dd, @i, @fechaDesde) between dateadd(dd, -1, fechaBaja) and dateadd(dd,duracion,fechaBaja)))
  if (@problemas > 0)
  begin
  set @i = @duracion
  end
  set @i=@i+1
  end
  end
  return @problemas
  end
  go

create function SKYNET.noPuedoDarDeBaja(@hotel numeric(18,0), @fecha datetime, @duracion numeric(18,0))
returns int
begin
declare @resultado int, @i int
set @resultado = 0
set @i = 0
while (@i<@duracion)
begin
set @resultado = (COALESCE((SELECT SKYNET.habitacionesOcupadas(0, dateadd(dd, @i, @fecha), 1001, @hotel)),0)+
COALESCE((SELECT SKYNET.habitacionesOcupadas(0, dateadd(dd, @i, @fecha), 1002, @hotel)),0)+
COALESCE((SELECT SKYNET.habitacionesOcupadas(0, dateadd(dd, @i, @fecha), 1003, @hotel)),0)+
COALESCE((SELECT SKYNET.habitacionesOcupadas(0, dateadd(dd, @i, @fecha), 1004, @hotel)),0)+
COALESCE((SELECT SKYNET.habitacionesOcupadas(0, dateadd(dd, @i, @fecha), 1005, @hotel)),0))
if (@resultado >0)
begin
set @i = @duracion
end
set @i=@i+1
end
return @resultado
end
go



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


