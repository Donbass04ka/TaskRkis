USE [master]
GO
/****** Object:  Database [sisTask]    Script Date: 06.06.2022 16:46:27 ******/
CREATE DATABASE [sisTask]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sisTask', FILENAME = N'C:\Users\gr611_mavvl\sisTask.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'sisTask_log', FILENAME = N'C:\Users\gr611_mavvl\sisTask_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [sisTask] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sisTask].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sisTask] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sisTask] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sisTask] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sisTask] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sisTask] SET ARITHABORT OFF 
GO
ALTER DATABASE [sisTask] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [sisTask] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sisTask] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sisTask] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sisTask] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sisTask] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sisTask] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sisTask] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sisTask] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sisTask] SET  DISABLE_BROKER 
GO
ALTER DATABASE [sisTask] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sisTask] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sisTask] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sisTask] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sisTask] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sisTask] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [sisTask] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sisTask] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [sisTask] SET  MULTI_USER 
GO
ALTER DATABASE [sisTask] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sisTask] SET DB_CHAINING OFF 
GO
ALTER DATABASE [sisTask] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [sisTask] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [sisTask] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [sisTask] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [sisTask] SET QUERY_STORE = OFF
GO
USE [sisTask]
GO
/****** Object:  Table [dbo].[StatusTask]    Script Date: 06.06.2022 16:46:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusTask](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nchar](15) NOT NULL,
 CONSTRAINT [PK_StatusTask] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 06.06.2022 16:46:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nchar](60) NOT NULL,
	[Writing] [nchar](300) NOT NULL,
	[Data] [date] NOT NULL,
	[IdWorker] [int] NULL,
	[IdAuthor] [int] NOT NULL,
	[IdStatus] [int] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 06.06.2022 16:46:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SecondName] [nchar](30) NOT NULL,
	[Name] [nchar](30) NOT NULL,
	[Patric] [nchar](30) NOT NULL,
	[Login] [nchar](25) NOT NULL,
	[Password] [nchar](50) NOT NULL,
	[NumberPhone] [nchar](10) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[StatusTask] ON 

INSERT [dbo].[StatusTask] ([Id], [Title]) VALUES (1, N'Готово         ')
INSERT [dbo].[StatusTask] ([Id], [Title]) VALUES (2, N'Свободно       ')
INSERT [dbo].[StatusTask] ([Id], [Title]) VALUES (3, N'???????????    ')
SET IDENTITY_INSERT [dbo].[StatusTask] OFF
GO
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([Id], [Title], [Writing], [Data], [IdWorker], [IdAuthor], [IdStatus]) VALUES (1, N'Создать 3D портрет Путина                                   ', N'С помощью ПО Блендер создать портрет с возможностью последующего изменения                                                                                                                                                                                                                                  ', CAST(N'2022-05-28' AS Date), 5, 1, 2)
INSERT [dbo].[Task] ([Id], [Title], [Writing], [Data], [IdWorker], [IdAuthor], [IdStatus]) VALUES (2, N'Пикник                                                      ', N'Создать сайт по поиску людей для пикников                                                                                                                                                                                                                                                                   ', CAST(N'2022-05-12' AS Date), 5, 2, 2)
SET IDENTITY_INSERT [dbo].[Task] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [SecondName], [Name], [Patric], [Login], [Password], [NumberPhone]) VALUES (1, N'Павлов                        ', N'Сыр                           ', N'Геннадьевич                   ', N'qwe                      ', N'qwe                                               ', N'9505373127')
INSERT [dbo].[User] ([Id], [SecondName], [Name], [Patric], [Login], [Password], [NumberPhone]) VALUES (2, N'Михайлов                      ', N'Торт                          ', N'Павлович                      ', N'qweqwe                   ', N'qweqwe                                            ', N'9505373126')
INSERT [dbo].[User] ([Id], [SecondName], [Name], [Patric], [Login], [Password], [NumberPhone]) VALUES (3, N'Печенькин                     ', N'Валидатор                     ', N'Буллович                      ', N'qweqweqwe                ', N'qweqweqwe                                         ', N'9505373128')
INSERT [dbo].[User] ([Id], [SecondName], [Name], [Patric], [Login], [Password], [NumberPhone]) VALUES (5, N'                              ', N'                              ', N'                              ', N'                         ', N'                                                  ', N'0000000000')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_StatusTask] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[StatusTask] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_StatusTask]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_User] FOREIGN KEY([IdWorker])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_User]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_User1] FOREIGN KEY([IdAuthor])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_User1]
GO
USE [master]
GO
ALTER DATABASE [sisTask] SET  READ_WRITE 
GO
