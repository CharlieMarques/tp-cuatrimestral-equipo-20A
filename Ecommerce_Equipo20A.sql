use master
create Database Ecommerce_Equipo20A
go

use Ecommerce_Equipo20A
go

create table MARCAS(
	Id int identity (1,1) not null primary key,
	Descripcion varchar (50) not null,
);
go

create table CATEGORIAS(
	Id int identity(1,1) not null primary key,
	Descripcion varchar (50) not null
);
go

create table PRODUCTOS(
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
go

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
go

Create table Cuentas(
id int identity(1,1) not null primary key,
UserName varchar(50) not null unique,
Email varchar(50) not null unique,
Contraseña varchar(20),
nivelAcceso int null 
);
go

Create table Clientes(
id int identity(1,1) not null primary key,
Nombre varchar(50) not null,
Apellido varchar(50) not null ,
nroDocumento int not null,
nroTelefono varchar(50),
idCuenta int not null foreign key(idCuenta) References Cuentas(id),
);
go

Create table Direcciones(
id int identity(1,1) not null primary key,
Provincia varchar(50) not null,
Localidad varchar(50) not null,
Calle varchar(50) not null,
Altura int not null,
CodigoPostal int not null,
Referencias varchar(300) null,
idCuenta int not null foreign key(idCuenta) References Cuentas(id),
idCliente int not null foreign key(idCliente) References Clientes(id)
);
go

insert into USUARIOS (Nombre, Apellido, Email, Contraseña, Direccion)
values
    ('Juan', 'Pérez', 'juan.perez@example.com', 'password123', 'arrollo 123'),
    ('María', 'González', 'maria.gonzalez@example.com', 'securepass', 'paseo 15'),
    ('Carlos', 'López', 'carlos.lopez@example.com', 'lopez2024', 'calle sin nombre 321'),
    ('Ana', 'Martínez', 'ana.martinez@example.com', 'ana2024', 'departamento 23');

insert into Cuentas(UserName,Email,Contraseña,nivelAcceso)
values
( 'Administrador', 'Admin@admin.com','admin',3),
('Moderador', 'mod@mod.com', 'moderador',2),
('Usuario','User@usuario.com', 'usuario',1)
go
insert into Clientes(Nombre,Apellido,nroDocumento,nroTelefono,idCuenta)
values
('Admin','Istrador',17180190,1122334455,1),
('Mode','Rador',18160150,1177889944,2),
('Usu','Ario',19140130,1155664477,1);
go
select * from clientes
delete from Clientes where id =15
/*create table PEDIDOS (
    Id int identity(1,1) not null primary key,
    IdCuenta int not null,
    Fecha datetime not null default getdate(),
    Total money not null,
    Estado varchar(50) not null,
    foreign key (IdCuenta) references Cuentas(Id)
);
go

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
go

insert into PEDIDOS (IdCuenta, Fecha, Total, Estado)
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
go*/

create table IMAGENES(
	Id int identity(1,1) not null primary key,
	IdProducto int not null,
	UrlImagen varchar(300) not null,
	foreign key (IdProducto) references PRODUCTOS(Id)
);
go

insert into IMAGENES
values	(1, 'https://imagedelivery.net/4fYuQyy-r8_rpBpcY7lH_A/falabellaCL/15643401_1/w=800,h=800,fit=pad'),
		(1, 'https://www.apple.com/newsroom/images/product/iphone/geo/Apple_iphone13_colors_geo_09142021_big.jpg.large.jpg'),
		(2, 'https://imagedelivery.net/4fYuQyy-r8_rpBpcY7lH_A/falabellaCL/124697493_01/w=800,h=800,fit=pad'),
		(2, 'https://images.samsung.com/cl/smartphones/galaxy-s21/buy/s21_family_kv_mo_img.jpg'),
		(2, 'https://i.blogs.es/39f1a3/samsung-galaxy-s21-y-s21-plus-5/1366_2000.jpgd'),
		(2, 'https://i.blogs.es/a29d67/captura-de-pantalla-2021-01-14-a-las-13.38.14/650_1200.webp'),
		(3, 'https://clsonyb2c.vtexassets.com/arquivos/ps5.png'),
		(3, 'https://imagedelivery.net/4fYuQyy-r8_rpBpcY7lH_A/falabellaCL/126614736_01/w=800,h=800,fit=pad'),
		(3, 'https://www.gsmpro.cl/cdn/shop/files/playstation-5-3_1024x.png?v=1698339844'),
		(4, 'https://images-cdn.ubuy.ae/635f8ad9afed8b54834faff3-dell-xps-13-plus-9320-13-4.jpg'),
		(4, 'https://media.spdigital.cl/thumbnails/products/8t1_y7c6_81d44706_thumbnail_512.jpg'),
		(4, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTEz7meIIVYGjtw9u6UgKDXrb_PhqkLL1AnqA&s'),
		(5, 'https://imagedelivery.net/4fYuQyy-r8_rpBpcY7lH_A/falabellaCL/17031107_6/w=800,h=800,fit=pad'),
		(5, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRko4op_WNvgLjlHzu9OFHf5744sWFeSJNW_Q&s'),
		(5, 'https://img-cdn.tnwcdn.com/image?fit=1200%2C675&height=675&url=https%3A%2F%2Fcdn0.tnwcdn.com%2Fwp-content%2Fblogs.dir%2F1%2Ffiles%2F2021%2F08%2FHP-Spectre-x360-14-1-of-7.jpg&signature=be2373b43e1088c3457ffd4f53fd987a'),
		(6, 'https://res.cloudinary.com/djx6viedj/image/upload/t_trimmed_square_512/nwfag0abeajb6x2bliq12wmhnz3v?_a=BACCd2Ev'),
		(6, 'https://sidemarket02.akamaized.net/1098-home_default/microsoft-surface-pro-6-8gb-ram-256-gb-ssd.jpg'),
		(7, 'https://www.ultrapc.cl/wp-content/uploads/2024/06/2304X3234700802028129.jpg'),
		(7, 'https://cdnx.jumpseller.com/notebook-store/image/43498618/resize/540/540?1702411144'),
		(7, 'https://p1-ofp.static.pub/medias/bWFzdGVyfHJvb3R8MjQ3Njh8aW1hZ2UvanBlZ3xoMzMvaGQxLzEwNjc0NTg2MzUzNjk0LmpwZ3w4MGUyZGY0Y2FiZGMzYmMzN2IxZDAxNTVkOTJkN2E1OTkwNjg1NmVlOTU3MzQ0ZDc5MWUxZTg3NWM4ZTU3MmI4/lenovo-laptop-thinkpad-x1-carbon-gen8-subseries-gallery-2.jpg'),
		(8, 'https://imagedelivery.net/4fYuQyy-r8_rpBpcY7lH_A/falabellaCL/135776764_01/w=1500,h=1500,fit=pad');
go

CREATE TABLE Tarjetas (
    NumeroTarjeta CHAR(16) NOT NULL PRIMARY KEY, 
    Saldo DECIMAL(10, 2) NOT NULL,              
    FechaVencimiento VARCHAR(7) NOT NULL,       
    CodigoSeguridad CHAR(3) NOT NULL            
);
go
insert into Tarjetas (NumeroTarjeta,Saldo,FechaVencimiento,CodigoSeguridad) 
values
('1111222233334444',700,'11/2025','007'),
('2222444466668888',400,'12/2024','001'),
('3333666655554444',15000,'07/2027','789')

go

CREATE TABLE Estados (
    id INT PRIMARY KEY identity(1,1),                  
    Descripcion VARCHAR(50) NOT NULL UNIQUE
);
go
INSERT INTO Estados (Descripcion)
VALUES 
('En preparación'),
('Listo para retirar'),
('Despachado'),
('En camino'),
('Entregado/Retirado');
go
create table Compras (
 NumeroCompra int Primary key identity(1,1),
 idCliente int not null foreign key references Clientes(id),
 idCuenta int not null foreign key references Cuentas(id),
 idDireccion int not null foreign key references Direcciones(id),
 idEstado int not null foreign key references Estados(id),
 FechaCompra datetime not null default getdate(),
 FechaEntrega datetime null
);
go
create table CompraProductos(
	numeroCompra int not null foreign key references Compras(NumeroCompra),
	idProducto int not null foreign key references Productos(id),
	Cantidad int not null check(Cantidad > 0),
	primary key (numeroCompra, idProducto)
);
go

/*
drop procedure NuevoUsuario
drop procedure NuevoCliente
drop procedure Log_In
drop procedure ListaDeProductos
drop procedure ListaPorCategoria
*/

use Ecommerce_Equipo20A
go
CREATE procedure NuevoUsuario
@nombreUsuario varchar(50),
@email varchar(50),
@contraseña varchar(20)
as
begin
insert into Cuentas (UserName,Email,Contraseña,nivelAcceso) output inserted.id values (@nombreUsuario,@email,@contraseña,0)
end

go
create procedure Log_In
@nombreUsuario varchar(50),
@contraseña varchar(20)
as
begin
select id,UserName,Email,Contraseña,nivelAcceso from Cuentas where UserName = @nombreUsuario and Contraseña = @contraseña
end

go
create procedure NuevoCliente
@nombre varchar(50),
@apellido varchar(50),
@dni int,
@telefono varchar(50),
@idCuenta int
as
begin 
insert into Clientes(Nombre,Apellido,nroDocumento,nroTelefono,idCuenta) values (@nombre,@apellido,@dni,@telefono,@idCuenta);SELECT SCOPE_IDENTITY()
end

go
create procedure ListaDeProductos
as
begin
Select P.id, P.Codigo,P.Nombre, P.Descripcion, P.Precio, P.idMarca, P.idCategoria,M.Descripcion as Marca,C.Descripcion as Categoria
From PRODUCTOS P 
inner join MARCAS M on M.Id = P.idMarca
inner join CATEGORIAS C on C.Id = p.idCategoria
end

go
create procedure ListaPorCategoria
@idCategoria int
as
begin
Select P.id, P.Codigo,P.Nombre, P.Descripcion, P.Precio, P.idMarca, P.idCategoria,M.Descripcion as Marca,C.Descripcion as Categoria
From PRODUCTOS P 
inner join MARCAS M on M.Id = P.idMarca
inner join CATEGORIAS C on C.Id = p.idCategoria
where P.idCategoria = @idCategoria
end

/*
EXEC Log_In @nombreUsuario="Administrador", @contraseña="admin";

select CL.id, CL.Nombre, CL.Apellido, CL.nroDocumento, CL.nroTelefono, CL.idCuenta from clientes CL 
inner join Cuentas CU on CU.id = CL.idCuenta where CU.id = 1
*/