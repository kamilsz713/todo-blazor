﻿CREATE TABLE [dbo].[TableColumn]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Index] INT NOT NULL, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    [TableId] INT NOT NULL, 
    CONSTRAINT [FK_TableId_Table] FOREIGN KEY ([TableId]) REFERENCES [Table]([Id])
)
