CREATE TABLE [dbo].[Scouts] (
	Id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	TeamKey VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES [dbo].[Teams](Id),
	EventKey VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES [dbo].[Events](Id),
	TemplateId INT NOT NULL,
	TemplateVersion INT NOT NULL,
	MatchKey VARCHAR(50) NULL FOREIGN KEY REFERENCES [dbo].[Matches](Id),
	ScoutName VARCHAR(255) NOT NULL,
	Data VARCHAR(MAX) NOT NULL,
    CreatedBy int NULL,
    CreatedAt datetime2 NULL DEFAULT sysdatetime(),
    ModifiedBy int NULL,
    ModifiedAt datetime2 NULL,
    RowVersion timestamp NOT NULL,
	FOREIGN KEY(TemplateId, TemplateVersion) REFERENCES [dbo].[Templates](Id, Version)
);