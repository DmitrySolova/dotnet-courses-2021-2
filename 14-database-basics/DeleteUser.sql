CREATE OR ALTER PROCEDURE DeleteUser(@userId int)
As 
	DELETE FROM UsersRewards
	WHERE UserID = @userId
	DELETE FROM Users
	WHERE ID = @userId
GO