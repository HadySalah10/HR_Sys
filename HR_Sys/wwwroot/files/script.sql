USE [ShababDondeet]
GO
/****** Object:  Table [dbo].[_7alaEgtma3ia]    Script Date: 10/9/2021 2:38:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[_7alaEgtma3ia](
	[id] [int] NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK__7alaEgtma3ia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[3ynyNaqdy]    Script Date: 10/9/2021 2:38:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[3ynyNaqdy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name3ynyNaqdy] [nvarchar](50) NULL,
 CONSTRAINT [PK_3ynyNaqdy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mara7elTa3leem]    Script Date: 10/9/2021 2:38:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mara7elTa3leem](
	[id] [int] NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Mara7elTa3leem] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MostafeedMosahem]    Script Date: 10/9/2021 2:38:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MostafeedMosahem](
	[id] [int] NOT NULL,
	[nameMostafedMosahem] [nvarchar](50) NULL,
 CONSTRAINT [PK_MostafeedMosahem] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalData]    Script Date: 10/9/2021 2:38:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[namePersonalData] [nvarchar](max) NULL,
	[idMostafeedMosahem] [int] NULL,
	[address] [nvarchar](max) NULL,
	[numQawmy] [nvarchar](max) NULL,
	[tele] [nvarchar](max) NULL,
	[date] [nvarchar](max) NULL,
	[wazifa] [nvarchar](max) NULL,
	[nameZog] [nvarchar](max) NULL,
	[id7alaegtma3ia] [int] NULL,
	[idType3imala] [int] NULL,
	[y3oul] [int] NULL,
	[numE3ala] [nvarchar](max) NULL,
	[_7alaS7ia] [nvarchar](max) NULL,
	[dakhlShahry] [nvarchar](max) NULL,
	[markAddress] [nvarchar](max) NULL,
	[typeTamleek] [nvarchar](max) NULL,
	[_7iazaZira3ia] [nvarchar](max) NULL,
	[_7isabBanki] [nvarchar](max) NULL,
	[momtalkatOthers] [nvarchar](max) NULL,
	[taqrirShaml] [nvarchar](max) NULL,
	[notice] [nvarchar](max) NULL,
	[opinionLagna] [nvarchar](max) NULL,
	[imagePath] [nvarchar](max) NULL,
	[Mra7elTa3leem] [nvarchar](max) NULL,
	[tsneef] [nvarchar](max) NULL,
 CONSTRAINT [PK_PersonalData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[table3ard]    Script Date: 10/9/2021 2:38:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table3ard](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPersonalData] [int] NULL,
	[idTypesMosahmatMostafed] [int] NULL,
	[nameMosahma] [nvarchar](max) NULL,
	[valueMosahma] [nvarchar](max) NULL,
	[notice] [nvarchar](max) NULL,
	[id3ynyNaqdy] [int] NULL,
	[dateSahm] [nvarchar](max) NULL,
 CONSTRAINT [PK_table3ard] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type3imala]    Script Date: 10/9/2021 2:38:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type3imala](
	[id] [int] NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Type3imala] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypesMosahmatMostafed]    Script Date: 10/9/2021 2:38:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypesMosahmatMostafed](
	[id] [int] NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_TypesMosahmatMostafed] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[_7alaEgtma3ia] ([id], [name]) VALUES (1, N'اعزب/عزباء')
INSERT [dbo].[_7alaEgtma3ia] ([id], [name]) VALUES (2, N'مطلق/مطلقة')
INSERT [dbo].[_7alaEgtma3ia] ([id], [name]) VALUES (3, N'متزوج/متزوجة')
INSERT [dbo].[_7alaEgtma3ia] ([id], [name]) VALUES (4, N'ارمل/ارملة')
GO
SET IDENTITY_INSERT [dbo].[3ynyNaqdy] ON 

INSERT [dbo].[3ynyNaqdy] ([id], [name3ynyNaqdy]) VALUES (1, N'عينى')
INSERT [dbo].[3ynyNaqdy] ([id], [name3ynyNaqdy]) VALUES (2, N'نقدى')
SET IDENTITY_INSERT [dbo].[3ynyNaqdy] OFF
GO
INSERT [dbo].[Mara7elTa3leem] ([id], [name]) VALUES (1, N'ابتدائى')
INSERT [dbo].[Mara7elTa3leem] ([id], [name]) VALUES (2, N'اعدادى')
INSERT [dbo].[Mara7elTa3leem] ([id], [name]) VALUES (3, N'ثانوى/دبلوم')
INSERT [dbo].[Mara7elTa3leem] ([id], [name]) VALUES (4, N'جامعى')
GO
INSERT [dbo].[MostafeedMosahem] ([id], [nameMostafedMosahem]) VALUES (1, N'مساهم')
INSERT [dbo].[MostafeedMosahem] ([id], [nameMostafedMosahem]) VALUES (2, N'مستفيد')
GO
SET IDENTITY_INSERT [dbo].[PersonalData] ON 

INSERT [dbo].[PersonalData] ([id], [namePersonalData], [idMostafeedMosahem], [address], [numQawmy], [tele], [date], [wazifa], [nameZog], [id7alaegtma3ia], [idType3imala], [y3oul], [numE3ala], [_7alaS7ia], [dakhlShahry], [markAddress], [typeTamleek], [_7iazaZira3ia], [_7isabBanki], [momtalkatOthers], [taqrirShaml], [notice], [opinionLagna], [imagePath], [Mra7elTa3leem], [tsneef]) VALUES (5, N'سلوى السعيد ابراهيم عبدالحى', 2, N'دنديط-ميت غمر-دقهلية', N'28601201201267', N'01226350845', N'10/9/2021 1:38:09 PM', N'ربة منزل ', N'احمد الشحات متولى محمد عبدالله', 4, 3, 1, N'1', N'مريضة -غسيل كلى', N'900', N'شارع الموافية -بجوار الدكتور خالد الشاذلي
', N'تمليك', N'لا يوجد', N'لا يوجد', N'لا يوجد', N'', N'غسيل كلي وتعمل بائعة خضروات ', N'', NULL, N'اعدادي', N'')
SET IDENTITY_INSERT [dbo].[PersonalData] OFF
GO
SET IDENTITY_INSERT [dbo].[table3ard] ON 

INSERT [dbo].[table3ard] ([id], [idPersonalData], [idTypesMosahmatMostafed], [nameMosahma], [valueMosahma], [notice], [id3ynyNaqdy], [dateSahm]) VALUES (9, 5, 4, N'شنطة مدرسية -ادوات مكتبية', N'200', N'', 1, N'10/9/2021 1:55:16 PM')
SET IDENTITY_INSERT [dbo].[table3ard] OFF
GO
INSERT [dbo].[Type3imala] ([id], [name]) VALUES (1, N'عمالة منتظمة')
INSERT [dbo].[Type3imala] ([id], [name]) VALUES (2, N'غير منتظمة')
INSERT [dbo].[Type3imala] ([id], [name]) VALUES (3, N'أخرى')
GO
INSERT [dbo].[TypesMosahmatMostafed] ([id], [name]) VALUES (1, N'توزيع مشاركات رمضان')
INSERT [dbo].[TypesMosahmatMostafed] ([id], [name]) VALUES (2, N'توزيع لبس العيد')
INSERT [dbo].[TypesMosahmatMostafed] ([id], [name]) VALUES (3, N'يوم اليتيم')
INSERT [dbo].[TypesMosahmatMostafed] ([id], [name]) VALUES (4, N'الرعاية الإجتماعية')
GO
ALTER TABLE [dbo].[PersonalData]  WITH CHECK ADD  CONSTRAINT [FK_PersonalData__7alaEgtma3ia] FOREIGN KEY([id7alaegtma3ia])
REFERENCES [dbo].[_7alaEgtma3ia] ([id])
GO
ALTER TABLE [dbo].[PersonalData] CHECK CONSTRAINT [FK_PersonalData__7alaEgtma3ia]
GO
ALTER TABLE [dbo].[PersonalData]  WITH CHECK ADD  CONSTRAINT [FK_PersonalData_PersonalData] FOREIGN KEY([id])
REFERENCES [dbo].[PersonalData] ([id])
GO
ALTER TABLE [dbo].[PersonalData] CHECK CONSTRAINT [FK_PersonalData_PersonalData]
GO
ALTER TABLE [dbo].[PersonalData]  WITH CHECK ADD  CONSTRAINT [FK_PersonalData_Type3imala] FOREIGN KEY([idType3imala])
REFERENCES [dbo].[Type3imala] ([id])
GO
ALTER TABLE [dbo].[PersonalData] CHECK CONSTRAINT [FK_PersonalData_Type3imala]
GO
ALTER TABLE [dbo].[table3ard]  WITH CHECK ADD  CONSTRAINT [FK_table3ard_3ynyNaqdy] FOREIGN KEY([id3ynyNaqdy])
REFERENCES [dbo].[3ynyNaqdy] ([id])
GO
ALTER TABLE [dbo].[table3ard] CHECK CONSTRAINT [FK_table3ard_3ynyNaqdy]
GO
ALTER TABLE [dbo].[table3ard]  WITH CHECK ADD  CONSTRAINT [FK_table3ard_PersonalData] FOREIGN KEY([idPersonalData])
REFERENCES [dbo].[PersonalData] ([id])
GO
ALTER TABLE [dbo].[table3ard] CHECK CONSTRAINT [FK_table3ard_PersonalData]
GO
ALTER TABLE [dbo].[table3ard]  WITH CHECK ADD  CONSTRAINT [FK_table3ard_TypesMosahmatMostafed] FOREIGN KEY([idTypesMosahmatMostafed])
REFERENCES [dbo].[TypesMosahmatMostafed] ([id])
GO
ALTER TABLE [dbo].[table3ard] CHECK CONSTRAINT [FK_table3ard_TypesMosahmatMostafed]
GO
