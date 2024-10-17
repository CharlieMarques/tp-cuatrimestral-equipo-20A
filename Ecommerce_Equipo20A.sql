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
	FOREIGN KEY (idMarca) REFERENCES MARCAS(Id),
	FOREIGN KEY (idCategoria) REFERENCES CATEGORIAS(Id)
);


INSERT INTO MARCAS (Descripcion) VALUES ('Apple');
INSERT INTO MARCAS (Descripcion) VALUES ('Samsung');
INSERT INTO MARCAS (Descripcion) VALUES ('Sony');
INSERT INTO MARCAS (Descripcion) VALUES ('Dell');
INSERT INTO MARCAS (Descripcion) VALUES ('HP');
INSERT INTO MARCAS (Descripcion) VALUES ('Microsoft');
INSERT INTO MARCAS (Descripcion) VALUES ('Lenovo');
GO

INSERT INTO CATEGORIAS (Descripcion) VALUES ('Celulares');
INSERT INTO CATEGORIAS (Descripcion) VALUES ('Notebooks');
INSERT INTO CATEGORIAS (Descripcion) VALUES ('Tablets');
INSERT INTO CATEGORIAS (Descripcion) VALUES ('Consolas');
INSERT INTO CATEGORIAS (Descripcion) VALUES ('Accesorios');
INSERT INTO CATEGORIAS (Descripcion) VALUES ('Monitores');
INSERT INTO CATEGORIAS (Descripcion) VALUES ('Smartwatches');
GO

INSERT INTO PRODUCTOS (Codigo, Nombre, Descripcion, Precio, idMarca, idCategoria) 
VALUES ('AP001', 'iPhone 13', 'Celular Apple con 128GB de almacenamiento', 999.99, 1, 1);

INSERT INTO PRODUCTOS (Codigo, Nombre, Descripcion, Precio, idMarca, idCategoria) 
VALUES ('SS001', 'Samsung Galaxy S21', 'Celular Samsung con pantalla de 6.2 pulgadas', 849.99, 2, 1);

INSERT INTO PRODUCTOS (Codigo, Nombre, Descripcion, Precio, idMarca, idCategoria) 
VALUES ('SN001', 'Sony PlayStation 5', 'Consola de videojuegos de última generación', 499.99, 3, 4);

INSERT INTO PRODUCTOS (Codigo, Nombre, Descripcion, Precio, idMarca, idCategoria) 
VALUES ('DL001', 'Dell XPS 13', 'Notebook ultradelgada con pantalla de 13.3 pulgadas', 1299.99, 4, 2);

INSERT INTO PRODUCTOS (Codigo, Nombre, Descripcion, Precio, idMarca, idCategoria) 
VALUES ('HP001', 'HP Spectre x360', 'Notebook convertible de 13 pulgadas', 1149.99, 5, 2);

INSERT INTO PRODUCTOS (Codigo, Nombre, Descripcion, Precio, idMarca, idCategoria) 
VALUES ('MI001', 'Microsoft Surface Pro 7', 'Tablet con teclado removible y pantalla táctil', 899.99, 6, 3);

INSERT INTO PRODUCTOS (Codigo, Nombre, Descripcion, Precio, idMarca, idCategoria) 
VALUES ('LN001', 'Lenovo ThinkPad X1', 'Notebook empresarial con pantalla de 14 pulgadas', 1399.99, 7, 2);

INSERT INTO PRODUCTOS (Codigo, Nombre, Descripcion, Precio, idMarca, idCategoria) 
VALUES ('AP002', 'Apple Watch Series 7', 'Smartwatch Apple con GPS y monitor de salud', 399.99, 1, 7);
GO


