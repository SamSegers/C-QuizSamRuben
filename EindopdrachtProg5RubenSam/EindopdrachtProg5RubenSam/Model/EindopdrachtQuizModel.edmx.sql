
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/27/2015 14:34:09
-- Generated from EDMX file: C:\Users\Ruben\Documents\GitHub\C-QuizSamRuben\EindopdrachtProg5RubenSam\EindopdrachtProg5RubenSam\Model\EindopdrachtQuizModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EindopdrachtQuizDb];
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

-- Creating table 'Quizs'
CREATE TABLE [dbo].[Quizs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Vraags'
CREATE TABLE [dbo].[Vraags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Category] nvarchar(max)  NOT NULL,
    [QuizId] int  NOT NULL
);
GO

-- Creating table 'Antwoords'
CREATE TABLE [dbo].[Antwoords] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Correct] int  NOT NULL,
    [VraagId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Quizs'
ALTER TABLE [dbo].[Quizs]
ADD CONSTRAINT [PK_Quizs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Vraags'
ALTER TABLE [dbo].[Vraags]
ADD CONSTRAINT [PK_Vraags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Antwoords'
ALTER TABLE [dbo].[Antwoords]
ADD CONSTRAINT [PK_Antwoords]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [QuizId] in table 'Vraags'
ALTER TABLE [dbo].[Vraags]
ADD CONSTRAINT [FK_QuizVraag]
    FOREIGN KEY ([QuizId])
    REFERENCES [dbo].[Quizs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuizVraag'
CREATE INDEX [IX_FK_QuizVraag]
ON [dbo].[Vraags]
    ([QuizId]);
GO

-- Creating foreign key on [VraagId] in table 'Antwoords'
ALTER TABLE [dbo].[Antwoords]
ADD CONSTRAINT [FK_VraagAntwoord]
    FOREIGN KEY ([VraagId])
    REFERENCES [dbo].[Vraags]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VraagAntwoord'
CREATE INDEX [IX_FK_VraagAntwoord]
ON [dbo].[Antwoords]
    ([VraagId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------