USE [master]
GO
/****** Object:  Database [Examen_ProyectoEscuela]    Script Date: 05/04/2020 07:38:53 p. m. ******/
CREATE DATABASE [Examen_ProyectoEscuela]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Examen_ProyectoEscuela', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Examen_ProyectoEscuela.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Examen_ProyectoEscuela_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Examen_ProyectoEscuela_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Examen_ProyectoEscuela].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET ARITHABORT OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET  MULTI_USER 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET QUERY_STORE = OFF
GO
USE [Examen_ProyectoEscuela]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 05/04/2020 07:38:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[ID_Alumno] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](60) NOT NULL,
	[Carrera] [int] NOT NULL,
 CONSTRAINT [PK_Alumnos] PRIMARY KEY CLUSTERED 
(
	[ID_Alumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cargas Alumnos]    Script Date: 05/04/2020 07:38:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargas Alumnos](
	[ID_Alumno] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [int] NOT NULL,
	[Carrera] [int] NOT NULL,
	[Materia] [int] NOT NULL,
	[Profesor] [int] NOT NULL,
 CONSTRAINT [PK_Cargas Alumnos] PRIMARY KEY CLUSTERED 
(
	[ID_Alumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cargas Docentes]    Script Date: 05/04/2020 07:38:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargas Docentes](
	[ID_Docente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [int] NOT NULL,
	[Carrera] [int] NULL,
	[Materia] [int] NULL,
 CONSTRAINT [PK_Cargas Docentes] PRIMARY KEY CLUSTERED 
(
	[ID_Docente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carreras]    Script Date: 05/04/2020 07:38:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carreras](
	[ID_Carrera] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](60) NOT NULL,
 CONSTRAINT [PK_Carrera] PRIMARY KEY CLUSTERED 
(
	[ID_Carrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maestros]    Script Date: 05/04/2020 07:38:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maestros](
	[ID_Maestros] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](60) NOT NULL,
	[Direccion] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Maestros] PRIMARY KEY CLUSTERED 
(
	[ID_Maestros] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materias]    Script Date: 05/04/2020 07:38:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materias](
	[ID_Materia] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](60) NOT NULL,
 CONSTRAINT [PK_Materias] PRIMARY KEY CLUSTERED 
(
	[ID_Materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios del sistema]    Script Date: 05/04/2020 07:38:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios del sistema](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](60) NOT NULL,
	[Contraseña] [nchar](200) NOT NULL,
 CONSTRAINT [PK_Usuarios del sistema] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Alumnos_Carreras] FOREIGN KEY([Carrera])
REFERENCES [dbo].[Carreras] ([ID_Carrera])
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [FK_Alumnos_Carreras]
GO
ALTER TABLE [dbo].[Cargas Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Cargas Alumnos_Carreras] FOREIGN KEY([Carrera])
REFERENCES [dbo].[Carreras] ([ID_Carrera])
GO
ALTER TABLE [dbo].[Cargas Alumnos] CHECK CONSTRAINT [FK_Cargas Alumnos_Carreras]
GO
ALTER TABLE [dbo].[Cargas Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Cargas Alumnos_Maestros] FOREIGN KEY([Profesor])
REFERENCES [dbo].[Maestros] ([ID_Maestros])
GO
ALTER TABLE [dbo].[Cargas Alumnos] CHECK CONSTRAINT [FK_Cargas Alumnos_Maestros]
GO
ALTER TABLE [dbo].[Cargas Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Cargas Alumnos_Materias] FOREIGN KEY([Materia])
REFERENCES [dbo].[Materias] ([ID_Materia])
GO
ALTER TABLE [dbo].[Cargas Alumnos] CHECK CONSTRAINT [FK_Cargas Alumnos_Materias]
GO
ALTER TABLE [dbo].[Cargas Docentes]  WITH CHECK ADD  CONSTRAINT [FK_Cargas Docentes_Carreras] FOREIGN KEY([Carrera])
REFERENCES [dbo].[Carreras] ([ID_Carrera])
GO
ALTER TABLE [dbo].[Cargas Docentes] CHECK CONSTRAINT [FK_Cargas Docentes_Carreras]
GO
ALTER TABLE [dbo].[Cargas Docentes]  WITH CHECK ADD  CONSTRAINT [FK_Cargas Docentes_Maestros] FOREIGN KEY([Nombre])
REFERENCES [dbo].[Maestros] ([ID_Maestros])
GO
ALTER TABLE [dbo].[Cargas Docentes] CHECK CONSTRAINT [FK_Cargas Docentes_Maestros]
GO
ALTER TABLE [dbo].[Cargas Docentes]  WITH CHECK ADD  CONSTRAINT [FK_Cargas Docentes_Materias] FOREIGN KEY([Materia])
REFERENCES [dbo].[Materias] ([ID_Materia])
GO
ALTER TABLE [dbo].[Cargas Docentes] CHECK CONSTRAINT [FK_Cargas Docentes_Materias]
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 05/04/2020 07:38:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Login]
	@usuario nchar,
	@pass nchar
AS
	select [Usuarios del sistema].Nombre as Usuario, [Usuarios del sistema].Contraseña as Contraseña from [Usuarios del sistema] 
	where [Usuarios del sistema].Nombre = @usuario and [Usuarios del sistema].Contraseña = @pass
GO
/****** Object:  StoredProcedure [dbo].[LoginPass]    Script Date: 05/04/2020 07:38:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoginPass]
 @pass nchar
AS
select [Usuarios del sistema].Nombre as Usuario, [Usuarios del sistema].Contraseña as Contraseña from [Usuarios del sistema] 
	where [Usuarios del sistema].Contraseña = @pass
GO
/****** Object:  StoredProcedure [dbo].[LoginUsuario]    Script Date: 05/04/2020 07:38:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoginUsuario]
 @usu nchar
AS
select [Usuarios del sistema].Nombre as Usuario, [Usuarios del sistema].Contraseña as Contraseña from [Usuarios del sistema] 
	where [Usuarios del sistema].Nombre = @usu
GO
/****** Object:  StoredProcedure [dbo].[MostrarAlumnos]    Script Date: 05/04/2020 07:38:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MostrarAlumnos]
AS
select Alumnos.ID_Alumno as ID,Alumnos.Nombre as Alumno, Carreras.Nombre as Carrera from Alumnos
INNER JOIN Carreras on Alumnos.Carrera = Carreras.ID_Carrera
GO
/****** Object:  StoredProcedure [dbo].[MostrarCargasAlumnos]    Script Date: 05/04/2020 07:38:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MostrarCargasAlumnos]
AS
select [Cargas Alumnos].ID_Alumno as ID, Alumnos.Nombre as Alumno, Carreras.Nombre as Carrera, Materias.Nombre as Materia, Maestros.Nombre as Profesor 
from [Cargas Alumnos]
INNER JOIN Alumnos on [Cargas Alumnos].ID_Alumno = Alumnos.ID_Alumno
INNER JOIN Carreras on [Cargas Alumnos].Carrera = Carreras.ID_Carrera
INNER JOIN Materias on [Cargas Alumnos].Materia = Materias.ID_Materia
INNER JOIN Maestros on [Cargas Alumnos].Profesor = Maestros.ID_Maestros
GO
/****** Object:  StoredProcedure [dbo].[MostrarCargasDocentes]    Script Date: 05/04/2020 07:38:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MostrarCargasDocentes]
AS
select [Cargas Docentes].ID_Docente as ID, Maestros.Nombre as Profesor, Carreras.Nombre as Carrera, Materias.Nombre as Materia from [Cargas Docentes] 
INNER JOIN Maestros on [Cargas Docentes].Nombre = Maestros.ID_Maestros
INNER JOIN Carreras on [Cargas Docentes].Carrera = Carreras.ID_Carrera
INNER JOIN Materias on [Cargas Docentes].Materia = Materias.ID_Materia
GO
/****** Object:  StoredProcedure [dbo].[MostrarNombreCarrera_Por_IdAlumno]    Script Date: 05/04/2020 07:38:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MostrarNombreCarrera_Por_IdAlumno]
	@idAlumno int
AS
	select Carreras.Nombre from Alumnos INNER JOIN Carreras on Alumnos.Carrera = Carreras.ID_Carrera
where Alumnos.ID_Alumno = @idAlumno
GO
/****** Object:  StoredProcedure [dbo].[Procedure]    Script Date: 05/04/2020 07:38:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Procedure]
AS
select [Cargas Docentes].ID_Docente as ID, Maestros.Nombre as Profesor, Carreras.Nombre as Carrera, Materias.Nombre as Materia from [Cargas Docentes] 
INNER JOIN Maestros on [Cargas Docentes].Nombre = Maestros.ID_Maestros
INNER JOIN Carreras on [Cargas Docentes].Carrera = Carreras.ID_Carrera
INNER JOIN Materias on [Cargas Docentes].Materia = Materias.ID_Materia
GO
USE [master]
GO
ALTER DATABASE [Examen_ProyectoEscuela] SET  READ_WRITE 
GO
