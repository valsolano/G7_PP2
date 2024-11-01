CREATE TABLE Usuario_G7(
	id_usuario INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    correo VARCHAR(100) NOT NULL,
    username VARCHAR(25) NOT NULL,
    contrasena VARCHAR(250) NOT NULL,
    activo BOOLEAN NOT NULL
);

CREATE TABLE Lista_G7(
	id_lista INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion VARCHAR(1000) NOT NULL,
    privacidad VARCHAR(25) NOT NULL,
    fecha_creacion  DATE NOT NULL,
    activo BOOLEAN NOT NULL
);

CREATE TABLE Cancion_G7(
	id_cancion INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    album VARCHAR(100) NOT NULL,
    num_reproducciones INT NOT NULL,
    duracion  INT NOT NULL,
    genero VARCHAR(50) NOT NULL
);

CREATE TABLE Cantante_G7(
	id_cantante INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion VARCHAR(1000) NOT NULL
);

CREATE TABLE UsuarioLista_G7(
	id_usuario_lista INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    id_usuario INT,
    id_lista INT,
    FOREIGN KEY (id_usuario) REFERENCES Usuario_G7(id_usuario),
    FOREIGN KEY (id_lista) REFERENCES Lista_G7(id_lista)
);

CREATE TABLE CancionLista_G7(
	id_cancion_lista INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    id_cancion INT,
    id_lista INT,
    FOREIGN KEY (id_cancion) REFERENCES Cancion_G7(id_cancion),
    FOREIGN KEY (id_lista) REFERENCES Lista_G7(id_lista)
);

CREATE TABLE CancionCantante_G7(
	id_cancion_cantante INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    id_cancion INT,
    id_cantante INT,
    FOREIGN KEY (id_cancion) REFERENCES Cancion_G7(id_cancion),
    FOREIGN KEY (id_cantante) REFERENCES Cantante_G7(id_cantante)
);

CREATE TABLE Tarea_G7(
	id_tarea INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    accion VARCHAR(500) NOT NULL,
    fecha_accion  DATE NOT NULL,
    id_usuario INT,
    id_lista INT,
    FOREIGN KEY (id_usuario) REFERENCES Usuario_G7(id_usuario),
    FOREIGN KEY (id_lista) REFERENCES Lista_G7(id_lista)
);