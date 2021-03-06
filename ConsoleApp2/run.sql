USE [penndb]
GO
/****** Object:  Table [dbo].[quartzdemo]    Script Date: 2017-11-02 18:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[quartzdemo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[express] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[quartzdemo] ON 

INSERT [dbo].[quartzdemo] ([id], [name], [express]) VALUES (1, N'job1', N'*/1 * * * * ?')
INSERT [dbo].[quartzdemo] ([id], [name], [express]) VALUES (2, N'job2', N'0 */1 * * * ?')
SET IDENTITY_INSERT [dbo].[quartzdemo] OFF
