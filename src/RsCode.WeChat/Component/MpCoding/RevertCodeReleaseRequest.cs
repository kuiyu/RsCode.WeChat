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
    /// 小程序版本回退
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/revertCodeRelease.html"/>
    /// </summary>
    public class RevertCodeReleaseRequest : WeChatRequest
    {
        public RevertCodeReleaseRequest(string authorizerAccessToken)
        {
           AuthorizerAccessToken= authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";
        /// <summary>
        /// 只能填get_history_version。表示获取可回退的小程序版本。该参数为 URL 参数，非 Body 参数。
        /// </summary>
        [JsonPropertyName("action")]
        public string Action { get; set; }
        /// <summary>
        /// 默认是回滚到上一个版本；也可回滚到指定的小程序版本，可通过get_history_version获取app_version。该参数为 URL 参数，非 Body 参数
        /// </summary>
        [JsonPropertyName("app_version")]
        public string AppVersion { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/revertcoderelease?access_token={AuthorizerAccessToken}";
        }

        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
