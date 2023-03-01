USE [PROG455FA23]
GO

INSERT INTO [dbo].[User]
           ([First_Name]
           ,[Last_Name]
           ,[Username]
           ,[Password]
           ,[Role])
     VALUES
           ('Test', 'User', 'testuser', '616104ebd93e67ae20bac90c86483da3cae1ee5b1c1483f739372a88ff1e79f9', 'User'),
		   ('Test', 'Admin', 'testadmin', '749f09bade8aca755660eeb17792da880218d4fbdc4e25fbec279d7fe9f65d70', 'Admin'),
		   ('Test', 'SuperAdmin', 'testsuperadmin', '540c34bbf833d2a33fabc87823ba122e033f1081a849c4ef21dbfd34b6d85ac2', 'Super Admin')
GO


