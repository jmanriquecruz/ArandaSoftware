GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 26/04/2020 6:58:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Names] [varchar](100) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](10) NULL,
	[Email] [varchar](30) NOT NULL,
	[Age] [int] NOT NULL,
	[Rol] [varchar](10) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO