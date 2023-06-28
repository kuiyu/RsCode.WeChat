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
    public class VoiceMessageRequest : KfMessageBase
    {
        public VoiceMessageRequest(string accessToken,string openid, string mediaId)
        {
            MsgType = "voice";
            ToUserName = openid;
            Content = new { media_id = mediaId };
            AccessToken= accessToken;
        }

        /// <summary>
        /// 图片消息媒体id，可以调用获取临时素材接口拉取数据。
        /// </summary>
        [JsonPropertyName("voice")]
        public object Content { get; set; }
    }
}
