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
    public class WarehouseController : ApiController
    {
        public IHttpActionResult Get(int ID)
        {
            int iID = int.Parse(ID.ToString());
            DataTable dt = SqlHelper.ExecuteDataset("WarehouseGetByID", iID).Tables[0];
            string su = JsonConvert.SerializeObject(dt, Formatting.Indented, WebHelper.timeConverter);
            if (su == null)
            {
                return NotFound();
            }
            return Ok(su);
        }

        public JObject GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataset("WarehouseGetAll").Tables[0];
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
            string sContacts = jfrom["Contacts"].ToString();
            string sTitle = jfrom["Title"].ToString();
            string sTelPhone = jfrom["TelPhone"].ToString();
            string sMobiPhone = jfrom["MobiPhone"].ToString();
            string sWeiXin = jfrom["WeiXin"].ToString();
            string sQQ = jfrom["QQ"].ToString();
            string sAddress = jfrom["Address"].ToString();
            string sDesc = jfrom["Desc"].ToString();

            WarehouseModel wh = new WarehouseModel();
            wh.Name = sName;
            wh.Pinyin = sPinyin;
            wh.Type = WebHelper.StrToInt(sType);
            wh.Contacts = sContacts;
            wh.Title = sTitle;
            wh.TelPhone = sTelPhone;
            wh.MobiPhone = sMobiPhone;
            wh.WeiXin = sWeiXin;
            wh.QQ = sQQ;
            wh.Address = sAddress;
            wh.Desc = sDesc;

            wh.NO = 0;
            wh.State = 1;
            wh.AddUser = 1;
            wh.AddTime = DateTime.Now;
            wh.LastTime = wh.AddTime;

            try
            {
                SqlHelper.ExecuteNonQuery("WarehouseAdd", wh.NO, wh.Name, wh.Pinyin, wh.Type,
                    wh.Address, wh.Contacts, wh.Title, wh.TelPhone, wh.MobiPhone, wh.WeiXin, wh.QQ, 
                    wh.Desc, wh.State,wh.AddUser, wh.AddTime, wh.LastTime);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }

            return Request.CreateResponse(HttpStatusCode.OK,1);
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
            string sContacts = jfrom["Contacts"].ToString();
            string sTitle = jfrom["Title"].ToString();
            string sTelPhone = jfrom["TelPhone"].ToString();
            string sMobiPhone = jfrom["MobiPhone"].ToString();
            string sWeiXin = jfrom["WeiXin"].ToString();
            string sQQ = jfrom["QQ"].ToString();
            string sAddress = jfrom["Address"].ToString();
            string sDesc = jfrom["Desc"].ToString();

            WarehouseModel wh = new WarehouseModel();
            wh.ID = iID;
            wh.Name = sName;
            wh.Pinyin = sPinyin;
            wh.Type = WebHelper.StrToInt(sType);
            wh.Contacts = sContacts;
            wh.Title = sTitle;
            wh.TelPhone = sTelPhone;
            wh.MobiPhone = sMobiPhone;
            wh.WeiXin = sWeiXin;
            wh.QQ = sQQ;
            wh.Address = sAddress;
            wh.Desc = sDesc;

            wh.NO = 0;
            wh.State = 1;
            wh.LastTime = DateTime.Now;

            try
            {
                SqlHelper.ExecuteNonQuery("WarehouseUpdate", wh.ID, wh.NO, wh.Name, wh.Pinyin, wh.Type,
                    wh.Address, wh.Contacts, wh.Title, wh.TelPhone, wh.MobiPhone, wh.WeiXin, wh.QQ,wh.Desc,
                    wh.State, wh.LastTime);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }

            return Request.CreateResponse(HttpStatusCode.OK, 1);
        }
    }
}