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
    /// 复用公众号主体快速注册小程序
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/register-management/fast-registration-officalaccount/registerMiniprogramByOffiaccount.html"/>
    /// </summary>
    public class RegisterByOffiaccountResponse:WeChatResponse
    {
        /// <summary>
        /// 新创建小程序的 appid
        /// </summary>
        [JsonPropertyName("appid")]
        public string AppId { get; set; }
        /// <summary>
        /// 新创建小程序的授权码；注：使用 appid 及 authorization_code 换取 authorizer_refresh_token 后需及时保存。
        /// </summary>
        [JsonPropertyName("authorization_code")]
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// 复用公众号微信认证小程序是否成功
        /// </summary>
        [JsonPropertyName("is_wx_verify_succ")]
        public bool IsWxVerifySuccess { get; set; }
        /// <summary>
        /// 小程序是否和公众号关联成功
        /// </summary>
        [JsonPropertyName("is_link_succ")]
        public bool IsLinkSuccess { get; set; }
    }
}
