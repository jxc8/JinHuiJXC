using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class WebHelper
    {
        /// <summary>
        /// 很抱歉，未能获取相关信息，请稍候重试。或与技术人员联系。
        /// </summary>
        public static string sMsgError = "很抱歉，未能获取相关信息，请稍候重试。或与技术人员联系。";

        /// <summary>
        /// JSON格式返回值"{\"ID\":0}
        /// </summary>
        public static string sJsonID0 = "{\"ID\":0}";

        /// <summary>
        /// JSON格式返回值"{\"ID\":1}
        /// </summary>
        public static string sJsonID1 = "{\"ID\":1}";

        /// <summary>
        /// "yyyy'-'MM'-'dd HH':'mm':'ss"
        /// </summary>
        public static IsoDateTimeConverter timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd HH':'mm':'ss" };

        /// <summary>
        /// 转换string为int
        /// </summary>
        /// <param name="sVal">string</param>
        /// <returns>int值，0转换失败</returns>
        public static int StrToInt(string sVal)
        {
            int iVal = 0;
            if (!int.TryParse(sVal, out iVal))
            {
                return 0;
            }
            return iVal;
        }

        /// <summary>
        /// 转换string为decimal
        /// </summary>
        /// <param name="sVal">string</param>
        /// <returns>decimal值，0转换失败</returns>
        public static decimal StrToDec(string sVal)
        {
            decimal iVal = 0;
            if (!decimal.TryParse(sVal, out iVal))
            {
                return 0;
            }

            return iVal;
        }

        /// <summary>
        /// 数据库DataTable转换为jQuery前台使用的JSON格式
        /// </summary>
        /// <param name="dt">数据库中读取的DataTable</param>
        /// <returns>JSON格式</returns>
        public static JObject DataTableToJsonObject(DataTable dt)
        {
            string sJson = JsonConvert.SerializeObject(dt,Formatting.Indented,timeConverter);
            JArray jData = JArray.Parse(sJson);
            int iTotal = jData.Count;
            JObject jObj = new JObject(
                new JProperty("total", iTotal),
                new JProperty("rows", jData)
            );
            return jObj;
        }

    }
}