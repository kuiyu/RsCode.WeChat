/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.WeChat.MP.Message
{
    public  class SendTextRequest
    {
        public SendTextRequest(string accessToken,string openId,TextMessageInfo textInfo)
        {
            AccessToken = accessToken;
            ToUser = openId;
            Text = textInfo;
            MsgType = "text";
        }
        /// <summary>
        /// 接口调用凭证
        /// </summary>
        [Required]
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 用户的 OpenID
        /// </summary>
        [Required]
        [JsonPropertyName("touser")]
        public string ToUser { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        [Required]
        [JsonPropertyName("msgtype")]
        public string MsgType { get; set; }
        /// <summary>
        /// 文本消息，msgtype="text" 时必填
        /// </summary>
        [JsonPropertyName("text")]
        public TextMessageInfo Text { get; set; }
        
    }
}
