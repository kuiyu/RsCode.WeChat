/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace RsCode.WeChat
{
    /// <summary>
    /// 获取授权帐号的调用令牌
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/ticket-token/getAuthorizerAccessToken.html"/>
    /// </summary>
    public class AuthorizerAccessTokenResponse:WeChatResponse
    {
        /// <summary>
        /// 授权方令牌
        /// </summary>
        [JsonPropertyName("authorizer_access_token")]
        public string AuthorizerAccessToken { get; set; }

        /// <summary>
        /// 有效期，单位：秒
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int Expires { get; set; }

        /// <summary>
        /// 刷新令牌
        /// </summary>
        [JsonPropertyName("authorizer_refresh_token")]
        public string AuthorizerRefreshToken { get; set; }
    }
}
