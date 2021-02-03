USE [Udemi_Management]
GO

/****** Object:  StoredProcedure [dbo].[Udemi_Courses_DeleteCategory]    Script Date: 2/3/2021 11:29:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Udemi_Courses_DeleteCategory]
(
	@Id INT
)
AS
Begin
	Declare @ErrorCode INT=0
	Declare @ErrorMessage NVARCHAR(200)= ''
	Declare @Profix INT=100000

	--Kiểm tra Category tồn tại
	IF(NOT EXISTS(SELECT * From Category C Where C.ID = @Id And C.isDelete = 0))
	BEGIN
		SET @ErrorCode = @Profix + 1
		SET @ErrorMessage = 'Category does not exists.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END

	Update Category SET isDelete = 1 Where Id = @Id

	SET @ErrorMessage = 'Success'
	Select @ErrorCode err_code, @ErrorMessage err_msg
	Return
End

GO


