IF OBJECT_ID('dbo.Category', 'U') IS NOT NULL
DROP TABLE dbo.Category
Create Table Category
(
	ID INT IDENTITY(1000000,1),
	Title NVARCHAR(MAX) NOT NULL,
	Courses_Description NText,
	CreatedBy NVARCHAR(100),
	CreatedDate DateTime Default CURRENT_TIMESTAMP,
	UpdatedBy NVARCHAR(100),
	UpdatedDate DateTime Default CURRENT_TIMESTAMP,
	isDelete Tinyint
	Primary Key (ID)	
)
Go