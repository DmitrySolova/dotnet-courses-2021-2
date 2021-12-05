CREATE OR ALTER PROCEDURE ReturnUserRewards(@userID INT)
As
	SELECT Title FROM UsersRewards, Rewards WHERE UserID = @userID AND Rewards.ID = RewardID