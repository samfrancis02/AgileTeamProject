USE [master]
GO
/****** Object:  Database [TransactionDB]    Script Date: 02/02/2025 23:56:24 ******/
CREATE DATABASE [TransactionDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TransactionDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\TransactionDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TransactionDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\TransactionDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TransactionDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TransactionDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TransactionDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TransactionDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TransactionDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TransactionDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TransactionDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TransactionDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TransactionDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TransactionDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TransactionDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TransactionDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TransactionDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TransactionDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TransactionDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TransactionDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TransactionDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TransactionDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TransactionDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TransactionDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TransactionDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TransactionDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TransactionDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TransactionDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TransactionDB] SET RECOVERY FULL 
GO
ALTER DATABASE [TransactionDB] SET  MULTI_USER 
GO
ALTER DATABASE [TransactionDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TransactionDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TransactionDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TransactionDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TransactionDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TransactionDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TransactionDB', N'ON'
GO
ALTER DATABASE [TransactionDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [TransactionDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TransactionDB]
GO
/****** Object:  Table [dbo].[ATMInventories]    Script Date: 02/02/2025 23:56:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ATMInventories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ATMId] [int] NOT NULL,
	[FiftyDenomination] [int] NOT NULL,
	[TwentyDenomination] [int] NOT NULL,
	[TenDenomination] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterCards]    Script Date: 02/02/2025 23:56:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterCards](
	[CardNumber] [varchar](16) NOT NULL,
	[CardHolderName] [varchar](100) NOT NULL,
	[ExpirationDate] [char](5) NOT NULL,
	[CVV] [char](3) NOT NULL,
	[HashedPIN] [varchar](255) NOT NULL,
	[IssuerBank] [varchar](100) NOT NULL,
	[Balance] [float] NOT NULL,
	[TransactionLimit] [float] NOT NULL,
	[DailyLimit] [float] NOT NULL,
	[DailyWithdrawn] [float] NOT NULL,
	[FailedAttempts] [int] NOT NULL,
	[LockoutUntil] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CardNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 02/02/2025 23:56:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [varchar](16) NOT NULL,
	[TransactionType] [varchar](50) NOT NULL,
	[Amount] [float] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[Status] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VisaCards]    Script Date: 02/02/2025 23:56:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisaCards](
	[CardNumber] [varchar](16) NOT NULL,
	[CardHolderName] [varchar](100) NOT NULL,
	[ExpirationDate] [char](5) NOT NULL,
	[CVV] [char](3) NOT NULL,
	[HashedPIN] [varchar](255) NOT NULL,
	[IssuerBank] [varchar](100) NOT NULL,
	[Balance] [float] NOT NULL,
	[TransactionLimit] [float] NOT NULL,
	[DailyLimit] [float] NOT NULL,
	[DailyWithdrawn] [float] NOT NULL,
	[FailedAttempts] [int] NOT NULL,
	[LockoutUntil] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CardNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ATMInventories] ADD  DEFAULT ((0)) FOR [FiftyDenomination]
GO
ALTER TABLE [dbo].[ATMInventories] ADD  DEFAULT ((0)) FOR [TwentyDenomination]
GO
ALTER TABLE [dbo].[ATMInventories] ADD  DEFAULT ((0)) FOR [TenDenomination]
GO
ALTER TABLE [dbo].[MasterCards] ADD  DEFAULT ((0.0)) FOR [Balance]
GO
ALTER TABLE [dbo].[MasterCards] ADD  DEFAULT ((1500.0)) FOR [TransactionLimit]
GO
ALTER TABLE [dbo].[MasterCards] ADD  DEFAULT ((6000.0)) FOR [DailyLimit]
GO
ALTER TABLE [dbo].[MasterCards] ADD  DEFAULT ((0.0)) FOR [DailyWithdrawn]
GO
ALTER TABLE [dbo].[MasterCards] ADD  DEFAULT ((0)) FOR [FailedAttempts]
GO
ALTER TABLE [dbo].[Transactions] ADD  DEFAULT ((0.0)) FOR [Amount]
GO
ALTER TABLE [dbo].[Transactions] ADD  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[VisaCards] ADD  DEFAULT ((0.0)) FOR [Balance]
GO
ALTER TABLE [dbo].[VisaCards] ADD  DEFAULT ((1000.0)) FOR [TransactionLimit]
GO
ALTER TABLE [dbo].[VisaCards] ADD  DEFAULT ((5000.0)) FOR [DailyLimit]
GO
ALTER TABLE [dbo].[VisaCards] ADD  DEFAULT ((0.0)) FOR [DailyWithdrawn]
GO
ALTER TABLE [dbo].[VisaCards] ADD  DEFAULT ((0)) FOR [FailedAttempts]
GO
USE [master]
GO
ALTER DATABASE [TransactionDB] SET  READ_WRITE 
GO
