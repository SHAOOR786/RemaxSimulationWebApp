USE [master]
GO
/****** Object:  Database [FinalDatabase]    Script Date: 2020-12-15 8:09:53 PM ******/
CREATE DATABASE [FinalDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FinalDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MYSQL2017\MSSQL\DATA\FinalDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FinalDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MYSQL2017\MSSQL\DATA\FinalDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FinalDatabase] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FinalDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FinalDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FinalDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FinalDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FinalDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FinalDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [FinalDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FinalDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FinalDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FinalDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FinalDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FinalDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FinalDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FinalDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FinalDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FinalDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FinalDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FinalDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FinalDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FinalDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FinalDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FinalDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FinalDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FinalDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FinalDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [FinalDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FinalDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FinalDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FinalDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FinalDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FinalDatabase] SET QUERY_STORE = OFF
GO
USE [FinalDatabase]
GO
/****** Object:  Table [dbo].[apointement]    Script Date: 2020-12-15 8:09:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[apointement](
	[apointmentId] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NOT NULL,
	[time] [time](7) NOT NULL,
	[managerId] [nvarchar](50) NOT NULL,
	[tenentId] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[apointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[appartement]    Script Date: 2020-12-15 8:09:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[appartement](
	[appartementNo] [int] NOT NULL,
	[buildingNo] [nvarchar](50) NOT NULL,
	[statusId] [nvarchar](50) NOT NULL,
	[roomNo] [int] NOT NULL,
	[washroomNo] [int] NOT NULL,
	[floorNo] [int] NOT NULL,
	[tenantId] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[appartementNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[building]    Script Date: 2020-12-15 8:09:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[building](
	[buildingNo] [nvarchar](50) NOT NULL,
	[streetName] [nvarchar](200) NOT NULL,
	[postalCode] [nvarchar](50) NOT NULL,
	[city] [nvarchar](50) NOT NULL,
	[province] [nvarchar](50) NOT NULL,
	[ownerId] [nvarchar](50) NOT NULL,
	[managerId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_building] PRIMARY KEY CLUSTERED 
(
	[buildingNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[manager]    Script Date: 2020-12-15 8:09:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[manager](
	[managerId] [nvarchar](50) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[email] [nvarchar](200) NOT NULL,
	[phoneNumber] [nvarchar](50) NOT NULL,
	[password] [nvarchar](200) NOT NULL,
	[ownerId] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[managerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[managerOwnerMessage]    Script Date: 2020-12-15 8:09:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[managerOwnerMessage](
	[messageId] [int] IDENTITY(1,1) NOT NULL,
	[managerId] [nvarchar](50) NOT NULL,
	[ownerId] [nvarchar](50) NOT NULL,
	[message] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[messageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[owner]    Script Date: 2020-12-15 8:09:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[owner](
	[ownerId] [nvarchar](50) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[phoneNumber] [nvarchar](50) NOT NULL,
	[email] [nvarchar](200) NOT NULL,
	[password] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ownerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[status]    Script Date: 2020-12-15 8:09:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[status](
	[statusId] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[statusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tenant]    Script Date: 2020-12-15 8:09:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tenant](
	[userId] [nvarchar](50) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[phoneNumber] [nvarchar](50) NOT NULL,
	[email] [nvarchar](200) NOT NULL,
	[password] [nvarchar](200) NOT NULL,
	[managerId] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tenantManagerMessage]    Script Date: 2020-12-15 8:09:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tenantManagerMessage](
	[messageId] [int] IDENTITY(1,1) NOT NULL,
	[managerId] [nvarchar](50) NOT NULL,
	[tenantId] [nvarchar](50) NOT NULL,
	[message] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[messageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[apointement] ON 

INSERT [dbo].[apointement] ([apointmentId], [date], [time], [managerId], [tenentId]) VALUES (1, CAST(N'2020-02-02' AS Date), CAST(N'11:59:00' AS Time), N'Mgr1', N'shaoor1')
INSERT [dbo].[apointement] ([apointmentId], [date], [time], [managerId], [tenentId]) VALUES (5, CAST(N'2020-02-02' AS Date), CAST(N'11:59:00' AS Time), N'Mgr1', N'shaoor1')
INSERT [dbo].[apointement] ([apointmentId], [date], [time], [managerId], [tenentId]) VALUES (6, CAST(N'2020-02-02' AS Date), CAST(N'11:59:00' AS Time), N'Mgr1', N'shaoor1')
SET IDENTITY_INSERT [dbo].[apointement] OFF
GO
INSERT [dbo].[appartement] ([appartementNo], [buildingNo], [statusId], [roomNo], [washroomNo], [floorNo], [tenantId]) VALUES (203, N'4020', N'Available', 2, 2, 2, N'Gujju')
INSERT [dbo].[appartement] ([appartementNo], [buildingNo], [statusId], [roomNo], [washroomNo], [floorNo], [tenantId]) VALUES (206, N'4030', N'Available', 2, 2, 2, N'shaoor1')
GO
INSERT [dbo].[building] ([buildingNo], [streetName], [postalCode], [city], [province], [ownerId], [managerId]) VALUES (N'300', N'saint catherine', N'7y7y6y', N'montreal', N'quebec', N'Owner1', N'Mgr1')
INSERT [dbo].[building] ([buildingNo], [streetName], [postalCode], [city], [province], [ownerId], [managerId]) VALUES (N'4020', N'Cote Dinesh', N'h7h6g6', N'Montreal', N'quebec', N'Owner2', N'Mgr2')
INSERT [dbo].[building] ([buildingNo], [streetName], [postalCode], [city], [province], [ownerId], [managerId]) VALUES (N'4030', N'boul des sources', N'h9b7h7', N'montreal', N'quebec', N'Owner1', N'Mgr1')
GO
INSERT [dbo].[manager] ([managerId], [firstName], [lastName], [email], [phoneNumber], [password], [ownerId]) VALUES (N'Mgr1', N'Utkarsh', N'Vrama', N'uv@gmail.com', N'5147678687', N'Mgr1', N'Owner1')
INSERT [dbo].[manager] ([managerId], [firstName], [lastName], [email], [phoneNumber], [password], [ownerId]) VALUES (N'Mgr2', N'Dakah', N'Parashar', N'Daksh@gmail.com', N'5143465433', N'Mgr2', N'Owner1')
INSERT [dbo].[manager] ([managerId], [firstName], [lastName], [email], [phoneNumber], [password], [ownerId]) VALUES (N'Mgr3', N'Daniel', N'Joe', N'Joe@gmail.com', N'514564545', N'Mgr3', N'Owner2')
INSERT [dbo].[manager] ([managerId], [firstName], [lastName], [email], [phoneNumber], [password], [ownerId]) VALUES (N'Mgr4', N'Josh', N'Halen', N'halen@gmail.com', N'514345433', N'Mgr4', N'Owner2')
GO
SET IDENTITY_INSERT [dbo].[managerOwnerMessage] ON 

INSERT [dbo].[managerOwnerMessage] ([messageId], [managerId], [ownerId], [message]) VALUES (1, N'Mgr1', N'Owner1', N'halo yes sir')
SET IDENTITY_INSERT [dbo].[managerOwnerMessage] OFF
GO
INSERT [dbo].[owner] ([ownerId], [firstName], [lastName], [phoneNumber], [email], [password]) VALUES (N'Owner1', N'shaoor ', N'hashmi', N'5145610987', N'shaoor@gmail.com', N'Owner1')
INSERT [dbo].[owner] ([ownerId], [firstName], [lastName], [phoneNumber], [email], [password]) VALUES (N'Owner2', N'Gurbaj', N'Singh', N'514675432', N'Gurbaj', N'Owner2')
GO
INSERT [dbo].[status] ([statusId]) VALUES (N'Available')
INSERT [dbo].[status] ([statusId]) VALUES (N'Un-Available')
GO
INSERT [dbo].[tenant] ([userId], [firstName], [lastName], [phoneNumber], [email], [password], [managerId]) VALUES (N'Gujju', N'Gurbaj ', N'Singh', N'546476587', N'Gurbaj@gmail.com', N'Gujju', N'Mgr2')
INSERT [dbo].[tenant] ([userId], [firstName], [lastName], [phoneNumber], [email], [password], [managerId]) VALUES (N'shaoor1', N'shaoor ud din ', N'hashmi', N'514667765', N'shaoor@gmail.com', N'shaoor1', N'Mgr1')
GO
SET IDENTITY_INSERT [dbo].[tenantManagerMessage] ON 

INSERT [dbo].[tenantManagerMessage] ([messageId], [managerId], [tenantId], [message]) VALUES (1, N'Mgr1', N'shaoor1', N'hi sir i just want to let you know that my kitchen''s fridge is not working i fixed i hope you will cooperate with in the meeting')
INSERT [dbo].[tenantManagerMessage] ([messageId], [managerId], [tenantId], [message]) VALUES (2, N'Mgr1', N'shaoor1', N'hi sir i just want to let you know that my kitchen''s fridge is not working i fixed i hope you will cooperate with in the meeting')
INSERT [dbo].[tenantManagerMessage] ([messageId], [managerId], [tenantId], [message]) VALUES (3, N'Mgr1', N'shaoor1', N'halo yes sir')
INSERT [dbo].[tenantManagerMessage] ([messageId], [managerId], [tenantId], [message]) VALUES (4, N'Mgr1', N'shaoor1', N'halo yes sir')
INSERT [dbo].[tenantManagerMessage] ([messageId], [managerId], [tenantId], [message]) VALUES (5, N'Mgr1', N'shaoor1', N'halo yes sir')
INSERT [dbo].[tenantManagerMessage] ([messageId], [managerId], [tenantId], [message]) VALUES (6, N'Mgr1', N'shaoor1', N'halo yes sir')
SET IDENTITY_INSERT [dbo].[tenantManagerMessage] OFF
GO
ALTER TABLE [dbo].[apointement]  WITH CHECK ADD  CONSTRAINT [FK_apointement_manager] FOREIGN KEY([managerId])
REFERENCES [dbo].[manager] ([managerId])
GO
ALTER TABLE [dbo].[apointement] CHECK CONSTRAINT [FK_apointement_manager]
GO
ALTER TABLE [dbo].[apointement]  WITH CHECK ADD  CONSTRAINT [FK_apointement_tenant] FOREIGN KEY([tenentId])
REFERENCES [dbo].[tenant] ([userId])
GO
ALTER TABLE [dbo].[apointement] CHECK CONSTRAINT [FK_apointement_tenant]
GO
ALTER TABLE [dbo].[appartement]  WITH CHECK ADD  CONSTRAINT [FK_appartement_status] FOREIGN KEY([statusId])
REFERENCES [dbo].[status] ([statusId])
GO
ALTER TABLE [dbo].[appartement] CHECK CONSTRAINT [FK_appartement_status]
GO
ALTER TABLE [dbo].[appartement]  WITH CHECK ADD  CONSTRAINT [FK_appartement_tenant] FOREIGN KEY([tenantId])
REFERENCES [dbo].[tenant] ([userId])
GO
ALTER TABLE [dbo].[appartement] CHECK CONSTRAINT [FK_appartement_tenant]
GO
ALTER TABLE [dbo].[building]  WITH CHECK ADD  CONSTRAINT [FK_building_manager] FOREIGN KEY([managerId])
REFERENCES [dbo].[manager] ([managerId])
GO
ALTER TABLE [dbo].[building] CHECK CONSTRAINT [FK_building_manager]
GO
ALTER TABLE [dbo].[building]  WITH CHECK ADD  CONSTRAINT [FK_building_owner] FOREIGN KEY([ownerId])
REFERENCES [dbo].[owner] ([ownerId])
GO
ALTER TABLE [dbo].[building] CHECK CONSTRAINT [FK_building_owner]
GO
ALTER TABLE [dbo].[manager]  WITH CHECK ADD FOREIGN KEY([ownerId])
REFERENCES [dbo].[owner] ([ownerId])
GO
ALTER TABLE [dbo].[managerOwnerMessage]  WITH CHECK ADD FOREIGN KEY([managerId])
REFERENCES [dbo].[manager] ([managerId])
GO
ALTER TABLE [dbo].[managerOwnerMessage]  WITH CHECK ADD FOREIGN KEY([ownerId])
REFERENCES [dbo].[owner] ([ownerId])
GO
ALTER TABLE [dbo].[tenant]  WITH CHECK ADD FOREIGN KEY([managerId])
REFERENCES [dbo].[manager] ([managerId])
GO
ALTER TABLE [dbo].[tenantManagerMessage]  WITH CHECK ADD  CONSTRAINT [FK_tenantManagerMessage_manager] FOREIGN KEY([managerId])
REFERENCES [dbo].[manager] ([managerId])
GO
ALTER TABLE [dbo].[tenantManagerMessage] CHECK CONSTRAINT [FK_tenantManagerMessage_manager]
GO
ALTER TABLE [dbo].[tenantManagerMessage]  WITH CHECK ADD  CONSTRAINT [FK_tenantManagerMessage_tenant] FOREIGN KEY([tenantId])
REFERENCES [dbo].[tenant] ([userId])
GO
ALTER TABLE [dbo].[tenantManagerMessage] CHECK CONSTRAINT [FK_tenantManagerMessage_tenant]
GO
USE [master]
GO
ALTER DATABASE [FinalDatabase] SET  READ_WRITE 
GO
