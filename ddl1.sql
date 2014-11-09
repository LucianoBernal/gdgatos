CREATE TABLE SKYNET.Regimenes ( 
	idRegimen numeric(18,0) NOT NULL,
	nombre nvarchar(50) NULL,
	precioBase numeric(18,2) NULL,
	descripcion nvarchar(255) NULL,
	estado bit NULL
)
;

CREATE TABLE SKYNET.Nacionalidades ( 
	idNacionalidad numeric(18,0) NOT NULL,
	nacionalidad nvarchar(255) NULL
)
;

CREATE TABLE SKYNET.Clientes ( 
	idCliente numeric(18,0) NOT NULL,
	apellido nvarchar(255) NULL,
	nombre nvarchar(255) NULL,
	tipoDoc numeric(18,0) NULL,
	numDoc numeric(18,0) NULL,
	mail nvarchar(255) NULL,
	telefono numeric(18,0) NULL,
	calle nvarchar(255) NULL,
	piso numeric(18,0) NULL,
	depto nvarchar(50) NULL,
	nacionalidad numeric(18,0) NULL,
	numCalle numeric(18,0) NULL,
	fechaNac datetime NULL,
	baja bit NULL
)
;

CREATE TABLE SKYNET.paises ( 
	idPais numeric(18,0) NOT NULL,
	pais nvarchar(255) NULL
)
;

CREATE TABLE SKYNET.Cadenas ( 
	idCadena numeric(18,0) NOT NULL,
	cadena nvarchar(255) NULL
)
;

CREATE TABLE SKYNET.RolFunciones ( 
	rol numeric(18,0) NOT NULL,
	funcion numeric(18,0) NOT NULL
)
;

CREATE TABLE SKYNET.DatosTarjeta ( 
	tipoPago numeric(18,0) NOT NULL,
	numTarjeta numeric(18,0) NOT NULL,
	datosTarjeta nvarchar(255) NULL
)
;

CREATE TABLE SKYNET.TiposPago ( 
	idTipoPago numeric(18,0) NOT NULL,
	nombre nvarchar(255) NULL
)
;

CREATE TABLE SKYNET.Facturas ( 
	facturaNumero numeric(18,0) NOT NULL,
	estadia numeric(18,0) NULL,
	fechaPago datetime NULL,
	tipoPago numeric(18,0) NULL,
	monto numeric(18,2) NULL
)
;

CREATE TABLE SKYNET.Cancelaciones ( 
	reserva numeric(18,0) NOT NULL,
	motivo nvarchar(50) NULL,
	fechaCancel datetime NULL
)
;

CREATE TABLE SKYNET.HotelHabEstadia ( 
	hotel numeric(18,0) NOT NULL,
	habitacion numeric(18) NOT NULL,
	estadia numeric(18,0) NOT NULL
)
;

CREATE TABLE SKYNET.Reservas ( 
	codigoReserva numeric(18,0) NOT NULL,
	hotel numeric(18,0) NULL,
	tipoHabitacion numeric(18,0) NULL,
	regimen numeric(18,0) NULL,
	fechaReserva datetime NULL,
	fechaDesde datetime NULL,
	cantNoches numeric(18,0) NULL,
	estado numeric(18,0) NULL,
	cliente numeric(18,0) NULL
)
;

CREATE TABLE SKYNET.HistorialHoteles ( 
	hotel numeric(18,0) NOT NULL,
	fechaBaja datetime NOT NULL,
	duracion numeric(18,0) NULL,
	motivo nvarchar(255) NULL
)
;

CREATE TABLE SKYNET.HotelesRegimen ( 
	hotel numeric(18,0) NOT NULL,
	regimen numeric(18,0) NOT NULL
)
;

CREATE TABLE SKYNET.Consumibles ( 
	codigo numeric(18,0) NOT NULL,
	nombre nvarchar(255) NULL,
	precio numeric(18,2) NULL
)
;

CREATE TABLE SKYNET.UsuarioRolHotel ( 
	usuario numeric(18,0) NOT NULL,
	hotel numeric(18,0) NOT NULL,
	rol numeric(18,0) NOT NULL
)
;

CREATE TABLE SKYNET.TiposDoc ( 
	idTipoDoc numeric(18,0) NOT NULL,
	nombre varchar(50) NULL
)
;

CREATE TABLE SKYNET.ConsumiblesEstadias ( 
	estadia numeric(18,0) NOT NULL,
	consumible numeric(18,0) NOT NULL,
	precio numeric(18,2) NULL,
	cantidad numeric(18,0) NULL
)
;

CREATE TABLE SKYNET.TiposHabitacion ( 
	codigo numeric(18,0) NOT NULL,
	descripcion nvarchar(255) NULL,
	porcentual numeric(18,2) NULL
)
;

CREATE TABLE SKYNET.EstadosReserva ( 
	idEstado numeric(18,0) NOT NULL,
	nombre varchar(50) NULL
)
;

CREATE TABLE SKYNET.Roles ( 
	idRol numeric(18,0) NOT NULL,
	nombre varchar(50) NULL,
	baja date NULL
)
;

CREATE TABLE SKYNET.Funciones ( 
	idFuncion numeric(18,0) NOT NULL,
	descripcion varchar(50) NULL
)
;

CREATE TABLE SKYNET.Habitaciones ( 
	hotel numeric(18,0) NOT NULL,
	numero numeric(18,0) NOT NULL,
	piso numeric(18,0) NULL,
	tipo numeric(18,0) NULL,
	ubicacion nvarchar(50) NULL,
	descripcion nvarchar(50) NULL,
	baja bit NULL
)
;

CREATE TABLE SKYNET.Estadias ( 
	reserva numeric(18,0) NOT NULL,
	usuarioIngreso numeric(18,0) NULL,
	fechaInicio datetime NULL,
	cantNoches numeric(18,0) NULL,	
	usuarioEgreso numeric(18,0) NULL
)
;

CREATE TABLE SKYNET.Hoteles ( 
	idHotel numeric(18,0) NOT NULL,
	nombre varchar(50) NULL,
	calle varchar(255) NULL,
	mail varchar(50) NULL,
	numCalle numeric(18,0) NULL,
	cantidadEstrellas numeric(18,0) NULL,
	ciudad numeric(18,0) NULL,
	pais numeric(18,0) NULL,
	fechaCreacion datetime NULL,
	cadena numeric(18,0) NULL
)
;

CREATE TABLE SKYNET.Usuarios ( 
	idUser numeric(18,0) NOT NULL,
	username nvarchar(50) NULL,
	pass numeric(18,2) NULL,
	apellido varchar(50) NULL,
	nombre varchar(50) NULL,
	tipoDoc nvarchar(50) NULL,
	numDoc numeric(18,2) NULL,
	mail nvarchar(50) NULL,
	telefono numeric(18,2) NULL,
	calle nvarchar(50) NULL,
	numCalle numeric(18,2) NULL,
	fechaNac date NULL
)
;


ALTER TABLE SKYNET.Regimenes ADD CONSTRAINT PK_Regimen 
	PRIMARY KEY CLUSTERED (idRegimen)
;

ALTER TABLE SKYNET.Nacionalidades ADD CONSTRAINT PK_Nacionalidad 
	PRIMARY KEY CLUSTERED (idNacionalidad)
;

ALTER TABLE SKYNET.Clientes ADD CONSTRAINT PK_Cliente 
	PRIMARY KEY CLUSTERED (idCliente)
;

ALTER TABLE SKYNET.paises ADD CONSTRAINT PK_pais 
	PRIMARY KEY CLUSTERED (idPais)
;

ALTER TABLE SKYNET.Cadenas ADD CONSTRAINT PK_Cadena 
	PRIMARY KEY CLUSTERED (idCadena)
;

ALTER TABLE SKYNET.RolFunciones ADD CONSTRAINT PK_RolFunciones 
	PRIMARY KEY CLUSTERED (rol, funcion)
;

ALTER TABLE SKYNET.DatosTarjeta ADD CONSTRAINT PK_DatosPago 
	PRIMARY KEY CLUSTERED (tipoPago)
;

ALTER TABLE SKYNET.TiposPago ADD CONSTRAINT PK_TipoPago 
	PRIMARY KEY CLUSTERED (idTipoPago)
;

ALTER TABLE SKYNET.Facturas ADD CONSTRAINT PK_Factura 
	PRIMARY KEY CLUSTERED (facturaNumero)
;

ALTER TABLE SKYNET.Cancelaciones ADD CONSTRAINT PK_Cancelaciones 
	PRIMARY KEY CLUSTERED (reserva)
;

ALTER TABLE SKYNET.HotelHabEstadia ADD CONSTRAINT PK_HotelHabEstadia 
	PRIMARY KEY CLUSTERED (hotel, habitacion, estadia)
;

ALTER TABLE SKYNET.Reservas ADD CONSTRAINT PK_Reserva 
	PRIMARY KEY CLUSTERED (codigoReserva)
;

ALTER TABLE SKYNET.HistorialHoteles ADD CONSTRAINT PK_HistorialHotel 
	PRIMARY KEY CLUSTERED (hotel, fechaBaja)
;

ALTER TABLE SKYNET.HotelesRegimen ADD CONSTRAINT PK_HotelRegimen 
	PRIMARY KEY CLUSTERED (hotel, regimen)
;

ALTER TABLE SKYNET.Consumibles ADD CONSTRAINT PK_Consumible 
	PRIMARY KEY CLUSTERED (codigo)
;

ALTER TABLE SKYNET.UsuarioRolHotel ADD CONSTRAINT PK_UsuarioRolHotel 
	PRIMARY KEY CLUSTERED (usuario, hotel, rol)
;

ALTER TABLE SKYNET.TiposDoc ADD CONSTRAINT PK_TipoDoc 
	PRIMARY KEY CLUSTERED (idTipoDoc)
;

ALTER TABLE SKYNET.ConsumiblesEstadias ADD CONSTRAINT PK_ConsumibleEstadia 
	PRIMARY KEY CLUSTERED (estadia, consumible)
;

ALTER TABLE SKYNET.TiposHabitacion ADD CONSTRAINT PK_TipoHabitacion 
	PRIMARY KEY CLUSTERED (codigo)
;

ALTER TABLE SKYNET.EstadosReserva ADD CONSTRAINT PK_EstadoReserva 
	PRIMARY KEY CLUSTERED (idEstado)
;

ALTER TABLE SKYNET.Roles ADD CONSTRAINT PK_Rol 
	PRIMARY KEY CLUSTERED (idRol)
;

ALTER TABLE SKYNET.Funciones ADD CONSTRAINT PK_Funcion 
	PRIMARY KEY CLUSTERED (idFuncion)
;

ALTER TABLE SKYNET.Habitaciones ADD CONSTRAINT PK_Habitacion 
	PRIMARY KEY CLUSTERED (hotel, numero)
;

ALTER TABLE SKYNET.Estadias ADD CONSTRAINT PK_Estadia 
	PRIMARY KEY CLUSTERED (reserva)
;

ALTER TABLE SKYNET.Hoteles ADD CONSTRAINT PK_Hotel 
	PRIMARY KEY CLUSTERED (idHotel)
;

ALTER TABLE SKYNET.Usuarios ADD CONSTRAINT PK_Usuario 
	PRIMARY KEY CLUSTERED (idUser)
;

