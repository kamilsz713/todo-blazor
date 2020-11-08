CREATE PROCEDURE [dbo].[DeleteAccount]
	@Login NVARCHAR(MAX)
AS
	DELETE FROM [dbo].[Account] WHERE Login = @Login
RETURN 0
