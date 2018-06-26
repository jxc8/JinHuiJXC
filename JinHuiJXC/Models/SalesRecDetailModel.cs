using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class SalesRecDetailModel
    {
        public int ID { get; set; }

        public int SalesID { get; set; }

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