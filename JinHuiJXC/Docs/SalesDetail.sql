USE [JinHuiJXCData]
GO

/****** Object:  Table [dbo].[SalesRec]    Script Date: 2017/5/23 16:32:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SalesRecDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,				--ID,自增
	[SalesID] [int] NULL,										--销售单ID
	[GoodsID] [int] NULL,									--商品ID
	[GoodsName] [nvarchar](100) NULL,				--商品名称
	[Nocode] [nvarchar](100) NULL,						--商品编码
	[Barcode] [nvarchar](100) NULL,					--商品条码
	[Pinyin] [nvarchar](100) NULL,						--拼音编码
	[PackMin] [int] NULL,									--最小包装
	[UnitPrice] [decimal](18, 2) NULL,					--单价
	[Sum] [int] NULL,											--数量
	[DisRate] [int] NULL,										--折扣(%)
	[TaxRate] [int] NULL,										--税率(%)
	[TotalPrice] [decimal](18, 2) NULL,					--总价
	[AddUser] [int] NULL,									--添加人ID
	[AddTime] [datetime] NULL,							--添加时间
	[LastTime] [datetime] NULL,							--修改时间
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SalesDetail] ADD  DEFAULT ((0)) FOR [SalesID]
GO

ALTER TABLE [dbo].[SalesDetail] ADD  DEFAULT ((0)) FOR [GoodsID]
GO

ALTER TABLE [dbo].[SalesDetail] ADD  DEFAULT ('') FOR [GoodsName]
GO

ALTER TABLE [dbo].[SalesDetail] ADD  DEFAULT ('') FOR [Nocode]
GO

ALTER TABLE [dbo].[SalesDetail] ADD  DEFAULT ('') FOR [Barcode]
GO

ALTER TABLE [dbo].[SalesDetail] ADD  DEFAULT ('') FOR [Pinyin]
GO

ALTER TABLE [dbo].[SalesDetail] ADD  DEFAULT ((0)) FOR [PackMin]
GO

ALTER TABLE [dbo].[SalesDetail] ADD  DEFAULT ((0)) FOR [UnitPrice]
GO

ALTER TABLE [dbo].[SalesDetail] ADD DEFAULT ((0)) FOR [Sum]
GO

ALTER TABLE [dbo].[SalesDetail] ADD DEFAULT ((0)) FOR [DisRate]
GO

ALTER TABLE [dbo].[SalesDetail] ADD DEFAULT ((0)) FOR [TaxRate]
GO

ALTER TABLE [dbo].[SalesDetail] ADD  DEFAULT ((0)) FOR [TotalPrice]
GO

ALTER TABLE [dbo].[SalesDetail] ADD DEFAULT ((1)) FOR [AddUser]
GO

ALTER TABLE [dbo].[SalesDetail] ADD  DEFAULT (getdate()) FOR [AddTime]
GO

ALTER TABLE [dbo].[SalesDetail] ADD  DEFAULT (getdate()) FOR [LastTime]
GO


