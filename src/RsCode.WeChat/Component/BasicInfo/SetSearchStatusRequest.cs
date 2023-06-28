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
    /// 设置搜索状态
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/basic-info-management/setSearchStatus.html"/>
    /// </summary>
    public class SetSearchStatusRequest : WeChatRequest
    {
        public SetSearchStatusRequest(string authorizerAccessToken, int status)
        {
            AuthorizerAccessToken= authorizerAccessToken;
            Status = status;
        }
        string AuthorizerAccessToken = "";

        /// <summary>
        /// 1 表示不可搜索，0 表示可搜索
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/changewxasearchstatus?access_token={AuthorizerAccessToken}";
        }
    }
}
