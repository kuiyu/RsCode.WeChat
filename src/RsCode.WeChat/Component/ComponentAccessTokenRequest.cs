/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Text.Json.Serialization;

namespace RsCode.WeChat
{
    /// <summary>
    /// 第三方平台调凭证-获取令牌
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/ticket-token/getComponentAccessToken.html"/>
    /// </summary>
    public class ComponentAccessTokenRequest : WeChatRequest
    {
        public ComponentAccessTokenRequest(string componentAppId, string componentAppSecret, string ticket)
        {
            Ticket = ticket;
            AppId = componentAppId;
            Secret = componentAppSecret;
        }

        /// <summary>
        /// 微信后台推送的 ticket
        /// </summary>
        [JsonPropertyName("component_verify_ticket")]
        public string Ticket { get; set; }
        /// <summary>
        /// 第三方平台 appid
        /// </summary>
        [JsonPropertyName("component_appid")]
        public string AppId { get; set; }
        /// <summary>
        /// 第三方平台 appsecret
        /// </summary>
        [JsonPropertyName("component_appsecret")]
        public string Secret { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/component/api_component_token";
        }
        
    }
}
