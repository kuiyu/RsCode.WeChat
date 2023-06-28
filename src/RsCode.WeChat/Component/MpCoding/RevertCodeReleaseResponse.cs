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
    /// 小程序版本回退
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/revertCodeRelease.html"/>
    /// </summary>
    public class RevertCodeReleaseResponse : WeChatResponse
    {
        /// <summary>
        /// 模板信息列表。当action=get_history_version，才会返回。
        /// </summary>
        [JsonPropertyName("version_list")]
        public VersionList VersionList { get; set; }
        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(-1, "system error", "系统繁忙，此时请开发者稍候再试"));
            ResponseMessages.Add(new WeChatResponseMessage(40001, "invalid credential  access_token isinvalid or not latest", "获取 access_token 时 AppSecret 错误，或者 access_token 无效。请开发者认真比对 AppSecret 的正确性，或查看是否正在为恰当的公众号调用接口"));

            return base.GetResponseMessage();
        }
    }

    public class VersionList
    {
        /// <summary>
        /// 小程序版本
        /// </summary>
        [JsonPropertyName("app_version")]
        public int AppVersion { get; set; }

        /// <summary>
        /// 模板版本号，开发者自定义字段
        /// </summary>
        [JsonPropertyName("user_version")]
        public string UserVersion { get; set; }

        /// <summary>
        /// 模板描述，开发者自定义字段
        /// </summary>
        [JsonPropertyName("user_desc")]
        public string UserDesc { get; set; }

        /// <summary>
        /// 更新时间，时间戳
        /// </summary>
        [JsonPropertyName("commit_time")]
        public int CommitTime { get; set; }
    }
}
