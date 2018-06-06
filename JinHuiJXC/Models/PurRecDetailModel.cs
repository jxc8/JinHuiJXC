using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    /// <summary>
    /// 采购记录商品详情
    /// </summary>
    public class PurRecDetailModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PurID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int GoodsID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Nocode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Pinyin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MinPack { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal UnitPrice { get; set; }

        public int Sum { get; set; }

        public int DisRate { get; set; }

        public int TaxRate { get; set; }

        public decimal TotalPrice { get; set; }
        public int AddUser { get; set; }
        public DateTime LastTime { get; set; }
        public DateTime AddTime { get; set; }
    }
}