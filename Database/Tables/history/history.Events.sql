CREATE TABLE [history].[Events] (
    HistoryId int IDENTITY(1,1) NOT NULL,
    HistoryStatusId int NOT NULL,
	Id VARCHAR(50) NOT NULL,
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
    CreatedAt datetime2 NULL,
    ModifiedBy int NULL,
    ModifiedAt datetime2 NULL,
    RowVersion timestamp NOT NULL
);