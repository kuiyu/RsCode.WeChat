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
    /// 查询小程序名称审核状态
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/basic-info-management/getNickNameStatus.html"/>
    /// </summary>
    public class GetNickNameStatusRequest : WeChatRequest
    {
        public GetNickNameStatusRequest(string authorizerAccessToken)
        {
            AuthorizerAccessToken= authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";

        /// <summary>
        /// 审核单 id
        /// </summary>
        [JsonPropertyName("audit_id")]
        public int AuditId { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/api_wxa_querynickname?access_token={AuthorizerAccessToken}";
        }
    }
}
