/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */



using System.Text.Json.Serialization;

namespace RsCode.WeChat.Message.KfMessage
{
    public class TextMessageRequest:KfMessageBase
    {

        public TextMessageRequest(
            string accessToken,
             string toUserName,
              string content 
            )
        {
            ToUserName = toUserName;
            MsgType = "text";
            Content = new { content = content };
            AccessToken= accessToken;
        }

        [JsonPropertyName("text")]
        public object Content { get; set; }

        
    }
}
