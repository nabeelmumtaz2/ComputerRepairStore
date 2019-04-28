
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/27/2019 22:18:16
-- Generated from EDMX file: C:\Users\Nabeel Mumtaz\source\repos\ComputerRepairStore2\ComputerRepair\ComputerRepair\CrModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ComputerStore];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomersSystem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Systems1] DROP CONSTRAINT [FK_CustomersSystem];
GO
IF OBJECT_ID(N'[dbo].[FK_SystemsAgents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Agents] DROP CONSTRAINT [FK_SystemsAgents];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Systems1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Systems1];
GO
IF OBJECT_ID(N'[dbo].[Agents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Agents];
GO
IF OBJECT_ID(N'[dbo].[Inventories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Inventories];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Client_Id] int IDENTITY(1,1) NOT NULL,
    [First_Name] nvarchar(max)  NOT NULL,
    [Last_Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Phone_Number] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Systems1'
CREATE TABLE [dbo].[Systems1] (
    [System_Id] int IDENTITY(1,1) NOT NULL,
    [Brands] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NULL,
    [Drop_Off_Date] datetime  NOT NULL,
    [Pick_Up_Date] datetime  NOT NULL,
    [Quote] nvarchar(max)  NOT NULL,
    [CustomersClient_Id] int  NOT NULL,
    [IsLaptop] bit  NULL,
    [IsDesktop] bit  NULL,
    [Is_All_In_One] bit  NULL,
    [IsMonitor] bit  NULL,
    [Tablet] bit  NULL,
    [IsCell_Phone] bit  NULL,
    [Mac_Number] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Agents'
CREATE TABLE [dbo].[Agents] (
    [Agent_Id] int IDENTITY(1,1) NOT NULL,
    [First_Name] nvarchar(max)  NOT NULL,
    [Last_Name] nvarchar(max)  NOT NULL,
    [Employ_Id] nvarchar(max)  NOT NULL,
    [Shift_Type] nvarchar(max)  NOT NULL,
    [SystemsSystem_Id] int  NULL
);
GO

-- Creating table 'Inventories'
CREATE TABLE [dbo].[Inventories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Comp_Name] nvarchar(max)  NOT NULL,
    [Comp_Check_In] datetime  NOT NULL,
    [Comp_Check_Out] datetime  NOT NULL,
    [Brand_Name] nvarchar(max)  NOT NULL,
    [Is_Ram_Installed] bit  NULL,
    [Is_Power_Supply_Installed] bit  NULL,
    [Part_Type] nvarchar(max)  NOT NULL,
    [Is_Complete_System] bit  NULL,
    [Serial_Number] nvarchar(max)  NOT NULL,
    [Service_Number] nvarchar(max)  NOT NULL,
    [Is_Asset_Tags] bit  NULL,
    [Asset_ID] nvarchar(max)  NULL,
    [Issues_Note] nvarchar(max)  NULL,
    [Imei_Number] nvarchar(max)  NULL,
    [Is_Broken_Fan] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Client_Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Client_Id] ASC);
GO

-- Creating primary key on [System_Id] in table 'Systems1'
ALTER TABLE [dbo].[Systems1]
ADD CONSTRAINT [PK_Systems1]
    PRIMARY KEY CLUSTERED ([System_Id] ASC);
GO

-- Creating primary key on [Agent_Id] in table 'Agents'
ALTER TABLE [dbo].[Agents]
ADD CONSTRAINT [PK_Agents]
    PRIMARY KEY CLUSTERED ([Agent_Id] ASC);
GO

-- Creating primary key on [Id] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [PK_Inventories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomersClient_Id] in table 'Systems1'
ALTER TABLE [dbo].[Systems1]
ADD CONSTRAINT [FK_CustomersSystem]
    FOREIGN KEY ([CustomersClient_Id])
    REFERENCES [dbo].[Customers]
        ([Client_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomersSystem'
CREATE INDEX [IX_FK_CustomersSystem]
ON [dbo].[Systems1]
    ([CustomersClient_Id]);
GO

-- Creating foreign key on [SystemsSystem_Id] in table 'Agents'
ALTER TABLE [dbo].[Agents]
ADD CONSTRAINT [FK_SystemsAgents]
    FOREIGN KEY ([SystemsSystem_Id])
    REFERENCES [dbo].[Systems1]
        ([System_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SystemsAgents'
CREATE INDEX [IX_FK_SystemsAgents]
ON [dbo].[Agents]
    ([SystemsSystem_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------