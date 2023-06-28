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
    /// 绑定体验者
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/member-management/bindTester.html"/>
    /// </summary>
    public class BindTesterRequest:WeChatRequest
    {
        public BindTesterRequest(string authorizerAccessToken,string wechatId)
        {
            AuthorizerAccessToken= authorizerAccessToken;
            WechatId= wechatId;
        }
        string AuthorizerAccessToken = "";

        /// <summary>
        /// 微信号
        /// </summary>
        [JsonPropertyName("wechatid")]
        public string WechatId { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/bind_tester?access_token={AuthorizerAccessToken}";
        }
    }
}
