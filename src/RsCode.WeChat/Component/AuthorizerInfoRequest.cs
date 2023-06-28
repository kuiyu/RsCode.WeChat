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
    /// 使用授权码获取授权信息
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/ticket-token/getAuthorizerRefreshToken.html"/>
    /// </summary>
    public class AuthorizerInfoRequest:WeChatRequest
    {
        public AuthorizerInfoRequest(string componentAccessToken, string componentAppId, string authorizationCode)
        {
            ComponentAccessToken = componentAccessToken;
            ComponentAppId = componentAppId;
            AuthorizationCode = authorizationCode;
         
        }
        string ComponentAccessToken = "";
        /// <summary>
        /// 第三方平台 appid
        /// </summary>
        [JsonPropertyName("component_appid")]
        public string ComponentAppId { get; set; }


    
        /// <summary>
        /// 刷新令牌，获取授权信息时得到
        /// </summary>
        [JsonPropertyName("authorization_code")]
        public string AuthorizationCode { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/component/api_query_auth?access_token={ComponentAccessToken}";
        }

    
    }
}
