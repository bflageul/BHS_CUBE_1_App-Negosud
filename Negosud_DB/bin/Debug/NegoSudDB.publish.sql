﻿/*
Deployment script for azertt

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "azertt"
:setvar DefaultFilePrefix "azertt"
:setvar DefaultDataPath "C:\Users\benja\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\benja\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating database $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating Table [dbo].[Address]...';


GO
CREATE TABLE [dbo].[Address] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [StreetNumber] NVARCHAR (255) NULL,
    [WayType]      NVARCHAR (255) NULL,
    [StreetName]   NVARCHAR (255) NOT NULL,
    [PostalCode]   VARCHAR (6)    NOT NULL,
    [City]         NVARCHAR (255) NOT NULL,
    [Country]      NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Address_Users]...';


GO
CREATE TABLE [dbo].[Address_Users] (
    [Users_Id]   INT NOT NULL,
    [Address_Id] INT NOT NULL,
    CONSTRAINT [PK_Address_Users] PRIMARY KEY CLUSTERED ([Address_Id] ASC, [Users_Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Alcohol]...';


GO
CREATE TABLE [dbo].[Alcohol] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Category] NVARCHAR (255) NOT NULL,
    [Range]    NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Alcohol_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Client]...';


GO
CREATE TABLE [dbo].[Client] (
    [Users_Id]   INT            NOT NULL,
    [Address_Id] INT            NOT NULL,
    [Email]      NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([Users_Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Employee]...';


GO
CREATE TABLE [dbo].[Employee] (
    [Users_Id] INT            NOT NULL,
    [Position] NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([Users_Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[GrapeVariety]...';


GO
CREATE TABLE [dbo].[GrapeVariety] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Product_Id] INT            NOT NULL,
    [Color]      NVARCHAR (255) NOT NULL,
    [GrapeName]  NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_GrapeVariety_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Legal]...';


GO
CREATE TABLE [dbo].[Legal] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Supplier_Id]  INT            NOT NULL,
    [Abbreviation] NVARCHAR (55)  NOT NULL,
    [LegalStatus]  NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Legal_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Order]...';


GO
CREATE TABLE [dbo].[Order] (
    [Id]           INT  IDENTITY (1, 1) NOT NULL,
    [Product_Id]   INT  NOT NULL,
    [OrderDate]    DATE NOT NULL,
    [DeliveryDate] DATE NOT NULL,
    [Quantity]     INT  NOT NULL,
    [Price]        INT  NOT NULL,
    CONSTRAINT [PK_Order_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Order_History]...';


GO
CREATE TABLE [dbo].[Order_History] (
    [Users_Id] INT NOT NULL,
    [Order_Id] INT NOT NULL,
    CONSTRAINT [PK_Order_History] PRIMARY KEY CLUSTERED ([Users_Id] ASC, [Order_Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Product]...';


GO
CREATE TABLE [dbo].[Product] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Supplier_Id]     INT            NOT NULL,
    [Alcohol_Id]      INT            NOT NULL,
    [GrapeVariety_Id] INT            NOT NULL,
    [Name]            NVARCHAR (255) NOT NULL,
    [Stock]           BIT            NULL,
    [Description]     TEXT           NULL,
    [Medal]           NVARCHAR (1)   NULL,
    [ProductionYear]  DATE           NOT NULL,
    CONSTRAINT [PK_Product_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Product_Ordered]...';


GO
CREATE TABLE [dbo].[Product_Ordered] (
    [Product_Id] INT NOT NULL,
    [Order_Id]   INT NOT NULL,
    CONSTRAINT [PK_Product_Order] PRIMARY KEY CLUSTERED ([Product_Id] ASC, [Order_Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Supplier]...';


GO
CREATE TABLE [dbo].[Supplier] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Address_Id]   INT            NOT NULL,
    [SupplierName] NVARCHAR (255) NOT NULL,
    [PhoneNumber]  NVARCHAR (15)  NOT NULL,
    CONSTRAINT [PK_Supplier_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Username]     NVARCHAR (255)  NOT NULL,
    [Firstname]    NVARCHAR (255)  NOT NULL,
    [Lastname]     NVARCHAR (255)  NOT NULL,
    [HashPassword] VARBINARY (255) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Default Constraint unnamed constraint on [dbo].[Product]...';


GO
ALTER TABLE [dbo].[Product]
    ADD DEFAULT 0 FOR [Stock];


GO
PRINT N'Creating Foreign Key [dbo].[FK_Users_Id]...';


GO
ALTER TABLE [dbo].[Address_Users]
    ADD CONSTRAINT [FK_Users_Id] FOREIGN KEY ([Users_Id]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE;


GO
PRINT N'Creating Foreign Key [dbo].[FK_Address]...';


GO
ALTER TABLE [dbo].[Address_Users]
    ADD CONSTRAINT [FK_Address] FOREIGN KEY ([Address_Id]) REFERENCES [dbo].[Address] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE;


GO
PRINT N'Creating Foreign Key [dbo].[FK_Client_User_Id]...';


GO
ALTER TABLE [dbo].[Client]
    ADD CONSTRAINT [FK_Client_User_Id] FOREIGN KEY ([Users_Id]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Client_Address_Id]...';


GO
ALTER TABLE [dbo].[Client]
    ADD CONSTRAINT [FK_Client_Address_Id] FOREIGN KEY ([Address_Id]) REFERENCES [dbo].[Address] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Employee_User_Id]...';


GO
ALTER TABLE [dbo].[Employee]
    ADD CONSTRAINT [FK_Employee_User_Id] FOREIGN KEY ([Users_Id]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_GrapeVariety_Product_Id]...';


GO
ALTER TABLE [dbo].[GrapeVariety]
    ADD CONSTRAINT [FK_GrapeVariety_Product_Id] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Product] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Order_Product_Id]...';


GO
ALTER TABLE [dbo].[Order]
    ADD CONSTRAINT [FK_Order_Product_Id] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Product] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[PK_Order_History_Users_Id]...';


GO
ALTER TABLE [dbo].[Order_History]
    ADD CONSTRAINT [PK_Order_History_Users_Id] FOREIGN KEY ([Users_Id]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[PK_Order_History_Order_Id]...';


GO
ALTER TABLE [dbo].[Order_History]
    ADD CONSTRAINT [PK_Order_History_Order_Id] FOREIGN KEY ([Order_Id]) REFERENCES [dbo].[Order] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Product_Supplier_Id]...';


GO
ALTER TABLE [dbo].[Product]
    ADD CONSTRAINT [FK_Product_Supplier_Id] FOREIGN KEY ([Supplier_Id]) REFERENCES [dbo].[Supplier] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Product_Alcohol_Id]...';


GO
ALTER TABLE [dbo].[Product]
    ADD CONSTRAINT [FK_Product_Alcohol_Id] FOREIGN KEY ([Alcohol_Id]) REFERENCES [dbo].[Alcohol] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Product_GrapeVariety_Id]...';


GO
ALTER TABLE [dbo].[Product]
    ADD CONSTRAINT [FK_Product_GrapeVariety_Id] FOREIGN KEY ([GrapeVariety_Id]) REFERENCES [dbo].[GrapeVariety] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Prod_Ord_Product_Id]...';


GO
ALTER TABLE [dbo].[Product_Ordered]
    ADD CONSTRAINT [FK_Prod_Ord_Product_Id] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Product] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Prod_Ord_Order_Id]...';


GO
ALTER TABLE [dbo].[Product_Ordered]
    ADD CONSTRAINT [FK_Prod_Ord_Order_Id] FOREIGN KEY ([Order_Id]) REFERENCES [dbo].[Order] ([Id]);


GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
