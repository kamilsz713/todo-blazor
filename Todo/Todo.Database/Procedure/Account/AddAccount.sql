CREATE PROCEDURE [dbo].[AddAccount]
	@Login NVARCHAR(MAX),
	@Password NVARCHAR(MAX),
	@Email NVARCHAR(MAX)
AS
	INSERT INTO [dbo].[Account]([Login], [Password], [Email]) VALUES (@Login, @Password, @Email)
RETURN 0
