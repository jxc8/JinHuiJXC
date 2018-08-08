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
using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// 商品信息实体类
    /// </summary>
    public class GoodsModel
    {
        /// <summary>
        /// 商品ID，自增
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "商品名称")]
        [Required(ErrorMessage = "{0} 必须填写")]
        [StringLength(100, ErrorMessage = "{0} 至少 {2} 个字", MinimumLength = 2)]
        public string Name { get; set; }

        /// <summary>
        /// 商品类别
        /// </summary>
        [Required]
        [Display(Name = "商品类别")]
        public int Category { get; set; }

        /// <summary>
        /// 商品品牌
        /// </summary>
        [Required]
        [Display(Name = "商品品牌")]
        public int Brand { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "商品编号")]
        public string Nocode { get; set; }

        /// <summary>
        /// 商品条码
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "商品条码")]
        public string Barcode { get; set; }

        /// <summary>
        /// 拼音编码
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "拼音编码")]
        [Required(ErrorMessage = "{0} 必须填写")]
        [StringLength(100, ErrorMessage = "{0} 至少 {2} 个字", MinimumLength = 2)]
        public string Pinyin { get; set; }

        /// <summary>
        /// 成本价
        /// </summary>
        [Display(Name = "成本价")]
        [Required(ErrorMessage = "{0} 必须填写")]
        [RegularExpression(@"^(([0-9]+)|([0-9]+\.[0-9]{1,2}))$", ErrorMessage = "{0}为数字且最多两位小数")]
        public decimal PriceCost { get; set; }

        /// <summary>
        /// 零售价
        /// </summary>
        [Display(Name = "零售价")]
        [RegularExpression(@"^(([0-9]+)|([0-9]+\.[0-9]{1,2}))$", ErrorMessage = "{0}为数字且最多两位小数")]
        public decimal PriceRetail { get; set; }

        /// <summary>
        /// 批发价
        /// </summary>
        [Display(Name = "批发价")]
        [Required(ErrorMessage = "{0} 必须填写")]
        [RegularExpression(@"^(([0-9]+)|([0-9]+\.[0-9]{1,2}))$", ErrorMessage = "{0}为数字且最多两位小数")]
        public decimal PriceTrade { get; set; }

        /// <summary>
        /// 会员价
        /// </summary>
        [Display(Name = "会员价")]
        [Required(ErrorMessage = "{0} 必须填写")]
        [RegularExpression(@"^(([0-9]+)|([0-9]+\.[0-9]{1,2}))$", ErrorMessage = "{0}为数字且最多两位小数")]
        public decimal PriceMember { get; set; }

        /// <summary>
        /// 当前库存
        /// </summary>
        [Display(Name = "当前库存")]
        [Required(ErrorMessage = "{0} 必须填写")]
        [RegularExpression(@"^\+?[1-9][0-9]*$", ErrorMessage = "{0}为大于0的整数")]
        public int InvNow { get; set; }

        /// <summary>
        /// 最低库存
        /// </summary>
        [Display(Name = "最低库存")]
        [Required(ErrorMessage = "{0} 必须填写")]
        [RegularExpression(@"^\+?[1-9][0-9]*$", ErrorMessage = "{0}为大于0的整数")]
        public int InvMin { get; set; }

        /// <summary>
        /// 最高库存
        /// </summary>
        [Display(Name = "最高库存")]
        [Required(ErrorMessage = "{0} 必须填写")]
        [RegularExpression(@"^\+?[1-9][0-9]*$", ErrorMessage = "{0}为大于0的整数")]
        public int InvMax { get; set; }

        /// <summary>
        /// 最小包装
        /// </summary>
        [Display(Name = "最小包装")]
        [Required(ErrorMessage = "{0} 必须填写")]
        [RegularExpression(@"^\+?[1-9][0-9]*$", ErrorMessage = "{0}为大于0的整数")]
        public int PackMin { get; set; }

        /// <summary>
        /// 最大包装
        /// </summary>
        [Display(Name = "最大包装")]
        [Required(ErrorMessage = "{0} 必须填写")]
        [RegularExpression(@"^\+?[1-9][0-9]*$", ErrorMessage = "{0}为大于0的整数")]
        public int PackMax { get; set; }

        /// <summary>
        /// 包装系数
        /// </summary>
        [Display(Name = "包装系数")]
        [Required(ErrorMessage = "{0} 必须填写")]
        [RegularExpression(@"^\+?[1-9][0-9]*$", ErrorMessage = "{0}为大于0的整数")]
        public int PackRatio { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "规格型号")]
        public string PackSpec { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        [Display(Name = "供应商")]
        public int Supplier { get; set; }

        /// <summary>
        /// 生产商ID
        /// </summary>
        [Display(Name = "生产商")]
        public int Producter { get; set; }

        /// <summary>
        /// 商品说明
        /// </summary>
        [MaxLength(2000)]
        [Display(Name = "商品说明")]
        public string Desc { get; set; }

        /// <summary>
        /// 添加人ID
        /// </summary>
        [Display(Name = "添加人")]
        public int AddUser { get; set; }

        /// <summary>
        /// 商品添加时间
        /// </summary>
        [Display(Name = "添加时间")]
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Display(Name = "最后修改时间")]
        public DateTime LastTime { get; set; }
    }
}