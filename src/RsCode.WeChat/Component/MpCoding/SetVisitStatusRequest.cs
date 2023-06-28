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
    /// 设置小程序服务状态
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/setVisitStatus.html"/>
    /// </summary>
    public class SetVisitStatusRequest : WeChatRequest
    {
        public SetVisitStatusRequest(string authorizerAccessToken)
        {
            AuthorizerAccessToken = authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";
        /// <summary>
        /// 设置可访问状态，发布后默认可访问，close 为不可见，open 为可见
        /// </summary>
        [JsonPropertyName("action")]
        public string Action { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/change_visitstatus?access_token={AuthorizerAccessToken}";
        }
    }
}
