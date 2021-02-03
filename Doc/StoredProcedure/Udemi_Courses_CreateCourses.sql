USE [Udemi_Management]
GO

/****** Object:  StoredProcedure [dbo].[Udemi_Courses_CreateCourses]    Script Date: 2/3/2021 11:29:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Udemi_Courses_CreateCourses]
(
	@Title Nvarchar(255),
	@DescriptionShort varchar(255),
	@DescriptionLong Ntext,
	@Thumbnail NVARCHAR(255),
	@Outline Ntext,
	@Teacher NVARCHAR(100),
	@CategoryId Int
)
AS
Begin
	Declare @ErrorCode INT=0
	Declare @ErrorMessage NVARCHAR(200)= ''
	Declare @Profix INT=100000

	--Kiểm tra Category tồn tại
	IF(EXISTS(SELECT * From Courses C Where C.Title = @Title))
	BEGIN
		SET @ErrorCode = @Profix + 1
		SET @ErrorMessage = 'Courses already exists.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END

	INSERT INTO Courses(Title, DescriptionShort,DescriptionLong,Thumbnail,Outline,Teacher,CategoryId,IsDeleted) 
	VALUES (@Title, @DescriptionShort,@DescriptionLong,@Thumbnail,@Outline,@Teacher,@CategoryId,0)

	SET @ErrorMessage = 'Success'
	Select @ErrorCode err_code, @ErrorMessage err_msg
	Return
End

GO


