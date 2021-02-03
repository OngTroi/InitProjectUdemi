USE [Udemi_Management]
GO

/****** Object:  StoredProcedure [dbo].[Udemi_Courses_DeleteCourses]    Script Date: 2/3/2021 11:29:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Udemi_Courses_DeleteCourses]
(
	@Id Int
)
AS
Begin
	Declare @ErrorCode INT=0
	Declare @ErrorMessage NVARCHAR(200)= ''
	Declare @Profix INT=100000

	--Kiểm tra Category tồn tại
	IF(NOT EXISTS(SELECT * From Courses C Where C.Id = @Id And C.IsDeleted = 0))
	BEGIN
		SET @ErrorCode = @Profix + 1
		SET @ErrorMessage = 'Courses does exists.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END

	Update Courses SET IsDeleted = 1
	Where Id = @Id

	SET @ErrorMessage = 'Success'
	Select @ErrorCode err_code, @ErrorMessage err_msg
	Return
End

GO


