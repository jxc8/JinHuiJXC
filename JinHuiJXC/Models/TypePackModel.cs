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
    public class TypePackModel
    {
        /// <summary>
        /// ID，自增
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}