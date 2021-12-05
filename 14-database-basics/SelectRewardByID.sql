CREATE OR ALTER PROCEDURE SelectRewardByID(@userId int, @rewardId int)
As
	INSERT INTO UsersRewards(UserId, RewardId) VALUES (@userId, @rewardId)
GO