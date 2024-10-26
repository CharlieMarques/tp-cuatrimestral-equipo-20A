/* use master
create Database Ecommerce_Equipo20A
go
*/

use Ecommerce_Equipo20A
go

/*
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
	FOREIGN KEY (idMarca) REFERENCES MARCAS(Id),
	FOREIGN KEY (idCategoria) REFERENCES CATEGORIAS(Id)
);

insert into MARCAS (Descripcion) 
values	('Apple'),
		('Samsung'),
		('Sony'),
		('Dell'),
		('HP'),
		('Microsoft'),
		('Lenovo');
go

insert into CATEGORIAS (Descripcion) 
values	('Celulares'), 
		('Notebooks'),
		('Tablets'),
		('Consolas'),
		('Accesorios'),
		('Monitores'),
		('Smartwatches');
go

insert into PRODUCTOS (Codigo, Nombre, Descripcion, Precio, idMarca, idCategoria) 
values	('AP001', 'iPhone 13', 'Celular Apple con 128GB de almacenamiento', 999.99, 1, 1),
		('SS001', 'Samsung Galaxy S21', 'Celular Samsung con pantalla de 6.2 pulgadas', 849.99, 2, 1),
		('SN001', 'Sony PlayStation 5', 'Consola de videojuegos de última generación', 499.99, 3, 4),
		('DL001', 'Dell XPS 13', 'Notebook ultradelgada con pantalla de 13.3 pulgadas', 1299.99, 4, 2),
		('HP001', 'HP Spectre x360', 'Notebook convertible de 13 pulgadas', 1149.99, 5, 2),
		('MI001', 'Microsoft Surface Pro 7', 'Tablet con teclado removible y pantalla táctil', 899.99, 6, 3),
		('LN001', 'Lenovo ThinkPad X1', 'Notebook empresarial con pantalla de 14 pulgadas', 1399.99, 7, 2),
		('AP002', 'Apple Watch Series 7', 'Smartwatch Apple con GPS y monitor de salud', 399.99, 1, 7);
go

create table USUARIOS (
    Id int identity(1,1) not null primary key,
    Nombre varchar(50) not null,
    Apellido varchar(50) not null,
    Email varchar(100) not null unique,
    Contraseña varchar(50) not null,
	Direccion varchar(50) not null,
    FechaRegistro datetime not null default getdate()
);

insert into USUARIOS (Nombre, Apellido, Email, Contraseña, Direccion)
values
    ('Juan', 'Pérez', 'juan.perez@example.com', 'password123', 'arrollo 123'),
    ('María', 'González', 'maria.gonzalez@example.com', 'securepass', 'paseo 15'),
    ('Carlos', 'López', 'carlos.lopez@example.com', 'lopez2024', 'calle sin nombre 321'),
    ('Ana', 'Martínez', 'ana.martinez@example.com', 'ana2024', 'departamento 23');
go

create table PEDIDOS (
    Id int identity(1,1) not null primary key,
    IdUsuario int not null,
    Fecha datetime not null default getdate(),
    Total money not null,
    Estado varchar(50) not null,
    foreign key (IdUsuario) references USUARIOS(Id)
);

create table DETALLES_PEDIDO (
    Id int identity(1,1) not null primary key,
    IdPedido int not null,
    IdProducto int not null,
    Cantidad int not null,
    PrecioUnitario money not null,
    Subtotal money not null,
    foreign key (IdPedido) references PEDIDOS(Id),
    foreign key (IdProducto) references PRODUCTOS(Id)
);

insert into PEDIDOS (IdUsuario, Fecha, Total, Estado)
values
    (1, getdate(), 1849.98, 'Procesando'),
    (2, getdate(), 399.99, 'Enviado'),
    (3, getdate(), 1149.99, 'Entregado'),
    (4, getdate(), 2299.98, 'Procesando');

insert into DETALLES_PEDIDO (IdPedido, IdProducto, Cantidad, PrecioUnitario, Subtotal)
values
    (1, 1, 1, 999.99, 999.99), -- Pedido 1, Producto: iPhone 13
    (1, 2, 1, 849.99, 849.99), -- Pedido 1, Producto: Samsung Galaxy S21
    (2, 8, 1, 399.99, 399.99), -- Pedido 2, Producto: Apple Watch Series 7
    (3, 5, 1, 1149.99, 1149.99), -- Pedido 3, Producto: HP Spectre x360
    (4, 4, 1, 1299.99, 1299.99), -- Pedido 4, Producto: Dell XPS 13
    (4, 7, 1, 999.99, 999.99); -- Pedido 4, Producto: Lenovo ThinkPad X1
*/

