CREATE PROCEDURE [dbo].[GetAccount]
	@Login NVARCHAR(MAX)
AS
	SELECT [Id], [Login], [Email], [CreatedAt] FROM [dbo].[Account] WHERE [Login] = @Login
RETURN 0
