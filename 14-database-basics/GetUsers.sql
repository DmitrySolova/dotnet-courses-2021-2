CREATE PROCEDURE GetUsers
As
	SELECT [ID], [First Name], [Last Name], [Birthdate]
		FROM Users