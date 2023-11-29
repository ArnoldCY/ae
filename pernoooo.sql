create database pernova
go
use pernova
go

CREATE TABLE Categoria (
    idCategoria int PRIMARY KEY identity(1,1),
    Nombre varchar(30) NOT NULL,
    Descripcion varchar(50),
);
go

CREATE TABLE Cargo (
    idCargo int PRIMARY KEY identity(1,1),
    Nombre varchar(30) NOT NULL,
    Descripcion varchar(50),
);
go

CREATE TABLE Empleado (
    CI int PRIMARY KEY NOT NULL,
    Usuario varchar(30) NOT NULL,
    Contraseña varchar(20) NOT NULL,
    Nombre varchar(30) NOT NULL,
    ApPaterno varchar(30) NOT NULL,
    ApMaterno varchar(30) NOT NULL,
    CargoID int,
    Telefono varchar(30) NOT NULL,
    Correo varchar(30),
    Direccion varchar(50),
    FOREIGN KEY (CargoID) REFERENCES Cargo(idCargo)
);
go

CREATE TABLE Articulo (
    idArticulo varchar(30) PRIMARY KEY NOT NULL,
    Nombre varchar(30) NOT NULL,
    Descripcion varchar(50),
    Precio float NOT NULL,
    Stock int NOT NULL,
    idCategoria int NOT NULL,
    FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria)
);
go


CREATE TABLE Entrada (
    idEntrada int PRIMARY KEY identity(1,1),
    fecha DATE NOT NULL,
    total DECIMAL NOT NULL,
    CI_Empleado int NOT NULL,
    FOREIGN KEY (CI_Empleado) REFERENCES Empleado(CI)
);
go

CREATE TABLE DetalleEntrada (
    idEntrada int NOT NULL,
    idArticulo varchar(30) NOT NULL,
    cantidad INT NOT NULL,
    precio_unitario float NOT NULL,
	primary key (idEntrada, idArticulo),
    FOREIGN KEY (idEntrada) REFERENCES Entrada(idEntrada),
    FOREIGN KEY (idArticulo) REFERENCES Articulo(idArticulo)
);
go

CREATE TABLE Salida (
    idSalida int PRIMARY KEY identity(1,1),
    fecha DATE NOT NULL,
    total DECIMAL NOT NULL,
    CI_Empleado int NOT NULL,
    FOREIGN KEY (CI_Empleado) REFERENCES Empleado(CI),
);
go

CREATE TABLE DetalleSalida (
    idSalida int NOT NULL,
    idArticulo varchar(30) NOT NULL,
    cantidad INT NOT NULL,
    precio_unitario float NOT NULL,
	primary key (idSalida, idArticulo),
    FOREIGN KEY (idSalida) REFERENCES Salida(idSalida),
    FOREIGN KEY (idArticulo) REFERENCES Articulo(idArticulo)
);
go

-- Inserción de datos en la tabla Cargo
INSERT INTO Cargo (Nombre, Descripcion)
VALUES 
    ('Gerente', 'Responsable de la gestión general'),
    ('Vendedor', 'Encargado de ventas y atención al cliente');

-- Inserción de datos en la tabla Empleado
INSERT INTO Empleado (CI, Usuario, Contraseña, Nombre, ApPaterno, ApMaterno, CargoID, Telefono, Correo, Direccion)
VALUES 
    (1, 'usuario1', 'clave1', 'Juan', 'Perez', 'Lopez', 1, '123456789', 'juan@email.com', 'Calle 123'),
    (2, 'usuario2', 'clave2', 'Ana', 'Gomez', 'Martinez', 2, '987654321', 'ana@email.com', 'Avenida 456');

-- Inserción de datos en la tabla Categoria
INSERT INTO Categoria (Nombre, Descripcion)
VALUES 
    ('Pernos de Acero', 'Pernos de acero inoxidable'),
    ('Pernos de Cobre', 'Pernos de cobre s');

-- Inserción de datos en la tabla Articulo
INSERT INTO Articulo (idArticulo, Nombre, Descripcion, Precio, Stock, idCategoria)
VALUES 
    ('art1', 'Perno A', 'Descripción del perno A', 2.99, 100, 1),
    ('art2', 'Perno B', 'Descripción del perno B', 3.99, 150, 2);

-- Inserción de datos en la tabla Entrada
INSERT INTO Entrada (fecha, total, CI_Empleado)
VALUES 
    ('2023-11-25', 200.00, 1),
    ('2023-11-26', 150.00, 2);

-- Inserción de datos en la tabla DetalleEntrada
INSERT INTO DetalleEntrada (idEntrada, idArticulo, cantidad, precio_unitario)
VALUES 
    (1, 'art1', 50, 2.99),
    (2, 'art2', 30, 3.99);

-- Inserción de datos en la tabla Salida
INSERT INTO Salida (fecha, total, CI_Empleado)
VALUES 
    ('2023-11-27', 100.00, 1),
    ('2023-11-28', 120.00, 2);

-- Inserción de datos en la tabla DetalleSalida
INSERT INTO DetalleSalida (idSalida, idArticulo, cantidad, precio_unitario)
VALUES 
    (1, 'art1', 20, 2.99),
    (2, 'art2', 15, 3.99);
go

CREATE PROCEDURE InsertarCargo
@Nombre varchar(30),
@Descripcion varchar(50)
AS
BEGIN
	INSERT INTO Cargo values (@Nombre, @Descripcion)
END
go

CREATE PROCEDURE MostrarCargo
AS
BEGIN
	SELECT *
	FROM Cargo
END
go

-- Actualizar Cargo
CREATE PROCEDURE ActualizarCargo
    @idCargo int,
    @Nombre varchar(30),
    @Descripcion varchar(50)
AS
BEGIN
    UPDATE Cargo SET Nombre = @Nombre, Descripcion = @Descripcion WHERE idCargo = @idCargo;
END;
GO
-- Eliminar Cargo
CREATE PROCEDURE EliminarCargo
    @idCargo int
AS
BEGIN
    DELETE FROM Cargo WHERE idCargo = @idCargo;
END;

CREATE PROCEDURE InsertarEmpleado
@CI int,
@Usuario varchar(30),
@Contraseña varchar(20),
@Nombre varchar(30),
@ApPaterno varchar(30),
@ApMaterno varchar(30),
@CargoID int,
@Telefono varchar(30),
@Correo varchar(30),
@Direccion varchar(50)
AS
BEGIN
	INSERT INTO Empleado values (@CI, @Usuario, @Contraseña, @Nombre, @ApPaterno, @ApMaterno, @CargoID, @Telefono, @Correo, @Direccion)
END
go

CREATE PROCEDURE MostrarEmpleado
AS
BEGIN
	SELECT *
	FROM Empleado
END
go

-- Actualizar Empleado
CREATE PROCEDURE ActualizarEmpleado
    @CI int,
    @Usuario varchar(30),
    @Contraseña varchar(20),
    @Nombre varchar(30),
    @ApPaterno varchar(30),
    @ApMaterno varchar(30),
    @CargoID int,
    @Telefono varchar(30),
    @Correo varchar(30),
    @Direccion varchar(50)
AS
BEGIN
    UPDATE Empleado SET Usuario = @Usuario, Contraseña = @Contraseña, Nombre = @Nombre, ApPaterno = @ApPaterno, ApMaterno = @ApMaterno, CargoID = @CargoID, Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion WHERE CI = @CI;
END;

-- Eliminar Empleado
CREATE PROCEDURE EliminarEmpleado
    @CI int
AS
BEGIN
    DELETE FROM Empleado WHERE CI = @CI;
END;


CREATE PROCEDURE InsertarArticulo
@idArticulo varchar(30),
@Nombre varchar(30),
@Descripcion varchar(50),
@Precio float,
@Stock int,
@idCategoria int
AS
BEGIN
	INSERT INTO Articulo values (@idArticulo, @Nombre, @Descripcion, @Precio, @Stock, @idCategoria)
END
go

CREATE PROCEDURE MostrarArticulo
AS
BEGIN
	SELECT *
	FROM Articulo
END
go

-- Actualizar Articulo
CREATE PROCEDURE ActualizarArticulo
    @idArticulo varchar(30),
    @Nombre varchar(30),
    @Descripcion varchar(50),
    @Precio float,
    @Stock int,
    @idCategoria int
AS
BEGIN
    UPDATE Articulo SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, Stock = @Stock, idCategoria = @idCategoria WHERE idArticulo = @idArticulo;
END;

-- Eliminar Articulo
CREATE PROCEDURE EliminarArticulo
    @idArticulo varchar(30)
AS
BEGIN
    DELETE FROM Articulo WHERE idArticulo = @idArticulo;
END;

CREATE PROCEDURE InsertarCategoria
@Nombre varchar(30),
@Descripcion varchar(50)
AS
BEGIN
	INSERT INTO Categoria values (@Nombre, @Descripcion)
END
go

CREATE PROCEDURE MostrarCategoria
AS
BEGIN
	SELECT *
	FROM Categoria
END
go

-- Actualizar Categoria
CREATE PROCEDURE ActualizarCategoria
    @idCategoria int,
    @Nombre varchar(30),
    @Descripcion varchar(50)
AS
BEGIN
    UPDATE Categoria SET Nombre = @Nombre, Descripcion = @Descripcion WHERE idCategoria = @idCategoria;
END;

-- Eliminar Categoria
CREATE PROCEDURE EliminarCategoria
    @idCategoria int
AS
BEGIN
    DELETE FROM Categoria WHERE idCategoria = @idCategoria;
END;

CREATE TYPE DetalleEntradaType AS TABLE (
    idArticulo VARCHAR(30),
    Cantidad INT,
    Precio_Unitario FLOAT
);

CREATE PROCEDURE RegistrarEntrada
    @Fecha DATE,
    @Total DECIMAL,
    @CI_Empleado INT,
    @DetallesEntrada DetalleEntradaType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar en la tabla Entrada
    INSERT INTO Entrada (fecha, total, CI_Empleado)
    VALUES (@Fecha, @Total, @CI_Empleado);

    -- Obtener el ID de la entrada recién insertada
    DECLARE @idEntrada INT;
    SET @idEntrada = SCOPE_IDENTITY();

    -- Insertar en la tabla DetalleEntrada
    INSERT INTO DetalleEntrada (idEntrada, idArticulo, cantidad, precio_unitario)
    SELECT @idEntrada, idArticulo, Cantidad, Precio_Unitario
    FROM @DetallesEntrada;

    -- Actualizar el stock en la tabla Articulo
    UPDATE A
    SET Stock = Stock + DE.Cantidad
    FROM Articulo A
    INNER JOIN @DetallesEntrada DE ON A.idArticulo = DE.idArticulo;
END
GO

DECLARE @DetallesEntrada AS DetalleEntradaType;

-- Agregar datos a @DetallesEntrada
INSERT INTO @DetallesEntrada (idArticulo, Cantidad, Precio_Unitario) VALUES ('art1', 10, 2.99);
INSERT INTO @DetallesEntrada (idArticulo, Cantidad, Precio_Unitario) VALUES ('art2', 5, 3.99);

-- Llamar al procedimiento almacenado
EXEC RegistrarEntrada '2023-11-25', 200.00, 1, @DetallesEntrada;



CREATE TYPE DetalleSalidaType AS TABLE (
    idArticulo VARCHAR(30),
    Cantidad INT,
    Precio_Unitario FLOAT
);

CREATE PROCEDURE RegistrarSalida
    @Fecha DATE,
    @CI_Empleado INT,
    @Total DECIMAL, -- Agregar este parámetro para el total
    @DetallesSalida DetalleSalidaType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar en la tabla Salida
    INSERT INTO Salida (Fecha, CI_Empleado, Total)
    VALUES (@Fecha, @CI_Empleado, @Total);

    -- Obtener el ID de la salida recién insertada
    DECLARE @idSalida INT;
    SET @idSalida = SCOPE_IDENTITY();

    -- Verificar que @idSalida no es nulo
    IF @idSalida IS NULL
    BEGIN
        RAISERROR ('Error al obtener el ID de la salida.', 16, 1);
        RETURN;
    END

    -- Insertar en la tabla DetalleSalida
    INSERT INTO DetalleSalida (idSalida, idArticulo, cantidad, precio_unitario)
    SELECT @idSalida, idArticulo, Cantidad, Precio_Unitario
    FROM @DetallesSalida;

    -- Actualizar el stock en la tabla Articulo
    UPDATE A
    SET Stock = Stock - DS.Cantidad
    FROM Articulo A
    INNER JOIN @DetallesSalida DS ON A.idArticulo = DS.idArticulo;
END
GO

DECLARE @DetallesSalida AS DetalleSalidaType;

-- Agregar datos a @DetallesSalida
INSERT INTO @DetallesSalida (idArticulo, Cantidad, Precio_Unitario) VALUES ('art1', 5, 10.0);
INSERT INTO @DetallesSalida (idArticulo, Cantidad, Precio_Unitario) VALUES ('art2', 3, 15.0);

-- Llamar al procedimiento almacenado
EXEC RegistrarSalida '2023-11-25', 1, 100.00, @DetallesSalida; -- Asegúrate de incluir un valor para el total