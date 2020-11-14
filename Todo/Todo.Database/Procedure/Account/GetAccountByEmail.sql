CREATE PROCEDURE [dbo].[GetAccountByEmail]
	@Email NVARCHAR(MAX)
AS
	SELECT [Id], [Login], [Email], [CreatedAt] FROM [dbo].[Account] WHERE [Email] = @Email
RETURN 0
