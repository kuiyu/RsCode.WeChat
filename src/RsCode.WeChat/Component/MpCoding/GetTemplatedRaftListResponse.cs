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
using static System.Net.WebRequestMethods;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 获取草稿箱列表
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/thirdparty-management/template-management/getTemplatedRaftList.html"/>
    /// </summary>
    public class GetTemplatedRaftListResponse : WeChatResponse
    {

        /// <summary>
        /// 草稿箱信息
        /// </summary>
        [JsonPropertyName("draft_list")]
        public TemplatedRaft[] RaftList { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(40001, "invalid credential  access_token isinvalid or not latest", "获取 access_token 时 AppSecret 错误，或者 access_token 无效。请开发者认真比对 AppSecret 的正确性，或查看是否正在为恰当的公众号调用接口"));
            ResponseMessages.Add(new WeChatResponseMessage(85064, "template not found", "找不到模板"));
            ResponseMessages.Add(new WeChatResponseMessage(-1, "system error", "系统繁忙，此时请开发者稍候再试"));
            return base.GetResponseMessage();
        }
    }
    /// <summary>
    /// 小程序模版草稿箱
    /// </summary>
    public class TemplatedRaft
    {
        [JsonPropertyName("create_time")]
        public long CreateTime { get; set; }
        [JsonPropertyName("user_version")]
        public string UserVersion { get; set; }
        [JsonPropertyName("user_desc")]
        public string UserDesc { get; set; }
        [JsonPropertyName("draft_id")]
        public int DraftId { get; set; }
    }
}
