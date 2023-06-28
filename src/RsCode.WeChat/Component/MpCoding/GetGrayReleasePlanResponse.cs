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
    /// 获取分阶段发布详情
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/getGrayReleasePlan.html"/>
    /// </summary>
    public class GetGrayReleasePlanResponse : WeChatResponse
    {
        /// <summary>
        /// 分阶段发布计划详情
        /// </summary>
        [JsonPropertyName("gray_release_plan")]
        public GrayReleasePlan GrayReleasePlan { get; set; }
        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(-1, "system error", "系统繁忙，此时请开发者稍候再试"));
            return base.GetResponseMessage();
        }
    }

    public class GrayReleasePlan
    {
        /// <summary>
        /// 0:初始状态 1:执行中 2:暂停中 3:执行完毕 4:被删除
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }
        /// <summary>
        /// 分阶段发布计划的创建时间
        /// </summary>
        [JsonPropertyName("create_timestamp")]
        public int CreateTimeStamp { get; set; }
        /// <summary>
        /// 当前的灰度比例
        /// </summary>
        [JsonPropertyName("gray_percentage")]
        public int GrayPercentage { get; set; }
        /// <summary>
        /// true表示支持按项目成员灰度
        /// </summary>
        [JsonPropertyName("support_debuger_first")]
        public bool SupportDebugerFirst { get; set; }
        /// <summary>
        /// true表示支持按体验成员灰度
        /// </summary>
        [JsonPropertyName("support_experiencer_first")]
        public bool SupportExperiencerFirst { get; set; }
    }
}
