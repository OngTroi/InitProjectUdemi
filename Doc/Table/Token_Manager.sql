IF OBJECT_ID('dbo.Token_Manager', 'U') IS NOT NULL
DROP TABLE dbo.Token_Manager;
Create Table Token_Manager
(
	TokenID NVARCHAR(255),
	RefreshToken NVARCHAR(255),
	Email NVARCHAR(200),
	User_Type VARCHAR(20),
	CreateDate DateTime Default Current_Timestamp,
	UpdatedDate DateTime Default Current_Timestamp,
	ExpiredTime DateTime
	Primary Key(Email)
)
Go