IF OBJECT_ID('dbo.User_Info', 'U') IS NOT NULL
DROP TABLE dbo.User_Info;
Create Table User_Info
(
	UserEmail NVARCHAR(100),
	UserPassword NVARCHAR(MAX),
	FullName NVARCHAR(150),
	Gender INT,
	DateOfBirth DateTime,
	Phone VARCHAR(15),
	UserType VARCHAR(20)
	Primary Key(UserEmail)
)
Go