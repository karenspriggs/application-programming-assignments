USE [PROG455FA23]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/1/2023 6:25:34 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/1/2023 6:25:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [varchar](20) NOT NULL,
	[Last_Name] [varchar](20) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](64) NOT NULL,
	[Role] [varchar](20) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([User_ID], [First_Name], [Last_Name], [Username], [Password], [Role]) VALUES (1, N'Test                ', N'User                ', N'testuser            ', N'616104ebd93e67ae20bac90c86483da3cae1ee5b1c1483f739372a88ff1e79f9', N'User                ')
INSERT [dbo].[User] ([User_ID], [First_Name], [Last_Name], [Username], [Password], [Role]) VALUES (2, N'Test                ', N'Admin               ', N'testadmin           ', N'749f09bade8aca755660eeb17792da880218d4fbdc4e25fbec279d7fe9f65d70', N'Admin               ')
INSERT [dbo].[User] ([User_ID], [First_Name], [Last_Name], [Username], [Password], [Role]) VALUES (3, N'Test                ', N'SuperAdmin          ', N'testsuperadmin      ', N'540c34bbf833d2a33fabc87823ba122e033f1081a849c4ef21dbfd34b6d85ac2', N'Super Admin         ')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
