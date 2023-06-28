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
    /// 上传提审素材
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/uploadMediaToCodeAudit.html"/>
    /// </summary>
    public class UploadMediaToCodeAuditResponse : WeChatResponse
    {
        /// <summary>
        /// 类型
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        /// <summary>
        /// 媒体id
        /// </summary>
        [JsonPropertyName("mediaid")]
        public object  MediaId{ get; set; }
        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(43002, "require POST method", "需要 POST 请求"));
            ResponseMessages.Add(new WeChatResponseMessage(41005, "media data missing", "缺少多媒体文件数据，传输素材无视频或图片内容"));
            ResponseMessages.Add(new WeChatResponseMessage(40006, "invalid meida size", "上传素材文件大小超出限制"));
            ResponseMessages.Add(new WeChatResponseMessage(40005, "invalid file type", "上传素材文件格式不对"));

            return base.GetResponseMessage();
        }
    }
}
