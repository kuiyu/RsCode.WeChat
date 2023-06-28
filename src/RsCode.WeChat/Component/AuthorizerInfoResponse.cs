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
    /// 第三方平台调用凭证 /获取刷新令牌
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/ticket-token/getAuthorizerRefreshToken.html"/>
    /// </summary>
    public class AuthorizerInfoResponse:WeChatResponse
    {
        /// <summary>
        /// 刷新令牌信息
        /// </summary>
        [JsonPropertyName("authorization_info")]
        public AuthorizationInfo AuthorizationInfo { get; set; }
    }
    /// <summary>
    /// 授权信息
    /// </summary>
    public class AuthorizationInfo
    {
        /// <summary>
        /// 授权的公众号或者小程序 appid
        /// </summary>
        [JsonPropertyName("authorizer_appid")]
        public string AuthorizerAppId { get; set; }
        /// <summary>
        /// 接口调用令牌（在授权的公众号/小程序具备 API 权限时，才有此返回值）
        /// </summary>
        [JsonPropertyName("authorizer_access_token")]
        public string AuthorizerAccessToken { get; set; }

        /// <summary>
        /// authorizer_access_token 的有效期（在授权的公众号/小程序具备 API 权限时，才有此返回值），单位：秒
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int Expires { get; set; }
        /// <summary>
        /// 刷新令牌（在授权的公众号具备 API 权限时，才有此返回值），刷新令牌主要用于第三方平台获取和刷新已授权用户的 authorizer_access_token。一旦丢失，只能让用户重新授权，才能再次拿到新的刷新令牌。用户重新授权后，之前的刷新令牌会失效
        /// </summary>
        [JsonPropertyName("authorizer_refresh_token")]
        public string AuthorizerRefreshToken { get; set; }

        /// <summary>
        /// 授权给第三方平台的权限集 id 列表，权限集 id 代表的含义可查看权限集介绍
        /// </summary>
        [JsonPropertyName("func_info")]
        public FuncInfo[] FuncInfo { get; set; }
    }

    public class FuncInfo
    {
        [JsonPropertyName("funcscope_category")]
        public FuncScopeCategory ScopeCategory { get; set; }
    }

    public class FuncScopeCategory
    {
        /// <summary>
        /// 权限集id
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }
        /// <summary>
        /// 权限集类型
        /// </summary>
        [JsonPropertyName("type")]
        public int Type { get; set; }
        [JsonPropertyName("type")]
        ///权限集名称
        public string Name { get; set; }
        /// <summary>
        /// 	权限集描述
        /// </summary>
        [JsonPropertyName("type")]
        public string Desc { get; set; }
    }
}
