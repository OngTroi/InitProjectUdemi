USE [Udemi_Management]
GO

/****** Object:  StoredProcedure [dbo].[Udemi_Courses_CreateCategory]    Script Date: 2/3/2021 11:29:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Udemi_Courses_CreateCategory]
(
	@Title NVARCHAR(100)
)
AS
Begin
	Declare @ErrorCode INT=0
	Declare @ErrorMessage NVARCHAR(200)= ''
	Declare @Profix INT=100000

	--Kiểm tra Category tồn tại
	IF(EXISTS(SELECT * From Category C Where C.Title = @Title))
	BEGIN
		SET @ErrorCode = @Profix + 1
		SET @ErrorMessage = 'Category already exists.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END

	INSERT INTO Category(Title, isDelete) 
	VALUES (@Title, 0)

	SET @ErrorMessage = 'Success'
	Select @ErrorCode err_code, @ErrorMessage err_msg
	Return
End


GO


