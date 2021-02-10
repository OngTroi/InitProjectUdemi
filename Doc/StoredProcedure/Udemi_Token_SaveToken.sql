USE [Udemi_Management]
GO

/****** Object:  StoredProcedure [dbo].[Udemi_User_SaveToken]    Script Date: 1/31/2021 10:08:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Udemi_Token_SaveToken]
(
	@Email NVARCHAR(100),
	@Token NVARCHAR(255),
	@ExpiredDate DateTime
)
AS
Begin

	--Kiểm tra User có tồn tại Token
	IF(EXISTS(SELECT * From Token_Manager A Where A.Email = @Email))
	BEGIN
		Delete Token_Manager Where Email = @Email
		Return
	END

	Declare @UserType NVARCHAR(20)
	SELECT @UserType = U.UserType FROM User_Info U Where U.UserEmail = @Email

	INSERT INTO Token_Manager(TokenID,Email,ExpiredTime, User_Type) VALUES (@Token,@Email,@ExpiredDate,@UserType);
	SELECT * From Token_Manager A Where A.Email = @Email;
	Return;
End
GO


