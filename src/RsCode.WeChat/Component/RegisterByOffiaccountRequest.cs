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
    public class RegisterByOffiaccountRequest:WeChatRequest
    {
        /// <summary>
        /// 复用公众号主体快速注册小程序
        /// </summary>
        /// <param name="authorizerAccessToken">第三方平台接口调用凭证authorizer_access_token</param>
        /// <param name="ticket">公众号扫码授权的凭证(公众平台扫码页面回跳到第三方平台时携带)，要看复用公众号主体快速注册小程序使用说明</param>
        public RegisterByOffiaccountRequest(string authorizerAccessToken,string ticket)
        {
            AccessToken = authorizerAccessToken;
            Ticket = ticket;
        }
        string AccessToken = "";

        /// <summary>
        /// 公众号扫码授权的凭证(公众平台扫码页面回跳到第三方平台时携带)，要看复用公众号主体快速注册小程序使用说明
        /// </summary>
        [JsonPropertyName("ticket")]
        public string Ticket { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/account/fastregister?access_token={AccessToken}";
        }
    }
}
