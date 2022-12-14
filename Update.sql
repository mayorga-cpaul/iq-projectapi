USE [EconomicKGB]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update]    Script Date: 10/10/2022 10:45:53 AM ******/
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

EXEC Recover 'kuroko0010@gmail.com'