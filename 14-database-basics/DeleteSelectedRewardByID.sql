CREATE OR ALTER PROCEDURE DeleteSelectedRewardByName(@userID int, @rewardName nvarchar(50))
As 
	DELETE FROM UsersRewards
	WHERE RewardID IN (SELECT ID FROM Rewards WHERE Title = @rewardName) AND UserID = @userID
GO