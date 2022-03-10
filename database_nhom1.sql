USE [master]
GO
/****** Object:  Database [DatabaseTienganh]    Script Date: 3/10/2022 3:32:54 PM ******/
CREATE DATABASE [DatabaseTienganh]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DatabaseTienganh', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DatabaseTienganh.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DatabaseTienganh_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DatabaseTienganh_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DatabaseTienganh] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DatabaseTienganh].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DatabaseTienganh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET ARITHABORT OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DatabaseTienganh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DatabaseTienganh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DatabaseTienganh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DatabaseTienganh] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET RECOVERY FULL 
GO
ALTER DATABASE [DatabaseTienganh] SET  MULTI_USER 
GO
ALTER DATABASE [DatabaseTienganh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DatabaseTienganh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DatabaseTienganh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DatabaseTienganh] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DatabaseTienganh] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DatabaseTienganh] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DatabaseTienganh', N'ON'
GO
ALTER DATABASE [DatabaseTienganh] SET QUERY_STORE = OFF
GO
USE [DatabaseTienganh]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 3/10/2022 3:32:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 3/10/2022 3:32:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[GradeID] [int] NOT NULL,
	[Room] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 3/10/2022 3:32:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TimeToStudy] [int] NOT NULL,
	[Cost] [int] NOT NULL,
	[BranchID] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 3/10/2022 3:32:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[Phone] [nchar](20) NOT NULL,
	[Qualification] [nchar](30) NOT NULL,
	[Nation] [nchar](10) NOT NULL,
	[Position] [nchar](30) NOT NULL,
	[Salary] [int] NULL,
	[BranchID] [int] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 3/10/2022 3:32:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[StartTime] [nchar](10) NOT NULL,
	[StudyDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Register]    Script Date: 3/10/2022 3:32:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Register](
	[ClassID] [int] NOT NULL,
	[StudentID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 3/10/2022 3:32:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[Phone] [nchar](20) NOT NULL,
	[Address] [nvarchar](150) NOT NULL,
	[BranchID] [int] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_Salary]  DEFAULT ((0)) FOR [Salary]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([ID])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Courses]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Employees]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Grades] FOREIGN KEY([GradeID])
REFERENCES [dbo].[Grades] ([ID])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Grades]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Branches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branches] ([ID])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Branches]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Branches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branches] ([ID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Branches]
GO
ALTER TABLE [dbo].[Register]  WITH CHECK ADD  CONSTRAINT [FK_Register_Classes] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Classes] ([ID])
GO
ALTER TABLE [dbo].[Register] CHECK CONSTRAINT [FK_Register_Classes]
GO
ALTER TABLE [dbo].[Register]  WITH CHECK ADD  CONSTRAINT [FK_Register_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([ID])
GO
ALTER TABLE [dbo].[Register] CHECK CONSTRAINT [FK_Register_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Branches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branches] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Branches]
GO
USE [master]
GO
ALTER DATABASE [DatabaseTienganh] SET  READ_WRITE 
GO
