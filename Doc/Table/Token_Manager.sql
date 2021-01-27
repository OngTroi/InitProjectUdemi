IF OBJECT_ID('dbo.Token_Manager', 'U') IS NOT NULL
DROP TABLE dbo.Token_Manager;
Create Table Token_Manager
(
	TokenID NVARCHAR(255),
	RefreshToken NVARCHAR(255),
	UserName NVARCHAR(100),
	Email NVARCHAR(200),
	CreateDate DateTime Default Current_Timestamp,
	UpdatedDate DateTime Default Current_Timestamp
	Primary Key(RefreshToken)
)
Go