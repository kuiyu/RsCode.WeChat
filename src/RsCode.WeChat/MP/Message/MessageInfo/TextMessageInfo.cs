/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Text.Json.Serialization;

namespace RsCode.WeChat
{
    /// <summary>
    /// 文字消息
    /// </summary>
    public class TextMessageInfo: SendMessage
    {
        public TextMessageInfo(string content)
        {
            Content = content;
        }
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
