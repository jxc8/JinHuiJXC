USE [JinHuiJXCData]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/** 销售记录表 **/

CREATE TABLE [dbo].[SalesRec](
	[ID] [int] IDENTITY(1,1) NOT NULL,				--销售记录ID,自增
	[SalesNo] [int] NULL,							--销售单据编号
	[SalesDate] [datetime] NULL,					--销售单据日期
	[SalesType] [int] NULL,							--单据类型：1小票2发票3收据4发货单5出库单
	[SalerName] [int] NULL,							--销售人员ID
	[MemberNo] [int] NULL,							--会员编号
	[MemberName] [nvarchar](100) NULL,				--会员姓名
	[MemberScore] [int] NULL,						--增加积分
	[ChargeAmount] [decimal](18, 2) NULL,				--其它费用
	[DiscountAmount] [decimal](18, 2) NULL,			--其它优惠
	[ReceiveAmount] [decimal](18, 2) NULL,			--实收金额=总价+费用-优惠
	[PaymentMethod] [int] NULL,					--付款方式：1现金2银行卡3信用卡4支付宝5微信6尚未付款
	[DeliveryMethod] [int] NULL,					--发货方式：1现售2网售3送货上门4货到付款
	[Desc] [nvarchar](2000) NULL,					--备注说明
    	[State]	[int]    NULL,						--订单状态0无效1有效					
	[AddUser] [int] NULL,							--添加人ID
	[AddTime] [datetime] NULL,						--添加时间
	[LastTime] [datetime] NULL,						--修改时间
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SalesRec] ADD  DEFAULT ((0)) FOR [SalesNo]
GO

ALTER TABLE [dbo].[SalesRec] ADD  DEFAULT ((0)) FOR [SalesType]
GO

ALTER TABLE [dbo].[SalesRec] ADD  DEFAULT ((0)) FOR [SalerName]
GO

ALTER TABLE [dbo].[SalesRec] ADD  DEFAULT ((0)) FOR [MemberNo]
GO

ALTER TABLE [dbo].[SalesRec] ADD  DEFAULT ('') FOR [MemberName]
GO

ALTER TABLE [dbo].[SalesRec] ADD  DEFAULT ((0)) FOR [MemberScore]
GO

ALTER TABLE [dbo].[SalesRec] ADD  DEFAULT ((0)) FOR [ChargeAmount]
GO

ALTER TABLE [dbo].[SalesRec] ADD  DEFAULT ((0)) FOR [DiscountAmount]
GO

ALTER TABLE [dbo].[SalesRec] ADD  DEFAULT ((0)) FOR [ReceiveAmount]
GO

ALTER TABLE [dbo].[SalesRec] ADD  DEFAULT ((0)) FOR [PaymentMethod]
GO

ALTER TABLE [dbo].[SalesRec] ADD  DEFAULT ((0)) FOR [DeliveryMethod]
GO

ALTER TABLE [dbo].[SalesRec] ADD  DEFAULT ('') FOR [Desc]
GO

ALTER TABLE [dbo].[SalesRec] ADD  DEFAULT ((0)) FOR [State]
GO

ALTER TABLE [dbo].[SalesRec] ADD  DEFAULT ((0)) FOR [AddUser]
GO


