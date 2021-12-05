CREATE PROCEDURE GetUserById(@id int)
As
	RETURN SELECT [ID], [First Name], [Last Name], [Birthdate], [Age]
		FROM [Users]
			WHERE ID = @id