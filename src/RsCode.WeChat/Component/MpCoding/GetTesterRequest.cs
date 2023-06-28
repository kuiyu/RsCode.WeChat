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
    /// 获取体验者列表
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/member-management/getTester.html"/>
    /// </summary>
    public class GetTesterRequest : WeChatRequest
    {
        public GetTesterRequest(string authorizerAccessToken, string action= "get_experiencer")
        {
            AuthorizerAccessToken = authorizerAccessToken;
            Action = action;
        }
        string AuthorizerAccessToken = "";

        /// <summary>
        /// 填 "get_experiencer" 即可
        /// </summary>
        [JsonPropertyName("action")]
        public string Action { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/memberauth?access_token={AuthorizerAccessToken}";
        }
    }
}
