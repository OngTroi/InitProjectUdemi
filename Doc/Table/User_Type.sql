IF OBJECT_ID('dbo.User_Type', 'U') IS NOT NULL
DROP TABLE dbo.User_Type;
Create Table User_Type
(
	TypeCode VARCHAR(20),
	TypeName NVARCHAR(100)
	Primary Key(TypeCode)
)
Go