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