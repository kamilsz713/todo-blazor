CREATE TABLE [dbo].[AccountRole]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [AccountId] UNIQUEIDENTIFIER NOT NULL, 
    [RoleId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_AccountRole_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account]([Id]), 
    CONSTRAINT [FK_AccountRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role]([Id])
)
