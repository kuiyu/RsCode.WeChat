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
    /// 申请地理位置接口
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/privacy-api-management/applyPrivacyInterface.html"/>
    /// </summary>
    public class ApplyPrivacyInterfaceResponse : WeChatResponse
    {

        /// <summary>
        /// 审核id
        /// </summary>
        [JsonPropertyName("audit_id")]
        public int AuditId { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(61031, "our last submission is under review, please do not apply again", "审核中，请不要重复申请"));
            ResponseMessages.Add(new WeChatResponseMessage(61032, "invalid video type, need mp4-type", "视频格式不对，要传mp4格式的"));
            ResponseMessages.Add(new WeChatResponseMessage(61033, "the media upload fail, please try again", "视频下载失败"));
            ResponseMessages.Add(new WeChatResponseMessage(61034, "invalid args, please check", "必填的参数没填，检查后重新提交"));

            ResponseMessages.Add(new WeChatResponseMessage(61035, "the api not need apply", "输入的api（api_name严格区分大小写）无需申请，可以直接使用；或者就是api_name输入错了；或者就是这个 api 已经申请了，不需要再申请"));
            ResponseMessages.Add(new WeChatResponseMessage(61036, "the appid is not allowed to apply the api", "该帐号不可申请，请检查类目是否符合"));
            ResponseMessages.Add(new WeChatResponseMessage(61037, "the encoding of content is invalid, need utf-8", "需要以utf-8的编码格式提交"));
            ResponseMessages.Add(new WeChatResponseMessage(61038, "apply api too frequently", "调用频率太快了，不可超过280个请求/min"));
           
            return base.GetResponseMessage();
        }
    }
}
