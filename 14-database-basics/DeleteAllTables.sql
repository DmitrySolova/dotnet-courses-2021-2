CREATE OR ALTER PROCEDURE DeleteAllTables
As 
	DROP TABLE IF EXISTS dbo.UsersRewards, dbo.Users, dbo.Rewards;
GO