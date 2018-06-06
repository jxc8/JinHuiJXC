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
    public class CategoryController : ApiController
    {
        public IHttpActionResult Get(int ID)
        {
            int iID = int.Parse(ID.ToString());
            DataTable dt = SqlHelper.ExecuteDataset("CategoryGetByID", iID).Tables[0];
            string su = JsonConvert.SerializeObject(dt, Formatting.Indented, WebHelper.timeConverter);
            if (su == null)
            {
                return NotFound();
            }
            return Ok(su);
        }

        public JObject GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataset("CategoryGetAll").Tables[0];
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
            string sDesc = jfrom["Desc"].ToString();

            CategoryModel ca = new CategoryModel();
            ca.Name = sName;
            ca.Pinyin = sPinyin;
            ca.Desc = sDesc;

            try
            {
                SqlHelper.ExecuteNonQuery("CategoryAdd", ca.Name, ca.Pinyin, ca.Desc);
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
            int iID = int.Parse(jfrom["CategoryID"].ToString());

            string sName = jfrom["Name"].ToString();
            string sPinyin = jfrom["Pinyin"].ToString();
            string sDesc = jfrom["Desc"].ToString();

            CategoryModel ca = new CategoryModel();
            ca.ID = iID;
            ca.Name = sName;
            ca.Pinyin = sPinyin;
            ca.Desc = sDesc;

            try
            {
                SqlHelper.ExecuteNonQuery("CategoryUpdate", ca.ID, ca.Name, ca.Pinyin, ca.Desc);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }

            return Request.CreateResponse(HttpStatusCode.OK, 1);
        }
    }
}