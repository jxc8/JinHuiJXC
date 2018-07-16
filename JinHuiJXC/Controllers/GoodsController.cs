using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class GoodsController : ApiController
    {
        public IHttpActionResult Get(int ID)
        {
            int iID = int.Parse(ID.ToString());
            DataTable dt = SqlHelper.ExecuteDataset("GoodsGetByID", iID).Tables[0];
            string sGood = JsonConvert.SerializeObject(dt,Formatting.Indented, WebHelper.timeConverter);
            if (sGood == null)
            {
                return NotFound();
            }
            return Ok(sGood);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JObject GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataset("GoodsGetAll").Tables[0];
            JObject joAll = WebHelper.DataTableToJsonObject(dt);
            return joAll;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetAllNameList()
        {
            DataTable dt = SqlHelper.ExecuteDataset("GoodsGetAll").Tables[0];
            string sJson = JsonConvert.SerializeObject(dt);
            return Ok(sJson);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jfrom"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Add([FromBody]JObject jfrom)
        {
            if (jfrom == null)
            {
                //return WebHelper.sJsonID0;
            }

            string sName = jfrom["Name"].ToString();
            string sCategory = jfrom["Category"].ToString();
            string sBrand = jfrom["Brand"].ToString();
            string sNocode = jfrom["Nocode"].ToString();
            string sBarcode = jfrom["Barcode"].ToString();
            string sPinyin = jfrom["Pinyin"].ToString();
            string sPriceCost = jfrom["PriceCost"].ToString();
            string sPriceRetail = jfrom["PriceRetail"].ToString();
            string sPriceTrade = jfrom["PriceTrade"].ToString();
            string sPriceMember = jfrom["PriceMember"].ToString();
            string sMinInv = jfrom["MinInv"].ToString();
            string sMaxInv = jfrom["MaxInv"].ToString();
            string sPackMin = jfrom["PackMin"].ToString();
            string sMaxPack = jfrom["MaxPack"].ToString();
            string sRatio = jfrom["Ratio"].ToString();
            string sSpec = jfrom["Spec"].ToString();
            string sSupplier = jfrom["Supplier"].ToString();
            string sProducter = jfrom["Producter"].ToString();
            string sDesc = jfrom["Desc"].ToString();

            GoodsModel Goods = new GoodsModel();
            Goods.Name = sName;
            Goods.Category = WebHelper.StrToInt(sCategory);
            Goods.Brand = WebHelper.StrToInt(sBrand);
            Goods.Nocode = sNocode;
            Goods.Barcode = sBarcode;
            Goods.Pinyin = sPinyin;
            Goods.PriceCost = WebHelper.StrToDec(sPriceCost);
            Goods.PriceRetail = WebHelper.StrToDec(sPriceRetail);
            Goods.PriceTrade = WebHelper.StrToDec(sPriceTrade);
            Goods.PriceMember = WebHelper.StrToDec(sPriceMember);

            if (Goods.PriceCost == 0 || Goods.PriceRetail == 0 ||
                Goods.PriceRetail == 0 || Goods.PriceMember == 0)
            {
                //return WebHelper.sJsonID0;
            }

            Goods.InvNow = 0;
            Goods.InvMin = WebHelper.StrToInt(sMinInv);
            Goods.InvMax = WebHelper.StrToInt(sMaxInv);
            Goods.PackMin = WebHelper.StrToInt(sPackMin);
            Goods.PackMax = WebHelper.StrToInt(sMaxPack);
            Goods.PackRatio = WebHelper.StrToInt(sRatio);

            if (Goods.InvMin == 0 || Goods.InvMin == 0 || Goods.PackMin == 0
                || Goods.PackMax == 0 || Goods.PackRatio == 0)
            {
                //return WebHelper.sJsonID0;
            }

            Goods.PackSpec = sSpec;
            Goods.Desc = sDesc;
            Goods.Supplier = WebHelper.StrToInt(sSupplier);
            Goods.Producter = WebHelper.StrToInt(sProducter);
            Goods.AddUser = 1;
            Goods.AddTime = DateTime.Now;
            Goods.LastTime = Goods.AddTime;

            try
            {
                SqlHelper.ExecuteNonQuery("GoodsAdd", Goods.Name, Goods.Category, Goods.Brand,
                    Goods.Nocode, Goods.Barcode, Goods.Pinyin, Goods.PriceCost, Goods.PriceRetail,
                    Goods.PriceTrade, Goods.PriceMember, Goods.InvNow, Goods.InvMin, Goods.InvMax,
                    Goods.PackMin, Goods.PackMax, Goods.PackRatio, Goods.PackSpec, Goods.Supplier, 
                    Goods.Producter,Goods.Desc, Goods.AddUser, Goods.AddTime, Goods.LastTime);
            }
            catch
            {
                //return WebHelper.sJsonID0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, "{\"ID\":1}");
        }

        [HttpPost]
        public IHttpActionResult Edit(JObject jfrom)
        {
            if (jfrom == null)
            {
                return NotFound();
            }
            int GoodID = int.Parse(jfrom["GoodID"].ToString());
            string sName = jfrom["Name"].ToString();
            string sCategory = jfrom["Category"].ToString();
            string sBrand = jfrom["Brand"].ToString();
            string sNocode = jfrom["Nocode"].ToString();
            string sBarcode = jfrom["Barcode"].ToString();
            string sPinyin = jfrom["Pinyin"].ToString();
            string sPriceCost = jfrom["PriceCost"].ToString();
            string sPriceRetail = jfrom["PriceRetail"].ToString();
            string sPriceTrade = jfrom["PriceTrade"].ToString();
            string sPriceMember = jfrom["PriceMember"].ToString();
            string sMinInv = jfrom["MinInv"].ToString();
            string sMaxInv = jfrom["MaxInv"].ToString();
            string sPackMin = jfrom["PackMin"].ToString();
            string sMaxPack = jfrom["MaxPack"].ToString();
            string sRatio = jfrom["Ratio"].ToString();
            string sSpec = jfrom["Spec"].ToString();
            string sSupplier = jfrom["Supplier"].ToString();
            string sProducter = jfrom["Producter"].ToString();
            string sDesc = jfrom["Desc"].ToString();

            GoodsModel Goods = new GoodsModel();
            Goods.ID = GoodID;
            Goods.Name = sName;
            Goods.Category = WebHelper.StrToInt(sCategory);
            Goods.Brand = WebHelper.StrToInt(sBrand);
            Goods.Nocode = sNocode;
            Goods.Barcode = sBarcode;
            Goods.Pinyin = sPinyin;
            Goods.PriceCost = WebHelper.StrToDec(sPriceCost);
            Goods.PriceRetail = WebHelper.StrToDec(sPriceRetail);
            Goods.PriceTrade = WebHelper.StrToDec(sPriceTrade);
            Goods.PriceMember = WebHelper.StrToDec(sPriceMember);

            if (Goods.PriceCost == 0 || Goods.PriceRetail == 0 ||
                Goods.PriceRetail == 0 || Goods.PriceMember == 0)
            {
                //return WebHelper.sJsonID0;
            }

            Goods.InvMin = WebHelper.StrToInt(sMinInv);
            Goods.InvMax = WebHelper.StrToInt(sMaxInv);
            Goods.PackMin = WebHelper.StrToInt(sPackMin);
            Goods.PackMax = WebHelper.StrToInt(sMaxPack);
            Goods.PackRatio = WebHelper.StrToInt(sRatio);

            if (Goods.InvMin == 0 || Goods.InvMin == 0 || Goods.PackMin == 0
                || Goods.PackMax == 0 || Goods.PackRatio == 0)
            {
                //return WebHelper.sJsonID0;
            }

            Goods.PackSpec = sSpec;
            Goods.Desc = sDesc;
            Goods.Supplier = WebHelper.StrToInt(sSupplier);
            Goods.Producter = WebHelper.StrToInt(sProducter);
            Goods.LastTime = DateTime.Now;

            try
            {
                SqlHelper.ExecuteNonQuery("GoodsUpdate", Goods.ID,Goods.Name, Goods.Category, Goods.Brand,
                    Goods.Nocode, Goods.Barcode, Goods.Pinyin, Goods.PriceCost, Goods.PriceRetail,
                    Goods.PriceTrade, Goods.PriceMember, Goods.InvMin, Goods.InvMax,
                    Goods.PackMin, Goods.PackMax, Goods.PackRatio, Goods.PackSpec, Goods.Supplier, 
                    Goods.Producter,Goods.Desc,Goods.LastTime);
            }
            catch
            {
                //return WebHelper.sJsonID0;
            }
            return Ok(1);
        }
    }
}
