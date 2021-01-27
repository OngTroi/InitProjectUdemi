IF OBJECT_ID('dbo.FeedBack', 'U') IS NOT NULL
DROP TABLE dbo.FeedBack;
Create Table FeedBack
(
	ID INT IDENTITY(100000000,1),
	CoursesId INT,
	Feedback Ntext,
	CreateBy NVARCHAR(100),
	CreatedDate DateTime Default Current_Timestamp,
	UpdatedDate DateTime Default Current_Timestamp
	Primary Key(ID)
)
Go