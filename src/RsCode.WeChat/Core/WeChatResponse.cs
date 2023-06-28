/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using RsCode.WeChat.Message;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace RsCode.WeChat
{
    /// <summary>
    /// 微信响应的信息
    /// </summary>
    public class WeChatResponse
    {
         

        /// <summary>
        /// 详细错误码
        /// </summary>
        [JsonPropertyName("errcode")]
        public int Code { get; set; }
        /// <summary>
        /// 错误描述，使用易理解的文字表示错误的原因
        /// </summary>
        [JsonPropertyName("errmsg")]
        public string Message { get; set; }

        internal List<WeChatResponseMessage> ResponseMessages { get; set; } = new List<WeChatResponseMessage>();
        /// <summary>
        /// 获取响应明细信息
        /// </summary>
        /// <returns></returns>
        public virtual WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(0, "ok", "ok"));
            ResponseMessages.Add(new WeChatResponseMessage(-1, "system error", "系统繁忙，此时请开发者稍候再试"));

            var resMessage= ResponseMessages.LastOrDefault(c => c.Code == Code);
            if (resMessage == null)
            {
                resMessage=  new WeChatResponseMessage(Code, Message, Message);
            }
            return resMessage;
        }
    }
}
