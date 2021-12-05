CREATE OR ALTER PROCEDURE InsertUser(@firstName nvarchar(50), @lastName nvarchar(50), @birthdate datetime)
As
	INSERT INTO Users([First Name], [Last Name], Birthdate)
		VALUES (@firstName, @lastName, @birthdate)
