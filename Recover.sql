USE [EconomicIE]
GO
/****** Object:  StoredProcedure [dbo].[Recover]    Script Date: 10/8/2022 5:08:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Recover]
	@email nvarchar(200)
As
Begin 
	SELECT CONVERT(nvarchar(200), DECRYPTBYPASSPHRASE('password',Password )) as Password from [User] where Email =@email
END