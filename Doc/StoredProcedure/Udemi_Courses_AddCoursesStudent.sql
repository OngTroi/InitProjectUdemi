USE [Udemi_Management]
GO

/****** Object:  StoredProcedure [dbo].[Udemi_Courses_AddCoursesStudent]    Script Date: 2/3/2021 11:28:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Udemi_Courses_AddCoursesStudent]
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
	IF(EXISTS(SELECT * From Courses_Member C Where C.CoursesID = @Id And C.Email = @Email))
	BEGIN
		SET @ErrorCode = @Profix + 1
		SET @ErrorMessage = 'This member already exists.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END

	INSERT INTO Courses_Member(CoursesID,Email,CreatedBy) 
	VALUES (@Id,@Email,@Email)

	SET @ErrorMessage = 'Success'
	Select @ErrorCode err_code, @ErrorMessage err_msg
	Return
End


GO


