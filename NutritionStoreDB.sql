CREATE DATABASE nutritionstore;

-- Tabla Usuarios
CREATE TABLE Usuarios (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(15),
    Apellido1 VARCHAR(10),
    Apellido2 VARCHAR(10),
    Username VARCHAR(10),
    Email VARCHAR(100) UNIQUE,
    Contraseña VARCHAR(100),
    Administrador BIT NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    PreguntaSeguridad VARCHAR(255),
    RespuestaSeguridad VARCHAR(255)
);

-- Tabla Categorías
CREATE TABLE Categorias (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50),
    Descripcion VARCHAR(100)
);

-- Tabla Suplementos
CREATE TABLE Suplementos (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(20),
    Descripcion VARCHAR(100),
    CategoriaID INT,
    Precio DECIMAL(10,2),
    Foto VARBINARY(MAX),
    Tendencia BIT,
    FechaAñadido DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CategoriaID) REFERENCES Categorias(ID)
);

-- Tabla GruposMusculares
CREATE TABLE GruposMusculares (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50),
    Descripcion VARCHAR(100)
);

-- Tabla Ejercicios
CREATE TABLE Ejercicios (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(20),
    GrupoMuscularID INT,
    Descripcion VARCHAR(100),
    Foto VARBINARY(MAX),
    Tendencia BIT,
    FechaAñadido DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (GrupoMuscularID) REFERENCES GruposMusculares(ID)
);

-- Tabla de favoritos: suplementos
CREATE TABLE Usuarios_SuplementosFavoritos (
    UsuarioID INT,
    SuplementoID INT,
    FechaAgregado DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (UsuarioID, SuplementoID),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(ID) ON DELETE CASCADE,
    FOREIGN KEY (SuplementoID) REFERENCES Suplementos(ID) ON DELETE CASCADE
);

-- Tabla de favoritos: ejercicios
CREATE TABLE Usuarios_EjerciciosFavoritos (
    UsuarioID INT,
    EjercicioID INT,
    FechaAgregado DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (UsuarioID, EjercicioID),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(ID) ON DELETE CASCADE,
    FOREIGN KEY (EjercicioID) REFERENCES Ejercicios(ID) ON DELETE CASCADE
);
