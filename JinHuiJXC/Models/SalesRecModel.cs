using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class SalesRecModel
    {
        /// <summary>
        /// 销售记录ID,自增
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 销售单据编号
        /// </summary>
        public string SalesNo { get; set; }

        /// <summary>
        /// 销售单据日期
        /// </summary>
        public DateTime SalesDate { get; set; }

        /// <summary>
        /// 单据类型：1小票2发票3收据4发货单5出库单
        /// </summary>
        public int SalesType { get; set; }

        /// <summary>
        /// 销售人员ID
        /// </summary>
        public int SalerName { get; set; }

        /// <summary>
        /// 会员编号
        /// </summary>
        public int MemberNo { get; set; }

        /// <summary>
        /// 会员姓名
        /// </summary>
        public int MemberName { get; set; }

        /// <summary>
        /// 增加积分
        /// </summary>
        public int MemberScore { get; set; }

        /// <summary>
        /// 其它费用
        /// </summary>
        public decimal AmountCharge { get; set; }

        /// <summary>
        /// 其它优惠
        /// </summary>
        public decimal AmountDiscount { get; set; }

        /// <summary>
        /// 实收金额=总价+费用-优惠
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
        /// 订单状态0无效1有效
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