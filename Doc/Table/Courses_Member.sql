IF OBJECT_ID('dbo.Courses_Member', 'U') IS NOT NULL
DROP TABLE dbo.Courses_Member;
Create Table Courses_Member
(
	ID INT IDENTITY(10000000,1),
	CoursesID INT NOT NULL,
	Email NVARCHAR(100),
	CreatedBy Nvarchar(100),
	CreatedDate DateTime Default Current_Timestamp,	
	Primary Key(ID)
)
Go