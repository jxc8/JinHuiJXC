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

namespace JinHuiJXC.Controllers
{
    public class MemberController : ApiController
    {
        public IHttpActionResult Get(int ID)
        {
            int iID = int.Parse(ID.ToString());
            DataTable dt = SqlHelper.ExecuteDataset("MemberGetByID", iID).Tables[0];
            string su = JsonConvert.SerializeObject(dt, Formatting.Indented, WebHelper.timeConverter);
            if (su == null)
            {
                return NotFound();
            }
            return Ok(su);
        }

        public JObject GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataset("MemberGetAll").Tables[0];
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
            string sNO = jfrom["NO"].ToString();
            string sIDCard = jfrom["IDCard"].ToString();
            string sRank = jfrom["Rank"].ToString();
            string sScore = jfrom["Score"].ToString();
            string sSex = jfrom["Sex"].ToString();
            string sBirthday = jfrom["Birthday"].ToString();
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

            MemberModel me = new MemberModel();
            me.Name = sName;
            me.Pinyin = sPinyin;
            me.NO = sNO;
            me.IDCard = sIDCard;
            me.Type = 1;
            me.Rank = WebHelper.StrToInt(sRank);
            me.Score = WebHelper.StrToInt(sScore);
            me.Sex = WebHelper.StrToInt(sSex);
            me.Birthday = DateTime.Parse(sBirthday);
            me.TelPhone = sTelPhone;
            me.MobiPhone = sMobiPhone;
            me.WeiXin = sWeiXin;
            me.QQ = sQQ;
            me.Address = sAddress;
            me.Company = sCompany;
            me.TaxID = sTaxID;
            me.TaxType = WebHelper.StrToInt(sTaxType);
            me.BankName = sBankName;
            me.BankNo = sTBankNo;
            me.Desc = sDesc;

            me.State = 1;
            me.AddUser = 1;
            me.AddTime = DateTime.Now;
            me.LastTime = me.AddTime;

            try
            {
                SqlHelper.ExecuteNonQuery("MemberAdd", me.IDCard, me.NO, me.Name, me.Pinyin, me.Type,
                    me.Rank, me.Score, me.Sex,me.Birthday,me.TelPhone, me.MobiPhone, me.WeiXin, me.QQ,
                    me.Address, me.Company, me.TaxID, me.TaxType, me.BankName, me.BankNo, me.Desc, me.State,
                    me.AddUser, me.AddTime, me.LastTime);
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
            int iID = int.Parse(jfrom["SupplierID"].ToString());
            string sName = jfrom["Name"].ToString();
            string sPinyin = jfrom["Pinyin"].ToString();
            string sNO = jfrom["NO"].ToString();
            string sType = jfrom["Type"].ToString();
            string sRank = jfrom["Rank"].ToString();
            string sScore = jfrom["Score"].ToString();
            string sSex = jfrom["Sex"].ToString();
            string sBirthday = jfrom["Birthday"].ToString();
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

            MemberModel me = new MemberModel();
            me.Name = sName;
            me.Pinyin = sPinyin;
            me.NO = sNO;
            me.Type = WebHelper.StrToInt(sType);
            me.Rank = WebHelper.StrToInt(sRank);
            me.Score = WebHelper.StrToInt(sScore);
            me.Sex = WebHelper.StrToInt(sSex);
            me.TelPhone = sTelPhone;
            me.MobiPhone = sMobiPhone;
            me.WeiXin = sWeiXin;
            me.QQ = sQQ;
            me.Address = sAddress;
            me.Company = sCompany;
            me.TaxID = sTaxID;
            me.TaxType = WebHelper.StrToInt(sTaxType);
            me.BankName = sBankName;
            me.BankNo = sTBankNo;
            me.Desc = sDesc;

            me.State = 1;
            me.LastTime = DateTime.Now;

            try
            {
                SqlHelper.ExecuteNonQuery("MemberUpdate", me.ID, me.NO, me.Name, me.Pinyin, me.Type,
                    me.Rank, me.Score, me.Sex, me.Birthday, me.TelPhone, me.MobiPhone, me.WeiXin, me.QQ,
                    me.Address, me.Company, me.TaxID, me.TaxType, me.BankName, me.BankNo, me.Desc, 
                    me.State, me.LastTime);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }

            return Request.CreateResponse(HttpStatusCode.OK, 1);
        }
    }
}