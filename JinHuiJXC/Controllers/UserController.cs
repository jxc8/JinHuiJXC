/*****************************************************
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