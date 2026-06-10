

USE master;
GO


IF EXISTS (SELECT name FROM sys.server_principals WHERE name = 'usrgimnasio')
    DROP LOGIN usrgimnasio;
GO


IF EXISTS (SELECT name FROM sys.databases WHERE name = N'Gimnasio')
BEGIN
    ALTER DATABASE Gimnasio SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Gimnasio;
END
GO


CREATE LOGIN usrgimnasio WITH PASSWORD = '123456', 
    DEFAULT_DATABASE = master, 
    CHECK_EXPIRATION = OFF, 
    CHECK_POLICY = OFF;
GO


CREATE DATABASE Gimnasio;
GO

USE Gimnasio;
GO


CREATE USER usrgimnasio FOR LOGIN usrgimnasio;
EXEC sp_addrolemember 'db_owner', 'usrgimnasio';
GO


CREATE TABLE Membresia (
    id INT PRIMARY KEY IDENTITY(1,1),
    tipo VARCHAR(50) NOT NULL,           
    precio DECIMAL(10,2) NOT NULL,       
    duracion_dias INT NOT NULL,
    activo BIT NOT NULL DEFAULT 1        
);


CREATE TABLE Servicio (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL,         
    descripcion VARCHAR(255) NULL,
    capacidad_maxima INT NOT NULL,
    activo BIT NOT NULL DEFAULT 1
);

-- Personal del gimnasio
CREATE TABLE Entrenador (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    telefono VARCHAR(20) NULL,
    especialidad VARCHAR(50) NULL,
    activo BIT NOT NULL DEFAULT 1
);


CREATE TABLE UsuarioSistema (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre_usuario VARCHAR(50) NOT NULL UNIQUE,
    contraseña VARCHAR(255) NOT NULL,
    salt VARCHAR(128) NOT NULL,
    rol VARCHAR(20) NOT NULL DEFAULT 'Recepcionista',
    activo BIT NOT NULL DEFAULT 1
);


CREATE TABLE Cliente (
    id INT PRIMARY KEY IDENTITY(1,1),
    ci VARCHAR(20) NOT NULL UNIQUE,      
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    telefono VARCHAR(20) NULL,
    correo VARCHAR(100) NULL,
    fecha_registro DATETIME NOT NULL DEFAULT GETDATE(),
    activo BIT NOT NULL DEFAULT 1
);


CREATE TABLE Inscripcion (
    id INT PRIMARY KEY IDENTITY(1,1),
    id_cliente INT NOT NULL,
    id_membresia INT NOT NULL,
    fecha_inicio DATE NOT NULL,
    fecha_fin DATE NOT NULL,
    monto_pagado DECIMAL(10,2) NOT NULL,
    metodo_pago VARCHAR(50) NOT NULL,    
    fecha_transaccion DATETIME NOT NULL DEFAULT GETDATE(),
    estado VARCHAR(20) NOT NULL DEFAULT 'Activa', 
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id),
    FOREIGN KEY (id_membresia) REFERENCES Membresia(id)
);


CREATE TABLE RegistroAcceso (
    id INT PRIMARY KEY IDENTITY(1,1),
    id_cliente INT NOT NULL,
    fecha_hora DATETIME NOT NULL DEFAULT GETDATE(),
    tipo VARCHAR(10) NOT NULL DEFAULT 'Entrada', 
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id)
);


CREATE TABLE HorarioClase (
    id INT PRIMARY KEY IDENTITY(1,1),
    id_servicio INT NOT NULL,
    id_entrenador INT NOT NULL,
    dia_semana VARCHAR(20) NOT NULL,     
    hora_inicio TIME NOT NULL,
    hora_fin TIME NOT NULL,
    cupos_reservados INT NOT NULL DEFAULT 0,
    activo BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (id_servicio) REFERENCES Servicio(id),
    FOREIGN KEY (id_entrenador) REFERENCES Entrenador(id)
);


CREATE TABLE Reserva (
    id INT PRIMARY KEY IDENTITY(1,1),
    id_cliente INT NOT NULL,
    id_horarioclase INT NOT NULL,
    fecha_reserva DATE NOT NULL,         
    asistio BIT NOT NULL DEFAULT 0,      
    estado VARCHAR(20) NOT NULL DEFAULT 'Confirmada',
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id),
    FOREIGN KEY (id_horarioclase) REFERENCES HorarioClase(id)
);


DECLARE @salt VARCHAR(128) = 'SaltSeguro2026';
DECLARE @pass VARCHAR(255) = CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', '123456' + @salt), 2);

INSERT INTO UsuarioSistema (nombre_usuario, contraseña, salt, rol) 
VALUES ('admin', @pass, @salt, 'Admin');


INSERT INTO Membresia (tipo, precio, duracion_dias) VALUES 
('Mensual Regular', 150.00, 30),
('Trimestral VIP', 400.00, 90),
('Anual Premium', 1200.00, 365);


INSERT INTO Servicio (nombre, descripcion, capacidad_maxima) VALUES 
('Musculación', 'Acceso a la sala de pesas y máquinas', 50), 
('Spinning', 'Clase guiada de bicicleta estática', 15),
('Zumba', 'Baile coreográfico aeróbico', 25);


INSERT INTO Entrenador (nombre, apellido, telefono, especialidad) VALUES 
('Carlos', 'López', '77712345', 'Musculación'),
('María', 'Fernández', '77798765', 'Cardio y Zumba');


PRINT '=========================================================';
PRINT 'Base de datos Gimnasio creada exitosamente.';
PRINT 'Credenciales SQL Server: usrgimnasio / 123456';
PRINT 'Credenciales App (Login WinForms): admin / 123456';
PRINT '=========================================================';
GO



USE Gimnasio;
GO


DECLARE @salt VARCHAR(128) = 'SaltSeguro2026';
DECLARE @passRecepcionista VARCHAR(255) = CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', '123456' + @salt), 2);

INSERT INTO UsuarioSistema (nombre_usuario, contraseña, salt, rol) 
VALUES ('recep', @passRecepcionista, @salt, 'Recepcionista');



INSERT INTO Entrenador (nombre, apellido, telefono, especialidad) VALUES
('Luis', 'García', '77765432', 'CrossFit'),
('Ana', 'Martínez', '77711223', 'Yoga y Pilates');



INSERT INTO Servicio (nombre, descripcion, capacidad_maxima) VALUES
('CrossFit', 'Entrenamiento funcional de alta intensidad', 20),
('Yoga', 'Relajación y flexibilidad', 15),
('Boxeo', 'Técnica y combate', 10);



INSERT INTO Membresia (tipo, precio, duracion_dias) VALUES
('Semanal', 50.00, 7);



INSERT INTO Cliente (ci, nombre, apellido, telefono, correo, fecha_registro) VALUES
('12345678', 'Juan', 'Pérez', '70011111', 'juan.perez@gmail.com', GETDATE()),
('23456789', 'María', 'Rodríguez', '70022222', 'maria.rodriguez@hotmail.com', GETDATE()),
('34567890', 'Pedro', 'González', '70033333', 'pedro.gonzalez@gmail.com', GETDATE()),
('45678901', 'Sofía', 'López', '70044444', 'sofia.lopez@yahoo.com', GETDATE()),
('56789012', 'Diego', 'Hernández', '70055555', 'diego.hernandez@gmail.com', GETDATE()),
('67890123', 'Valentina', 'Díaz', '70066666', 'valentina.diaz@outlook.com', GETDATE()),
('78901234', 'Carlos', 'Torres', '70077777', 'carlos.torres@gmail.com', GETDATE()),
('89012345', 'Lucía', 'Ramírez', '70088888', 'lucia.ramirez@hotmail.com', GETDATE()),
('90123456', 'Andrés', 'Flores', '70099999', 'andres.flores@gmail.com', GETDATE()),
('01234567', 'Camila', 'Vargas', '70000000', 'camila.vargas@yahoo.com', GETDATE());



INSERT INTO Inscripcion (id_cliente, id_membresia, fecha_inicio, fecha_fin, monto_pagado, metodo_pago, estado)
VALUES (1, 1, DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, 20, GETDATE()), 150.00, 'Efectivo', 'Activa');


INSERT INTO Inscripcion (id_cliente, id_membresia, fecha_inicio, fecha_fin, monto_pagado, metodo_pago, estado)
VALUES (2, 2, DATEADD(DAY, -5, GETDATE()), DATEADD(DAY, 85, GETDATE()), 400.00, 'Tarjeta', 'Activa');


INSERT INTO Inscripcion (id_cliente, id_membresia, fecha_inicio, fecha_fin, monto_pagado, metodo_pago, estado)
VALUES (3, 1, DATEADD(DAY, -35, GETDATE()), DATEADD(DAY, -1, GETDATE()), 150.00, 'QR', 'Vencida');


INSERT INTO Inscripcion (id_cliente, id_membresia, fecha_inicio, fecha_fin, monto_pagado, metodo_pago, estado)
VALUES (4, 3, DATEADD(DAY, -60, GETDATE()), DATEADD(DAY, 305, GETDATE()), 1200.00, 'Transferencia', 'Activa');


INSERT INTO Inscripcion (id_cliente, id_membresia, fecha_inicio, fecha_fin, monto_pagado, metodo_pago, estado)
VALUES (5, 4, DATEADD(DAY, -5, GETDATE()), DATEADD(DAY, 2, GETDATE()), 50.00, 'Efectivo', 'Activa');


INSERT INTO Inscripcion (id_cliente, id_membresia, fecha_inicio, fecha_fin, monto_pagado, metodo_pago, estado)
VALUES (6, 1, DATEADD(DAY, -35, GETDATE()), DATEADD(DAY, -5, GETDATE()), 150.00, 'Efectivo', 'Vencida');


INSERT INTO Inscripcion (id_cliente, id_membresia, fecha_inicio, fecha_fin, monto_pagado, metodo_pago, estado)
VALUES (7, 2, DATEADD(DAY, -20, GETDATE()), DATEADD(DAY, 70, GETDATE()), 400.00, 'Tarjeta', 'Activa');


INSERT INTO Inscripcion (id_cliente, id_membresia, fecha_inicio, fecha_fin, monto_pagado, metodo_pago, estado)
VALUES (8, 1, DATEADD(DAY, -2, GETDATE()), DATEADD(DAY, 28, GETDATE()), 150.00, 'QR', 'Activa');


INSERT INTO Inscripcion (id_cliente, id_membresia, fecha_inicio, fecha_fin, monto_pagado, metodo_pago, estado)
VALUES (9, 4, DATEADD(DAY, -8, GETDATE()), DATEADD(DAY, -1, GETDATE()), 50.00, 'Efectivo', 'Vencida');


INSERT INTO Inscripcion (id_cliente, id_membresia, fecha_inicio, fecha_fin, monto_pagado, metodo_pago, estado)
VALUES (10, 3, DATEADD(DAY, -100, GETDATE()), DATEADD(DAY, 265, GETDATE()), 1200.00, 'Transferencia', 'Activa');


INSERT INTO RegistroAcceso (id_cliente, fecha_hora, tipo) VALUES
(1, DATEADD(HOUR, -2, GETDATE()), 'Entrada'),  
(2, DATEADD(HOUR, -1, GETDATE()), 'Entrada'),
(4, DATEADD(MINUTE, -30, GETDATE()), 'Entrada'),
(5, DATEADD(MINUTE, -15, GETDATE()), 'Entrada'),
(7, DATEADD(HOUR, -3, GETDATE()), 'Entrada'),
(8, DATEADD(HOUR, -4, GETDATE()), 'Entrada'),
(10, DATEADD(MINUTE, -5, GETDATE()), 'Entrada');


INSERT INTO RegistroAcceso (id_cliente, fecha_hora, tipo) VALUES
(1, DATEADD(DAY, -1, GETDATE()), 'Entrada'),
(2, DATEADD(DAY, -1, GETDATE()), 'Entrada'),
(3, DATEADD(DAY, -1, GETDATE()), 'Entrada'),
(4, DATEADD(DAY, -1, GETDATE()), 'Entrada'),
(6, DATEADD(DAY, -1, GETDATE()), 'Entrada');


INSERT INTO RegistroAcceso (id_cliente, fecha_hora, tipo) VALUES
(2, DATEADD(DAY, -2, GETDATE()), 'Entrada'),
(3, DATEADD(DAY, -2, GETDATE()), 'Entrada'),
(5, DATEADD(DAY, -2, GETDATE()), 'Entrada'),
(7, DATEADD(DAY, -2, GETDATE()), 'Entrada');


INSERT INTO HorarioClase (id_servicio, id_entrenador, dia_semana, hora_inicio, hora_fin, cupos_reservados) VALUES
(1, 1, 'Lunes', '08:00', '09:00', 0),    
(4, 2, 'Lunes', '10:00', '11:00', 0),    
(2, 3, 'Lunes', '15:00', '16:00', 0);    


INSERT INTO HorarioClase (id_servicio, id_entrenador, dia_semana, hora_inicio, hora_fin, cupos_reservados) VALUES
(5, 4, 'Martes', '07:00', '08:00', 0),   
(1, 2, 'Martes', '09:00', '10:00', 0),   
(3, 3, 'Martes', '17:00', '18:00', 0);   


INSERT INTO HorarioClase (id_servicio, id_entrenador, dia_semana, hora_inicio, hora_fin, cupos_reservados) VALUES
(2, 3, 'Miércoles', '08:00', '09:00', 0),
(4, 2, 'Miércoles', '11:00', '12:00', 0),
(6, 1, 'Miércoles', '16:00', '17:00', 0); 


INSERT INTO HorarioClase (id_servicio, id_entrenador, dia_semana, hora_inicio, hora_fin, cupos_reservados) VALUES
(5, 4, 'Jueves', '07:00', '08:00', 0),
(1, 2, 'Jueves', '09:00', '10:00', 0),
(3, 3, 'Jueves', '18:00', '19:00', 0);


INSERT INTO HorarioClase (id_servicio, id_entrenador, dia_semana, hora_inicio, hora_fin, cupos_reservados) VALUES
(4, 2, 'Viernes', '10:00', '11:00', 0),
(2, 3, 'Viernes', '14:00', '15:00', 0),
(6, 1, 'Viernes', '17:00', '18:00', 0);


INSERT INTO HorarioClase (id_servicio, id_entrenador, dia_semana, hora_inicio, hora_fin, cupos_reservados) VALUES
(1, 1, 'Sábado', '09:00', '10:00', 0),
(3, 3, 'Sábado', '11:00', '12:00', 0);


INSERT INTO Reserva (id_cliente, id_horarioclase, fecha_reserva, asistio, estado)
VALUES (1, 1, CAST(GETDATE() AS DATE), 0, 'Confirmada');


INSERT INTO Reserva (id_cliente, id_horarioclase, fecha_reserva, asistio, estado)
VALUES (2, 1, CAST(GETDATE() AS DATE), 0, 'Confirmada');


UPDATE HorarioClase SET cupos_reservados = 2 WHERE id = 1;


INSERT INTO Reserva (id_cliente, id_horarioclase, fecha_reserva, asistio, estado)
VALUES (4, 4, CAST(GETDATE() AS DATE), 0, 'Confirmada');
UPDATE HorarioClase SET cupos_reservados = 1 WHERE id = 4;


INSERT INTO Reserva (id_cliente, id_horarioclase, fecha_reserva, asistio, estado)
VALUES (5, 5, CAST(GETDATE() AS DATE), 0, 'Confirmada');
UPDATE HorarioClase SET cupos_reservados = 1 WHERE id = 5;


INSERT INTO Reserva (id_cliente, id_horarioclase, fecha_reserva, asistio, estado)
VALUES (7, 2, DATEADD(DAY, 1, CAST(GETDATE() AS DATE)), 0, 'Confirmada'); 

INSERT INTO Reserva (id_cliente, id_horarioclase, fecha_reserva, asistio, estado)
VALUES (8, 2, DATEADD(DAY, 1, CAST(GETDATE() AS DATE)), 0, 'Confirmada');
UPDATE HorarioClase SET cupos_reservados = 2 WHERE id = 2;

PRINT '=========================================================';
PRINT 'Datos de prueba insertados correctamente.';
PRINT 'Usuarios: admin/123456, recep/123456';
PRINT 'Clientes de ejemplo con CI desde 12345678 hasta 01234567';
PRINT 'Planes activos y vencidos, reservas para hoy, etc.';
PRINT '=========================================================';
GO