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
using System.Web.Security;
using System.Web;

namespace Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Login([FromBody]JObject jfrom)
        {
            if (jfrom == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }

            string sName = jfrom["Name"].ToString();
            string sPass = jfrom["Pass"].ToString();

            //CategoryModel ca = new CategoryModel();
            //ca.ID = iID;
            //ca.Name = sName;
            //ca.Pinyin = sPinyin;
            //ca.Desc = sDesc;

            if (sName == "admin")
            {
                //FormsAuthentication.SetAuthCookie(sName,false);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,sName,DateTime.Now, 
                    DateTime.Now.AddDays(3),true,"", FormsAuthentication.FormsCookiePath);
                string encTicket = FormsAuthentication.Encrypt(ticket);

                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                cookie.HttpOnly = true;
                HttpContext.Current.Response.Cookies.Add(cookie);
                return Request.CreateResponse(HttpStatusCode.OK, 1);
            }

            try
            {
                //SqlHelper.ExecuteNonQuery("CategoryUpdate", ca.ID, ca.Name, ca.Pinyin, ca.Desc);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }

            return Request.CreateResponse(HttpStatusCode.OK, 1);
        }

        [HttpPost]
        public HttpResponseMessage LogOut([FromBody]JObject jfrom)
        {
            FormsAuthentication.SignOut();
            return Request.CreateResponse(HttpStatusCode.OK, 1);
        }
    }
}