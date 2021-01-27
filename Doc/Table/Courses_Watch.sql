IF OBJECT_ID('dbo.Courses_Watch', 'U') IS NOT NULL
DROP TABLE dbo.Courses_Watch;
Create Table Courses_Watch
(
	ID INT IDENTITY(10000000,1),
	CoursesID INT NOT NULL,
	Email NVARCHAR(100),
	CreatedBy Nvarchar(100),
	CreatedDate DateTime Default Current_Timestamp,
	Primary Key(ID)
)
Go