using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.WeChat.Message.KfMessage
{
    public class KfMessageBase:WeChatRequest
    {
        /// <summary>
        /// 微信号
        /// </summary>
        [JsonPropertyName("touser")]
        public string ToUserName { get; set; }


        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonPropertyName("msgtype")] public string MsgType { get; set; }

        [JsonIgnore]
        public string AccessToken { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={AccessToken}";
        }
    }
}
