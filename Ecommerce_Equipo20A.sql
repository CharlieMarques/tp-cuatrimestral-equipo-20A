use master

create Database Ecommerce_Equipo20A
Go
use Ecommerce_Equipo20A

Create table MARCAS(
	Id int identity (1,1) not null primary key,
	Descripcion varchar (50) not null,
);
go
Create table CATEGORIAS(
	Id int identity(1,1) not null primary key,
	Descripcion varchar (50) not null
);
go
Create table PRODUCTOS(
	Id int identity(1,1) not null primary key,
	Codigo varchar (50)null unique,
	Nombre varchar(50)null,
	Descripcion varchar(150) null,
	Precio money not null,
	idMarca int null,
	idCategoria int null
);

