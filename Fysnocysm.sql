USE [master]
GO
/****** Object:  Database [Fysnocysm]    Script Date: 03/12/2021 17:26:05 ******/
CREATE DATABASE [Fysnocysm]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Fysnocysm', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Fysnocysm.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Fysnocysm_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Fysnocysm_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Fysnocysm] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Fysnocysm].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Fysnocysm] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Fysnocysm] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Fysnocysm] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Fysnocysm] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Fysnocysm] SET ARITHABORT OFF 
GO
ALTER DATABASE [Fysnocysm] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Fysnocysm] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Fysnocysm] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Fysnocysm] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Fysnocysm] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Fysnocysm] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Fysnocysm] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Fysnocysm] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Fysnocysm] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Fysnocysm] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Fysnocysm] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Fysnocysm] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Fysnocysm] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Fysnocysm] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Fysnocysm] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Fysnocysm] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Fysnocysm] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Fysnocysm] SET RECOVERY FULL 
GO
ALTER DATABASE [Fysnocysm] SET  MULTI_USER 
GO
ALTER DATABASE [Fysnocysm] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Fysnocysm] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Fysnocysm] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Fysnocysm] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Fysnocysm] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Fysnocysm] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Fysnocysm', N'ON'
GO
ALTER DATABASE [Fysnocysm] SET QUERY_STORE = OFF
GO
USE [Fysnocysm]
GO
/****** Object:  Table [dbo].[Personne]    Script Date: 03/12/2021 17:26:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personne](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[prenom] [varchar](50) NOT NULL,
	[idSoiree] [int] NULL,
 CONSTRAINT [PK_Personne] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prix]    Script Date: 03/12/2021 17:26:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prix](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[montant] [float] NOT NULL,
	[idPersonne] [int] NOT NULL,
	[idSoiree] [int] NOT NULL,
 CONSTRAINT [PK_Prix] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Soiree]    Script Date: 03/12/2021 17:26:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Soiree](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[lieu] [varchar](50) NOT NULL,
	[date] [date] NOT NULL,
 CONSTRAINT [PK_Soiree] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Personne]  WITH CHECK ADD  CONSTRAINT [FK_Personne_Soiree] FOREIGN KEY([idSoiree])
REFERENCES [dbo].[Soiree] ([ID])
GO
ALTER TABLE [dbo].[Personne] CHECK CONSTRAINT [FK_Personne_Soiree]
GO
ALTER TABLE [dbo].[Prix]  WITH CHECK ADD  CONSTRAINT [FK_Prix_Soiree] FOREIGN KEY([idSoiree])
REFERENCES [dbo].[Soiree] ([ID])
GO
ALTER TABLE [dbo].[Prix] CHECK CONSTRAINT [FK_Prix_Soiree]
GO
USE [master]
GO
ALTER DATABASE [Fysnocysm] SET  READ_WRITE 
GO
