USE [Udemi_Management]
GO

/****** Object:  StoredProcedure [dbo].[Udemi_Courses_UpdateCourses]    Script Date: 2/3/2021 11:30:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Udemi_Courses_UpdateCourses]
(
	@Id Int,
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
	IF(NOT EXISTS(SELECT * From Courses C Where C.Id = @Id And IsDeleted = 0))
	BEGIN
		SET @ErrorCode = @Profix + 1
		SET @ErrorMessage = 'Courses does not exists.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END

	Update Courses SET
		Title = @Title,
		DescriptionShort = @DescriptionShort,
		DescriptionLong = @DescriptionLong,
		Thumbnail = @Thumbnail,
		Outline = @Outline,
		Teacher = @Teacher,
		CategoryId = @CategoryId 
	Where Id = @Id

	SET @ErrorMessage = 'Success'
	Select @ErrorCode err_code, @ErrorMessage err_msg
	Return
End


GO


