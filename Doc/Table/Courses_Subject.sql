IF OBJECT_ID('dbo.Courses_Subject', 'U') IS NOT NULL
DROP TABLE dbo.Courses_Subject
Create Table Courses_Subject
(
	Id Int Identity(1000000,1),
	Title varchar(255) NOT NULL,
	Thumbnail Nvarchar(255) NOT NULL,
	Content Ntext NOT NULL,
	CourseId Int NOT NULL,
	CreatedDate Datetime Default Current_Timestamp,
	CreatedBy Nvarchar(100),
	UpdatedDate Datetime DEFAULT Current_Timestamp,
	UpdatedBy varchar(100),
	IsDeleted Int DEFAULT 0
	PRIMARY KEY (ID)
)
Go