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
    /// 设置最低基础库版本
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/setSupportVersion.html"/>
    /// </summary>
    public class SetSupportVersionRequest : WeChatRequest
    {
        public SetSupportVersionRequest(string authorizerAccessToken)
        {
           AuthorizerAccessToken= authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";
        /// <summary>
        /// 为已发布的基础库版本号
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/wxopen/setweappsupportversion?access_token={AuthorizerAccessToken}";
        }
    }
}
