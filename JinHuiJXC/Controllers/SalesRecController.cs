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
    public class SalesRecController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jfrom"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Add(JObject jfrom)
        {
            string s = "";
            if (string.IsNullOrWhiteSpace(jfrom.ToString()))
            {
                return Ok(0);
            }

            SalesRecModel rec = new SalesRecModel();

            rec.SalesNo = jfrom["SalesNo"].ToString();

            DateTime dSalesDate = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(jfrom["SalesDate"].ToString()))
            {
                DateTime.TryParse(jfrom["SalesDate"].ToString(), out dSalesDate);
            }
            rec.SalesDate = dSalesDate;

            int iSalesType = 0;
            int.TryParse(jfrom["SalesType"].ToString(), out iSalesType);
            rec.SalesType = iSalesType;

            int iMemberNo = 0;
            int.TryParse(jfrom["MemberNo"].ToString(), out iMemberNo);
            rec.MemberNo = iMemberNo;

            int iMemberName = 0;
            int.TryParse(jfrom["MemberName"].ToString(), out iMemberName);
            rec.MemberName = iMemberName;

            int iMemberScore = 0;
            int.TryParse(jfrom["MemberScore"].ToString(), out iMemberScore);
            rec.MemberScore = iMemberScore;

            decimal dChargeAmount = 0;
            decimal.TryParse(jfrom["ChargeAmount"].ToString(), out dChargeAmount);
            rec.AmountCharge = dChargeAmount;

            decimal dDiscountAmount = 0;
            decimal.TryParse(jfrom["DiscountAmount"].ToString(), out dDiscountAmount);
            rec.AmountDiscount = dDiscountAmount;

            decimal dReceiveAmount = 0;
            decimal.TryParse(jfrom["ReceiveAmount"].ToString(), out dReceiveAmount);
            rec.AmountReceive = dReceiveAmount;

            rec.ProfitSum = rec.AmountReceive;
            rec.ProfitRate = rec.AmountReceive;

            int iPaymentMethod = 0;
            int.TryParse(jfrom["PaymentMethod"].ToString(), out iPaymentMethod);
            rec.PaymentType = iPaymentMethod;

            int iDeliveryMethod = 0;
            int.TryParse(jfrom["DeliveryMethod"].ToString(), out iDeliveryMethod);
            rec.DeliveryType = iDeliveryMethod;

            if (jfrom["Desc"] == null)
            {
                rec.Desc = "";
            }
            else
            {
                rec.Desc = jfrom["Desc"].ToString();
            }

            rec.SalerName = 1;
            rec.AddUser = 1;
            rec.AddTime = DateTime.Now;
            rec.LastTime = rec.AddTime;

            rec.State = 0;

            object oRowID = SqlHelper.ExecuteScalar("SalesRecAdd", rec.SalesNo, rec.SalesDate,
                rec.SalesType, rec.SalerName, rec.MemberNo, rec.MemberName, rec.MemberScore,
                rec.AmountCharge, rec.AmountDiscount, rec.AmountReceive, rec.ProfitSum, rec.ProfitRate,
                rec.PaymentType, rec.DeliveryType, rec.Desc, rec.State, rec.AddUser, rec.AddTime, rec.LastTime);

            int iRowID = int.Parse(oRowID.ToString());

            SalesRecDetailModel da = new SalesRecDetailModel();
            da.SalesID = iRowID;
            da.AddUser = 1;
            da.AddTime = rec.AddTime;
            da.LastTime = da.AddTime;

            JArray jar = JArray.Parse(jfrom["list"].ToString());
            var varList = jfrom["list"];
            for (int i = 0; i < jar.Count; i++)
            {
                JObject j = JObject.Parse(jar[i].ToString());
                da.GoodsID = int.Parse(j["ID"].ToString());
                da.GoodsName = j["Name"].ToString();
                da.Barcode = j["Barcode"].ToString();
                da.Sum = int.Parse(j["Num"].ToString());
                da.PriceUnit = decimal.Parse(j["UnitPrice"].ToString());
                da.PackMin = int.Parse(j["MinPack"].ToString());
                da.RateDis = int.Parse(j["Discount"].ToString());
                da.PriceTotal = decimal.Parse(j["PriceTotal"].ToString());

                SqlHelper.ExecuteNonQuery("SalesRecDetailAdd", da.SalesID, da.GoodsID, da.GoodsName,da.Nocode,
                    da.Barcode,da.Pinyin,da.PackMin, da.PriceUnit, da.Sum,  da.PriceTotal,da.RateDis,da.RateTax,
                    da.AddUser, da.AddTime, da.LastTime);
            }

            return Ok(1);
        }

        public IHttpActionResult GetSalesRec(int ID)
        {
            int iid = int.Parse(ID.ToString());
            DataTable dt = SqlHelper.ExecuteDataset("SalesRecGetByID", iid).Tables[0];
            string sRec = JsonConvert.SerializeObject(dt, Formatting.Indented, WebHelper.timeConverter);
            if (sRec == null)
            {
                return NotFound();
            }
            return Ok(sRec);
        }

        public JObject GetSalesRecAll()
        {
            DataTable dt = SqlHelper.ExecuteDataset("SalesRecGetAll").Tables[0];
            JObject joAll = WebHelper.DataTableToJsonObject(dt);
            return joAll;
        }

        public JObject GetSalesRecDetailBySID(int ID)
        {
            DataTable dt = SqlHelper.ExecuteDataset("SalesRecDetailGetBySalesID", ID).Tables[0];
            JObject joAll = WebHelper.DataTableToJsonObject(dt);
            return joAll;
        }

        [HttpDelete]
        public IHttpActionResult DeleteSalesRec(int SalesID)
        {
            SqlHelper.ExecuteScalar("SalesRecDel", SalesID);
            return Ok(1);
        }
    }
}
