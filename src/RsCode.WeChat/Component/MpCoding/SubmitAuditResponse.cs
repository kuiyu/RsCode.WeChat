/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using RsCode.WeChat.Message;
using System.Text.Json.Serialization;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 提交代码审核
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/submitAudit.html"/>
    /// </summary>
    public class SubmitAuditResponse : WeChatResponse
    {
        [JsonPropertyName("auditid")]
        public int AuditId { get; set; }
        public override WeChatResponseMessage GetResponseMessage()
        {
            return base.GetResponseMessage();
        }
    }
}
