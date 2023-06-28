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
    /// 查询小程序版本信息
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/getVersionInfo.html"/>
    /// </summary>
    public class GetVersionInfoResponse : WeChatResponse
    {
        /// <summary>
        /// 体验版信息
        /// </summary>
        [JsonPropertyName("exp_info")]
        public ExpInfo ExpInfo { get; set; }
        /// <summary>
        /// 线上版信息
        /// </summary>
        [JsonPropertyName("release_info")]
        public ReleaseInfo ReleaseInfo { get; set; }
        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(-1, "system error", "系统繁忙，此时请开发者稍候再试"));
            ResponseMessages.Add(new WeChatResponseMessage(44002, "empty post data", "POST 的数据包为空"));
            return base.GetResponseMessage();
        }
    }

    public class ExpInfo
    {
        /// <summary>
        /// 提交体验版的时间
        /// </summary>
        [JsonPropertyName("exp_time")]
        public int ExpTime { get; set; }
        /// <summary>
        /// 体验版版本信息
        /// </summary>
        [JsonPropertyName("exp_version")]
        public string ExpVersion { get; set; }
        /// <summary>
        /// 体验版版本描述
        /// </summary>
        [JsonPropertyName("exp_desc")]
        public string ExpDesc { get; set; }
    }
    public class ReleaseInfo
    {
        /// <summary>
        /// 发布线上版的时间
        /// </summary>
        [JsonPropertyName("release_time")]
        public int ReleaseTime { get; set; }
        /// <summary>
        /// 线上版版本信息
        /// </summary>
        [JsonPropertyName("release_version")]
        public string ReleaseVersion { get; set; }
        /// <summary>
        /// 线上版本描述
        /// </summary>
        [JsonPropertyName("release_desc")]
        public string ReleaseDesc { get; set; }
    }
}
