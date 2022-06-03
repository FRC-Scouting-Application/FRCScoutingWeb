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