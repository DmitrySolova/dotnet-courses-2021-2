CREATE OR ALTER PROCEDURE UpdateUser(@userId int, @firstName nvarchar(50), @lastName nvarchar(50), @birthdate datetime)
AS
	UPDATE dbo.Users
	SET [First Name] = @firstName, [Last Name] = @lastName, Birthdate = @birthdate
	WHERE ID = @userId
GO
