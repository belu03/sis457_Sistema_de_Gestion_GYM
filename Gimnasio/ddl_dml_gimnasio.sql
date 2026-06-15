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

-- ==========================================
-- 1. CREACIÓN DE TABLAS 
-- ==========================================

CREATE TABLE Membresia (
    id INT PRIMARY KEY IDENTITY(1,1),
    tipo VARCHAR(50) NOT NULL,           
    precio DECIMAL(10,2) NOT NULL,       
    duracion_dias INT NOT NULL
);

CREATE TABLE Servicio (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL,         
    descripcion VARCHAR(255) NULL,
    capacidad_maxima INT NOT NULL
);

CREATE TABLE Entrenador (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    telefono VARCHAR(20) NULL,
    especialidad VARCHAR(50) NULL
);

CREATE TABLE UsuarioSistema (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre_usuario VARCHAR(50) NOT NULL UNIQUE,
    contraseña VARCHAR(255) NOT NULL,
    salt VARCHAR(128) NOT NULL,
    rol VARCHAR(20) NOT NULL DEFAULT 'Recepcionista'
);

CREATE TABLE Cliente (
    id INT PRIMARY KEY IDENTITY(1,1),
    ci VARCHAR(20) NOT NULL UNIQUE,      
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    telefono VARCHAR(20) NULL,
    correo VARCHAR(100) NULL
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
    estado_inscripcion VARCHAR(20) NOT NULL DEFAULT 'Activa', 
    CONSTRAINT fk_Inscripcion_Cliente FOREIGN KEY (id_cliente) REFERENCES Cliente(id),
    CONSTRAINT fk_Inscripcion_Membresia FOREIGN KEY (id_membresia) REFERENCES Membresia(id)
);

CREATE TABLE RegistroAcceso (
    id INT PRIMARY KEY IDENTITY(1,1),
    id_cliente INT NOT NULL,
    fecha_hora DATETIME NOT NULL DEFAULT GETDATE(),
    tipo VARCHAR(10) NOT NULL DEFAULT 'Entrada', 
    CONSTRAINT fk_RegistroAcceso_Cliente FOREIGN KEY (id_cliente) REFERENCES Cliente(id)
);

CREATE TABLE HorarioClase (
    id INT PRIMARY KEY IDENTITY(1,1),
    id_servicio INT NOT NULL,
    id_entrenador INT NOT NULL,
    dia_semana VARCHAR(20) NOT NULL,     
    hora_inicio TIME NOT NULL,
    hora_fin TIME NOT NULL,
    cupos_reservados INT NOT NULL DEFAULT 0,
    CONSTRAINT fk_HorarioClase_Servicio FOREIGN KEY (id_servicio) REFERENCES Servicio(id),
    CONSTRAINT fk_HorarioClase_Entrenador FOREIGN KEY (id_entrenador) REFERENCES Entrenador(id)
);

CREATE TABLE Reserva (
    id INT PRIMARY KEY IDENTITY(1,1),
    id_cliente INT NOT NULL,
    id_horarioclase INT NOT NULL,
    fecha_reserva DATE NOT NULL,         
    asistio BIT NOT NULL DEFAULT 0,      
    estado_reserva VARCHAR(20) NOT NULL DEFAULT 'Confirmada',
    CONSTRAINT fk_Reserva_Cliente FOREIGN KEY (id_cliente) REFERENCES Cliente(id),
    CONSTRAINT fk_Reserva_HorarioClase FOREIGN KEY (id_horarioclase) REFERENCES HorarioClase(id)
);

-- ==========================================
-- 2. ALTER TABLES PARA AÑADIR AUDITORÍA
-- ==========================================

ALTER TABLE Membresia ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado INT NOT NULL DEFAULT 1;
ALTER TABLE Servicio ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado INT NOT NULL DEFAULT 1;
ALTER TABLE Entrenador ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado INT NOT NULL DEFAULT 1;
ALTER TABLE UsuarioSistema ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado INT NOT NULL DEFAULT 1;
ALTER TABLE Cliente ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado INT NOT NULL DEFAULT 1;
ALTER TABLE Inscripcion ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado INT NOT NULL DEFAULT 1;
ALTER TABLE RegistroAcceso ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado INT NOT NULL DEFAULT 1;
ALTER TABLE HorarioClase ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado INT NOT NULL DEFAULT 1;
ALTER TABLE Reserva ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado INT NOT NULL DEFAULT 1;

GO

-- ==========================================
-- 3. PROCEDIMIENTOS ALMACENADOS DE BÚSQUEDA 
-- ==========================================

DROP PROC IF EXISTS paClienteListar;
GO
CREATE PROC paClienteListar @parametro VARCHAR(50)
AS
  SELECT id, ci, nombre, apellido, telefono, correo, usuarioRegistro, fechaRegistro, estado
  FROM Cliente
  WHERE estado=1 AND ci+nombre+apellido LIKE '%'+REPLACE(@parametro,' ','%')+'%'
  ORDER BY apellido, nombre;
GO

DROP PROC IF EXISTS paMembresiaListar;
GO
CREATE PROC paMembresiaListar @parametro VARCHAR(50)
AS
  SELECT id, tipo, precio, duracion_dias, usuarioRegistro, fechaRegistro, estado
  FROM Membresia
  WHERE estado=1 AND tipo LIKE '%'+REPLACE(@parametro,' ','%')+'%'
  ORDER BY tipo;
GO

DROP PROC IF EXISTS paServicioListar;
GO
CREATE PROC paServicioListar @parametro VARCHAR(50)
AS
  SELECT id, nombre, descripcion, capacidad_maxima, usuarioRegistro, fechaRegistro, estado
  FROM Servicio
  WHERE estado=1 AND nombre+ISNULL(descripcion,'') LIKE '%'+REPLACE(@parametro,' ','%')+'%'
  ORDER BY nombre;
GO

DROP PROC IF EXISTS paEntrenadorListar;
GO
CREATE PROC paEntrenadorListar @parametro VARCHAR(50)
AS
  SELECT id, nombre, apellido, telefono, especialidad, usuarioRegistro, fechaRegistro, estado
  FROM Entrenador
  WHERE estado=1 AND nombre+apellido+ISNULL(especialidad,'') LIKE '%'+REPLACE(@parametro,' ','%')+'%'
  ORDER BY apellido, nombre;
GO

DROP PROC IF EXISTS paInscripcionListar;
GO
CREATE PROC paInscripcionListar @parametro VARCHAR(50)
AS
  SELECT i.id, i.id_cliente, i.id_membresia, c.ci, c.nombre, c.apellido, m.tipo AS tipo_membresia, 
         i.fecha_inicio, i.fecha_fin, i.monto_pagado, i.metodo_pago, i.estado_inscripcion, 
         i.usuarioRegistro, i.fechaRegistro, i.estado
  FROM Inscripcion i
  INNER JOIN Cliente c ON c.id = i.id_cliente
  INNER JOIN Membresia m ON m.id = i.id_membresia
  WHERE i.estado=1 AND c.ci+c.nombre+c.apellido+m.tipo LIKE '%'+REPLACE(@parametro,' ','%')+'%'
  ORDER BY i.fecha_fin DESC;
GO

-- ==========================================
-- 4. INSERCIÓN DE DATOS DE PRUEBA
-- ==========================================

DECLARE @salt VARCHAR(128) = 'SaltSeguro2026';
DECLARE @pass VARCHAR(255) = CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', '123456' + @salt), 2);
DECLARE @passRecepcionista VARCHAR(255) = CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', '123456' + @salt), 2);

INSERT INTO UsuarioSistema (nombre_usuario, contraseña, salt, rol) VALUES ('admin', @pass, @salt, 'Admin');
INSERT INTO UsuarioSistema (nombre_usuario, contraseña, salt, rol) VALUES ('recep', @passRecepcionista, @salt, 'Recepcionista');

INSERT INTO Membresia (tipo, precio, duracion_dias) VALUES 
('Mensual Regular', 150.00, 30),
('Mensual Estudiante', 120.00, 30),
('Trimestral Básico', 400.00, 90),
('Trimestral VIP', 550.00, 90),
('Semestral', 800.00, 180),
('Anual Básico', 1200.00, 365),
('Anual Premium', 1500.00, 365),
('Semanal', 50.00, 7),
('Día Pase', 10.00, 1),
('Familiar Mensual', 250.00, 30);

INSERT INTO Servicio (nombre, descripcion, capacidad_maxima) VALUES 
('Musculación', 'Acceso a la sala de pesas y máquinas', 50),
('Spinning', 'Clase guiada de bicicleta estática', 15),
('Zumba', 'Baile coreográfico aeróbico', 25),
('CrossFit', 'Entrenamiento funcional de alta intensidad', 20),
('Yoga', 'Relajación y flexibilidad', 15),
('Boxeo', 'Técnica y combate', 10),
('Pilates', 'Ejercicios de fortalecimiento y flexibilidad', 15),
('Funcional', 'Entrenamiento funcional grupal', 20),
('Aeróbicos', 'Clases de acondicionamiento cardiovascular', 25),
('TRX', 'Entrenamiento en suspensión', 12),
('Kick Boxing', 'Entrenamiento de boxeo y acondicionamiento físico', 15);

INSERT INTO Entrenador (nombre, apellido, telefono, especialidad) VALUES 
('Carlos', 'López', '77712345', 'Musculación'), 
('María', 'Fernández', '77798765', 'Cardio y Zumba'),
('Luis', 'García', '77765432', 'CrossFit'), 
('Ana', 'Martínez', '77711223', 'Yoga y Pilates'),
('Roberto', 'Quispe', '77722334', 'Boxeo'),
('Fernanda', 'Cruz', '77733445', 'Yoga'),
('Diego', 'Paredes', '77744556', 'Musculación'),
('Carla', 'Flores', '77755667', 'Zumba'),
('Andrés', 'Choque', '77766778', 'CrossFit');

INSERT INTO Cliente (ci, nombre, apellido, telefono, correo) VALUES
('12345678', 'Juan', 'Pérez', '70011111', 'juan.perez@gmail.com'),
('23456789', 'María', 'Rodríguez', '70022222', 'maria.rodriguez@hotmail.com'),
('34567890', 'Pedro', 'González', '70033333', 'pedro.gonzalez@gmail.com'),
('45678902', 'Ana', 'Quispe', '70044004', 'ana.quispe@gmail.com'),
('56789013', 'Luis', 'Mamani', '70055005', 'luis.mamani@yahoo.com'),
('67890124', 'Carla', 'Flores', '70066006', 'carla.flores@gmail.com'),
('78901235', 'Diego', 'Choque', '70077007', 'diego.choque@hotmail.com'),
('89012346', 'Fernanda', 'Cruz', '70088008', 'fernanda.cruz@gmail.com'),
('90123457', 'Roberto', 'Vargas', '70099009', 'roberto.vargas@gmail.com'),
('11223345', 'Sofía', 'Mendoza', '70111010', 'sofia.mendoza@gmail.com');

INSERT INTO Inscripcion (id_cliente, id_membresia, fecha_inicio, fecha_fin, monto_pagado, metodo_pago, estado_inscripcion)
VALUES 
(1, 1, DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, 20, GETDATE()), 150.00, 'Efectivo', 'Activa'),
(2, 2, DATEADD(DAY, -5, GETDATE()), DATEADD(DAY, 85, GETDATE()), 400.00, 'Tarjeta', 'Activa'),
(3, 1, DATEADD(DAY, -35, GETDATE()), DATEADD(DAY, -1, GETDATE()), 150.00, 'QR', 'Vencida');

INSERT INTO HorarioClase (id_servicio, id_entrenador, dia_semana, hora_inicio, hora_fin, cupos_reservados) VALUES
(1, 1, 'Lunes', '08:00', '09:00', 0),
(4, 2, 'Lunes', '10:00', '11:00', 0),
(2, 2, 'Lunes', '09:00', '10:00', 8),
(3, 3, 'Martes', '10:00', '11:00', 12),
(1, 2, 'Martes', '18:00', '19:00', 15),
(2, 1, 'Miércoles', '07:00', '08:00', 10),
(3, 3, 'Miércoles', '19:00', '20:00', 20),
(1, 3, 'Jueves', '16:00', '17:00', 12),
(2, 2, 'Viernes', '17:00', '18:00', 14);


USE Gimnasio;
GO
DROP PROC IF EXISTS paRegistroAccesoListar;
GO
CREATE PROC paRegistroAccesoListar @parametro VARCHAR(50)
AS
  SELECT r.id, c.ci, c.nombre, c.apellido, r.fecha_hora, r.tipo, r.usuarioRegistro, r.fechaRegistro, r.estado
  FROM RegistroAcceso r
  INNER JOIN Cliente c ON c.id = r.id_cliente
  WHERE r.estado=1 AND c.ci+c.nombre+c.apellido LIKE '%'+REPLACE(@parametro,' ','%')+'%'
  ORDER BY r.fecha_hora DESC;
GO

USE Gimnasio;
GO

DROP PROC IF EXISTS paHorarioClaseListar;
GO
CREATE PROC paHorarioClaseListar @parametro VARCHAR(50)
AS
  SELECT h.id, h.id_servicio, h.id_entrenador, 
         s.nombre AS servicio, 
         e.nombre + ' ' + e.apellido AS entrenador,
         h.dia_semana, h.hora_inicio, h.hora_fin, h.cupos_reservados,
         h.usuarioRegistro, h.fechaRegistro, h.estado
  FROM HorarioClase h
  INNER JOIN Servicio s ON s.id = h.id_servicio
  INNER JOIN Entrenador e ON e.id = h.id_entrenador
  WHERE h.estado=1 AND (s.nombre + e.nombre + e.apellido + h.dia_semana LIKE '%'+REPLACE(@parametro,' ','%')+'%')
  ORDER BY h.dia_semana, h.hora_inicio;
GO

DROP PROC IF EXISTS paReservaListar;
GO
CREATE PROC paReservaListar @parametro VARCHAR(50)
AS
  SELECT r.id, r.id_cliente, r.id_horarioclase, 
         c.ci, c.nombre + ' ' + c.apellido AS cliente,
         s.nombre + ' (' + h.dia_semana + ' ' + CAST(h.hora_inicio AS VARCHAR(5)) + ')' AS clase,
         r.fecha_reserva, r.asistio, r.estado_reserva,
         r.usuarioRegistro, r.fechaRegistro, r.estado
  FROM Reserva r
  INNER JOIN Cliente c ON c.id = r.id_cliente
  INNER JOIN HorarioClase h ON h.id = r.id_horarioclase
  INNER JOIN Servicio s ON s.id = h.id_servicio
  WHERE r.estado=1 AND (c.ci + c.nombre + c.apellido + s.nombre LIKE '%'+REPLACE(@parametro,' ','%')+'%')
  ORDER BY r.fecha_reserva DESC;
GO

USE Gimnasio;
GO
DROP PROC IF EXISTS paUsuarioSistemaListar;
GO
CREATE PROC paUsuarioSistemaListar @parametro VARCHAR(50)
AS
  SELECT id, nombre_usuario, rol, usuarioRegistro, fechaRegistro, estado
  FROM UsuarioSistema
  WHERE estado=1 AND nombre_usuario LIKE '%'+REPLACE(@parametro,' ','%')+'%'
  ORDER BY nombre_usuario;
GO

USE Gimnasio;
GO

-- 1. Borramos al admin si se creó mal antes
DELETE FROM UsuarioSistema WHERE nombre_usuario = 'admin';

-- 2. Insertamos al admin con la contraseña encriptada directamente (sin usar variables)
INSERT INTO UsuarioSistema (nombre_usuario, contraseña, salt, rol, usuarioRegistro, fechaRegistro, estado) 
VALUES (
    'admin', 
    CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', '123456' + 'SaltSeguro2026'), 2), 
    'SaltSeguro2026', 
    'Admin', 
    'sistema', 
    GETDATE(), 
    1
);

PRINT '¡Administrador creado con éxito y a prueba de errores!';
GO

USE Gimnasio;
GO
DROP PROC IF EXISTS paReporteIngresos;
GO
CREATE PROC paReporteIngresos @fechaInicio DATE, @fechaFin DATE
AS
  SELECT i.id, c.ci, c.nombre + ' ' + c.apellido AS cliente, 
         m.tipo AS plan_membresia, i.fecha_transaccion, i.monto_pagado, i.metodo_pago
  FROM Inscripcion i
  INNER JOIN Cliente c ON c.id = i.id_cliente
  INNER JOIN Membresia m ON m.id = i.id_membresia
  -- Filtramos por estado=1 (no eliminados) e Inscripcion 'Activa'
  WHERE i.estado = 1 AND i.estado_inscripcion = 'Activa'
    AND CAST(i.fecha_transaccion AS DATE) BETWEEN @fechaInicio AND @fechaFin
  ORDER BY i.fecha_transaccion DESC;
GO