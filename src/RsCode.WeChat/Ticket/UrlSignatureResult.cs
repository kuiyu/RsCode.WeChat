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

namespace RsCode.WeChat
{
    public class UrlSignatureResult
    {
        [JsonPropertyName("appId")]
        public string AppId { get; set; }
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }
        [JsonPropertyName("nonceStr")]
        public string nonceStr { get; set; }
        [JsonPropertyName("signature")]
        public string Signature { get; set; }
      

    }
}
