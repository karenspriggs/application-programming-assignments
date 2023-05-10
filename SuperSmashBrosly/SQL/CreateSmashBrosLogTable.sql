USE [PROG455FA23]
GO

/****** Object:  Table [dbo].[SmashBrosLog]    Script Date: 5/10/2023 6:38:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SmashBrosLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LogLevel] [nchar](10) NULL,
	[LogMessage] [nchar](100) NULL
) ON [PRIMARY]
GO


