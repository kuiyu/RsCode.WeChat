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
    /// 第三方平台代公众号 ，通过 code 换取 access_token
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/Third-party_Platforms/2.0/api/Before_Develop/Official_Accounts/official_account_website_authorization.html"/>
    /// </summary>
    public class AssistAccessTokenResponse:WeChatResponse
    {
        /// <summary>
        /// 接口调用凭证
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// access_token 接口调用凭证超时时间，单位（秒）
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
        /// <summary>
        /// 用户刷新 access_token
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
        /// <summary>
        /// 授权用户唯一标识
        /// </summary>
        [JsonPropertyName("openid")]
        public string OpenId { get; set; }
        /// <summary>
        /// 用户授权的作用域，使用逗号（,）分隔
        /// </summary>
        [JsonPropertyName("scope")]
        public string Scope { get; set; }
        
    }
}
