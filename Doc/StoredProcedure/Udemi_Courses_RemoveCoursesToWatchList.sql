USE [Udemi_Management]
GO

/****** Object:  StoredProcedure [dbo].[Udemi_Courses_RemoveCoursesToWatchList]    Script Date: 2/3/2021 11:30:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Udemi_Courses_RemoveCoursesToWatchList]
(
	@Id Int,
	@Email varchar(100)
)
AS
Begin
	Declare @ErrorCode INT=0
	Declare @ErrorMessage NVARCHAR(200)= ''
	Declare @Profix INT=100000

	--Kiểm tra Category tồn tại
	IF(NOT EXISTS(SELECT * From Courses_Watch C Where C.CoursesID = @Id And C.Email = @Email))
	BEGIN
		SET @ErrorCode = @Profix + 1
		SET @ErrorMessage = 'This member does not exists in courses.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END

	Delete Courses_Watch Where CoursesID = @Id And Email = @Email

	SET @ErrorMessage = 'Success'
	Select @ErrorCode err_code, @ErrorMessage err_msg
	Return
End



GO


