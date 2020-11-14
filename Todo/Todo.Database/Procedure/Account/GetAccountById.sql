CREATE PROCEDURE [dbo].[GetAccountById]
	@Id INT
AS
	SELECT [Id], [Login], [Email], [CreatedAt] FROM [dbo].[Account] WHERE [Id] = @Id
RETURN 0
