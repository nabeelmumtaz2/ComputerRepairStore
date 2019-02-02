
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/01/2019 21:14:44
-- Generated from EDMX file: C:\Users\Nabeel Mumtaz\source\repos\ComputerRepairStore\ComputerRepair\ComputerRepair\CrModel.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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
    [Note] nvarchar(max)  NOT NULL,
    [Drop_Off_Date] datetime  NOT NULL,
    [Pick_Up_Date] datetime  NOT NULL,
    [Quote] nvarchar(max)  NOT NULL,
    [CustomersClient_Id] int  NOT NULL
);
GO

-- Creating table 'Agents'
CREATE TABLE [dbo].[Agents] (
    [Agent_Id] int IDENTITY(1,1) NOT NULL,
    [First_Name] nvarchar(max)  NOT NULL,
    [Last_Name] nvarchar(max)  NOT NULL,
    [Employ_Id] nvarchar(max)  NOT NULL,
    [Shift_Time] datetime  NOT NULL,
    [SystemsSystem_Id] int  NULL
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