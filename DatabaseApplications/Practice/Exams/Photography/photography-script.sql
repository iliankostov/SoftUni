USE [master]
GO
/****** Object:  Database [PhotographySystem]    Script Date: 6/23/2015 9:22:02 AM ******/
CREATE DATABASE [PhotographySystem]
GO
ALTER DATABASE [PhotographySystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PhotographySystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PhotographySystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PhotographySystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PhotographySystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PhotographySystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PhotographySystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [PhotographySystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PhotographySystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PhotographySystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PhotographySystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PhotographySystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PhotographySystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PhotographySystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PhotographySystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PhotographySystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PhotographySystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PhotographySystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PhotographySystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PhotographySystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PhotographySystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PhotographySystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PhotographySystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PhotographySystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PhotographySystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PhotographySystem] SET RECOVERY FULL 
GO
ALTER DATABASE [PhotographySystem] SET  MULTI_USER 
GO
ALTER DATABASE [PhotographySystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PhotographySystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PhotographySystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PhotographySystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PhotographySystem', N'ON'
GO
USE [PhotographySystem]
GO
/****** Object:  Table [dbo].[Albums]    Script Date: 6/23/2015 9:22:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AlbumsPhotographs]    Script Date: 6/23/2015 9:22:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumsPhotographs](
	[AlbumId] [int] NOT NULL,
	[PhotographId] [int] NOT NULL,
 CONSTRAINT [PK_AlbumsPhotographs] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC,
	[PhotographId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cameras]    Script Date: 6/23/2015 9:22:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cameras](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ManufacturerId] [int] NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Year] [int] NOT NULL,
	[Price] [money] NULL,
	[Megapixels] [int] NULL,
 CONSTRAINT [PK_Cameras] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/23/2015 9:22:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Equipments]    Script Date: 6/23/2015 9:22:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LensId] [int] NULL,
	[CameraId] [int] NOT NULL,
 CONSTRAINT [PK_Equipments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lenses]    Script Date: 6/23/2015 9:22:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lenses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ManufacturerId] [int] NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Price] [money] NULL,
 CONSTRAINT [PK_Lenses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Manufacturers]    Script Date: 6/23/2015 9:22:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Manufacturers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Photographs]    Script Date: 6/23/2015 9:22:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photographs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[CategoryId] [int] NOT NULL,
	[EquipmentId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Link] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Photographs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/23/2015 9:22:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](30) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[EquipmentId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Albums] ON 

INSERT [dbo].[Albums] ([Id], [Name], [UserId], [Description]) VALUES (1, N'Mobile', 3, N'Mobile uploads')
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [Description]) VALUES (2, N'SoftUni Teambuilding', 3, N'Специални благодарности на: Angel Marchev, Влади, Atanas Petkov, Boni Mislyashki, Ivaylo Iliev, Goran Radkov за цялия съпорт. : ) Благодаря ви, момчета. За пореден път се убеждавам, че преди 5 години попаднах на правилното място - при вас. : ) Благодаря ви, че бяхте до мен в този ден и заедно направихме един страхотен тиймбилдинг на студентите от Fundamental Level (May 2015).')
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [Description]) VALUES (3, N'The little things in my life ♥', 3, N'Unforgettable moments...')
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [Description]) VALUES (4, N'OpenFest 2014', 2, N'OpenFest - Sofia, 1-Nov-2014
Лекция за висшето образование в ИТ сферата - проблеми и решения')
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [Description]) VALUES (5, N'Digital Kids Conference - 1 Nov 2014', 2, NULL)
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [Description]) VALUES (6, N'VarnaConf 2013', 2, N'Конференция за програмиране и технологии')
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [Description]) VALUES (7, N'New Year 2015', 1, NULL)
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [Description]) VALUES (8, N'SoftUni Conf May 2014', 1, NULL)
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [Description]) VALUES (9, N'Telerik Academy Team Building GrandFinale', 1, NULL)
SET IDENTITY_INSERT [dbo].[Albums] OFF
INSERT [dbo].[AlbumsPhotographs] ([AlbumId], [PhotographId]) VALUES (1, 3)
INSERT [dbo].[AlbumsPhotographs] ([AlbumId], [PhotographId]) VALUES (1, 7)
INSERT [dbo].[AlbumsPhotographs] ([AlbumId], [PhotographId]) VALUES (1, 18)
INSERT [dbo].[AlbumsPhotographs] ([AlbumId], [PhotographId]) VALUES (2, 10)
INSERT [dbo].[AlbumsPhotographs] ([AlbumId], [PhotographId]) VALUES (2, 18)
INSERT [dbo].[AlbumsPhotographs] ([AlbumId], [PhotographId]) VALUES (2, 19)
INSERT [dbo].[AlbumsPhotographs] ([AlbumId], [PhotographId]) VALUES (3, 19)
INSERT [dbo].[AlbumsPhotographs] ([AlbumId], [PhotographId]) VALUES (3, 20)
INSERT [dbo].[AlbumsPhotographs] ([AlbumId], [PhotographId]) VALUES (3, 21)
INSERT [dbo].[AlbumsPhotographs] ([AlbumId], [PhotographId]) VALUES (4, 1)
INSERT [dbo].[AlbumsPhotographs] ([AlbumId], [PhotographId]) VALUES (4, 3)
INSERT [dbo].[AlbumsPhotographs] ([AlbumId], [PhotographId]) VALUES (4, 7)
INSERT [dbo].[AlbumsPhotographs] ([AlbumId], [PhotographId]) VALUES (4, 10)
INSERT [dbo].[AlbumsPhotographs] ([AlbumId], [PhotographId]) VALUES (4, 19)
SET IDENTITY_INSERT [dbo].[Cameras] ON 

INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (1, 4, N'K-3 II', 2015, 969.0000, 24)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (2, 4, N'K-S2', 2015, 860.0000, 20)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (3, 4, N'K-S1', 2014, 360.0000, 20)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (5, 4, N'Q-S1', 2014, 297.0000, 12)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (7, 4, N'XG-1', 2014, 165.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (8, 4, N'645Z', 2014, 8024.0000, 51)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (9, 4, N'K-3', 2013, 979.0000, 24)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (10, 4, N'K-50', 2013, 423.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (11, 4, N'Q7', 2013, 420.0000, 12)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (12, 4, N'K-500', 2013, 650.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (13, 4, N'Efina', 2013, 2.0000, 14)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (14, 4, N'WG-3 GPS', 2013, 339.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (15, 4, N'WG-3', 2013, 359.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (16, 4, N'WG-10', 2013, 360.0000, 15)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (17, 4, N'MX-1', 2013, 520.0000, 12)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (18, 4, N'K-5 II', 2012, 998.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (19, 4, N'Q10', 2012, 250.0000, 12)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (20, 4, N'X-5', 2012, 575.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (21, 4, N'K-30', 2012, 890.0000, 14)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (22, 5, N'PowerShot G3 X', 2015, 999.0000, 20)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (23, 5, N'5DS', 2015, 3899.0000, 51)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (24, 5, N'XC10', 2015, NULL, 12)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (25, 5, N'EOS 760D', 2015, 1298.0000, 24)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (26, 5, N'EOS 750D', 2015, 749.0000, 24)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (27, 5, N'PowerShot SX410 IS', 2015, 249.0000, 20)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (28, 5, N'EOS M3', 2015, NULL, 24)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (29, 5, N'PowerShot SX530 HS', 2015, 299.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (30, 5, N'PowerShot SX710 HS', 2015, 329.0000, 20)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (31, 5, N'PowerShot SX610 HS', 2014, 296.0000, 20)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (32, 5, N'PowerShot SX60 HS', 2014, 479.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (33, 5, N'EOS 7D Mark II', 2014, 2248.0000, 20)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (34, 5, N'PowerShot G7 X', 2014, 649.0000, 18)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (35, 5, N'EOS 1200D', 2014, 849.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (36, 5, N'PowerShot SX700 HS', 2014, 515.0000, 12)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (37, 6, N'X-T10', 2015, 799.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (38, 6, N'X-A2', 2015, 550.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (39, 6, N'XQ2', 2015, 399.0000, 12)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (40, 6, N'FinePix S9800', 2015, 245.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (41, 6, N'FixePix S990W', 2015, 287.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (42, 6, N'X100T', 2014, 1299.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (43, 6, N'X30', 2014, 599.0000, 12)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (44, 6, N'X-T1', 2014, 1899.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (45, 6, N'FinePix S1', 2014, 330.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (46, 6, N'FixePix S8600', 2014, 123.0000, 14)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (47, 6, N'FixePix S9400W', 2014, 300.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (48, 6, N'X-E2', 2013, 685.0000, 13)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (49, 6, N'XQ1', 2013, 375.0000, 14)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (50, 7, N'Q (Typ 116)', 2015, NULL, 24)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (51, 7, N'M Monochrom (Typ 246)', 2015, NULL, 22)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (52, 7, N'X (Typ 113)', 2014, NULL, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (53, 7, N'M Edition 60', 2014, NULL, 24)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (54, 7, N'C (Typ 112)', 2013, 669.0000, 12)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (55, 7, N'X Vario', 2013, 2099.0000, 14)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (56, 11, N'D7200', 2015, 1644.0000, 24)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (57, 11, N'Coolpix P900', 2015, 597.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (58, 11, N'Coolpix AW130', 2015, 297.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (59, 11, N'Coolpix P610', 2015, 447.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (60, 11, N'Coolpix L840', 2014, 295.0000, 14)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (61, 11, N'D5500', 2015, 1194.0000, 24)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (62, 11, N'D750', 2014, 3697.0000, 24)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (63, 11, N'D810', 2014, 4697.0000, 34)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (64, 11, N'Coolpix S810c', 2014, 347.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (65, 11, N'Coolpix P530', 2014, 269.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (66, 11, N'Coolpix L320', 2014, 250.0000, NULL)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (67, 12, N'NX500', 2015, 600.0000, 28)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (68, 12, N'NX1', 2014, 1299.0000, 28)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (69, 12, N'NX3000', 2014, 530.0000, 20)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (70, 12, N'NX mini', 2014, 298.0000, 21)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (71, 12, N'WB350F', 2014, 210.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (72, 12, N'WB2200F', 2014, 270.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (73, 12, N'NX30', 2014, 796.0000, 20)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (74, 12, N'Galaxy NX', 2013, 1399.0000, 20)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (75, 12, N'WB250F', 2013, 264.0000, 14)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (76, 19, N'Alpha 7R II', 2015, 3198.0000, 42)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (77, 19, N'Cyber-shot DSC-RX100 IV', 2015, 948.0000, 20)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (78, 19, N'Cyber-shot DSC-RX10 II', 2015, 1298.0000, 22)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (79, 19, N'Alpha 7 II', 2014, 1698.0000, 24)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (80, 19, N'Alpha QX1', 2014, 398.0000, 20)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (81, 19, N'Alpha 7S', 2014, 2498.0000, 12)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (82, 19, N'Cyber-shot DSC-WX350', 2014, 320.0000, 18)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (83, 19, N'Alpha 7', 2013, 1596.0000, 24)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (84, 18, N'Lumix DMC G7', 2015, 1098.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (85, 18, N'Lumix DMC GF7', 2015, 544.0000, 16)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (86, 18, N'Lumix DMC-ZS50', 2015, 398.0000, 12)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (87, 18, N'Lumix DMC-LX100', 2014, 725.0000, 13)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (88, 18, N'Lumix DMC-ZS40', 2014, 384.0000, 18)
INSERT [dbo].[Cameras] ([Id], [ManufacturerId], [Model], [Year], [Price], [Megapixels]) VALUES (89, 18, N'Lumix DMC-GH3', 2012, 898.0000, 16)
SET IDENTITY_INSERT [dbo].[Cameras] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Street')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Nature')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Reportage')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Portrait')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (5, N'Landscape')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (6, N'Wild life')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (7, N'Macro')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (8, N'Naturmort')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (9, N'Architecture')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (10, N'Experiment')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (11, N'Advertisement')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (12, N'Panorama')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (13, N'Wedding')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (14, N'Act')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (15, N'Abstract')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (16, N'Travels')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (17, N'Sport')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Equipments] ON 

INSERT [dbo].[Equipments] ([Id], [LensId], [CameraId]) VALUES (1, 4, 25)
INSERT [dbo].[Equipments] ([Id], [LensId], [CameraId]) VALUES (2, 6, 25)
INSERT [dbo].[Equipments] ([Id], [LensId], [CameraId]) VALUES (3, 9, 26)
INSERT [dbo].[Equipments] ([Id], [LensId], [CameraId]) VALUES (5, 8, 29)
INSERT [dbo].[Equipments] ([Id], [LensId], [CameraId]) VALUES (6, 10, 39)
INSERT [dbo].[Equipments] ([Id], [LensId], [CameraId]) VALUES (8, 17, 49)
INSERT [dbo].[Equipments] ([Id], [LensId], [CameraId]) VALUES (9, 15, 42)
INSERT [dbo].[Equipments] ([Id], [LensId], [CameraId]) VALUES (10, 13, 36)
SET IDENTITY_INSERT [dbo].[Equipments] OFF
SET IDENTITY_INSERT [dbo].[Lenses] ON 

INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (1, 5, N'EF 8-15 f/4L Fisheye USM', N'Wideangle fisheye zoom lens', 1249.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (3, 5, N'EF 14mm f/2.8L II USM', N'Wideangle prime lens', 2099.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (4, 5, N'EF 14mm f/2.8L USM', N'Wideangle prime lens', NULL)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (6, 5, N'EF 15mm f/2.8 Fisheye', N'Wideangle fisheye prime lens', NULL)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (8, 5, N'EF 16-35mm f/2.8L II USM', N'Wideangle zoom lens', 1599.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (9, 5, N'EF 17-40mm f/4.0L USM', N'Wideangle zoom lens', 799.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (10, 11, N'AF Nikkor 24-85mm f/2.8-4D IF', N'Zoom lens', 729.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (11, 11, N'AF-S DX Nikkor 35mm f/1.8G', N'Prime lens', 197.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (13, 11, N'AF-S Micro-Nikkor 60mm f/2.8G ED', N'Macro prime lens', 529.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (14, 11, N'AF-S DX Nikkor 55-200mm f/4-5.6G VR II', N'Telephoto zoom lens', 347.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (15, 11, N'AF-S Micro-Nikkor 105mm f/2.8G IF-ED VR', N'Telephoto macro prime lens', 982.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (16, 11, N'AF-S Nikkor 24-85mm F3.5-4.5G ED VR', N'Zoom lens', 597.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (17, 11, N'AF-S Nikkor 600mm f/4G ED VR', N'Telephoto prime lens', 9699.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (18, 19, N'70-200mm F2.8 G', N'Telephoto zoom lens', 2458.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (19, 19, N'70-300mm F4.5-5.6 G SSM', N'Telephoto zoom lens', 998.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (20, 19, N'100mm F2.8 Macro', N'Telephoto macro prime lens', 748.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (21, 19, N'85mm F2.8 SAM', N'Telephoto prime lens', 273.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (22, 19, N'500mm F4 G SSM', N'Telephoto prime lens', 11997.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (23, 19, N'DT 11-18mm F4.5-5.6', N'Wideangle zoom lens', 748.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (24, 4, N'DA 55-300mm F4.0-5.8 ED WR', N'Telephoto zoom lens', 397.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (25, 4, N'DA 21mm F3.2 AL Limited', N'Wideangle prime lens', 500.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (26, 4, N'DA 16-85mm F3.5-5.6 ED DC WR', N'Zoom lens', NULL)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (27, 16, N'10mm F2.8 EX DC HSM Diagonal Fisheye', N'Wideangle fisheye prime lens', 649.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (28, 16, N'12-24mm F4.5-5.6 II DG HSM', N'Wideangle zoom lens', 949.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (29, 16, N'15mm F2.8 EX DG Diagonal Fisheye', N'Wideangle fisheye prime lens', 830.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (30, 18, N'Lumix G Fisheye 8mm F3.5', N'Wideangle fisheye prime lens', 641.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (31, 18, N'Lumix G Vario 14-45mm F3.5-5.6 ASPH OIS', N'Zoom lens', 392.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (32, 15, N'M.Zuiko Digital ED 8mm F1.8 Fisheye Pro', N'Wideangle fisheye prime lens', 946.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (33, 15, N'Zuiko Digital ED 50-200mm 1:2.8-3.5 SWD', N'Telephoto zoom lens', 1180.0000)
INSERT [dbo].[Lenses] ([Id], [ManufacturerId], [Model], [Type], [Price]) VALUES (34, 15, N'Zuiko Digital ED 150mm 1:2.0', N'Telephoto prime lens', NULL)
SET IDENTITY_INSERT [dbo].[Lenses] OFF
SET IDENTITY_INSERT [dbo].[Manufacturers] ON 

INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (1, N'Agfa')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (2, N'Epson')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (3, N'Kyocera')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (4, N'Pentax')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (5, N'Canon')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (6, N'Fujifilm')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (7, N'Leica')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (8, N'Ricoh')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (9, N'Casio')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (10, N'HP')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (11, N'Nikon')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (12, N'Samsung')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (13, N'Contax')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (14, N'Kodak')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (15, N'Olympus')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (16, N'Sigma')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (17, N'Konica Minolta')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (18, N'Panasonic')
INSERT [dbo].[Manufacturers] ([Id], [Name]) VALUES (19, N'Sony')
SET IDENTITY_INSERT [dbo].[Manufacturers] OFF
SET IDENTITY_INSERT [dbo].[Photographs] ON 

INSERT [dbo].[Photographs] ([Id], [Title], [Description], [CategoryId], [EquipmentId], [UserId], [Link]) VALUES (1, N'Жита', NULL, 3, 1, 2, N'http://photo-forum.net/i/1919442')
INSERT [dbo].[Photographs] ([Id], [Title], [Description], [CategoryId], [EquipmentId], [UserId], [Link]) VALUES (3, N'.', NULL, 4, 2, 3, N'http://photo-forum.net/i/1920515')
INSERT [dbo].[Photographs] ([Id], [Title], [Description], [CategoryId], [EquipmentId], [UserId], [Link]) VALUES (4, N'Dog', NULL, 1, 3, 1, N'http://photo-forum.net/i/1920281')
INSERT [dbo].[Photographs] ([Id], [Title], [Description], [CategoryId], [EquipmentId], [UserId], [Link]) VALUES (7, N'Tilma Lek ', N'https://www.youtube.com/watch?v=wJN9GN0xzdk', 1, 5, 2, N'http://photo-forum.net/i/1920390')
INSERT [dbo].[Photographs] ([Id], [Title], [Description], [CategoryId], [EquipmentId], [UserId], [Link]) VALUES (10, N'Идват!', NULL, 1, 6, 1, N'http://photo-forum.net/i/1920370')
INSERT [dbo].[Photographs] ([Id], [Title], [Description], [CategoryId], [EquipmentId], [UserId], [Link]) VALUES (18, N'Кацнал на едно дърво...', NULL, 2, 3, 2, N'http://photo-forum.net/i/1920004')
INSERT [dbo].[Photographs] ([Id], [Title], [Description], [CategoryId], [EquipmentId], [UserId], [Link]) VALUES (19, N'Духовито време... ', N'мястото е на Царево', 4, 5, 3, N'http://photo-forum.net/i/1920110')
INSERT [dbo].[Photographs] ([Id], [Title], [Description], [CategoryId], [EquipmentId], [UserId], [Link]) VALUES (20, N'Angel eyes', NULL, 4, 2, 1, N'http://photo-forum.net/i/1919347')
INSERT [dbo].[Photographs] ([Id], [Title], [Description], [CategoryId], [EquipmentId], [UserId], [Link]) VALUES (21, N'Не искам да си тръгваш!', NULL, 4, 3, 3, N'http://photo-forum.net/i/1919931')
SET IDENTITY_INSERT [dbo].[Photographs] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [FullName], [BirthDate], [EquipmentId]) VALUES (1, N'VGeorgiev', N'Vladimir Georgiev', CAST(0x0000832C00000000 AS DateTime), NULL)
INSERT [dbo].[Users] ([Id], [Username], [FullName], [BirthDate], [EquipmentId]) VALUES (2, N'nakov', N'Svetlin Nakov', CAST(0x000072A900000000 AS DateTime), NULL)
INSERT [dbo].[Users] ([Id], [Username], [FullName], [BirthDate], [EquipmentId]) VALUES (3, N'Alex', N'Alexandra Svilarova', CAST(0x0000837B00000000 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [FK_Albums_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [FK_Albums_Users]
GO
ALTER TABLE [dbo].[AlbumsPhotographs]  WITH CHECK ADD  CONSTRAINT [FK_AlbumsPhotographs_Albums] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Albums] ([Id])
GO
ALTER TABLE [dbo].[AlbumsPhotographs] CHECK CONSTRAINT [FK_AlbumsPhotographs_Albums]
GO
ALTER TABLE [dbo].[AlbumsPhotographs]  WITH CHECK ADD  CONSTRAINT [FK_AlbumsPhotographs_Photographs] FOREIGN KEY([PhotographId])
REFERENCES [dbo].[Photographs] ([Id])
GO
ALTER TABLE [dbo].[AlbumsPhotographs] CHECK CONSTRAINT [FK_AlbumsPhotographs_Photographs]
GO
ALTER TABLE [dbo].[Cameras]  WITH CHECK ADD  CONSTRAINT [FK_Cameras_Manufacturers] FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[Manufacturers] ([Id])
GO
ALTER TABLE [dbo].[Cameras] CHECK CONSTRAINT [FK_Cameras_Manufacturers]
GO
ALTER TABLE [dbo].[Equipments]  WITH CHECK ADD  CONSTRAINT [FK_Equipments_Cameras] FOREIGN KEY([CameraId])
REFERENCES [dbo].[Cameras] ([Id])
GO
ALTER TABLE [dbo].[Equipments] CHECK CONSTRAINT [FK_Equipments_Cameras]
GO
ALTER TABLE [dbo].[Equipments]  WITH CHECK ADD  CONSTRAINT [FK_Equipments_Lenses] FOREIGN KEY([LensId])
REFERENCES [dbo].[Lenses] ([Id])
GO
ALTER TABLE [dbo].[Equipments] CHECK CONSTRAINT [FK_Equipments_Lenses]
GO
ALTER TABLE [dbo].[Lenses]  WITH CHECK ADD  CONSTRAINT [FK_Lenses_Manufacturers] FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[Manufacturers] ([Id])
GO
ALTER TABLE [dbo].[Lenses] CHECK CONSTRAINT [FK_Lenses_Manufacturers]
GO
ALTER TABLE [dbo].[Photographs]  WITH CHECK ADD  CONSTRAINT [FK_Photographs_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Photographs] CHECK CONSTRAINT [FK_Photographs_Categories]
GO
ALTER TABLE [dbo].[Photographs]  WITH CHECK ADD  CONSTRAINT [FK_Photographs_Equipments] FOREIGN KEY([EquipmentId])
REFERENCES [dbo].[Equipments] ([Id])
GO
ALTER TABLE [dbo].[Photographs] CHECK CONSTRAINT [FK_Photographs_Equipments]
GO
ALTER TABLE [dbo].[Photographs]  WITH CHECK ADD  CONSTRAINT [FK_Photographs_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Photographs] CHECK CONSTRAINT [FK_Photographs_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Equipments] FOREIGN KEY([EquipmentId])
REFERENCES [dbo].[Equipments] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Equipments]
GO
USE [master]
GO
ALTER DATABASE [PhotographySystem] SET  READ_WRITE 
GO
