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
        public int ID { get; set; }

        public int PurID { get; set; }

        public int GoodsID { get; set; }

        public string GoodsName { get; set; }

        public string Nocode { get; set; }

        public string Barcode { get; set; }

        public string Pinyin { get; set; }

        public int PackMin { get; set; }

        public decimal PriceUnit { get; set; }

        public int Sum { get; set; }

        public int RateDis { get; set; }

        public int RateTax { get; set; }

        public decimal PriceTotal { get; set; }

        public int AddUser { get; set; }

        public DateTime LastTime { get; set; }

        public DateTime AddTime { get; set; }
    }
}