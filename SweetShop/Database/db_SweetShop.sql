USE [db_SweetShop]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/31/2022 4:22:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CatID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Details] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedbacks]    Script Date: 12/31/2022 4:22:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedbacks](
	[FeedBackID] [int] IDENTITY(1,1) NOT NULL,
	[ShopFID] [int] NULL,
	[UserFID] [int] NULL,
	[FeedbackType] [nvarchar](50) NOT NULL,
	[Message] [nvarchar](400) NOT NULL,
	[Date] [date] NOT NULL,
	[Time] [time](7) NOT NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Feedbacks] PRIMARY KEY CLUSTERED 
(
	[FeedBackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 12/31/2022 4:22:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CatFID] [int] NULL,
	[ShopFID] [int] NULL,
	[SalePrice] [float] NOT NULL,
	[CostPrice] [float] NOT NULL,
	[MFGDate] [date] NOT NULL,
	[EXPDate] [date] NOT NULL,
	[Image1] [nvarchar](max) NULL,
	[Image2] [nvarchar](max) NULL,
	[Type] [nvarchar](50) NULL,
	[Quantity] [int] NOT NULL,
	[Rating] [int] NULL,
	[Details] [nvarchar](250) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 12/31/2022 4:22:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderFID] [int] NULL,
	[ItemFID] [int] NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/31/2022 4:22:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserFID] [int] NULL,
	[Date] [date] NULL,
	[Time] [time](7) NULL,
	[Details] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shops]    Script Date: 12/31/2022 4:22:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shops](
	[ShopID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BranchCode] [nchar](10) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[Image] [nvarchar](max) NULL,
	[Details] [nvarchar](250) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Shops] PRIMARY KEY CLUSTERED 
(
	[ShopID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/31/2022 4:22:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Details] [nvarchar](250) NULL,
	[Status] [nvarchar](50) NULL,
	[ShopFID] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CatID], [Name], [Image], [Details], [Status]) VALUES (1, N'Gulab Jaman Rasgullah', N'taste-of-india506.jpg', N'All kinds of Cakes', N'Active')
GO
INSERT [dbo].[Categories] ([CatID], [Name], [Image], [Details], [Status]) VALUES (2, N'Sweets', N'pressure-cooker-milk-burfi.jpg', N'All kinds of Pastries', N'Active')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Items] ON 
GO
INSERT [dbo].[Items] ([ItemID], [Name], [CatFID], [ShopFID], [SalePrice], [CostPrice], [MFGDate], [EXPDate], [Image1], [Image2], [Type], [Quantity], [Rating], [Details], [Status]) VALUES (3, N'Rasgullah ', 1, 2, 1100, 700, CAST(N'2022-10-08' AS Date), CAST(N'2022-08-10' AS Date), N'rasgulla_5819.jpg', NULL, NULL, 10, 5, N'Choclate Cake', N'Active')
GO
INSERT [dbo].[Items] ([ItemID], [Name], [CatFID], [ShopFID], [SalePrice], [CostPrice], [MFGDate], [EXPDate], [Image1], [Image2], [Type], [Quantity], [Rating], [Details], [Status]) VALUES (1005, N'Barfi', 2, 4, 1100, 650, CAST(N'2012-12-12' AS Date), CAST(N'2012-12-12' AS Date), N'pressure-cooker-milk-burfi.jpg', NULL, NULL, 12, 5, N'Pineapple Cake', N'Active')
GO
INSERT [dbo].[Items] ([ItemID], [Name], [CatFID], [ShopFID], [SalePrice], [CostPrice], [MFGDate], [EXPDate], [Image1], [Image2], [Type], [Quantity], [Rating], [Details], [Status]) VALUES (1007, N'Gulab Jaman', 1, 2, 1300, 800, CAST(N'2012-12-12' AS Date), CAST(N'2012-12-12' AS Date), N'1604695335894.jpeg', NULL, NULL, 20, 5, N'Vanilla Cake', N'Active')
GO
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 
GO
INSERT [dbo].[OrderDetails] ([OrderDetailID], [OrderFID], [ItemFID], [Quantity]) VALUES (1, 1, 1005, 2)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailID], [OrderFID], [ItemFID], [Quantity]) VALUES (2, 2, 3, 3)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailID], [OrderFID], [ItemFID], [Quantity]) VALUES (3, 3, 1005, 2)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailID], [OrderFID], [ItemFID], [Quantity]) VALUES (4, 3, 3, 1)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailID], [OrderFID], [ItemFID], [Quantity]) VALUES (5, NULL, 3, 3)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailID], [OrderFID], [ItemFID], [Quantity]) VALUES (6, NULL, 1005, 1)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailID], [OrderFID], [ItemFID], [Quantity]) VALUES (7, 5, NULL, 2)
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderID], [UserFID], [Date], [Time], [Details], [Status]) VALUES (1, 1001, CAST(N'2022-12-27' AS Date), CAST(N'16:04:17.5728687' AS Time), NULL, N'Waiting')
GO
INSERT [dbo].[Orders] ([OrderID], [UserFID], [Date], [Time], [Details], [Status]) VALUES (2, 1001, CAST(N'2022-12-27' AS Date), CAST(N'18:15:13.3273869' AS Time), NULL, N'Delivered')
GO
INSERT [dbo].[Orders] ([OrderID], [UserFID], [Date], [Time], [Details], [Status]) VALUES (3, 1001, CAST(N'2022-12-27' AS Date), CAST(N'20:13:52.3802420' AS Time), NULL, N'Pending')
GO
INSERT [dbo].[Orders] ([OrderID], [UserFID], [Date], [Time], [Details], [Status]) VALUES (5, 1001, CAST(N'2022-12-31' AS Date), CAST(N'15:25:57.4626750' AS Time), NULL, N'Pending')
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Shops] ON 
GO
INSERT [dbo].[Shops] ([ShopID], [Name], [BranchCode], [Phone], [Email], [Address], [Image], [Details], [Status]) VALUES (2, N'Cakes Bakes', N'xy12      ', N'0301123453', N'cakesbakes@info.com', N'Pakistan', N'Screenshot_20221227_060945.png', N'Details On Demand', N'Active')
GO
INSERT [dbo].[Shops] ([ShopID], [Name], [BranchCode], [Phone], [Email], [Address], [Image], [Details], [Status]) VALUES (4, N'Hot Bakers', N'xy12      ', N'0301123453', N'hotbakers@gmail.com', N'Pakistan', N'Screenshot_20221227_060924.png', N'Details On Demand', N'Active')
GO
SET IDENTITY_INSERT [dbo].[Shops] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserID], [Name], [Email], [Password], [Phone], [Address], [Type], [Image], [Details], [Status], [ShopFID]) VALUES (1001, N'Customer', N'customer@customer.com', N'customer', N'030000000', N'Gujranwala Main City', N'Customer', NULL, N'NA', N'Active', NULL)
GO
INSERT [dbo].[Users] ([UserID], [Name], [Email], [Password], [Phone], [Address], [Type], [Image], [Details], [Status], [ShopFID]) VALUES (1003, N'Admin', N'admin@admin.com', N'admin', N'NA', N'NA', N'Admin', N'NA', N'N/A', N'Active', NULL)
GO
INSERT [dbo].[Users] ([UserID], [Name], [Email], [Password], [Phone], [Address], [Type], [Image], [Details], [Status], [ShopFID]) VALUES (2004, N'Manager', N'manager@manager.com', N'manager', N'NA', N'NA', N'Manager', N'N/A', N'N/A', N'Active', 4)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD  CONSTRAINT [FK_Feedbacks_Shops] FOREIGN KEY([ShopFID])
REFERENCES [dbo].[Shops] ([ShopID])
GO
ALTER TABLE [dbo].[Feedbacks] CHECK CONSTRAINT [FK_Feedbacks_Shops]
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD  CONSTRAINT [FK_Feedbacks_Users] FOREIGN KEY([UserFID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Feedbacks] CHECK CONSTRAINT [FK_Feedbacks_Users]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Categories] FOREIGN KEY([CatFID])
REFERENCES [dbo].[Categories] ([CatID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Categories]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Shops] FOREIGN KEY([ShopFID])
REFERENCES [dbo].[Shops] ([ShopID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Shops]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Items] FOREIGN KEY([ItemFID])
REFERENCES [dbo].[Items] ([ItemID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Items]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderFID])
REFERENCES [dbo].[Orders] ([OrderID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserFID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Shops] FOREIGN KEY([ShopFID])
REFERENCES [dbo].[Shops] ([ShopID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Shops]
GO
