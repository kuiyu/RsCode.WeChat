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
    /// 查询审核单状态
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/getAuditStatus.html"/>
    /// </summary>
    public class GetAuditStatusRequest:WeChatRequest
    {
        public GetAuditStatusRequest(string authorizerAccessToken)
        {
           AuthorizerAccessToken= authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";

        /// <summary>
        /// 提交审核时获得的审核 id
        /// </summary>
        [JsonPropertyName("auditid")]
        public int AuditId { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/get_auditstatus?access_token={AuthorizerAccessToken}";
        }
    }
}
