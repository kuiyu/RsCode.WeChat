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
    ///   /// <summary>
    /// 服务端发送客服消息
    /// <see cref="https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/customer-message/customerServiceMessage.send.html"/>
    /// </summary>
    /// </summary>
    public class CustomerServiceMessageSendRequest:WeChatRequest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="toUser"></param>
        /// <param name="msgType">msgtype 的合法值 text image link miniprogrampage</param>
        public CustomerServiceMessageSendRequest(string accessToken,string toUser,string msgType,SendMessage sendMessage)
        {
            AccessToken = accessToken;
            ToUser = toUser;
            MsgType = msgType;
            
            if(msgType=="text")
            {
                TextMessageInfo = sendMessage as TextMessageInfo;
            }
            if(msgType=="image")
            {
                ImageMessageInfo = sendMessage as ImageMessageInfo;
            }
            if(msgType=="link")
            {
                LinkMessageInfo = sendMessage as LinkMessageInfo;
            }
            if(msgType== "miniprogrampage")
            {
                MiniProgramPageMessageInfo = sendMessage as MiniProgramPageMessageInfo;
            }

        }

        /// <summary>
        /// 接口调用凭证
        /// </summary>
        
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 用户的 OpenID
        /// </summary>
       
        [JsonPropertyName("touser")]
        public string ToUser { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
       
        [JsonPropertyName("msgtype")]
        public string MsgType { get; set; }
        [JsonPropertyName("text")]
        public TextMessageInfo TextMessageInfo { get; set; }
        [JsonPropertyName("image")]
        public ImageMessageInfo ImageMessageInfo { get; set; }
        [JsonPropertyName("link")]
        public LinkMessageInfo LinkMessageInfo { get; set; }
        [JsonPropertyName("miniprogrampage")]
        public MiniProgramPageMessageInfo MiniProgramPageMessageInfo { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={AccessToken}";
        }
        
    }
}
