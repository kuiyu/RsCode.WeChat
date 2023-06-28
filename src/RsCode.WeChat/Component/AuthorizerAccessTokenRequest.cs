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
    /// 获取/刷新接口调用令牌
    /// 第三方平台获取授权帐号的authorizer_access_token。authorizer_access_token 有效期为 2 小时，authorizer_access_token 失效时，可以使用 authorizer_refresh_token 获取新的 authorizer_access_token。
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/ticket-token/getAuthorizerAccessToken.html"/>
    /// </summary>
    public class AuthorizerAccessTokenRequest:WeChatRequest
    {
        /// <summary>
        /// 获取/刷新接口调用令牌
        /// </summary>
        /// <param name="componentAccessToken"></param>
        /// <param name="componentAppId"></param>
        /// <param name="authorizerAppId"></param>
        /// <param name="authorizerRefreshToken">刷新令牌，获取授权信息时得到</param>
        public AuthorizerAccessTokenRequest(string componentAccessToken,string componentAppId,string authorizerAppId,string authorizerRefreshToken)
        {
            ComponentAccessToken=componentAccessToken;
            ComponentAppId = componentAppId;
            AuthorizerAppId=authorizerAppId;
            AuthorizerRefreshToken=authorizerRefreshToken;
        }
        string ComponentAccessToken = "";
        /// <summary>
        /// 第三方平台 appid
        /// </summary>
        [JsonPropertyName("component_appid")]
        public string ComponentAppId { get; set; }


        /// <summary>
        /// 授权方 appid
        /// </summary>
        [JsonPropertyName("authorizer_appid")] 
        public string AuthorizerAppId { get; set; }
        /// <summary>
        /// 刷新令牌，获取授权信息时得到
        /// </summary>
        [JsonPropertyName("authorizer_refresh_token")] 
        public string AuthorizerRefreshToken { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/component/api_authorizer_token?component_access_token={ComponentAccessToken}";
        }

      
    }
}
