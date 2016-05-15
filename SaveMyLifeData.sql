
CREATE TABLE [dbo].[Employee] (
    [IdEmployee] INT        IDENTITY(1,1)  NOT NULL,
    [Name]       VARCHAR (50) NOT NULL,
    [Salary]     INT          NOT NULL,
    [Age]        INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([IdEmployee] ASC)
);

CREATE TABLE [dbo].[HabitatType] (
   [IdHabitatType] INT       IDENTITY(1,1)   NOT NULL,
   [Name]          VARCHAR (50) NOT NULL,
   PRIMARY KEY CLUSTERED ([IdHabitatType] ASC)
);

CREATE TABLE [dbo].[Habitat] (
   [IdHabitat]     INT       IDENTITY(1,1)   NOT NULL,
   [Name]          VARCHAR (50) NOT NULL,
   [IdHabitatType] INT          NOT NULL,
   [IdEmployee]    INT          NOT NULL,
   PRIMARY KEY CLUSTERED ([IdHabitat] ASC),
   CONSTRAINT [FK_Habitat_HabitatType] FOREIGN KEY ([IdHabitatType]) REFERENCES [dbo].[HabitatType] ([IdHabitatType]),
   CONSTRAINT [FK_Habitat_Employee] FOREIGN KEY ([IdEmployee]) REFERENCES [dbo].[Employee] ([IdEmployee])
);

CREATE TABLE [dbo].[Maintenance] (
    [IdMaintenance] INT IDENTITY(1,1)NOT NULL,
    [IdHabitat]     INT NOT NULL,
    [IdEmployee]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdMaintenance] ASC),
    CONSTRAINT [FK_Maintenance_Employee] FOREIGN KEY ([IdEmployee]) REFERENCES [dbo].[Employee] ([IdEmployee]),
    CONSTRAINT [FK_Maintenance_Habitat] FOREIGN KEY ([IdHabitat]) REFERENCES [dbo].[Habitat] ([IdHabitat])
);


CREATE TABLE [dbo].[Genus] (
   [IdGenus]      INT      IDENTITY(1,1)    NOT NULL,
   [scientificName] VARCHAR (50) NOT NULL,
   [commonName]     VARCHAR (50) NOT NULL,
   [url]       VARCHAR (50) NOT NULL,
   PRIMARY KEY CLUSTERED ([IdGenus] ASC)
);

CREATE TABLE [dbo].[Species] (
   [IdSpecies]    INT       IDENTITY(1,1)   NOT NULL,
   [IdGenus]      INT          NOT NULL,
   [scientificName] VARCHAR (50) NOT NULL,
   [commonName]     VARCHAR (50) NOT NULL,
   [url]       VARCHAR (50) NOT NULL,
   PRIMARY KEY CLUSTERED ([IdSpecies] ASC),
   CONSTRAINT [FK_Species_Genus] FOREIGN KEY ([IdGenus]) REFERENCES [dbo].[Genus] ([IdGenus]),
);
