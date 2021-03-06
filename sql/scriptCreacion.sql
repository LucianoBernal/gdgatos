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
