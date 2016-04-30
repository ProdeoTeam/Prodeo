
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/13/2016 19:49:28
-- Generated from EDMX file: C:\Users\Usuario\Documents\GitHub\Prodeo\Datos\ModelProdeo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [prodeo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Modulos_Proyectos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Modulos] DROP CONSTRAINT [FK_Modulos_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[FK_Modulos_Usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Modulos] DROP CONSTRAINT [FK_Modulos_Usuarios];
GO
IF OBJECT_ID(N'[dbo].[FK_participantes_usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Participantes] DROP CONSTRAINT [FK_participantes_usuarios];
GO
IF OBJECT_ID(N'[dbo].[FK_ParticipantesProyectos_Proyectos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParticipantesProyectos] DROP CONSTRAINT [FK_ParticipantesProyectos_Proyectos];
GO
IF OBJECT_ID(N'[dbo].[FK_ParticipantesTareas_Tareas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParticipantesTareas] DROP CONSTRAINT [FK_ParticipantesTareas_Tareas];
GO
IF OBJECT_ID(N'[dbo].[FK_Tareas_Modulos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tareas] DROP CONSTRAINT [FK_Tareas_Modulos];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Mails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mails];
GO
IF OBJECT_ID(N'[dbo].[Modulos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Modulos];
GO
IF OBJECT_ID(N'[dbo].[Participantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Participantes];
GO
IF OBJECT_ID(N'[dbo].[ParticipantesProyectos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParticipantesProyectos];
GO
IF OBJECT_ID(N'[dbo].[ParticipantesTareas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParticipantesTareas];
GO
IF OBJECT_ID(N'[dbo].[Proyectos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proyectos];
GO
IF OBJECT_ID(N'[dbo].[Tareas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tareas];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Mails'
CREATE TABLE [dbo].[Mails] (
    [idMail] int IDENTITY(1,1) NOT NULL,
    [idProyecto] int  NULL,
    [idModulo] int  NULL,
    [idTarea] int  NULL,
    [asunto] nvarchar(1)  NULL,
    [detalle] nvarchar(1)  NULL,
    [destinatarios] varchar(1)  NULL,
    [enviado] char(1)  NULL
);
GO

-- Creating table 'Modulos'
CREATE TABLE [dbo].[Modulos] (
    [idModulo] int IDENTITY(1,1) NOT NULL,
    [idProyecto] int  NOT NULL,
    [idUsuarioCreador] int  NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Descripcion] nvarchar(200)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [FechaFinalizacion] datetime  NULL,
    [FechaVencimiento] datetime  NOT NULL,
    [Baja] int  NOT NULL,
    [FechaInicio] datetime  NOT NULL
);
GO

-- Creating table 'Participantes'
CREATE TABLE [dbo].[Participantes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idUsuario] int  NOT NULL,
    [PermisosAdministrador] char(1)  NOT NULL
);
GO

-- Creating table 'ParticipantesProyectos'
CREATE TABLE [dbo].[ParticipantesProyectos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idUsuario] int  NOT NULL,
    [idProyecto] int  NOT NULL,
    [permisosAdministrador] char(1)  NULL
);
GO

-- Creating table 'ParticipantesTareas'
CREATE TABLE [dbo].[ParticipantesTareas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idUsuario] int  NOT NULL,
    [idTarea] int  NOT NULL
);
GO

-- Creating table 'Tareas'
CREATE TABLE [dbo].[Tareas] (
    [idTarea] int IDENTITY(1,1) NOT NULL,
    [idModulo] int  NOT NULL,
    [Nombre] nvarchar(200)  NOT NULL,
    [Descripcion] nvarchar(200)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [FechaVencimiento] datetime  NOT NULL,
    [FechaFinalizacion] datetime  NULL,
    [AlertaPrevia] nvarchar(10)  NOT NULL,
    [DireccionGPS] nvarchar(100)  NOT NULL,
    [Prioridad] char(1)  NOT NULL,
    [Comentario] nvarchar(200)  NOT NULL,
    [Estado] nvarchar(50)  NULL,
    [Tiempo] float  NULL,
    [Baja] int  NOT NULL,
    [FechaInicio] datetime  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [idUsuario] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(200)  NOT NULL,
    [mail] nvarchar(100)  NOT NULL,
    [password] nvarchar(200)  NOT NULL,
    [usuarioActivo] bit  NOT NULL,
    [codigoVerificacion] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Proyectos'
CREATE TABLE [dbo].[Proyectos] (
    [idProyecto] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Descripcion] nvarchar(200)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [FechaVencimiento] datetime  NOT NULL,
    [FechaFinalizacion] datetime  NULL,
    [AlertaPrevia] nvarchar(10)  NOT NULL,
    [Baja] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idMail] in table 'Mails'
ALTER TABLE [dbo].[Mails]
ADD CONSTRAINT [PK_Mails]
    PRIMARY KEY CLUSTERED ([idMail] ASC);
GO

-- Creating primary key on [idModulo] in table 'Modulos'
ALTER TABLE [dbo].[Modulos]
ADD CONSTRAINT [PK_Modulos]
    PRIMARY KEY CLUSTERED ([idModulo] ASC);
GO

-- Creating primary key on [id] in table 'Participantes'
ALTER TABLE [dbo].[Participantes]
ADD CONSTRAINT [PK_Participantes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ParticipantesProyectos'
ALTER TABLE [dbo].[ParticipantesProyectos]
ADD CONSTRAINT [PK_ParticipantesProyectos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ParticipantesTareas'
ALTER TABLE [dbo].[ParticipantesTareas]
ADD CONSTRAINT [PK_ParticipantesTareas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [idTarea] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [PK_Tareas]
    PRIMARY KEY CLUSTERED ([idTarea] ASC);
GO

-- Creating primary key on [idUsuario] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([idUsuario] ASC);
GO

-- Creating primary key on [idProyecto] in table 'Proyectos'
ALTER TABLE [dbo].[Proyectos]
ADD CONSTRAINT [PK_Proyectos]
    PRIMARY KEY CLUSTERED ([idProyecto] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idUsuarioCreador] in table 'Modulos'
ALTER TABLE [dbo].[Modulos]
ADD CONSTRAINT [FK_Modulos_Usuarios]
    FOREIGN KEY ([idUsuarioCreador])
    REFERENCES [dbo].[Usuarios]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Modulos_Usuarios'
CREATE INDEX [IX_FK_Modulos_Usuarios]
ON [dbo].[Modulos]
    ([idUsuarioCreador]);
GO

-- Creating foreign key on [idModulo] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK_Tareas_Modulos]
    FOREIGN KEY ([idModulo])
    REFERENCES [dbo].[Modulos]
        ([idModulo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tareas_Modulos'
CREATE INDEX [IX_FK_Tareas_Modulos]
ON [dbo].[Tareas]
    ([idModulo]);
GO

-- Creating foreign key on [idUsuario] in table 'Participantes'
ALTER TABLE [dbo].[Participantes]
ADD CONSTRAINT [FK_participantes_usuarios]
    FOREIGN KEY ([idUsuario])
    REFERENCES [dbo].[Usuarios]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_participantes_usuarios'
CREATE INDEX [IX_FK_participantes_usuarios]
ON [dbo].[Participantes]
    ([idUsuario]);
GO

-- Creating foreign key on [idTarea] in table 'ParticipantesTareas'
ALTER TABLE [dbo].[ParticipantesTareas]
ADD CONSTRAINT [FK_ParticipantesTareas_Tareas]
    FOREIGN KEY ([idTarea])
    REFERENCES [dbo].[Tareas]
        ([idTarea])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ParticipantesTareas_Tareas'
CREATE INDEX [IX_FK_ParticipantesTareas_Tareas]
ON [dbo].[ParticipantesTareas]
    ([idTarea]);
GO

-- Creating foreign key on [idProyecto] in table 'Modulos'
ALTER TABLE [dbo].[Modulos]
ADD CONSTRAINT [FK_Modulos_Proyectos]
    FOREIGN KEY ([idProyecto])
    REFERENCES [dbo].[Proyectos]
        ([idProyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Modulos_Proyectos'
CREATE INDEX [IX_FK_Modulos_Proyectos]
ON [dbo].[Modulos]
    ([idProyecto]);
GO

-- Creating foreign key on [idProyecto] in table 'ParticipantesProyectos'
ALTER TABLE [dbo].[ParticipantesProyectos]
ADD CONSTRAINT [FK_ParticipantesProyectos_Proyectos]
    FOREIGN KEY ([idProyecto])
    REFERENCES [dbo].[Proyectos]
        ([idProyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ParticipantesProyectos_Proyectos'
CREATE INDEX [IX_FK_ParticipantesProyectos_Proyectos]
ON [dbo].[ParticipantesProyectos]
    ([idProyecto]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------