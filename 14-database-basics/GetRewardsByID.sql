CREATE PROCEDURE GetRewardsById(@id int)
As
	RETURN SELECT ID, [Title], [Description]
		FROM [Rewards]
			WHERE ID = @id

