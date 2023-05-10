-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UserApiInsertRecord]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Username char(20),
	@Password char(100),
	@Attempts int,
	@CorrectGuesses int,
	@LastFighter char(20),
	@ReturnValue int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF NOT EXISTS(SELECT * FROM dbo.SmashBrosUser WHERE ID = @ID)
	BEGIN
	INSERT INTO dbo.SmashBrosUser
	Values(@Username, @Password, @LastFighter, @CorrectGuesses, @Attempts)
	SET @ReturnValue = 1
	END
	ELSE 
	BEGIN 
	SET @ReturnValue = 0;
	END;
END
GO