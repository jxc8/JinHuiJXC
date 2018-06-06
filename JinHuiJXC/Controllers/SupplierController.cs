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
    public class SupplierController : ApiController
    {
        public IHttpActionResult Get(int ID)
        {
            int iID = int.Parse(ID.ToString());
            DataTable dt = SqlHelper.ExecuteDataset("SupplierGetByID", iID).Tables[0];
            string su = JsonConvert.SerializeObject(dt, Formatting.Indented, WebHelper.timeConverter);
            if (su == null)
            {
                return NotFound();
            }
            return Ok(su);
        }

        public JObject GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataset("SupplierGetAll").Tables[0];
            JObject joAll = WebHelper.DataTableToJsonObject(dt);
            return joAll;
        }

        [HttpPost]
        public HttpResponseMessage Add([FromBody]JObject jfrom)
        {
            if (jfrom == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }

            string sName = jfrom["Name"].ToString();
            string sPinyin = jfrom["Pinyin"].ToString();
            string sType = jfrom["Type"].ToString();
            string sRank = jfrom["Rank"].ToString();
            string sContacts = jfrom["Contacts"].ToString();
            string sTitle = jfrom["Title"].ToString();
            string sTelPhone = jfrom["TelPhone"].ToString();
            string sMobiPhone = jfrom["MobiPhone"].ToString();
            string sWeiXin = jfrom["WeiXin"].ToString();
            string sQQ = jfrom["QQ"].ToString();
            string sAddress = jfrom["Address"].ToString();
            string sCompany = jfrom["Company"].ToString();
            string sTaxID = jfrom["TaxID"].ToString();
            string sTaxType = jfrom["TaxType"].ToString();
            string sBankName = jfrom["BankName"].ToString();
            string sTBankNo = jfrom["BankNo"].ToString();
            string sDesc = jfrom["Desc"].ToString();

            SupplierModel su = new SupplierModel();
            su.Name = sName;
            su.Pinyin = sPinyin;
            su.Type = WebHelper.StrToInt(sType);
            su.Rank = WebHelper.StrToInt(sRank);
            su.Contacts = sContacts;
            su.Title = sTitle;
            su.TelPhone = sTelPhone;
            su.MobiPhone = sMobiPhone;
            su.WeiXin = sWeiXin;
            su.QQ = sQQ;
            su.Address = sAddress;
            su.Company = sCompany;
            su.TaxID = sTaxID;
            su.TaxType = WebHelper.StrToInt(sTaxType);
            su.BankName = sBankName;
            su.BankNo = sTBankNo;
            su.Desc = sDesc;

            su.Mail = "";
            su.NO = 0;
            su.State = 1;
            su.AddUser = 1;
            su.AddTime = DateTime.Now;
            su.LastTime = su.AddTime;

            try
            {
                SqlHelper.ExecuteNonQuery("SupplierAdd", su.NO, su.Name, su.Pinyin, su.Type,
                    su.Rank, su.Contacts, su.Title, su.TelPhone, su.MobiPhone, su.WeiXin, su.QQ, su.Mail,
                    su.Address, su.Company, su.TaxID, su.TaxType, su.BankName, su.BankNo, su.Desc, su.State,
                    su.AddUser, su.AddTime, su.LastTime);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, "{\"ID\":0}");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "{\"ID\":1}");
        }

        [HttpPost]
        public HttpResponseMessage Edit([FromBody]JObject jfrom)
        {
            if (jfrom == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }
            int iID = int.Parse(jfrom["SupplierID"].ToString());
            string sName = jfrom["Name"].ToString();
            string sPinyin = jfrom["Pinyin"].ToString();
            string sType = jfrom["Type"].ToString();
            string sRank = jfrom["Rank"].ToString();
            string sContacts = jfrom["Contacts"].ToString();
            string sTitle = jfrom["Title"].ToString();
            string sTelPhone = jfrom["TelPhone"].ToString();
            string sMobiPhone = jfrom["MobiPhone"].ToString();
            string sWeiXin = jfrom["WeiXin"].ToString();
            string sQQ = jfrom["QQ"].ToString();
            string sAddress = jfrom["Address"].ToString();
            string sCompany = jfrom["Company"].ToString();
            string sTaxID = jfrom["TaxID"].ToString();
            string sTaxType = jfrom["TaxType"].ToString();
            string sBankName = jfrom["BankName"].ToString();
            string sTBankNo = jfrom["BankNo"].ToString();
            string sDesc = jfrom["Desc"].ToString();

            SupplierModel su = new SupplierModel();
            su.ID = iID;
            su.Name = sName;
            su.Pinyin = sPinyin;
            su.Type = WebHelper.StrToInt(sType);
            su.Rank = WebHelper.StrToInt(sRank);
            su.Contacts = sContacts;
            su.Title = sTitle;
            su.TelPhone = sTelPhone;
            su.MobiPhone = sMobiPhone;
            su.WeiXin = sWeiXin;
            su.QQ = sQQ;
            su.Address = sAddress;
            su.Company = sCompany;
            su.TaxID = sTaxID;
            su.TaxType = WebHelper.StrToInt(sTaxType);
            su.BankName = sBankName;
            su.BankNo = sTBankNo;
            su.Desc = sDesc;

            su.Mail = "";
            su.NO = 0;
            su.State = 1;
            su.LastTime = DateTime.Now;

            try
            {
                SqlHelper.ExecuteNonQuery("SupplierUpdate", su.ID, su.NO, su.Name, su.Pinyin, su.Type,
                    su.Rank, su.Contacts, su.Title, su.TelPhone, su.MobiPhone, su.WeiXin, su.QQ, su.Mail,
                    su.Address, su.Company, su.TaxID, su.TaxType, su.BankName, su.BankNo, su.Desc,
                    su.State, su.LastTime);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }

            return Request.CreateResponse(HttpStatusCode.OK,1);
        }
    }
}
