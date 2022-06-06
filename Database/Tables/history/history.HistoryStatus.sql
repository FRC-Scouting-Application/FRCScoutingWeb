CREATE TABLE [history].[HistoryStatus] (
    Id int NOT NULL,
    Name varchar(50) NOT NULL,
);
GO

INSERT INTO [history].[HistoryStatus] (Id, Name) VALUES
(1, 'CREATE'),
(2, 'UPDATE'),
(3, 'DELETE')
GO