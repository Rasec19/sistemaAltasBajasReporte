USE [master]
GO
/****** Object:  Database [Examen_PoroyectoEscuela]    Script Date: 03/04/2020 08:45:26 p. m. ******/
CREATE DATABASE [Examen_PoroyectoEscuela]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Examen_PoroyectoEscuela', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Examen_PoroyectoEscuela.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Examen_PoroyectoEscuela_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Examen_PoroyectoEscuela_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Examen_PoroyectoEscuela].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET ARITHABORT OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET  MULTI_USER 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET QUERY_STORE = OFF
GO
USE [Examen_PoroyectoEscuela]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 03/04/2020 08:45:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[ID_Alumnos] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](50) NOT NULL,
	[Carrera] [int] NOT NULL,
 CONSTRAINT [PK_Alumnos] PRIMARY KEY CLUSTERED 
(
	[ID_Alumnos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cargas_Alumnos]    Script Date: 03/04/2020 08:45:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargas_Alumnos](
	[ID_CargaAlumno] [int] IDENTITY(1,1) NOT NULL,
	[NombreAlumno] [int] NOT NULL,
	[Carrera] [int] NOT NULL,
	[Materia] [int] NOT NULL,
	[Profesor] [int] NOT NULL,
 CONSTRAINT [PK_Cargas_Alumnos] PRIMARY KEY CLUSTERED 
(
	[ID_CargaAlumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cargas_Docentes]    Script Date: 03/04/2020 08:45:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargas_Docentes](
	[ID_CargaDocente] [int] IDENTITY(1,1) NOT NULL,
	[NombreProfesor] [int] NOT NULL,
	[Carrera] [int] NOT NULL,
	[Materia] [int] NOT NULL,
 CONSTRAINT [PK_Cargas_Docentes] PRIMARY KEY CLUSTERED 
(
	[ID_CargaDocente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carreras]    Script Date: 03/04/2020 08:45:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carreras](
	[ID_Carrera] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Carreras] PRIMARY KEY CLUSTERED 
(
	[ID_Carrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maestros]    Script Date: 03/04/2020 08:45:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maestros](
	[ID_Maestros] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](50) NOT NULL,
	[Direccion] [nchar](60) NOT NULL,
 CONSTRAINT [PK_Maestros] PRIMARY KEY CLUSTERED 
(
	[ID_Maestros] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materias]    Script Date: 03/04/2020 08:45:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materias](
	[ID_Materias] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Materias] PRIMARY KEY CLUSTERED 
(
	[ID_Materias] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios del sistema]    Script Date: 03/04/2020 08:45:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios del sistema](
	[ID_Usuarios] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](50) NOT NULL,
	[Contraseña] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios del sistema] PRIMARY KEY CLUSTERED 
(
	[ID_Usuarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alumnos] ON 

INSERT [dbo].[Alumnos] ([ID_Alumnos], [Nombre], [Carrera]) VALUES (1, N'Rasec                                             ', 1)
INSERT [dbo].[Alumnos] ([ID_Alumnos], [Nombre], [Carrera]) VALUES (6, N'Armando                                           ', 3)
INSERT [dbo].[Alumnos] ([ID_Alumnos], [Nombre], [Carrera]) VALUES (7, N'Toño                                              ', 1)
INSERT [dbo].[Alumnos] ([ID_Alumnos], [Nombre], [Carrera]) VALUES (8, N'Pedro                                             ', 6)
INSERT [dbo].[Alumnos] ([ID_Alumnos], [Nombre], [Carrera]) VALUES (10, N'Chepo                                             ', 6)
SET IDENTITY_INSERT [dbo].[Alumnos] OFF
SET IDENTITY_INSERT [dbo].[Cargas_Alumnos] ON 

INSERT [dbo].[Cargas_Alumnos] ([ID_CargaAlumno], [NombreAlumno], [Carrera], [Materia], [Profesor]) VALUES (2, 7, 1, 2, 2)
INSERT [dbo].[Cargas_Alumnos] ([ID_CargaAlumno], [NombreAlumno], [Carrera], [Materia], [Profesor]) VALUES (3, 1, 1, 1, 1)
INSERT [dbo].[Cargas_Alumnos] ([ID_CargaAlumno], [NombreAlumno], [Carrera], [Materia], [Profesor]) VALUES (4, 6, 4, 4, 4)
INSERT [dbo].[Cargas_Alumnos] ([ID_CargaAlumno], [NombreAlumno], [Carrera], [Materia], [Profesor]) VALUES (5, 8, 6, 3, 5)
SET IDENTITY_INSERT [dbo].[Cargas_Alumnos] OFF
SET IDENTITY_INSERT [dbo].[Cargas_Docentes] ON 

INSERT [dbo].[Cargas_Docentes] ([ID_CargaDocente], [NombreProfesor], [Carrera], [Materia]) VALUES (1, 1, 1, 1)
INSERT [dbo].[Cargas_Docentes] ([ID_CargaDocente], [NombreProfesor], [Carrera], [Materia]) VALUES (3, 1, 1, 2)
SET IDENTITY_INSERT [dbo].[Cargas_Docentes] OFF
SET IDENTITY_INSERT [dbo].[Carreras] ON 

INSERT [dbo].[Carreras] ([ID_Carrera], [Nombre]) VALUES (1, N'Software                                          ')
INSERT [dbo].[Carreras] ([ID_Carrera], [Nombre]) VALUES (2, N'Mecatronica                                       ')
INSERT [dbo].[Carreras] ([ID_Carrera], [Nombre]) VALUES (3, N'Administracion de Empresas                        ')
INSERT [dbo].[Carreras] ([ID_Carrera], [Nombre]) VALUES (4, N'Contaduria                                        ')
INSERT [dbo].[Carreras] ([ID_Carrera], [Nombre]) VALUES (5, N'Geociencias                                       ')
INSERT [dbo].[Carreras] ([ID_Carrera], [Nombre]) VALUES (6, N'Turismo                                           ')
INSERT [dbo].[Carreras] ([ID_Carrera], [Nombre]) VALUES (9, N'Gastronomia                                       ')
SET IDENTITY_INSERT [dbo].[Carreras] OFF
SET IDENTITY_INSERT [dbo].[Maestros] ON 

INSERT [dbo].[Maestros] ([ID_Maestros], [Nombre], [Direccion]) VALUES (1, N'Miguel                                            ', N'Hermosillo                                                  ')
INSERT [dbo].[Maestros] ([ID_Maestros], [Nombre], [Direccion]) VALUES (2, N'Jalil                                             ', N'Hermosillo                                                  ')
INSERT [dbo].[Maestros] ([ID_Maestros], [Nombre], [Direccion]) VALUES (3, N'Margarita                                         ', N'Navojoa                                                     ')
INSERT [dbo].[Maestros] ([ID_Maestros], [Nombre], [Direccion]) VALUES (4, N'Shihemy                                           ', N'Hermosillo                                                  ')
INSERT [dbo].[Maestros] ([ID_Maestros], [Nombre], [Direccion]) VALUES (5, N'Gabriel                                           ', N'Hermosillo                                                  ')
INSERT [dbo].[Maestros] ([ID_Maestros], [Nombre], [Direccion]) VALUES (6, N'Alicia                                            ', N'Cajeme                                                      ')
SET IDENTITY_INSERT [dbo].[Maestros] OFF
SET IDENTITY_INSERT [dbo].[Materias] ON 

INSERT [dbo].[Materias] ([ID_Materias], [Nombre]) VALUES (1, N'programacion Avanzada                             ')
INSERT [dbo].[Materias] ([ID_Materias], [Nombre]) VALUES (2, N'Seguridad de la Informacion                       ')
INSERT [dbo].[Materias] ([ID_Materias], [Nombre]) VALUES (3, N'Contaduria                                        ')
INSERT [dbo].[Materias] ([ID_Materias], [Nombre]) VALUES (4, N'Matematicas Basicas                               ')
INSERT [dbo].[Materias] ([ID_Materias], [Nombre]) VALUES (5, N'Programacion Web                                  ')
SET IDENTITY_INSERT [dbo].[Materias] OFF
SET IDENTITY_INSERT [dbo].[Usuarios del sistema] ON 

INSERT [dbo].[Usuarios del sistema] ([ID_Usuarios], [Nombre], [Contraseña]) VALUES (1, N'Admin                                             ', N'Ues12345                                          ')
INSERT [dbo].[Usuarios del sistema] ([ID_Usuarios], [Nombre], [Contraseña]) VALUES (3, N'Rasec                                             ', N'BEN100                                            ')
INSERT [dbo].[Usuarios del sistema] ([ID_Usuarios], [Nombre], [Contraseña]) VALUES (4, N'Jaimito12                                         ', N'12                                                ')
INSERT [dbo].[Usuarios del sistema] ([ID_Usuarios], [Nombre], [Contraseña]) VALUES (6, N'Pablo                                             ', N'123                                               ')
INSERT [dbo].[Usuarios del sistema] ([ID_Usuarios], [Nombre], [Contraseña]) VALUES (7, N'Jesys4                                            ', N'4                                                 ')
SET IDENTITY_INSERT [dbo].[Usuarios del sistema] OFF
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Alumnos_Carreras] FOREIGN KEY([Carrera])
REFERENCES [dbo].[Carreras] ([ID_Carrera])
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [FK_Alumnos_Carreras]
GO
ALTER TABLE [dbo].[Cargas_Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Cargas_Alumnos_Alumnos] FOREIGN KEY([NombreAlumno])
REFERENCES [dbo].[Alumnos] ([ID_Alumnos])
GO
ALTER TABLE [dbo].[Cargas_Alumnos] CHECK CONSTRAINT [FK_Cargas_Alumnos_Alumnos]
GO
ALTER TABLE [dbo].[Cargas_Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Cargas_Alumnos_Carreras] FOREIGN KEY([Carrera])
REFERENCES [dbo].[Carreras] ([ID_Carrera])
GO
ALTER TABLE [dbo].[Cargas_Alumnos] CHECK CONSTRAINT [FK_Cargas_Alumnos_Carreras]
GO
ALTER TABLE [dbo].[Cargas_Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Cargas_Alumnos_Maestros] FOREIGN KEY([Profesor])
REFERENCES [dbo].[Maestros] ([ID_Maestros])
GO
ALTER TABLE [dbo].[Cargas_Alumnos] CHECK CONSTRAINT [FK_Cargas_Alumnos_Maestros]
GO
ALTER TABLE [dbo].[Cargas_Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Cargas_Alumnos_Materias] FOREIGN KEY([Materia])
REFERENCES [dbo].[Materias] ([ID_Materias])
GO
ALTER TABLE [dbo].[Cargas_Alumnos] CHECK CONSTRAINT [FK_Cargas_Alumnos_Materias]
GO
ALTER TABLE [dbo].[Cargas_Docentes]  WITH CHECK ADD  CONSTRAINT [FK_Cargas_Docentes_Carreras] FOREIGN KEY([Carrera])
REFERENCES [dbo].[Carreras] ([ID_Carrera])
GO
ALTER TABLE [dbo].[Cargas_Docentes] CHECK CONSTRAINT [FK_Cargas_Docentes_Carreras]
GO
ALTER TABLE [dbo].[Cargas_Docentes]  WITH CHECK ADD  CONSTRAINT [FK_Cargas_Docentes_Maestros] FOREIGN KEY([NombreProfesor])
REFERENCES [dbo].[Maestros] ([ID_Maestros])
GO
ALTER TABLE [dbo].[Cargas_Docentes] CHECK CONSTRAINT [FK_Cargas_Docentes_Maestros]
GO
ALTER TABLE [dbo].[Cargas_Docentes]  WITH CHECK ADD  CONSTRAINT [FK_Cargas_Docentes_Materias] FOREIGN KEY([Materia])
REFERENCES [dbo].[Materias] ([ID_Materias])
GO
ALTER TABLE [dbo].[Cargas_Docentes] CHECK CONSTRAINT [FK_Cargas_Docentes_Materias]
GO
/****** Object:  StoredProcedure [dbo].[IngresarAlumno_Por_IdCarrera]    Script Date: 03/04/2020 08:45:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IngresarAlumno_Por_IdCarrera]
	@idCarrera int
AS
select Carreras.Nombre as Carrera from Carreras  
INNER JOIN Alumnos on Carreras.ID_Carrera = Alumnos.Carrera
where Alumnos.Carrera = @idCarrera
GO
/****** Object:  StoredProcedure [dbo].[MostrarAlumnos]    Script Date: 03/04/2020 08:45:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MostrarAlumnos]
	AS
select Alumnos.ID_Alumnos as ID,Alumnos.Nombre as Nombre,Carreras.Nombre as Carrera from Carreras  
INNER JOIN Alumnos on Carreras.ID_Carrera = Alumnos.Carrera
GO
/****** Object:  StoredProcedure [dbo].[MostrarCargasAlumnos]    Script Date: 03/04/2020 08:45:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MostrarCargasAlumnos]
AS
select Cargas_Alumnos.ID_CargaAlumno as ID,Alumnos.Nombre as Alumno,Carreras.Nombre as Carrera,Materias.Nombre as Materia, Maestros.Nombre as Profesor 
from Cargas_Alumnos
INNER JOIN Alumnos on Cargas_Alumnos.NombreAlumno = Alumnos.ID_Alumnos
INNER JOIN Carreras on Cargas_Alumnos.Carrera = Carreras.ID_Carrera
INNER JOIN Materias on Cargas_Alumnos.Materia = Materias.ID_Materias
INNER JOIN Maestros on Cargas_Alumnos.Profesor = Maestros.ID_Maestros
GO
/****** Object:  StoredProcedure [dbo].[MostrasCargasDocentes]    Script Date: 03/04/2020 08:45:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MostrasCargasDocentes]
AS
select Cargas_Docentes.ID_CargaDocente as ID, Maestros.Nombre as Profesor, Carreras.Nombre as Carrera, Materias.Nombre as Materia from Cargas_Docentes 
INNER JOIN Maestros on Cargas_Docentes.NombreProfesor = Maestros.ID_Maestros
INNER JOIN Carreras on Cargas_Docentes.Carrera = Carreras.ID_Carrera
INNER JOIN Materias on Cargas_Docentes.Materia = Materias.ID_Materias
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCarrera_Por_IdAlumno]    Script Date: 03/04/2020 08:45:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerCarrera_Por_IdAlumno]
	@idAlumno int
AS
select Carreras.Nombre as Carrera from Carreras  
INNER JOIN Alumnos on Carreras.ID_Carrera = Alumnos.Carrera
where Alumnos.ID_Alumnos = @idAlumno
GO
USE [master]
GO
ALTER DATABASE [Examen_PoroyectoEscuela] SET  READ_WRITE 
GO
