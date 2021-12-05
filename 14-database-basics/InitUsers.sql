CREATE PROCEDURE InitUsers
AS
	INSERT INTO Users ([First Name], [Last Name], Birthdate)
	VALUES ('Роман', 'Пешков', '01.01.2000')
	INSERT INTO Users ([First Name], [Last Name], Birthdate)
	VALUES ('Андрей', 'Морозкин', '02.02.1990')
	INSERT INTO Users ([First Name], [Last Name], Birthdate)
	VALUES ('Мария', 'Шабашкина', '03.03.1980')
	