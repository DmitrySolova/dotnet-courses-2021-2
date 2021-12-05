CREATE OR ALTER PROCEDURE UpdateReward(@rewardId int, @title nvarchar(50), @description nvarchar(250))
AS
	UPDATE dbo.Rewards
	SET Title = @title, Description = @description
	WHERE ID = @rewardId
GO
