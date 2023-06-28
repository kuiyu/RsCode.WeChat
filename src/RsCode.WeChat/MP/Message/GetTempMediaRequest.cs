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

namespace RsCode.WeChat.MP
{
    public class GetTempMediaRequest:WeChatRequest
    {
        public GetTempMediaRequest(string accessToken,string mediaId)
        {
            AccessToken = accessToken;
            MediaId = mediaId;
        }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 媒体文件 ID
        /// </summary>

        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }


        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/media/get?access_token={AccessToken}&media_id={MediaId}";
        }
        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
