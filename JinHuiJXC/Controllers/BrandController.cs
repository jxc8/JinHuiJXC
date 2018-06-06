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
    public class BrandController : ApiController
    {
        public IHttpActionResult Get(int ID)
        {
            int iID = int.Parse(ID.ToString());
            DataTable dt = SqlHelper.ExecuteDataset("BrandGetByID", iID).Tables[0];
            string su = JsonConvert.SerializeObject(dt, Formatting.Indented, WebHelper.timeConverter);
            if (su == null)
            {
                return NotFound();
            }
            return Ok(su);
        }

        public JObject GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataset("BrandGetAll").Tables[0];
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
            string sCompany = jfrom["Company"].ToString();
            string sDesc = jfrom["Desc"].ToString();

            BrandModel br = new BrandModel();
            br.Name = sName;
            br.Pinyin = sPinyin;
            br.Company = sCompany;
            br.Desc = sDesc;

            try
            {
                SqlHelper.ExecuteNonQuery("BrandAdd", br.Name, br.Pinyin, br.Company,br.Desc);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }

            return Request.CreateResponse(HttpStatusCode.OK, 1);
        }

        [HttpPost]
        public HttpResponseMessage Edit([FromBody]JObject jfrom)
        {
            if (jfrom == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }
            int iID = int.Parse(jfrom["BrandID"].ToString());

            string sName = jfrom["Name"].ToString();
            string sPinyin = jfrom["Pinyin"].ToString();
            string sCompany = jfrom["Company"].ToString();
            string sDesc = jfrom["Desc"].ToString();

            BrandModel br = new BrandModel();
            br.ID = iID;
            br.Name = sName;
            br.Pinyin = sPinyin;
            br.Company = sCompany;
            br.Desc = sDesc;

            try
            {
                SqlHelper.ExecuteNonQuery("BrandUpdate", br.ID, br.Name, br.Pinyin, br.Company, br.Desc);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }

            return Request.CreateResponse(HttpStatusCode.OK, 1);
        }
    }
}