USE [Udemi_Management]
GO

/****** Object:  StoredProcedure [dbo].[Udemi_User_CreateOTP]    Script Date: 1/31/2021 6:34:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Udemi_User_CreateOTP]
(
	@Email NVARCHAR(100),
	@Value NVARCHAR(20),
	@ExpiredTime DATETIME
)
AS
Begin
	--Kiểm tra OTP tồn tại
	IF(EXISTS(SELECT * From OTP A Where A.Email = @Email ))
	BEGIN
		DELETE OTP WHERE Email = @Email
	END

	INSERT INTO OTP (Email,Value,Expiredin) Values (@Email, @Value,@ExpiredTime)
	
	Select A.Email,A.Value OTP,A.Expiredin From OTP A Where A.Email = @Email
	Return
End


GO


