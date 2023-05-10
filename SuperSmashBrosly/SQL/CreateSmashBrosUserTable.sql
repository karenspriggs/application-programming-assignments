USE [PROG455FA23]
GO

/****** Object:  Table [dbo].[SmashBrosUser]    Script Date: 5/10/2023 5:01:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SmashBrosUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Last_Fighter_Guessed] [varchar](50) NOT NULL,
	[Correct_Guesses] [int] NOT NULL,
	[Attempts] [int] NOT NULL
) ON [PRIMARY]
GO


