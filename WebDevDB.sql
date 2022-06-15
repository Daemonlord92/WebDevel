USE [master]
GO
IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = N'WebDevPortDBCore' OR name = N'WebDevPortDBCore')))
	DROP DATABASE WebDevPortDBCore

	CREATE DATABASE WebDevPortDBCore
	GO

	USE WebDevPortDBCore
	GO

	SET ANSI_NULLS ON
	GO

	SET QUOTED_IDENTIFIER ON
	GO

/**DROPPING TABLES ON YOUR DB**/

IF OBJECT_ID('User') IS NOT NULL
	DROP TABLE [User]
GO

IF OBJECT_ID('Project') IS NOT NULL
	DROP TABLE [Project]
GO

IF OBJECT_ID('BugTracker') IS NOT NULL
	DROP TABLE [BugTracker]
GO

/**CREATING TABLES**/

CREATE TABLE [User]
(
	[UserId] NUMERIC(3,0) CONSTRAINT pk_User_UserId PRIMARY KEY IDENTITY (100,1) NOT NULL,
	[Username] VARCHAR(50) CONSTRAINT ck_User_UserUsername CHECK(Username NOT LIKE '[0-9]%') CONSTRAINT uq_User_Username UNIQUE NOT NULL,
	[Password] VARCHAR(300) NOT NULL,
	[EmailId] VARCHAR(300) CONSTRAINT uq_User_UserEmailId UNIQUE NOT NULL
)
GO

CREATE TABLE [Project]
(
	[ProjectId] NUMERIC(4,0) CONSTRAINT pk_Project_ProjectId PRIMARY KEY IDENTITY (1000,1) NOT NULL,
	[ProjectName] VARCHAR(150) CONSTRAINT uq_Project_ProjectName UNIQUE NOT NULL,
	[Description] VARCHAR(400) NOT NULL,
	[ProjectVersion] NUMERIC(3,2) NOT NULL,
	[GitUrl] VARCHAR(MAX) NOT NULL,
	[UserId] NUMERIC(3,0) CONSTRAINT fk_Project_UserId FOREIGN KEY REFERENCES [User](UserId)
)
GO

CREATE TABLE [BugTracker]
(
	[BugId] NUMERIC(6,0) CONSTRAINT pk_BugTracker_BugId PRIMARY KEY IDENTITY(20,2) NOT NULL,
	[BugName] VARCHAR(150) NOT NULL,
	[BugDescription] VARCHAR(300) NOT NULL,
	[GitUrl] VARCHAR(MAX) NOT NULL,
	[UserId] NUMERIC(3,0) CONSTRAINT fk_BugTracker_UserId FOREIGN KEY REFERENCES [User](UserId)
)
GO

/**Stored Procedures**/

CREATE OR ALTER PROCEDURE [dbo].[usp_RegisterUser]
(
	@Username VARCHAR(50),
	@Password VARCHAR(300),
	@EmailId VARCHAR(300)
)
AS
BEGIN
	DECLARE @RETVAL INT
	BEGIN TRY
	IF(LEN(@EmailId) < 5 OR LEN(@EmailId) > 100 OR (@EmailId IS NULL))
		SET @RETVAL = -1
	IF(LEN(@Username) < 4 OR LEN(@Username) > 50 OR (@Username IS NULL))
		SET @RETVAL = -2
	ElSE
	BEGIN
		INSERT INTO [User]
		(
			"Username",
			"Password",
			"EmailId"
		)
		VALUES
		(
			@Username,
			@Password,
			@EmailId
		)
		SET @RETVAL = 1
		RETURN @RETVAL
	END
RETURN @RETVAL
END TRY
BEGIN CATCH
	SET @RETVAL = -99
	RETURN @RETVAL
END CATCH
END
GO

CREATE OR ALTER PROCEDURE [dbo].[usp_PostNewProject]
(
	@ProjectName VARCHAR(150),
	@Description VARCHAR(400),
	@GitUrl VARCHAR(MAX),
	@UserId NUMERIC(3,0)
)
AS
BEGIN
	DECLARE @RETVAL INT
	DECLARE @ProjectVersion NUMERIC(3,2)
	BEGIN TRY
		IF(LEN(@ProjectName) < 4 OR LEN(@ProjectName) > 150 OR (@ProjectName IS NULL))
			SET @RETVAL = -1
		IF(LEN(@GitUrl) < 25 OR (@GitUrl IS NULL))
			SET @RETVAL = -2
		IF(@UserId IS NULL)
			SET @RETVAL = -3
		ELSE
			BEGIN
				SET @ProjectVersion = 1.0
				INSERT INTO [Project]
				(
					"ProjectName",
					"Description",
					"GitUrl",
					"ProjectVersion",
					"UserId"
				)
				VALUES
				(
					@ProjectName,
					@Description,
					@GitUrl,
					@ProjectVersion,
					@UserId
				)
				SET @RETVAL = 1
				RETURN @RETVAL
			END
	END TRY
	BEGIN CATCH
		SET @RETVAL = -99
		RETURN @RETVAL
	END CATCH
END
GO
