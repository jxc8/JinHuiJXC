using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SupplierModel
    {
        /// <summary>
        /// ID，自增
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public int NO { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Pinyin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Contacts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TelPhone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MobiPhone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WeiXin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TaxID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TaxType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BankNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 添加人ID
        /// </summary>
        public int AddUser { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastTime { get; set; }

    }
}