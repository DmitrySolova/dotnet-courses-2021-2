CREATE PROCEDURE InitUsersRewards
AS
	INSERT INTO UsersRewards (UserID, RewardID)
	VALUES (1, 3)
	INSERT INTO UsersRewards (UserID, RewardID)
	VALUES (1, 4)
	INSERT INTO UsersRewards (UserID, RewardID)
	VALUES (2, 3)
	INSERT INTO UsersRewards (UserID, RewardID)
	VALUES (2, 1)
	INSERT INTO UsersRewards (UserID, RewardID)
	VALUES (0, 1)
	INSERT INTO UsersRewards (UserID, RewardID)
	VALUES (0, 2)