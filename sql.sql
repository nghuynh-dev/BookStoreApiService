USE [BanHang2]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 19/06/2022 13:36:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Fullname] [nvarchar](max) NULL,
	[IsAdmin] [bit] NOT NULL,
	[Avatar] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Carts]    Script Date: 19/06/2022 13:36:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 19/06/2022 13:36:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [int] NOT NULL,
	[AccountID] [int] NOT NULL,
 CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 19/06/2022 13:36:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NULL,
	[AccountId] [int] NOT NULL,
	[IssuedDate] [datetime2](7) NOT NULL,
	[ShippingAddress] [nvarchar](max) NULL,
	[ShippingPhone] [nvarchar](max) NULL,
	[Total] [money] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 19/06/2022 13:36:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Productname] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[ProductTypeId] [int] NOT NULL DEFAULT ((0)),
	[SKU] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL DEFAULT (CONVERT([bit],(0))),
	[Stock] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 19/06/2022 13:36:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_ProductTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([Id], [Username], [Password], [Email], [Phone], [Address], [Fullname], [IsAdmin], [Avatar], [Status]) VALUES (1, N'admin', N'admin', N'admin@Eshop.com', N'01234567890', N'Tp.Hồ Chí Minh', N'Nguyễn Văn Ad Min', 1, N'admin.jpg', 1)
INSERT [dbo].[Accounts] ([Id], [Username], [Password], [Email], [Phone], [Address], [Fullname], [IsAdmin], [Avatar], [Status]) VALUES (2, N'john', N'123456', N'john@gmail.com', N'0905486957', N'Đà Nẵng', N'John Henry', 0, N'john.jpg', 1)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Productname], [Description], [Price], [Image], [ProductTypeId], [SKU], [Status], [Stock]) VALUES (1, N'Tuổi trẻ đáng giá bao nhiêu', N'Rosie Nguyễn', 45000, N'1.jpg', 5, N'WT3WPGZ9BTWB', 1, 6)
INSERT [dbo].[Products] ([Id], [Productname], [Description], [Price], [Image], [ProductTypeId], [SKU], [Status], [Stock]) VALUES (2, N'Bứt phá điểm thi THPT Quốc gia môn Hóa học', N'Nguyễn Đức Dũng', 51000, N'2.jpg', 2, N'98IOWWXWYVQ4', 1, 6)
INSERT [dbo].[Products] ([Id], [Productname], [Description], [Price], [Image], [ProductTypeId], [SKU], [Status], [Stock]) VALUES (3, N'Khéo ăn khéo nói sẽ có được thiên hạ', N'Trác Nhã', 59000, N'3.jpg', 6, N'21RH48HRFXX8', 1, 0)
INSERT [dbo].[Products] ([Id], [Productname], [Description], [Price], [Image], [ProductTypeId], [SKU], [Status], [Stock]) VALUES (4, N'Nhà giả kim', N'Paulo Coelho', 53000, N'4.jpg', 3, N'QOXYSDE605P5', 1, 1)
INSERT [dbo].[Products] ([Id], [Productname], [Description], [Price], [Image], [ProductTypeId], [SKU], [Status], [Stock]) VALUES (5, N'Để yên cho bác sĩ "Hiền"', N'BS. Ngô Đức Hùng', 52000, N'5.jpg', 4, N'6YI6TZ3JPO1L', 1, 30)
INSERT [dbo].[Products] ([Id], [Productname], [Description], [Price], [Image], [ProductTypeId], [SKU], [Status], [Stock]) VALUES (6, N'Mình là cá, việc của mình là bơi ', N'Takeshi Furukawa', 57000, N'6.jpg', 3, N'YHB5JTSVRF8E', 1, 9)
INSERT [dbo].[Products] ([Id], [Productname], [Description], [Price], [Image], [ProductTypeId], [SKU], [Status], [Stock]) VALUES (7, N'Đời ngắn đừng ngủ dài', N'Robin Sharma', 42000, N'7.jpg', 3, N'LXL64LZAR5M2', 1, 1)
INSERT [dbo].[Products] ([Id], [Productname], [Description], [Price], [Image], [ProductTypeId], [SKU], [Status], [Stock]) VALUES (8, N'Bứt phá điểm thi THPT Quốc gia môn Toán', N'ThS. Đỗ Đường Hiếu', 51000, N'8.jpg', 2, N'C5V645HVP91W', 1, 0)
INSERT [dbo].[Products] ([Id], [Productname], [Description], [Price], [Image], [ProductTypeId], [SKU], [Status], [Stock]) VALUES (9, N'Cà phê cùng Tony ', N'Tony Buổi Sáng', 62000, N'9.jpg', 6, N'4KLYT2UF7VB9', 1, 18)
INSERT [dbo].[Products] ([Id], [Productname], [Description], [Price], [Image], [ProductTypeId], [SKU], [Status], [Stock]) VALUES (10, N'Em sẽ đến cùng cơn mưa', N'Ichikawa Takuji', 56000, N'10.jpg', 5, N'KBD67VI81M80', 1, 62)
INSERT [dbo].[Products] ([Id], [Productname], [Description], [Price], [Image], [ProductTypeId], [SKU], [Status], [Stock]) VALUES (11, N'Quẳng gánh lo đi mà vui sống', N'Dale Carnegie', 45000, N'11.jpg', 6, N'3RISEFVDWYVF', 1, 107)
INSERT [dbo].[Products] ([Id], [Productname], [Description], [Price], [Image], [ProductTypeId], [SKU], [Status], [Stock]) VALUES (12, N'Mình nói gì khi nói về hạnh phúc?', N'Rosie Nguyễn', 36000, N'12.jpg', 5, N'VIAZXR3Y24IY', 1, 46)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[ProductTypes] ON 

INSERT [dbo].[ProductTypes] ([Id], [Name], [Status]) VALUES (1, N'Sách giáo khoa', 1)
INSERT [dbo].[ProductTypes] ([Id], [Name], [Status]) VALUES (2, N'Sách tham khảo', 1)
INSERT [dbo].[ProductTypes] ([Id], [Name], [Status]) VALUES (3, N'Sách nước ngoài', 1)
INSERT [dbo].[ProductTypes] ([Id], [Name], [Status]) VALUES (4, N'Báo & Tạp chí', 1)
INSERT [dbo].[ProductTypes] ([Id], [Name], [Status]) VALUES (5, N'Tiểu thuyết & Tự truyện', 1)
INSERT [dbo].[ProductTypes] ([Id], [Name], [Status]) VALUES (6, N'Khác', 1)
SET IDENTITY_INSERT [dbo].[ProductTypes] OFF
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Accounts_AccountId]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Products_ProductId]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Invoices_InvoiceId] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Invoices_InvoiceId]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Products_ProductId]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Accounts_AccountId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductTypes_ProductTypeId] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductTypes_ProductTypeId]
GO
