USE [Udemi_Management]
GO

/****** Object:  StoredProcedure [dbo].[Udemi_Courses_UpdateCategory]    Script Date: 2/3/2021 11:30:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Udemi_Courses_UpdateCategory]
(
	@Id INT,
	@Title NVARCHAR(100)
)
AS
Begin
	Declare @ErrorCode INT=0
	Declare @ErrorMessage NVARCHAR(200)= ''
	Declare @Profix INT=100000

	--Kiểm tra Category tồn tại
	IF(NOT EXISTS(SELECT * From Category C Where C.ID = @Id))
	BEGIN
		SET @ErrorCode = @Profix + 1
		SET @ErrorMessage = 'Category does not exists.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END

	IF(EXISTS(SELECT * From Category C Where C.ID = @Id And C.isDelete = 1))
	BEGIN
		SET @ErrorCode = @Profix + 1
		SET @ErrorMessage = 'Category does not exists.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END

	Update Category SET 
		Title = @Title, 
		UpdatedDate = CURRENT_TIMESTAMP 
	Where Id = @Id

	SET @ErrorMessage = 'Success'
	Select @ErrorCode err_code, @ErrorMessage err_msg
	Return
End




GO


