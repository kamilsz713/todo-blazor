CREATE TABLE [dbo].[AccountRole]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AccountId] INT NOT NULL, 
    [RoleId] INT NOT NULL, 
    CONSTRAINT [FK_AccountRole_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account]([Id]), 
    CONSTRAINT [FK_AccountRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role]([Id])
)
