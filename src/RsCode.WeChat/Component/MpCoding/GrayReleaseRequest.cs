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
    /// 分阶段发布
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/grayRelease.html"/>
    /// </summary>
    public class GrayReleaseRequest:WeChatRequest
    {
        public GrayReleaseRequest(string authorizerAccessToken)
        {
           AuthorizerAccessToken= authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";

        /// <summary>
        /// 灰度的百分比 0~ 100 的整。如果gray_percentage=0，support_experiencer_first与support_debuger_first二选一必填
        /// </summary>
        [JsonPropertyName("gray_percentage")]
        public int GrayPercentage { get; set; }

        /// <summary>
        /// true表示支持按体验成员灰度，默认是false
        /// </summary>
        [JsonPropertyName("support_debuger_first")]
        public bool SupporDebugerFirst { get; set; }
        /// <summary>
        /// true表示支持按项目成员灰度，默认是false
        /// </summary>
        [JsonPropertyName("support_experiencer_first")]
        public bool SupporExperiencerFirst { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/grayrelease?access_token={AuthorizerAccessToken}";
        }
    }
}
