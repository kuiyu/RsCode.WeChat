/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace RsCode.WeChat.Message.EventMessage
{
  public   class ScanEventMessage:MessageBase
    {
        public string Event { get; set; } = "SCAN";

        public string EventKey { get; set; }

        public string Ticket { get; set; }
    }
}
