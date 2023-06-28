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
    /// 查询最新一次审核单状态
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/getLatestAuditStatus.html"/>
    /// </summary>
    public class GetLatestAuditStatusResponse : WeChatResponse
    {
        /// <summary>
        /// 最新的审核id
        /// </summary>
        [JsonPropertyName("auditid")]
        public int AuditId { get; set; }
        /// <summary>
        /// 审核状态
        /// 0成功 1 被拒绝 2审核中 3己撤回 4审核延后
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }
        /// <summary>
        /// 当审核被拒绝时，返回的拒绝原因
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
        /// <summary>
        /// 当审核被拒绝时，会返回审核失败的小程序截图示例。用 竖线I 分隔的 media_id 的列表，可通过获取永久素材接口拉取截图内容
        /// </summary>
        [JsonPropertyName("screenshot")]
        public string ScreenShot { get; set; }
        /// <summary>
        /// 审核版本
        /// </summary>
        [JsonPropertyName("user_version")]
        public string UserVersion { get; set; }
        /// <summary>
        /// 版本描述
        /// </summary>
        [JsonPropertyName("user_desc")]
        public string UserDesc { get; set; }
        /// <summary>
        /// 时间戳，提交审核的时间
        /// </summary>
        [JsonPropertyName("submit_audit_time")]
        public int SubmitAuditTime { get; set; }
       

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(-1, "system error", "系统繁忙，此时请开发者稍候再试"));
            ResponseMessages.Add(new WeChatResponseMessage(40001, "invalid credential  access_token isinvalid or not latest", "获取 access_token 时 AppSecret 错误，或者 access_token 无效。请开发者认真比对 AppSecret 的正确性，或查看是否正在为恰当的公众号调用接口"));
            return base.GetResponseMessage();
        }
    }
}
