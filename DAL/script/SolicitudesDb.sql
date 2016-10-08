
Create table Solicitud(
		SolicitudId int identity(1,1) Primary key,
		Razon varchar(100),
		Fecha varchar(20),
		Total float
)go
create table SolicitudDetalle(
     Id int identity(1,1) Primary key,
	 SolicitudId int foreign key references Solicitud(SolicitudId),
	 Material varchar(100),
	 Cantidad int,
	 Precio float
)go
create table Materiales(
	MaterialesId int identity(1,1) Primary key,
	Descripcion varchar(100),
	Precio float
);

drop table SolicitudDetalle;