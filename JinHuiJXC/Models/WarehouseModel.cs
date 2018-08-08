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
using System.Web;

namespace Models
{
    public class WarehouseModel
    {
        /// <summary>
        /// ID，自增
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public int NO { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Pinyin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Contacts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TelPhone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MobiPhone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WeiXin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 添加人ID
        /// </summary>
        public int AddUser { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastTime { get; set; }
    }
}