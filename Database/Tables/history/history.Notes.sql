CREATE TABLE [history].[Notes] (
    HistoryId int IDENTITY(1,1) NOT NULL,
    HistoryStatusId int NOT NULL,
	Id INT NOT NULL,
	TeamKey VARCHAR(50) NOT NULL,
	EventKey VARCHAR(50) NOT NULL,
	ScoutName VARCHAR(255) NOT NULL,
	Text VARCHAR(MAX) NOT NULL,
    CreatedBy int NULL,
    CreatedAt datetime2 NULL DEFAULT sysdatetime(),
    ModifiedBy int NULL,
    ModifiedAt datetime2 NULL,
    RowVersion timestamp NOT NULL
);