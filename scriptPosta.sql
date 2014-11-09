USE [GD2C2014]
GO
/****** Object:  Schema [SKYNET]    Script Date: 11/09/2014 04:51:26 ******/
CREATE SCHEMA [SKYNET] AUTHORIZATION [dbo]
GO
/****** Object:  Table [SKYNET].[Usuarios]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [SKYNET].[Usuarios](
	[idUser] [numeric](18, 0) NOT NULL,
	[username] [nvarchar](50) NULL,
	[pass] [numeric](18, 2) NULL,
	[apellido] [varchar](50) NULL,
	[nombre] [varchar](50) NULL,
	[tipoDoc] [nvarchar](50) NULL,
	[numDoc] [numeric](18, 2) NULL,
	[mail] [nvarchar](50) NULL,
	[telefono] [numeric](18, 2) NULL,
	[calle] [nvarchar](50) NULL,
	[numCalle] [numeric](18, 2) NULL,
	[fechaNac] [date] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [SKYNET].[UsuarioRolHotel]    Script Date: 11/09/2014 04:51:28 ******/
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
/****** Object:  Table [SKYNET].[TiposPago]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[TiposPago](
	[idTipoPago] [numeric](18, 0) NOT NULL,
	[nombre] [nvarchar](255) NULL,
 CONSTRAINT [PK_TipoPago] PRIMARY KEY CLUSTERED 
(
	[idTipoPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[TiposHabitacion]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[TiposHabitacion](
	[codigo] [numeric](18, 0) NOT NULL,
	[descripcion] [nvarchar](255) NULL,
	[porcentual] [numeric](18, 2) NULL,
 CONSTRAINT [PK_TipoHabitacion] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[TiposDoc]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [SKYNET].[TiposDoc](
	[idTipoDoc] [numeric](18, 0) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_TipoDoc] PRIMARY KEY CLUSTERED 
(
	[idTipoDoc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [SKYNET].[RolFunciones]    Script Date: 11/09/2014 04:51:28 ******/
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
/****** Object:  Table [SKYNET].[Roles]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [SKYNET].[Roles](
	[idRol] [numeric](18, 0) NOT NULL,
	[nombre] [varchar](50) NULL,
	[baja] [date] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [SKYNET].[Reservas]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Reservas](
	[codigoReserva] [numeric](18, 0) NOT NULL,
	[hotel] [numeric](18, 0) NULL,
	[tipoHabitacion] [numeric](18, 0) NULL,
	[regimen] [numeric](18, 0) NULL,
	[fechaReserva] [datetime] NULL,
	[fechaDesde] [datetime] NULL,
	[cantNoches] [numeric](18, 0) NULL,
	[estado] [numeric](18, 0) NULL,
	[cliente] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[codigoReserva] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Regimenes]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Regimenes](
	[idRegimen] [numeric](18, 0) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[precioBase] [numeric](18, 2) NULL,
	[descripcion] [nvarchar](255) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Regimen] PRIMARY KEY CLUSTERED 
(
	[idRegimen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[paises]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[paises](
	[idPais] [numeric](18, 0) NOT NULL,
	[pais] [nvarchar](255) NULL,
 CONSTRAINT [PK_pais] PRIMARY KEY CLUSTERED 
(
	[idPais] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Nacionalidades]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Nacionalidades](
	[idNacionalidad] [numeric](18, 0) NOT NULL,
	[nacionalidad] [nvarchar](255) NULL,
 CONSTRAINT [PK_Nacionalidad] PRIMARY KEY CLUSTERED 
(
	[idNacionalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[HotelHabEstadia]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[HotelHabEstadia](
	[hotel] [numeric](18, 0) NOT NULL,
	[habitacion] [numeric](18, 0) NOT NULL,
	[estadia] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_HotelHabEstadia] PRIMARY KEY CLUSTERED 
(
	[hotel] ASC,
	[habitacion] ASC,
	[estadia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[HotelesRegimen]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[HotelesRegimen](
	[hotel] [numeric](18, 0) NOT NULL,
	[regimen] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_HotelRegimen] PRIMARY KEY CLUSTERED 
(
	[hotel] ASC,
	[regimen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Hoteles]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [SKYNET].[Hoteles](
	[idHotel] [numeric](18, 0) NOT NULL,
	[nombre] [varchar](50) NULL,
	[calle] [varchar](255) NULL,
	[mail] [varchar](50) NULL,
	[numCalle] [numeric](18, 0) NULL,
	[cantidadEstrellas] [numeric](18, 0) NULL,
	[ciudad] [numeric](18, 0) NULL,
	[pais] [numeric](18, 0) NULL,
	[fechaCreacion] [datetime] NULL,
	[cadena] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[idHotel] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [SKYNET].[HistorialHoteles]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[HistorialHoteles](
	[hotel] [numeric](18, 0) NOT NULL,
	[fechaBaja] [datetime] NOT NULL,
	[duracion] [numeric](18, 0) NULL,
	[motivo] [nvarchar](255) NULL,
 CONSTRAINT [PK_HistorialHotel] PRIMARY KEY CLUSTERED 
(
	[hotel] ASC,
	[fechaBaja] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Habitaciones]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Habitaciones](
	[hotel] [numeric](18, 0) NOT NULL,
	[numero] [numeric](18, 0) NOT NULL,
	[piso] [numeric](18, 0) NULL,
	[tipo] [numeric](18, 0) NULL,
	[ubicacion] [nvarchar](50) NULL,
	[descripcion] [nvarchar](50) NULL,
	[baja] [bit] NULL,
 CONSTRAINT [PK_Habitacion] PRIMARY KEY CLUSTERED 
(
	[hotel] ASC,
	[numero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Funciones]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [SKYNET].[Funciones](
	[idFuncion] [numeric](18, 0) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Funcion] PRIMARY KEY CLUSTERED 
(
	[idFuncion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [SKYNET].[Facturas]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Facturas](
	[facturaNumero] [numeric](18, 0) NOT NULL,
	[estadia] [numeric](18, 0) NULL,
	[fechaPago] [datetime] NULL,
	[tipoPago] [numeric](18, 0) NULL,
	[monto] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[facturaNumero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[EstadosReserva]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [SKYNET].[EstadosReserva](
	[idEstado] [numeric](18, 0) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_EstadoReserva] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [SKYNET].[Estadias]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Estadias](
	[reserva] [numeric](18, 0) NOT NULL,
	[usuarioIngreso] [numeric](18, 0) NULL,
	[fechaInicio] [datetime] NULL,
	[cantNoches] [numeric](18, 0) NULL,
	[usuarioEgreso] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Estadia] PRIMARY KEY CLUSTERED 
(
	[reserva] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[DatosTarjeta]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[DatosTarjeta](
	[tipoPago] [numeric](18, 0) NOT NULL,
	[numTarjeta] [numeric](18, 0) NOT NULL,
	[datosTarjeta] [nvarchar](255) NULL,
 CONSTRAINT [PK_DatosPago] PRIMARY KEY CLUSTERED 
(
	[tipoPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[ConsumiblesEstadias]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[ConsumiblesEstadias](
	[estadia] [numeric](18, 0) NOT NULL,
	[consumible] [numeric](18, 0) NOT NULL,
	[precio] [numeric](18, 2) NULL,
	[cantidad] [numeric](18, 0) NULL,
 CONSTRAINT [PK_ConsumibleEstadia] PRIMARY KEY CLUSTERED 
(
	[estadia] ASC,
	[consumible] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Consumibles]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Consumibles](
	[codigo] [numeric](18, 0) NOT NULL,
	[nombre] [nvarchar](255) NULL,
	[precio] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Consumible] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Clientes]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Clientes](
	[idCliente] [numeric](18, 0) NOT NULL,
	[apellido] [nvarchar](255) NULL,
	[nombre] [nvarchar](255) NULL,
	[tipoDoc] [numeric](18, 0) NULL,
	[numDoc] [numeric](18, 0) NULL,
	[mail] [nvarchar](255) NULL,
	[telefono] [numeric](18, 0) NULL,
	[calle] [nvarchar](255) NULL,
	[piso] [numeric](18, 0) NULL,
	[depto] [nvarchar](50) NULL,
	[nacionalidad] [numeric](18, 0) NULL,
	[numCalle] [numeric](18, 0) NULL,
	[fechaNac] [datetime] NULL,
	[baja] [bit] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Cancelaciones]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Cancelaciones](
	[reserva] [numeric](18, 0) NOT NULL,
	[motivo] [nvarchar](50) NULL,
	[fechaCancel] [datetime] NULL,
 CONSTRAINT [PK_Cancelaciones] PRIMARY KEY CLUSTERED 
(
	[reserva] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKYNET].[Cadenas]    Script Date: 11/09/2014 04:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKYNET].[Cadenas](
	[idCadena] [numeric](18, 0) NOT NULL,
	[cadena] [nvarchar](255) NULL,
 CONSTRAINT [PK_Cadena] PRIMARY KEY CLUSTERED 
(
	[idCadena] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
