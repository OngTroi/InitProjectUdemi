USE [Udemi_Management]
GO

/****** Object:  StoredProcedure [dbo].[Udemi_User_UpdateUser]    Script Date: 1/29/2021 9:38:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Udemi_User_UpdateUser]
(
	@Email NVARCHAR(100),
	@FullName NVARCHAR(200),
	@Gender INT NULL,
	@DOB DATETIME NULL,
	@Phone NVARCHAR(20)
)
AS
Begin
	Declare @ErrorCode INT=0
	Declare @ErrorMessage NVARCHAR(200)= ''
	Declare @Profix INT=100000

	--Kiểm tra Email tồn tại
	IF(NOT EXISTS(SELECT * From User_Info A Where A.UserEmail = @Email))
	BEGIN
		SET @ErrorCode = @Profix + 1
		SET @ErrorMessage = 'Email does not exists.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END
	--Kiểm tra số điện thoại
	IF(EXISTS(SELECT * From User_Info A Where A.Phone = @Phone And A.UserEmail <> @Email))
	BEGIN
		SET @ErrorCode = @Profix + 2
		SET @ErrorMessage = 'Phone already exists.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END

	Update User_Info
	SET FullName = @FullName,
		Gender = @Gender,
		Phone = @Phone,
		DateOfBirth = @DOB
	Where UserEmail = @Email

	Select @ErrorCode err_code, @ErrorMessage err_msg
	Return
End

GO


