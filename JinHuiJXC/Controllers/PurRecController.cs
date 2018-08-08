﻿/*****************************************************
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
    public class PurRecController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jfrom"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Add(JObject jfrom)
        {
            string s = "";
            if (string.IsNullOrWhiteSpace(jfrom.ToString()))
            {
                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }

            PurRecModel pur = new PurRecModel();

            pur.PurNo = jfrom["PurNo"].ToString();

            DateTime dPurDate = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(jfrom["PurDate"].ToString()))
            {
                DateTime.TryParse(jfrom["PurDate"].ToString(), out dPurDate);
            }
            pur.PurDate = dPurDate;

            int iPurType = 0;
            int.TryParse(jfrom["PurType"].ToString(), out iPurType);
            pur.PurType = iPurType;

            int iSupplierNo = 0;
            int.TryParse(jfrom["SupplierNo"].ToString(), out iSupplierNo);
            pur.SupplierNo = iSupplierNo;

            DateTime dWarehouseTime = DateTime.Now;
            DateTime.TryParse(jfrom["WarehouseTime"].ToString(), out dWarehouseTime);
            pur.WarehouseTime = dWarehouseTime;

            decimal dChargeAmount = 0;
            decimal.TryParse(jfrom["ChargeAmount"].ToString(), out dChargeAmount);
            pur.AmountCharge = dChargeAmount;

            decimal dDiscountAmount = 0;
            decimal.TryParse(jfrom["DiscountAmount"].ToString(), out dDiscountAmount);
            pur.AmountDiscount = dDiscountAmount;

            decimal dReceiveAmount = 0;
            decimal.TryParse(jfrom["ReceiveAmount"].ToString(), out dReceiveAmount);
            pur.AmountReceive = dReceiveAmount;

            pur.ProfitSum = 0;
            pur.ProfitRate = 0;

            int iPaymentMethod = 0;
            int.TryParse(jfrom["PaymentMethod"].ToString(), out iPaymentMethod);
            pur.PaymentType = iPaymentMethod;

            int iDeliveryMethod = 0;
            int.TryParse(jfrom["DeliveryMethod"].ToString(), out iDeliveryMethod);
            pur.DeliveryType = iDeliveryMethod;

            if (jfrom["Desc"] == null)
            {
                pur.Desc = "";
            }
            else
            {
                pur.Desc = jfrom["Desc"].ToString();
            }

            pur.PurName = "1";
            pur.AddUser = 1;
            pur.AddTime = DateTime.Now;
            pur.LastTime = pur.AddTime;

            pur.State = 0;

            object oRowID = SqlHelper.ExecuteScalar("PurRecAdd", pur.PurNo, pur.PurDate,
                pur.PurType, pur.PurName, pur.SupplierNo, pur.WarehouseNo, pur.WarehouseTime,
                pur.AmountCharge, pur.AmountDiscount, pur.AmountReceive, pur.ProfitSum, pur.ProfitRate,
                pur.PaymentType, pur.DeliveryType, pur.Desc, pur.State, pur.AddUser, pur.AddTime, pur.LastTime);

            int iRowID = int.Parse(oRowID.ToString());

            PurRecDetailModel da = new PurRecDetailModel();
            da.PurID = iRowID;
            da.AddUser = 1;
            da.AddTime = pur.AddTime;
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
                da.PriceUnit = decimal.Parse(j["PriceRetail"].ToString());
                da.PackMin = int.Parse(j["PackMin"].ToString());
                da.RateDis = int.Parse(j["Discount"].ToString());
                da.PriceTotal = decimal.Parse(j["PriceTotal"].ToString());

                SqlHelper.ExecuteNonQuery("PurRecDetailAdd", da.PurID, da.GoodsID, da.GoodsName, da.Nocode,
                    da.Barcode, da.Pinyin, da.PackMin, da.PriceUnit, da.Sum, da.PriceTotal, da.RateDis, da.RateTax,
                    da.AddUser, da.AddTime, da.LastTime);

                SqlHelper.ExecuteNonQuery("GoodsInvNowAdd", da.GoodsID, da.Sum);
            }

            return Request.CreateResponse(HttpStatusCode.OK, 1);
        }

        public IHttpActionResult GetPurRec(int ID)
        {
            int iid = int.Parse(ID.ToString());
            DataTable dt = SqlHelper.ExecuteDataset("PurRecGetByID", iid).Tables[0];
            string sRec = JsonConvert.SerializeObject(dt, Formatting.Indented, WebHelper.timeConverter);
            if (sRec == null)
            {
                return NotFound();
            }
            return Ok(sRec);
        }

        public JObject GetPurRecAll()
        {
            DataTable dt = SqlHelper.ExecuteDataset("PurRecGetAll").Tables[0];
            JObject joAll = WebHelper.DataTableToJsonObject(dt);
            return joAll;
        }

        public JObject GetPurRecDetailByPID(int ID)
        {
            DataTable dt = SqlHelper.ExecuteDataset("PurRecDetailGetByPurID", ID).Tables[0];
            JObject joAll = WebHelper.DataTableToJsonObject(dt);
            return joAll;
        }

        [HttpDelete]
        public IHttpActionResult DeletePurRec(int PurID)
        {
            SqlHelper.ExecuteScalar("PurRecDel", PurID);
            return Ok(1);
        }
    }
}
