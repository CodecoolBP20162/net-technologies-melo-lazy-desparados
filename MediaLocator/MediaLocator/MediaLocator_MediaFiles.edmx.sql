
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/16/2017 12:30:58
-- Generated from EDMX file: C:\Users\Judit\Source\Repos\net-technologies-melo-lazy-desparados\MediaLocator\MediaLocator\MediaLocator_MediaFiles.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MediaLocator_MediaFilesDB];
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

-- Creating table 'AudioSet'
CREATE TABLE [dbo].[AudioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Path] nvarchar(max)  NOT NULL,
    [Size] bigint  NOT NULL,
    [Long] bigint  NOT NULL,
    [SaveDate] datetime  NOT NULL,
    [Folder_Id] int  NOT NULL,
    [Playlist_Id] int  NOT NULL
);
GO

-- Creating table 'VideoSet'
CREATE TABLE [dbo].[VideoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Path] nvarchar(max)  NOT NULL,
    [Size] bigint  NOT NULL,
    [Long] bigint  NOT NULL,
    [SaveDate] datetime  NOT NULL,
    [Folder_Id] int  NOT NULL
);
GO

-- Creating table 'PictureSet'
CREATE TABLE [dbo].[PictureSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Path] nvarchar(max)  NOT NULL,
    [Size] bigint  NOT NULL,
    [SaveDate] datetime  NOT NULL,
    [Folder_Id] int  NOT NULL
);
GO

-- Creating table 'FolderSet'
CREATE TABLE [dbo].[FolderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Path] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PlaylistSet'
CREATE TABLE [dbo].[PlaylistSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Path] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AudioSet'
ALTER TABLE [dbo].[AudioSet]
ADD CONSTRAINT [PK_AudioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VideoSet'
ALTER TABLE [dbo].[VideoSet]
ADD CONSTRAINT [PK_VideoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PictureSet'
ALTER TABLE [dbo].[PictureSet]
ADD CONSTRAINT [PK_PictureSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FolderSet'
ALTER TABLE [dbo].[FolderSet]
ADD CONSTRAINT [PK_FolderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlaylistSet'
ALTER TABLE [dbo].[PlaylistSet]
ADD CONSTRAINT [PK_PlaylistSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Folder_Id] in table 'AudioSet'
ALTER TABLE [dbo].[AudioSet]
ADD CONSTRAINT [FK_FolderAudio]
    FOREIGN KEY ([Folder_Id])
    REFERENCES [dbo].[FolderSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FolderAudio'
CREATE INDEX [IX_FK_FolderAudio]
ON [dbo].[AudioSet]
    ([Folder_Id]);
GO

-- Creating foreign key on [Folder_Id] in table 'VideoSet'
ALTER TABLE [dbo].[VideoSet]
ADD CONSTRAINT [FK_FolderVideo]
    FOREIGN KEY ([Folder_Id])
    REFERENCES [dbo].[FolderSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FolderVideo'
CREATE INDEX [IX_FK_FolderVideo]
ON [dbo].[VideoSet]
    ([Folder_Id]);
GO

-- Creating foreign key on [Folder_Id] in table 'PictureSet'
ALTER TABLE [dbo].[PictureSet]
ADD CONSTRAINT [FK_FolderPicture]
    FOREIGN KEY ([Folder_Id])
    REFERENCES [dbo].[FolderSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FolderPicture'
CREATE INDEX [IX_FK_FolderPicture]
ON [dbo].[PictureSet]
    ([Folder_Id]);
GO

-- Creating foreign key on [Playlist_Id] in table 'AudioSet'
ALTER TABLE [dbo].[AudioSet]
ADD CONSTRAINT [FK_PlaylistAudio]
    FOREIGN KEY ([Playlist_Id])
    REFERENCES [dbo].[PlaylistSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlaylistAudio'
CREATE INDEX [IX_FK_PlaylistAudio]
ON [dbo].[AudioSet]
    ([Playlist_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------