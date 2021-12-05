CREATE OR ALTER PROCEDURE InsertReward(@title nvarchar(50), @description nvarchar(50))
As
	INSERT INTO [Rewards] (Title, Description)
		VALUES (@title, @description)

