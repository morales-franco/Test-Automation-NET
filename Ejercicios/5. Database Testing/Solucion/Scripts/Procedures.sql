USE [AutomateTesting]
GO

/****** Object:  StoredProcedure [dbo].[EmployeeCreate] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmployeeCreate]
	@FirstName nvarchar(100), 
	@LastName nvarchar(100),
	@HireDate DateTime
AS
BEGIN

	IF @HireDate IS NULL
		SET @HireDate=GetDate();

	INSERT INTO [dbo].[Employee]
           ([FirstName]
           ,[LastName]
           ,[HireDate])
     VALUES
           (@FirstName
           ,@LastName
           ,@HireDate);
END
GO

