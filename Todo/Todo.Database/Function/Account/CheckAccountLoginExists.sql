CREATE FUNCTION [dbo].[CheckAccountLoginExists]
(
	@Login NVARCHAR(MAX)
)
RETURNS INT
AS
BEGIN
	IF EXISTS (SELECT TOP(1) [Login] FROM [dbo].[Account] WHERE Login = @Login)
	BEGIN	
		RETURN 1
	END
	
	RETURN 0
END
