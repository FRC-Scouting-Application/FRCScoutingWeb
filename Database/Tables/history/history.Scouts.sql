CREATE TABLE [history].[Scouts] (
    HistoryId int IDENTITY(1,1) NOT NULL,
    HistoryStatusId int NOT NULL,
	Id INT NOT NULL,
	TeamKey VARCHAR(50) NOT NULL,
	EventKey VARCHAR(50) NOT NULL,
	TemplateId INT NOT NULL,
	TemplateVersion INT NOT NULL,
	MatchKey VARCHAR(50) NULL,
	ScoutName VARCHAR(255) NOT NULL,
	Data VARCHAR(MAX) NOT NULL,
    CreatedBy int NULL,
    CreatedAt datetime2 NULL,
    ModifiedBy int NULL,
    ModifiedAt datetime2 NULL,
    RowVersion timestamp NOT NULL
);