CREATE TABLE [dbo].[Card]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [TableColumnId] INT NOT NULL, 
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_TableColumnId_TableColumn] FOREIGN KEY ([TableColumnId]) REFERENCES [TableColumn]([Id])
)
