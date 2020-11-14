CREATE PROCEDURE [dbo].[UpdateAccount]
	@Login NVARCHAR(MAX),
	@Password NVARCHAR(MAX),
	@Email NVARCHAR(MAX),
	@Id INT
AS
	UPDATE [dbo].[Account]
	SET [Login] = @Login, [Password] = @Password, [Email] = @Email
	WHERE [Id] = @Id
RETURN 0
