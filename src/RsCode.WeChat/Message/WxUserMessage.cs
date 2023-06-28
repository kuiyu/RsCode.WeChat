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
using System.Text.Json;

namespace RsCode.WeChat.Message
{
    /// <summary>
    /// 微信推送的与用户相关的消息
    /// </summary>
    public class WxUserMessage:WeChatMessage
    {
        
        /// <summary>
        /// 微信号
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get; set; }

        public string Event { get; set; }
        public string EventKey { get; set; }
        public string SessionFrom { get; set; }

        string data;
        DataTransferFormatter dataTransferFormatter;

        public void LoadData(string data, DataTransferFormatter dataTransferFormatter)
        {
            if (dataTransferFormatter == DataTransferFormatter.XML)
            {
                this.FromXml(data);
                MsgType = GetValue("MsgType") == null ? "" : GetValue("MsgType").ToString();
                SessionFrom = GetValue("SessionFrom") == null ? "" : GetValue("SessionFrom").ToString();
                FromUserName = GetValue("FromUserName") == null ? "" : GetValue("FromUserName").ToString();
                ToUserName = GetValue("ToUserName") == null ? "" : GetValue("ToUserName").ToString();
                Event = GetValue("Event") == null ? "" : GetValue("Event").ToString();
                EventKey = GetValue("EventKey") == null ? "" : GetValue("EventKey").ToString();
                object time = GetValue("CreateTime");
                if (time != null)
                    CreateTime = Convert.ToInt64(time);
            }
            else
            {
                JsonSerializer.Deserialize<ThirdPlatformMessage>(data);
            }
        }
    }
}
