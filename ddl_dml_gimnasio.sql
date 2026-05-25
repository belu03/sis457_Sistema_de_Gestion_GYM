CREATE DATABASE Gimnasio;
GO
USE master
GO

CREATE LOGIN usrgimnasio WITH PASSWORD = '123456',
  DEFAULT_DATABASE = Gimnasio,
  CHECK_EXPIRATION = OFF,
  CHECK_POLICY = ON
GO
USE Gimnasio
GO
CREATE USER usrgimnasio FOR LOGIN usrgimnasio
GO
ALTER ROLE db_owner ADD MEMBER usrgimnasio
GO

CREATE TABLE Usuario(
id INT PRIMARY KEY IDENTITY(1,1),
nombre VARCHAR(50),
apellido VARCHAR(50),
correo VARCHAR(100),
contraseña VARCHAR(50),
tipo VARCHAR(10) CHECK (tipo IN ('cliente', 'admin'))
);

CREATE TABLE Entrenador(
id INT PRIMARY KEY IDENTITY(1,1),
nombre VARCHAR(50),
apellido VARCHAR(50),
telefono VARCHAR(15),
especialidad VARCHAR(50),
correo VARCHAR(100)
);

CREATE TABLE Servicio(
id INT PRIMARY KEY IDENTITY(1,1),
nombre VARCHAR(50),
descripcion VARCHAR(255),
duracion INT, -- duración en minutos
capacidad_maxima INT
);

CREATE TABLE Horario(
id INT PRIMARY KEY IDENTITY(1,1),
dia VARCHAR(20),
hora_inicio TIME,
hora_fin TIME,
id_servicio INT,
id_entrenador INT,
FOREIGN KEY (id_servicio) REFERENCES Servicio(id),
FOREIGN KEY (id_entrenador) REFERENCES Entrenador(id)
);

CREATE TABLE Reserva(
id INT PRIMARY KEY IDENTITY(1,1),
fecha DATE,
estado VARCHAR(20),
id_usuario INT,
id_horario INT,
FOREIGN KEY (id_usuario) REFERENCES Usuario(id),
FOREIGN KEY (id_horario) REFERENCES Horario(id)
);	

CREATE TABLE Membresia(
id INT PRIMARY KEY IDENTITY(1,1),
tipo VARCHAR(50),
precio DECIMAL(10, 2),
duracion INT, -- duración en meses
id_usuario INT,
FOREIGN KEY (id_usuario) REFERENCES Usuario(id)
);

CREATE TABLE Pago(
id INT PRIMARY KEY IDENTITY(1,1),
monto DECIMAL(10, 2),
fecha DATE,
metodo_pago VARCHAR(50),
id_usuario INT,
id_membresia INT,
FOREIGN KEY (id_usuario) REFERENCES Usuario(id),
FOREIGN KEY (id_membresia) REFERENCES Membresia(id)
);

CREATE TABLE Asistencia(
id INT PRIMARY KEY IDENTITY(1,1),
fecha DATE,
estado VARCHAR(20) CHECK (estado IN ('asistió', 'no asistió')),
id_usuario INT,
id_horario INT,
FOREIGN KEY (id_usuario) REFERENCES Usuario(id),
FOREIGN KEY (id_horario) REFERENCES Horario(id)
);

GO
DROP PROC IF EXISTS spUsuarioListar;
GO

CREATE PROC spUsuarioListar @parametro VARCHAR(50)
AS
BEGIN
SELECT u.id, u.nombre, u.apellido,u.correo,u.tipo,
a.fecha AS fechaAsistencia,a.estado AS asistencia,
p.fecha AS fechaPago,p.metodo_pago,p.monto,
m.tipo AS membresia,m.duracion,m.precio,
r.fecha AS fechaReserva,r.estado AS estadoReserva,
h.dia,h.hora_inicio,h.hora_fin
FROM Usuario u
INNER JOIN Asistencia a ON u.id = a.id_usuario
INNER JOIN Pago p ON u.id = p.id_usuario
INNER JOIN Membresia m ON u.id = m.id_usuario
INNER JOIN Reserva r ON u.id = r.id_usuario
INNER JOIN Horario h ON r.id_horario = h.id
WHERE 
	u.nombre LIKE '%' + @parametro + '%'
	OR u.apellido LIKE '%' + @parametro + '%'
	OR u.correo LIKE '%' + @parametro + '%';
END
GO
EXEC spUsuarioListar '';

GO
DROP PROC IF EXISTS spEntrenadorListar;
GO
CREATE PROC spEntrenadorListar @parametro VARCHAR(50)
AS
BEGIN
SELECT e.id,e.nombre,e.apellido,e.telefono,e.especialidad,e.correo,
	h.dia,h.hora_inicio,h.hora_fin,
    s.nombre AS servicio,s.descripcion,s.duracion,s.capacidad_maxima
FROM Entrenador e
INNER JOIN Horario h ON e.id = h.id_entrenador
INNER JOIN Servicio s ON h.id_servicio = s.id
WHERE e.nombre LIKE '%' + @parametro + '%' 
    OR e.apellido LIKE '%' + @parametro + '%'
	OR e.especialidad LIKE '%' + @parametro + '%';
END
GO
EXEC spEntrenadorListar '';

GO
DROP PROC IF EXISTS spServicioListar;
GO
CREATE PROC spServicioListar @parametro VARCHAR(50)
AS
BEGIN
SELECT * FROM Servicio
WHERE nombre LIKE '%' + @parametro + '%'
   OR descripcion LIKE '%' + @parametro + '%';
END
GO
EXEC spServicioListar '';

GO	
DROP PROC IF EXISTS spHorarioListar;
GO
CREATE PROC spHorarioListar @parametro VARCHAR(50)
AS
BEGIN
SELECT h.id, h.dia, h.hora_inicio, h.hora_fin, s.nombre AS servicio,e.nombre AS entrenador
FROM Horario h
INNER JOIN Servicio s ON h.id_servicio = s.id
INNER JOIN Entrenador e ON h.id_entrenador = e.id
WHERE h.dia LIKE '%' + @parametro + '%';
END
GO
EXEC spHorarioListar '';

GO
DROP PROC IF EXISTS spReservaListar;
GO
CREATE PROC spReservaListar @parametro VARCHAR(50)
AS
BEGIN
SELECT r.id, r.fecha, r.estado,u.nombre AS usuario,h.dia, h.hora_inicio, h.hora_fin
FROM Reserva r
INNER JOIN Usuario u ON r.id_usuario = u.id
INNER JOIN Horario h ON r.id_horario = h.id
WHERE r.estado LIKE '%' + @parametro + '%';
END
GO
EXEC spReservaListar '';

GO
DROP PROC IF EXISTS spMembresiaListar;
GO
CREATE PROC spMembresiaListar @parametro VARCHAR(50)
AS
BEGIN
SELECT m.id, m.tipo, m.precio, m.duracion,u.nombre AS usuario
FROM Membresia m
INNER JOIN Usuario u ON m.id_usuario = u.id
WHERE m.tipo LIKE '%' + @parametro + '%';
END
GO
EXEC spMembresiaListar '';

GO
DROP PROC IF EXISTS spPagoListar;
GO
CREATE PROC spPagoListar @parametro VARCHAR(50)
AS
BEGIN
SELECT p.id, p.monto, p.fecha, p.metodo_pago, u.nombre AS usuario,m.tipo AS membresia
FROM Pago p
INNER JOIN Usuario u ON p.id_usuario = u.id
INNER JOIN Membresia m ON p.id_membresia = m.id
WHERE p.metodo_pago LIKE '%' + @parametro + '%';
END
GO
EXEC spPagoListar '';

GO
DROP PROC IF EXISTS spAsistenciaListar;
GO
CREATE PROC spAsistenciaListar @parametro VARCHAR(50)
AS
BEGIN
SELECT a.id, a.fecha, a.estado,u.nombre AS usuario,h.dia, h.hora_inicio, h.hora_fin
FROM Asistencia a
INNER JOIN Usuario u ON a.id_usuario = u.id
INNER JOIN Horario h ON a.id_horario = h.id
WHERE a.estado LIKE '%' + @parametro + '%';
END
GO
EXEC spAsistenciaListar '';

INSERT INTO Usuario (nombre, apellido, correo, contraseña, tipo) VALUES ( 'Ana', 'Perez', 'ana@gmail.com', '123', 'cliente');
INSERT INTO Usuario (nombre, apellido, correo, contraseña, tipo) VALUES ( 'Luis', 'Gomez', 'luis@gmail.com', '123', 'cliente');

INSERT INTO Entrenador(nombre, apellido, telefono, especialidad, correo) VALUES ( 'Carlos', 'Lopez', '77711122', 'Pesas', 'carlos@gmail.com');
INSERT INTO Entrenador(nombre, apellido, telefono, especialidad, correo) VALUES ( 'Maria', 'Fernandez', '77733344', 'Cardio', 'maria@gmail.com');

INSERT INTO Servicio (nombre, descripcion, duracion, capacidad_maxima)VALUES ( 'Pesas', 'Entrenamiento con pesas', 60, '20');
INSERT INTO Servicio (nombre, descripcion, duracion, capacidad_maxima)VALUES ( 'Cardio', 'Ejercicios cardiovasculares', 45, '15');

INSERT INTO Horario (dia, hora_inicio, hora_fin, id_servicio, id_entrenador) VALUES ( 'Lunes', '08:00', '09:00', 1, 1);
INSERT INTO Horario (dia, hora_inicio, hora_fin, id_servicio, id_entrenador) VALUES ('Martes', '10:00', '11:00', 2, 2);

INSERT INTO Reserva (fecha, estado, id_usuario, id_horario) VALUES ('2026-04-10', 'confirmado', 1, 1);
INSERT INTO Reserva (fecha, estado, id_usuario, id_horario) VALUES('2026-04-11', 'pendiente', 2, 2);

INSERT INTO Membresia (tipo, precio, duracion, id_usuario) VALUES ( 'Mensual', 100.00, 1, 1);
INSERT INTO Membresia (tipo, precio, duracion, id_usuario) VALUES ('Trimestral', 250.00, 3, 2);

INSERT INTO Pago(monto, fecha, metodo_pago, id_usuario, id_membresia) VALUES ( 100.00, '2026-04-01', 'Efectivo', 1, 1);
INSERT INTO Pago(monto, fecha, metodo_pago, id_usuario, id_membresia) VALUES ( 250.00, '2026-04-02', 'Tarjeta', 2, 2);

INSERT INTO Asistencia (fecha, estado, id_usuario, id_horario) VALUES ('2026-04-10', 'asistió', 1, 1);
INSERT INTO Asistencia (fecha, estado, id_usuario, id_horario) VALUES('2026-04-11', 'no asistió', 2, 2);

SELECT * FROM Usuario;
SELECT * FROM Entrenador;
SELECT * FROM Servicio;
SELECT * FROM Horario;
SELECT * FROM Reserva;
SELECT * FROM Membresia;
SELECT * FROM Pago;
SELECT * FROM Asistencia;