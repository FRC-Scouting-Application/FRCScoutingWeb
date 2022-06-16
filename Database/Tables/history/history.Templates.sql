CREATE TABLE [history].[Templates] (
    HistoryId int IDENTITY(1,1) NOT NULL,
    HistoryStatusId int NOT NULL,
	Id INT NOT NULL,
	Version INT NOT NULL DEFAULT 0,
	Type VARCHAR(10) NOT NULL,
	Name VARCHAR(255) NOT NULL,
	DefaultTemplate BIT NULL DEFAULT 0,
	Data VARCHAR(MAX) NOT NULL,
    CreatedBy int NULL,
    CreatedAt datetime2 NULL DEFAULT sysdatetime(),
    ModifiedBy int NULL,
    ModifiedAt datetime2 NULL,
	PRIMARY KEY (Id, Version)
);