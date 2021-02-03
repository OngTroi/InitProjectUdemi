USE [Udemi_Management]
GO

/****** Object:  StoredProcedure [dbo].[Udemi_Courses_AddCoursesToWatchList]    Script Date: 2/3/2021 11:28:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Udemi_Courses_AddCoursesToWatchList]
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
	IF(EXISTS(SELECT * From Courses_Watch C Where C.CoursesID = @Id And C.Email = @Email))
	BEGIN
		SET @ErrorCode = @Profix + 1
		SET @ErrorMessage = 'This member alreadys exists.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END

	INSERT INTO Courses_Watch(CoursesID,Email,CreatedBy) 
	VALUES (@Id,@Email,@Email)

	SET @ErrorMessage = 'Success'
	Select @ErrorCode err_code, @ErrorMessage err_msg
	Return
End



GO


