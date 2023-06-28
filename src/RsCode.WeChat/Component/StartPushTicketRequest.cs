/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Text.Json.Serialization;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 启动票据推送服务
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/ticket-token/startPushTicket.html"/>
    /// </summary>
    public class StartPushTicketRequest:WeChatRequest
    {
        public StartPushTicketRequest(string componentAppId, string componentAppSecret)
        {
            ComponentAppId = componentAppId;
            ComponentAppSecret = componentAppSecret;          
        }

        /// <summary>
        /// 平台型第三方平台的appid
        /// </summary>
        [JsonPropertyName("component_appid")]
        public string ComponentAppId { get; set; }
        /// <summary>
        /// 平台型第三方平台的APPSECRET
        /// </summary>
        [JsonPropertyName("component_secret")]
        public string ComponentAppSecret { get; set; }

        public override string GetApiUrl()
        {
            return "https://api.weixin.qq.com/cgi-bin/component/api_start_push_ticket";
        }
    }
}
