CREATE DATABASE GYM;
GO
USE GYM;
GO

CREATE TABLE Usuario(
Id_Usuario INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50),
Apellido VARCHAR(50),
Correo VARCHAR(100),
Contraseña VARCHAR(50),
Tipo VARCHAR(10) CHECK (Tipo IN ('cliente', 'admin'))
);

CREATE TABLE Entrenador(
Id_Entrenador INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50),
Apellido VARCHAR(50),
Telefono VARCHAR(15),
Especialidad VARCHAR(50),
Correo VARCHAR(100)
);

CREATE TABLE Servicio(
Id_Servicio INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50),
Descripcion VARCHAR(255),
Duracion INT, -- duración en minutos
Capacidad_Maxima INT
);

CREATE TABLE Horario(
Id_Horario INT PRIMARY KEY IDENTITY(1,1),
Dia VARCHAR(20),
Hora_Inicio TIME,
Hora_Fin TIME,
Id_Servicio INT,
Id_Entrenador INT
);

CREATE TABLE Reserva(
Id_Reserva INT PRIMARY KEY IDENTITY(1,1),
Fecha DATE,
Estado VARCHAR(20),
Id_Usuario INT,
Id_Horario INT,
FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario),
FOREIGN KEY (Id_Horario) REFERENCES Horario(Id_Horario)
);	

CREATE TABLE Membresia(
Id_membresia INT PRIMARY KEY IDENTITY(1,1),
Tipo VARCHAR(50),
Precio DECIMAL(10, 2),
Duracion INT, -- duración en meses
Id_Usuario INT,
FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario)
);

CREATE TABLE Pago(
Id_Pago INT PRIMARY KEY IDENTITY(1,1),
Monto DECIMAL(10, 2),
Fecha DATE,
Metodo_Pago VARCHAR(50),
Id_Usuario INT,
Id_Membresia INT,
FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario),
FOREIGN KEY (Id_Membresia) REFERENCES Membresia(Id_Membresia)
);

CREATE TABLE Asistencia(
Id_Asistencia INT PRIMARY KEY IDENTITY(1,1),
Fecha DATE,
Estado VARCHAR(20) CHECK (Estado IN ('asistió', 'no asistió')),
Id_Usuario INT,
Id_Horario INT,
FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario),
FOREIGN KEY (Id_Horario) REFERENCES Horario(Id_Horario)
);

INSERT INTO Usuario (Nombre, Apellido,Correo ,Contraseña, Tipo) VALUES ( 'Ana', 'Perez', 'ana@gmail.com', '123', 'cliente');
INSERT INTO Usuario (Nombre, Apellido, Correo, Contraseña, Tipo) VALUES ( 'Luis', 'Gomez', 'luis@gmail.com', '123', 'cliente');

INSERT INTO Entrenador(Nombre, Apellido, Telefono, Especialidad, Correo) VALUES ( 'Carlos', 'Lopez', '77711122', 'Pesas', 'carlos@gmail.com');
INSERT INTO Entrenador(Nombre, Apellido, Telefono, Especialidad, Correo) VALUES ( 'Maria', 'Fernandez', '77733344', 'Cardio', 'maria@gmail.com');

INSERT INTO Servicio (Nombre, Descripcion, Duracion, Capacidad_Maxima)VALUES ( 'Pesas', 'Entrenamiento con pesas', 60, '20');
INSERT INTO Servicio (Nombre, Descripcion, Duracion, Capacidad_Maxima)VALUES ( 'Cardio', 'Ejercicios cardiovasculares', 45, '15');

INSERT INTO Horario (Dia, Hora_Inicio, Hora_Fin,Id_Servicio , Id_Entrenador) VALUES ( 'Lunes', '08:00', '09:00', 1, 1);
INSERT INTO Horario (Dia, Hora_Inicio, Hora_Fin,Id_Servicio , Id_Entrenador) VALUES ('Martes', '10:00', '11:00', 2, 2);

INSERT INTO Reserva (Fecha, Estado, Id_Usuario, Id_Horario) VALUES ('2026-04-10', 'confirmado', 1, 1);
INSERT INTO Reserva (Fecha, Estado, Id_Usuario, Id_Horario) VALUES('2026-04-11', 'pendiente', 2, 2);

INSERT INTO Membresia (Tipo, Precio, Duracion, Id_Usuario) VALUES ( 'Mensual', 100.00, 1, 1);
INSERT INTO Membresia (Tipo, Precio, Duracion, Id_Usuario) VALUES ('Trimestral', 250.00, 3, 2);

INSERT INTO Pago(Monto, Fecha, Metodo_Pago, Id_Usuario, Id_Membresia) VALUES ( 100.00, '2026-04-01', 'Efectivo', 1, 1);
INSERT INTO Pago(Monto, Fecha, Metodo_Pago, Id_Usuario, Id_Membresia) VALUES ( 250.00, '2026-04-02', 'Tarjeta', 2, 2);

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


