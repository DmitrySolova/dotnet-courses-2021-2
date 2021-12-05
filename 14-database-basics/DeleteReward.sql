CREATE OR ALTER PROCEDURE DeleteReward(@rewardId int)
As 
	DELETE FROM UsersRewards
	WHERE RewardID = @rewardId
	DELETE FROM Rewards
	WHERE ID = @rewardId
GO