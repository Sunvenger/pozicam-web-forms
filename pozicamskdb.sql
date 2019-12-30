USE [pozicamsk]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 30. 12. 2019 19:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Description] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category_StoreItem]    Script Date: 30. 12. 2019 19:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category_StoreItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[StoreItemId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManagmentState]    Script Date: 30. 12. 2019 19:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagmentState](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManagmentTask]    Script Date: 30. 12. 2019 19:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagmentTask](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NULL,
	[Description] [varchar](max) NULL,
	[CreationDate] [datetime] NULL,
	[DeadlineDate] [datetime] NULL,
	[Priority] [int] NULL,
	[CreatorUserId] [int] NULL,
	[Cost] [money] NULL,
	[Rent] [money] NULL,
	[ManagmentStateId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoreItem]    Script Date: 30. 12. 2019 19:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NULL,
	[Description] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoreItem_User_Relations]    Script Date: 30. 12. 2019 19:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreItem_User_Relations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[StoreItemId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 30. 12. 2019 19:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](150) NULL,
	[LastName] [varchar](150) NULL,
	[Email] [varchar](150) NULL,
	[IsVerified] [bit] NULL,
	[Password] [varchar](max) NULL,
	[ActivationKey] [varchar](50) NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (1, N'Auto - Moto', NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (2, N'PC', NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (3, N'Dom a záhrada', NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (4, N'TV', NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[ManagmentState] ON 

INSERT [dbo].[ManagmentState] ([id], [Name]) VALUES (1, N'Neschválené')
INSERT [dbo].[ManagmentState] ([id], [Name]) VALUES (2, N'Čaká sa na zahájenie')
INSERT [dbo].[ManagmentState] ([id], [Name]) VALUES (3, N'Vykonáva sa')
INSERT [dbo].[ManagmentState] ([id], [Name]) VALUES (4, N'Dokončená')
INSERT [dbo].[ManagmentState] ([id], [Name]) VALUES (5, N'Prerušená')
INSERT [dbo].[ManagmentState] ([id], [Name]) VALUES (6, N'Zrušená')
SET IDENTITY_INSERT [dbo].[ManagmentState] OFF
SET IDENTITY_INSERT [dbo].[ManagmentTask] ON 

INSERT [dbo].[ManagmentTask] ([Id], [Name], [Description], [CreationDate], [DeadlineDate], [Priority], [CreatorUserId], [Cost], [Rent], [ManagmentStateId]) VALUES (12, N'Oprava kuchynského robota', N'Potrebné opraviť trimmer a Zložiť mechaniku', CAST(N'2019-12-29T21:36:00.503' AS DateTime), CAST(N'2019-12-31T00:00:00.000' AS DateTime), 1, 11, 12.7000, 35.0000, 1)
INSERT [dbo].[ManagmentTask] ([Id], [Name], [Description], [CreationDate], [DeadlineDate], [Priority], [CreatorUserId], [Cost], [Rent], [ManagmentStateId]) VALUES (13, N'Ninštalovať tlačiareň', N'Nainštalovať tlaćiareň pre "čistu dušu"', CAST(N'2019-12-29T21:40:49.323' AS DateTime), CAST(N'2019-12-31T00:00:00.000' AS DateTime), 1, 11, 20.0000, 20.0000, 1)
SET IDENTITY_INSERT [dbo].[ManagmentTask] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [IsVerified], [Password], [ActivationKey], [IsAdmin]) VALUES (11, NULL, NULL, N'sunvenger@gmail.com', 1, N'test', N'T7V4REUIPY7DEDT4Z93N', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Category_StoreItem]  WITH CHECK ADD  CONSTRAINT [FK_Category_StoreItem_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Category_StoreItem] CHECK CONSTRAINT [FK_Category_StoreItem_Category]
GO
ALTER TABLE [dbo].[Category_StoreItem]  WITH CHECK ADD  CONSTRAINT [FK_Category_StoreItem_StoreItem] FOREIGN KEY([StoreItemId])
REFERENCES [dbo].[StoreItem] ([Id])
GO
ALTER TABLE [dbo].[Category_StoreItem] CHECK CONSTRAINT [FK_Category_StoreItem_StoreItem]
GO
ALTER TABLE [dbo].[ManagmentTask]  WITH CHECK ADD  CONSTRAINT [FK_ManagmentTask_ManagmentState] FOREIGN KEY([ManagmentStateId])
REFERENCES [dbo].[ManagmentState] ([id])
GO
ALTER TABLE [dbo].[ManagmentTask] CHECK CONSTRAINT [FK_ManagmentTask_ManagmentState]
GO
ALTER TABLE [dbo].[ManagmentTask]  WITH CHECK ADD  CONSTRAINT [FK_ManagmentTask_User] FOREIGN KEY([CreatorUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ManagmentTask] CHECK CONSTRAINT [FK_ManagmentTask_User]
GO
ALTER TABLE [dbo].[StoreItem_User_Relations]  WITH CHECK ADD  CONSTRAINT [FK_StoreItem_User_Relations_StoreItem] FOREIGN KEY([StoreItemId])
REFERENCES [dbo].[StoreItem] ([Id])
GO
ALTER TABLE [dbo].[StoreItem_User_Relations] CHECK CONSTRAINT [FK_StoreItem_User_Relations_StoreItem]
GO
ALTER TABLE [dbo].[StoreItem_User_Relations]  WITH CHECK ADD  CONSTRAINT [FK_StoreItem_User_Relations_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[StoreItem_User_Relations] CHECK CONSTRAINT [FK_StoreItem_User_Relations_User]
GO
