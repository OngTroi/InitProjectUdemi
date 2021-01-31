USE [Udemi_Management]
GO

/****** Object:  StoredProcedure [dbo].[Udemi_User_Register]    Script Date: 1/31/2021 11:49:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Udemi_User_Register]
(
	@Email NVARCHAR(100),
	@Password NVARCHAR(255),
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
	IF(EXISTS(SELECT * From User_Info A Where A.UserEmail = @Email))
	BEGIN
		SET @ErrorCode = @Profix + 1
		SET @ErrorMessage = 'Email already exists.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END
	--Kiểm tra số điện thoại
	IF(EXISTS(SELECT * From User_Info A Where A.Phone = @Phone))
	BEGIN
		SET @ErrorCode = @Profix + 2
		SET @ErrorMessage = 'Phone already exists.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END

	INSERT INTO User_Info(UserEmail,UserPassword,FullName,Gender,Phone,DateOfBirth,IsActive,UserType) 
	VALUES (@Email,@Password,@FullName,@Gender,@Phone,@DOB,0,'U')

	SET @ErrorMessage = 'Success'
	Select @ErrorCode err_code, @ErrorMessage err_msg
	Return
End

GO


