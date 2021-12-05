CREATE OR ALTER PROCEDURE ClearAllTables
As
	DELETE FROM dbo.UsersRewards
	DELETE FROM dbo.Users
	DELETE FROM dbo.Rewards
GO