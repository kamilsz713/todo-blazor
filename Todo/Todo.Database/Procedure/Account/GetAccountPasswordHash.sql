CREATE PROCEDURE [dbo].[GetAccountPasswordHash]
	@Login NVARCHAR(MAX)
AS
	SELECT [Password] FROM [dbo].[Account] WHERE [Login] = @Login
RETURN 0
