IF OBJECT_ID('dbo.OTP', 'U') IS NOT NULL
DROP TABLE dbo.OTP;
Create Table OTP
(
	Id Int NOT NULL IDentity(10000000,1),
	Email NVARCHAR(200) NOT NULL,
	Value Varchar(10) NOT NULL,
	Expiredin DateTime,
	CreatedDate datetime Default Current_TimeStamp,
	PRIMARY KEY (Id)
)
Go