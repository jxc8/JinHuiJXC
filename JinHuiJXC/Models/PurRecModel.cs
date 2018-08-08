/*****************************************************
金汇进销存版权归金汇技术团队所有。
金汇进销存源码基于GPLv3协议开源。
您可以免费下载安装使用。
您可以添加、修改、扩展源码。
但是必须保持开源，仍然保留金汇进销存软件名称。
禁止修改删除版权声明。
禁止向其他人销售源码。 
违反将被追究侵权责任。
如您需要功能定制、接口适配、硬件搭配等服务，
请将需求发送邮件至205265245@qq.com。
我们会及时与您联系。
 ****************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// 采购记录
    /// </summary>
    public class PurRecModel
    {
        /// <summary>
        /// 采购记录ID,自增
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 采购单据编号
        /// </summary>
        public string PurNo { get; set; }

        /// <summary>
        /// 采购单据日期
        /// </summary>
        public DateTime PurDate { get; set; }

        /// <summary>
        /// 单据类型：1小票2发票3收据4进货单5出库单
        /// </summary>
        public int PurType { get; set; }

        /// <summary>
        /// 采购员ID
        /// </summary>
        public string PurName { get; set; }
                
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int SupplierNo { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WarehouseNo { get; set; }

        /// <summary>
        /// 采购单据日期
        /// </summary>
        public DateTime WarehouseTime { get; set; }

        /// <summary>
        /// 其它费用
        /// </summary>
        public decimal AmountCharge { get; set; }

        /// <summary>
        /// 其它优惠
        /// </summary>
        public decimal AmountDiscount { get; set; }

        /// <summary>
        /// 实付金额=总价+费用-优惠
        /// </summary>
        public decimal AmountReceive { get; set; }

        /// <summary>
        /// 利润额
        /// </summary>
        public decimal ProfitSum { get; set; }

        /// <summary>
        /// 利润率
        /// </summary>
        public decimal ProfitRate { get; set; }

        /// <summary>
        /// 付款方式：1现金2银行卡3信用卡4支付宝5微信6尚未付款
        /// </summary>
        public int PaymentType { get; set; }

        /// <summary>
        /// 发货方式：1现售2网售3送货上门4货到付款
        /// </summary>
        public int DeliveryType { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 订单状态0尚未入库1已经入库
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 添加人ID
        /// </summary>
        public int AddUser { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime LastTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}