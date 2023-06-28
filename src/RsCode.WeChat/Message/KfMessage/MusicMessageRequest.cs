/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.WeChat.Message.KfMessage
{
    public class MusicMessageRequest : KfMessageBase
    {
        public MusicMessageRequest(string accessToken, string openid, string musicUrl,string hqmusicUrl, string thumbMediaId, string title, string description)
        {
            MsgType = "music";
            ToUserName = openid;
            Content = new
            {
                musicurl = musicUrl,
                thumb_media_id = thumbMediaId,
                hqmusicurl=hqmusicUrl,
                title = title,
                description = description
            };
            AccessToken = accessToken;
        }

        /// <summary>
        /// 图片消息媒体id，可以调用获取临时素材接口拉取数据。
        /// </summary>
        [JsonPropertyName("music")]
        public object Content { get; set; }
    }
}
