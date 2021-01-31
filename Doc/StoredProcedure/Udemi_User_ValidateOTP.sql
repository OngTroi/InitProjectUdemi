USE [Udemi_Management]
GO

/****** Object:  StoredProcedure [dbo].[Udemi_User_ValidateOTP]    Script Date: 1/29/2021 10:03:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Udemi_User_ValidateOTP]
(
	@OTP NVARCHAR(10)
)
AS
Begin
	Declare @ErrorCode INT=0
	Declare @ErrorMessage NVARCHAR(200)= ''
	Declare @Profix INT=100000

	--Kiểm tra OTP tồn tại
	IF(NOT EXISTS(SELECT * From OTP A Where A.Value = @OTP))
	BEGIN
		SET @ErrorCode = @Profix + 1
		SET @ErrorMessage = 'OTP does not exists.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END
	--Kiểm tra hết hạn
	IF((SELECT Expiredin From OTP A Where A.Value = @OTP) < CURRENT_TIMESTAMP)
	BEGIN
		SET @ErrorCode = @Profix + 2
		SET @ErrorMessage = 'OTP was expired.'
		Select @ErrorCode err_code, @ErrorMessage err_msg
		Return
	END
	--Return thông báo
	Declare @Email NVARCHAR(100)
	Select @Email = A.Email  From OTP A Where A.Value = @OTP
	Update User_Info SET IsActive = 1 where UserEmail = @Email

	SET @ErrorMessage = 'Success'
	Select @ErrorCode err_code, @ErrorMessage err_msg
	Return
End


GO


