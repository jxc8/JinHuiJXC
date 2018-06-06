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

namespace JinHuiJXC.Controllers
{
    public class TypeDeliveryController : ApiController
    {
        public IHttpActionResult Get(int ID)
        {
            int iID = int.Parse(ID.ToString());
            DataTable dt = SqlHelper.ExecuteDataset("TypeDeliveryGetByID", iID).Tables[0];
            string su = JsonConvert.SerializeObject(dt, Formatting.Indented, WebHelper.timeConverter);
            if (su == null)
            {
                return NotFound();
            }
            return Ok(su);
        }

        public JObject GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataset("TypeDeliveryGetAll").Tables[0];
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
            string sDesc = jfrom["Desc"].ToString();

            TypePayModel tp = new TypePayModel();
            tp.Name = sName;
            tp.Desc = sDesc;

            try
            {
                SqlHelper.ExecuteNonQuery("TypeDeliveryAdd", tp.Name, tp.Desc);
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
            int iID = int.Parse(jfrom["TypeID"].ToString());

            string sName = jfrom["Name"].ToString();
            string sDesc = jfrom["Desc"].ToString();

            TypeDeliveryModel tp = new TypeDeliveryModel();
            tp.ID = iID;
            tp.Name = sName;
            tp.Desc = sDesc;

            try
            {
                SqlHelper.ExecuteNonQuery("TypeDeliveryUpdate", tp.ID, tp.Name, tp.Desc);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }

            return Request.CreateResponse(HttpStatusCode.OK, 1);
        }
    }
}