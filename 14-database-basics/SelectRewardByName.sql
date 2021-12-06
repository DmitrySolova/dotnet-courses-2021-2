CREATE OR ALTER PROCEDURE SelectRewardByName(@userId int, @rewardTitle nvarchar(50))
As
	INSERT INTO UsersRewards(UserId, RewardId) VALUES (@userId, (SELECT ID FROM Rewards WHERE Title = @rewardTitle))
GO

INSERT FROM