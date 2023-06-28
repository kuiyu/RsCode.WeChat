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
    /// 获取小程序全局唯一后台接口调用凭据（access_token）。调用绝大多数后台接口时都需使用 access_token，开发者需要进行妥善保存。
    /// <see cref="https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/access-token/auth.getAccessToken.html"/> 
    /// </summary>
    public class AppAccessTokenRequest:WeChatRequest
    {
        public AppAccessTokenRequest(string appId,string appSecret)
        {
            AppId = appId;
            Secret = appSecret;
        }
        /// <summary>
        /// 填写 client_credential
        /// </summary>
        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; } = "client_credential";
        /// <summary>
        /// 小程序唯一凭证，即 AppID，可在「微信公众平台 - 设置 - 开发设置」页中获得。（需要已经成为开发者，且帐号没有异常状态）
        /// </summary>
        [JsonPropertyName("appid")]
        public string AppId { get; set; }
        /// <summary>
        /// 小程序唯一凭证密钥，即 AppSecret，获取方式同 appid
        /// </summary>
        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/token?grant_type={GrantType}&appid={AppId}&secret={Secret}";
        }
        public override string RequestMethod()
        {
            return "GET";
        }

    }
}
