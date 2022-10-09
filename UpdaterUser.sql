USE [EconomicIE]
GO
/****** Object:  StoredProcedure [dbo].[sp_Registras]    Script Date: 10/8/2022 5:55:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Update]
    -- Add the parameters for the stored procedure here
    @name nvarchar(100),
	@email nvarchar(100),
	@phoneNumber nvarchar(100),
	@dni nvarchar(100),
	@password nvarchar(100),
	@estado bit,
	@creacion datetime
AS
BEGIN
	UPDATE  [User] SET Name = @name, Email = @email, PhoneNumber = @phoneNumber,
	DNI = @dni, Password = ENCRYPTBYPASSPHRASE('password', @password), Creation = @creacion , State = @estado
END