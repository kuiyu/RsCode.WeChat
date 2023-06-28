/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using RsCode.WeChat.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace RsCode.WeChat.Message.EventMessage
{
   public class MenuClickEventMessage:MessageBase
    {
         
        public string Event { get; set; } = "CLICK";
        /// <summary>
        /// 事件KEY值，设置的跳转URL
        /// </summary>
        public string EventKey { get; set; }

       
    }
}
