/* Drop Existing Tables */
PRINT 'Dropping Existing Tables';
PRINT '';
DROP TABLE IF EXISTS [dbo].[Scouts];
DROP TABLE IF EXISTS [dbo].[Notes];
DROP TABLE IF EXISTS [dbo].[Templates];
DROP TABLE IF EXISTS [dbo].[Matches];
DROP TABLE IF EXISTS [dbo].[Teams];
DROP TABLE IF EXISTS [dbo].[Events];
GO

PRINT 'Create Events Table';
CREATE TABLE [dbo].[Events] (
	Id VARCHAR(50) PRIMARY KEY,
	Name VARCHAR(255) NOT NULL,
	ShortName VARCHAR(255) NULL,
	City VARCHAR(255) NULL,
	StateProv VARCHAR(255) NULL,
	Country VARCHAR(255) NULL,
	Address VARCHAR(MAX) NULL,
	PostalCode VARCHAR(50) NULL,
	LocationName VARCHAR(MAX) NULL,
	Website VARCHAR(MAX) NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	Year INT NOT NULL,
	EventType VARCHAR(50) NOT NULL,
	Week INT NULL,
    CreatedBy int NULL,
    CreatedAt datetime2 NULL DEFAULT sysdatetime(),
    ModifiedBy int NULL,
    ModifiedAt datetime2 NULL,
    RowVersion timestamp NOT NULL
);
GO

PRINT 'Create Teams Table';
CREATE TABLE [dbo].[Teams] (
	Id VARCHAR(50) PRIMARY KEY,
	TeamNumber INT NOT NULL,
	Nickname VARCHAR(255) NULL,
	Name VARCHAR(MAX) NOT NULL,
	SchoolName VARCHAR(MAX) NULL,
	City VARCHAR(255) NULL,
	StateProv VARCHAR(255) NULL,
	Country VARCHAR(255) NULL,
	Address VARCHAR(MAX) NULL,
	PostalCode VARCHAR(50) NULL,
	LocationName VARCHAR(MAX) NULL,
	Website VARCHAR(MAX) NULL,
	RookieYear INT NULL,
    CreatedBy int NULL,
    CreatedAt datetime2 NULL DEFAULT sysdatetime(),
    ModifiedBy int NULL,
    ModifiedAt datetime2 NULL,
    RowVersion timestamp NOT NULL
);
GO

PRINT 'Create Matches Table';
CREATE TABLE [dbo].[Matches] (
	Id VARCHAR(50) PRIMARY KEY,
	MatchNumber INT NOT NULL,
	Red1 VARCHAR(50) NULL FOREIGN KEY REFERENCES [dbo].[Teams](Id),
	Red2 VARCHAR(50) NULL FOREIGN KEY REFERENCES [dbo].[Teams](Id),
	Red3 VARCHAR(50) NULL FOREIGN KEY REFERENCES [dbo].[Teams](Id),
	Blue1 VARCHAR(50) NULL FOREIGN KEY REFERENCES [dbo].[Teams](Id),
	Blue2 VARCHAR(50) NULL FOREIGN KEY REFERENCES [dbo].[Teams](Id),
	Blue3 VARCHAR(50) NULL FOREIGN KEY REFERENCES [dbo].[Teams](Id),
	EventKey VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES [dbo].[Events](Id),
	RedScore INT NULL,
	BlueScore INT NULL,
	WinningAlliance VARCHAR(10) NULL,
	Time DATETIME NULL,
	ActualTime DATETIME NULL,
	PredictedTime DATETIME NULL,
    CreatedBy int NULL,
    CreatedAt datetime2 NULL DEFAULT sysdatetime(),
    ModifiedBy int NULL,
    ModifiedAt datetime2 NULL,
    RowVersion timestamp NOT NULL
);
GO

PRINT 'Create Templates Table';
CREATE TABLE [dbo].[Templates] (
	Id INT IDENTITY(0,1),
	Version INT NOT NULL DEFAULT 0,
	Type VARCHAR(10) NOT NULL,
	Name VARCHAR(255) NOT NULL,
	DefaultTemplate BIT NULL DEFAULT 0,
	Xml XML NOT NULL,
    CreatedBy int NULL,
    CreatedAt datetime2 NULL DEFAULT sysdatetime(),
    ModifiedBy int NULL,
    ModifiedAt datetime2 NULL,
    RowVersion timestamp NOT NULL
	PRIMARY KEY (Id, Version)
);
GO

PRINT 'Create Scouts Table';
CREATE TABLE [dbo].[Scouts] (
	Id INT IDENTITY(0,1),
	TeamKey VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES [dbo].[Teams](Id),
	EventKey VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES [dbo].[Events](Id),
	TemplateId INT NOT NULL,
	TemplateVersion INT NOT NULL,
	MatchKey VARCHAR(50) NULL FOREIGN KEY REFERENCES [dbo].[Matches](Id),
	ScoutName VARCHAR(255) NOT NULL,
	Xml XML NOT NULL,
    CreatedBy int NULL,
    CreatedAt datetime2 NULL DEFAULT sysdatetime(),
    ModifiedBy int NULL,
    ModifiedAt datetime2 NULL,
    RowVersion timestamp NOT NULL,
	FOREIGN KEY(TemplateId, TemplateVersion) REFERENCES [dbo].[Templates](Id, Version)
);
GO

PRINT 'Create Notes Table';
CREATE TABLE [dbo].[Notes] (
	Id INT IDENTITY(0,1) PRIMARY KEY,
	TeamKey VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES [dbo].[Teams](Id),
	EventKey VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES [dbo].[Events](Id),
	ScoutName VARCHAR(255) NOT NULL,
	Text VARCHAR(MAX) NOT NULL,
    CreatedBy int NULL,
    CreatedAt datetime2 NULL DEFAULT sysdatetime(),
    ModifiedBy int NULL,
    ModifiedAt datetime2 NULL,
    RowVersion timestamp NOT NULL
);
GO

PRINT '';
PRINT 'DONE!';
GO