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
using System.Text.Json.Serialization;

namespace RsCode.WeChat.MP.Message
{
    /// <summary>
    /// 发送订阅消息
    /// <see cref="https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/subscribe-message/subscribeMessage.send.html"/> 
    /// </summary>
    public class SubscribeMessageRequest:WeChatRequest
    {
        /// <summary>
        /// 接口调用凭证
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// 用户openid
        /// </summary>
        [JsonPropertyName("touser")]
        public string ToUser { get; set; }

        [JsonPropertyName("template_id")]
        public string TemplateId { get; set; }
        [JsonPropertyName("page")]
        public string Page { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }
        /// <summary>
        /// 跳转小程序类型：developer为开发版；trial为体验版；formal为正式版；默认为正式版
        /// </summary>
        [JsonPropertyName("miniprogram_state")]
        public string MiniProgramState { get; set; }
        [JsonPropertyName("lang")]
        public string Lang { get; set; } = "zh_CN";
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/message/subscribe/send?access_token={AccessToken}";
        }
    }
}
