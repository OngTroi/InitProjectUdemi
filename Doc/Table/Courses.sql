--Courses
IF OBJECT_ID('dbo.Courses', 'U') IS NOT NULL
DROP TABLE dbo.Courses
Create Table Courses
(
	ID INT IDENTITY(1000000, 1),
	Title Nvarchar(255) NOT NULL,
	DescriptionShort varchar(255) NOT NULL,
	DescriptionLong Ntext NOT NULL,
	Thumbnail NVARCHAR(255) NOT NULL,
	Price FLOAT,
	Sale FLOAT,
	ReviewPoint FLOAT DEFAULT 0,
	Reviews Int DEFAULT 0,
	Participants Int DEFAULT 0,
	Outline Ntext,
	TeacherId Int NOT NULL,
	CategoryId Int DEFAULT NULL,
	SubjectTotal INT,
	CreatedDate Datetime Default Current_Timestamp,
	CreatedBy Nvarchar(100),
	UpdatedDate Datetime DEFAULT Current_Timestamp,
	UpdatedBy Nvarchar(100),
	IsDeleted INT DEFAULT 0,
	IsCompleted INT DEFAULT 0
	Primary Key (ID)
)
Go
