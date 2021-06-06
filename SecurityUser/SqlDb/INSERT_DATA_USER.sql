SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([IdUser], [LoginName], [Password], [Names], [Address], [PhoneNumber], [Email], [Age], [Rol]) 
VALUES (1, N'jmanrique', N'123456', N'jose manrique', N'aosdkjasdh', N'3108720506', N'jmanrique@gmail.com', 35, N'administrador')
SET IDENTITY_INSERT [dbo].[User] OFF
