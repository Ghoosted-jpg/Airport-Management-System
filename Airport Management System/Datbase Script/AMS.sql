USE [master]
GO
/****** Object:  Database [AMS]    Script Date: 7/20/2024 4:11:58 AM ******/
CREATE DATABASE [AMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\AMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\AMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [AMS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [AMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AMS] SET RECOVERY FULL 
GO
ALTER DATABASE [AMS] SET  MULTI_USER 
GO
ALTER DATABASE [AMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AMS', N'ON'
GO
ALTER DATABASE [AMS] SET QUERY_STORE = ON
GO
ALTER DATABASE [AMS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [AMS]
GO
/****** Object:  Table [dbo].[Airline]    Script Date: 7/20/2024 4:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airline](
	[Airline_Name] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[Since] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Airline] PRIMARY KEY CLUSTERED 
(
	[Airline_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Airplanes]    Script Date: 7/20/2024 4:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airplanes](
	[Model_No] [varchar](50) NOT NULL,
	[Capacity] [varchar](50) NOT NULL,
	[Fuel_Capacity] [varchar](50) NOT NULL,
	[Airline_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Airplanes] PRIMARY KEY CLUSTERED 
(
	[Model_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Airport]    Script Date: 7/20/2024 4:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airport](
	[Airport_Name] [varchar](50) NOT NULL,
	[Size] [varchar](50) NOT NULL,
	[Area] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Airport] PRIMARY KEY CLUSTERED 
(
	[Airport_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Airport_Airline]    Script Date: 7/20/2024 4:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airport_Airline](
	[Airport_Name] [varchar](50) NOT NULL,
	[Airline_Name] [varchar](50) NOT NULL,
	[Date] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Airport_Airline] PRIMARY KEY CLUSTERED 
(
	[Airport_Name] ASC,
	[Airline_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Boarding]    Script Date: 7/20/2024 4:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boarding](
	[Boarding_ID] [varchar](50) NOT NULL,
	[Time] [varchar](50) NOT NULL,
	[Schedule_No] [varchar](50) NOT NULL,
	[Gate_No] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Boarding] PRIMARY KEY CLUSTERED 
(
	[Boarding_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cabs]    Script Date: 7/20/2024 4:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cabs](
	[Cab_ID] [varchar](50) NOT NULL,
	[Model] [varchar](50) NOT NULL,
	[Company] [varchar](50) NOT NULL,
	[Airport_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cabs] PRIMARY KEY CLUSTERED 
(
	[Cab_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_Passenger]    Script Date: 7/20/2024 4:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_Passenger](
	[CNIC] [varchar](50) NOT NULL,
	[Emp_ID] [varchar](50) NOT NULL,
	[Date] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Employee_Passenger] PRIMARY KEY CLUSTERED 
(
	[CNIC] ASC,
	[Emp_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 7/20/2024 4:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Emp_ID] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DOB] [varchar](50) NOT NULL,
	[Designation] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[H_no] [varchar](50) NOT NULL,
	[Area] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[Salary] [varchar](50) NOT NULL,
	[Phone_No] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Airport_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Emp_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flights]    Script Date: 7/20/2024 4:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flights](
	[Flight_ID] [varchar](50) NOT NULL,
	[Departure] [varchar](50) NOT NULL,
	[Arrival] [varchar](50) NOT NULL,
	[Source] [varchar](50) NOT NULL,
	[Destination] [varchar](50) NOT NULL,
	[Schedule_No] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Flights] PRIMARY KEY CLUSTERED 
(
	[Flight_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gates]    Script Date: 7/20/2024 4:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gates](
	[Gate_No] [varchar](50) NOT NULL,
	[Terminal_No] [varchar](50) NOT NULL,
	[Airport_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Gates] PRIMARY KEY CLUSTERED 
(
	[Gate_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Luggage]    Script Date: 7/20/2024 4:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luggage](
	[Luggage_Id] [varchar](50) NOT NULL,
	[Weight] [varchar](50) NOT NULL,
	[CNIC] [varchar](50) NOT NULL,
	[Flight_ID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Luggage] PRIMARY KEY CLUSTERED 
(
	[Luggage_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maintenance]    Script Date: 7/20/2024 4:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maintenance](
	[Maintenance_ID] [varchar](50) NOT NULL,
	[Date] [varchar](50) NOT NULL,
	[Cost] [varchar](50) NOT NULL,
	[Airport_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Maintenance] PRIMARY KEY CLUSTERED 
(
	[Maintenance_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passengers]    Script Date: 7/20/2024 4:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passengers](
	[CNIC] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DOB] [varchar](50) NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[H_no] [varchar](50) NOT NULL,
	[Area] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[Flight_ID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Passengers] PRIMARY KEY CLUSTERED 
(
	[CNIC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 7/20/2024 4:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[Schedule_No] [varchar](50) NOT NULL,
	[Airport_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[Schedule_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 7/20/2024 4:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[Ticket_No] [varchar](50) NOT NULL,
	[CNIC] [varchar](50) NOT NULL,
	[Flight_ID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[Ticket_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Airplanes]  WITH CHECK ADD  CONSTRAINT [FK_Airplanes_Airline] FOREIGN KEY([Airline_Name])
REFERENCES [dbo].[Airline] ([Airline_Name])
GO
ALTER TABLE [dbo].[Airplanes] CHECK CONSTRAINT [FK_Airplanes_Airline]
GO
ALTER TABLE [dbo].[Airport_Airline]  WITH CHECK ADD  CONSTRAINT [FK_Airport_Airline_Airline] FOREIGN KEY([Airline_Name])
REFERENCES [dbo].[Airline] ([Airline_Name])
GO
ALTER TABLE [dbo].[Airport_Airline] CHECK CONSTRAINT [FK_Airport_Airline_Airline]
GO
ALTER TABLE [dbo].[Airport_Airline]  WITH CHECK ADD  CONSTRAINT [FK_Airport_Airline_Airport] FOREIGN KEY([Airport_Name])
REFERENCES [dbo].[Airport] ([Airport_Name])
GO
ALTER TABLE [dbo].[Airport_Airline] CHECK CONSTRAINT [FK_Airport_Airline_Airport]
GO
ALTER TABLE [dbo].[Boarding]  WITH CHECK ADD  CONSTRAINT [FK_Boarding_Gates] FOREIGN KEY([Gate_No])
REFERENCES [dbo].[Gates] ([Gate_No])
GO
ALTER TABLE [dbo].[Boarding] CHECK CONSTRAINT [FK_Boarding_Gates]
GO
ALTER TABLE [dbo].[Boarding]  WITH CHECK ADD  CONSTRAINT [FK_Boarding_Schedule] FOREIGN KEY([Schedule_No])
REFERENCES [dbo].[Schedule] ([Schedule_No])
GO
ALTER TABLE [dbo].[Boarding] CHECK CONSTRAINT [FK_Boarding_Schedule]
GO
ALTER TABLE [dbo].[Cabs]  WITH CHECK ADD  CONSTRAINT [FK_Cabs_Airport] FOREIGN KEY([Airport_Name])
REFERENCES [dbo].[Airport] ([Airport_Name])
GO
ALTER TABLE [dbo].[Cabs] CHECK CONSTRAINT [FK_Cabs_Airport]
GO
ALTER TABLE [dbo].[Employee_Passenger]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Passenger_Employees] FOREIGN KEY([Emp_ID])
REFERENCES [dbo].[Employees] ([Emp_ID])
GO
ALTER TABLE [dbo].[Employee_Passenger] CHECK CONSTRAINT [FK_Employee_Passenger_Employees]
GO
ALTER TABLE [dbo].[Employee_Passenger]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Passenger_Passengers] FOREIGN KEY([CNIC])
REFERENCES [dbo].[Passengers] ([CNIC])
GO
ALTER TABLE [dbo].[Employee_Passenger] CHECK CONSTRAINT [FK_Employee_Passenger_Passengers]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Airport] FOREIGN KEY([Airport_Name])
REFERENCES [dbo].[Airport] ([Airport_Name])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Airport]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Flights_Schedule] FOREIGN KEY([Schedule_No])
REFERENCES [dbo].[Schedule] ([Schedule_No])
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Flights_Schedule]
GO
ALTER TABLE [dbo].[Gates]  WITH CHECK ADD  CONSTRAINT [FK_Gates_Airport] FOREIGN KEY([Airport_Name])
REFERENCES [dbo].[Airport] ([Airport_Name])
GO
ALTER TABLE [dbo].[Gates] CHECK CONSTRAINT [FK_Gates_Airport]
GO
ALTER TABLE [dbo].[Luggage]  WITH CHECK ADD  CONSTRAINT [FK_Luggage_Flights] FOREIGN KEY([Flight_ID])
REFERENCES [dbo].[Flights] ([Flight_ID])
GO
ALTER TABLE [dbo].[Luggage] CHECK CONSTRAINT [FK_Luggage_Flights]
GO
ALTER TABLE [dbo].[Luggage]  WITH CHECK ADD  CONSTRAINT [FK_Luggage_Passengers] FOREIGN KEY([CNIC])
REFERENCES [dbo].[Passengers] ([CNIC])
GO
ALTER TABLE [dbo].[Luggage] CHECK CONSTRAINT [FK_Luggage_Passengers]
GO
ALTER TABLE [dbo].[Maintenance]  WITH CHECK ADD  CONSTRAINT [FK_Maintenance_Airport] FOREIGN KEY([Airport_Name])
REFERENCES [dbo].[Airport] ([Airport_Name])
GO
ALTER TABLE [dbo].[Maintenance] CHECK CONSTRAINT [FK_Maintenance_Airport]
GO
ALTER TABLE [dbo].[Passengers]  WITH CHECK ADD  CONSTRAINT [FK_Passengers_Flights] FOREIGN KEY([Flight_ID])
REFERENCES [dbo].[Flights] ([Flight_ID])
GO
ALTER TABLE [dbo].[Passengers] CHECK CONSTRAINT [FK_Passengers_Flights]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Airport] FOREIGN KEY([Airport_Name])
REFERENCES [dbo].[Airport] ([Airport_Name])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Airport]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Flights] FOREIGN KEY([Flight_ID])
REFERENCES [dbo].[Flights] ([Flight_ID])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Flights]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Passengers] FOREIGN KEY([CNIC])
REFERENCES [dbo].[Passengers] ([CNIC])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Passengers]
GO
USE [master]
GO
ALTER DATABASE [AMS] SET  READ_WRITE 
GO
