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
CREATE PROCEDURE [dbo].[ApiDeleteById]
	-- Add the parameters for the stored procedure here
	@id int,
	@ReturnValue int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS(SELECT * FROM dbo.TowerGame WHERE id = @id)
	BEGIN
	DELETE FROM dbo.TowerGame
	WHERE id = @id;
	SET @ReturnValue = 1;
	END
	ELSE
	BEGIN 
	SET @ReturnValue = 0;
	END;
END
GO
