CREATE FUNCTION [dbo].[CheckAccountEmailExists]
(
	@Email NVARCHAR(MAX)
)
RETURNS INT AS
BEGIN
	IF EXISTS (SELECT TOP(1) Email FROM [dbo].[Account] WHERE Email = @Email)
	BEGIN	
		RETURN 1
	END
	
	RETURN 0
END
