/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using RsCode.WeChat.Message;
using RsCode.WeChat.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace RsCode.WeChat.Message
{
    /// <summary>
    /// 会话事件
    /// </summary>
    public class SessionMessage: MessageBase
    {
        /// <summary>
        /// 小程序的原始ID
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送者的openid
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 事件创建时间(整型）
        /// </summary>
        public long CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get; set; }
        /// <summary>
        /// 事件类型，user_enter_tempsession
        /// </summary>
        public string Event { get; set; }
        /// <summary>
        /// 开发者在客服会话按钮设置的session-from属性
        /// </summary>
        public string SessionFrom { get; set; }

         
    }
}
