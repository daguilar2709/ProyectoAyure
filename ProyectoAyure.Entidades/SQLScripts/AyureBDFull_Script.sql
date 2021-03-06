USE [master]
GO
/****** Object:  Database [AyureBD]    Script Date: 4/6/2022 8:18:49 PM ******/
CREATE DATABASE [AyureBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AyureBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\AyureBD.mdf' , SIZE = 61440KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AyureBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\AyureBD_log.ldf' , SIZE = 61440KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AyureBD] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AyureBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AyureBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AyureBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AyureBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AyureBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AyureBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [AyureBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AyureBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AyureBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AyureBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AyureBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AyureBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AyureBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AyureBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AyureBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AyureBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AyureBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AyureBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AyureBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AyureBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AyureBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AyureBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AyureBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AyureBD] SET RECOVERY FULL 
GO
ALTER DATABASE [AyureBD] SET  MULTI_USER 
GO
ALTER DATABASE [AyureBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AyureBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AyureBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AyureBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AyureBD] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AyureBD', N'ON'
GO
ALTER DATABASE [AyureBD] SET QUERY_STORE = OFF
GO
USE [AyureBD]
GO
/****** Object:  User [plugin]    Script Date: 4/6/2022 8:18:49 PM ******/
CREATE USER [plugin] FOR LOGIN [plugin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [plugin]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/6/2022 8:18:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfiles]    Script Date: 4/6/2022 8:18:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombrePerfil] [nvarchar](150) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Perfiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioAcceso]    Script Date: 4/6/2022 8:18:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioAcceso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](50) NOT NULL,
	[Constraseña] [nvarchar](50) NOT NULL,
	[Identificador] [uniqueidentifier] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[FechaModificacion] [datetime2](7) NOT NULL,
	[Activo] [bit] NOT NULL,
	[usuarioId] [int] NULL,
 CONSTRAINT [PK_UsuarioAcceso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 4/6/2022 8:18:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](75) NOT NULL,
	[ApellidoPaterno] [nvarchar](100) NOT NULL,
	[ApellidoMaterno] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](250) NOT NULL,
	[Telefono1] [nvarchar](75) NOT NULL,
	[Telefono2] [nvarchar](max) NULL,
	[CodigoPostal] [int] NOT NULL,
	[FechaCreacion] [nvarchar](max) NOT NULL,
	[FechaModificacion] [nvarchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
	[perfilId] [int] NULL,
	[usuarioAccesoId] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220123213223_UsersMigration', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220123214803_PerfilyRelacionMigration', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220123215425_AccesosyRelacionMigration', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220127021357_ConfiguraUsuariosPerfilesRelacion26012022', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220127044501_ConfiguraUsuariosPerfilesRelacion_2_26012022', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220127050715_ConfiguraUsuariosPerfilesRelacion_3_26012022', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220127050745_ConfiguraUsuariosPerfilesRelacion_4_26012022', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220201004328_UsuarioModificacion', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220205230111_Fixes02052022', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220205231441_2nd_Fixes02052022', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220206222544_3rd_Fixes06022022', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220206224039_4th_Fixes06022022', N'6.0.1')
GO
SET IDENTITY_INSERT [dbo].[Perfiles] ON 

INSERT [dbo].[Perfiles] ([Id], [NombrePerfil], [Activo]) VALUES (1, N'Administrador', 1)
INSERT [dbo].[Perfiles] ([Id], [NombrePerfil], [Activo]) VALUES (2, N'Socio Ambientalista', 1)
SET IDENTITY_INSERT [dbo].[Perfiles] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuarioAcceso] ON 

INSERT [dbo].[UsuarioAcceso] ([Id], [NombreUsuario], [Constraseña], [Identificador], [FechaCreacion], [FechaModificacion], [Activo], [usuarioId]) VALUES (1, N'davidAguilar ', N'prueba123', N'234817c3-0f1c-488d-9c22-3457fdd1443b', CAST(N'2022-02-06T17:43:54.5349790' AS DateTime2), CAST(N'2022-02-06T17:43:54.5350867' AS DateTime2), 1, NULL)
INSERT [dbo].[UsuarioAcceso] ([Id], [NombreUsuario], [Constraseña], [Identificador], [FechaCreacion], [FechaModificacion], [Activo], [usuarioId]) VALUES (2, N'juanPerez', N'prueba123', N'33586776-308e-4f91-b46c-d1c1a37f3b63', CAST(N'2022-04-06T19:24:05.7639793' AS DateTime2), CAST(N'2022-04-06T19:24:05.7640391' AS DateTime2), 1, NULL)
SET IDENTITY_INSERT [dbo].[UsuarioAcceso] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Direccion], [Telefono1], [Telefono2], [CodigoPostal], [FechaCreacion], [FechaModificacion], [Activo], [perfilId], [usuarioAccesoId]) VALUES (1, N'David Ernesto', N'Aguilar ', N'Gamez', N'5 Polaris Way', N'9497168757', NULL, 92656, N'02/06/2022 17:42:54', N'02/06/2022 17:42:54', 1, 1, 1)
INSERT [dbo].[Usuarios] ([Id], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Direccion], [Telefono1], [Telefono2], [CodigoPostal], [FechaCreacion], [FechaModificacion], [Activo], [perfilId], [usuarioAccesoId]) VALUES (2, N'Juan ', N'Perez', N'Ruiz', N'5 Polaris Way', N'9497168757', N'8114821243', 92656, N'04/06/2022 19:24:05', N'04/06/2022 19:24:05', 1, 1, 2)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  Index [IX_Usuarios_perfilId]    Script Date: 4/6/2022 8:18:50 PM ******/
CREATE NONCLUSTERED INDEX [IX_Usuarios_perfilId] ON [dbo].[Usuarios]
(
	[perfilId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuarios_usuarioAccesoId]    Script Date: 4/6/2022 8:18:50 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Usuarios_usuarioAccesoId] ON [dbo].[Usuarios]
(
	[usuarioAccesoId] ASC
)
WHERE ([usuarioAccesoId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Perfiles_perfilId] FOREIGN KEY([perfilId])
REFERENCES [dbo].[Perfiles] ([Id])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Perfiles_perfilId]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_UsuarioAcceso_usuarioAccesoId] FOREIGN KEY([usuarioAccesoId])
REFERENCES [dbo].[UsuarioAcceso] ([Id])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_UsuarioAcceso_usuarioAccesoId]
GO
USE [master]
GO
ALTER DATABASE [AyureBD] SET  READ_WRITE 
GO
