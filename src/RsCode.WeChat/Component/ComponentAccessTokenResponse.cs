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
    /// 第三方平台接口的调用凭据:令牌（component_access_token）
    /// 令牌的获取是有限制的，每个令牌的有效期为 2 小时
    /// </summary>
    public class ComponentAccessTokenResponse : WeChatResponse
    {
        /// <summary>
        /// 第三方平台 access_token
        /// </summary>
        [JsonPropertyName("component_access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 有效期，单位：秒
        /// </summary>
        [JsonPropertyName("expires_in")]
        public long Expires { get; set; }
    }
}
