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

namespace RsCode.WeChat.Core
{
    /// <summary>
    /// 微信请求的数据
    /// </summary>
    public  class WeChatRequestData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        [JsonPropertyName("createDate")]
        public DateTime CreateDate { get; set; }=DateTime.Now;
        /// <summary>
        /// 请求的url
        /// </summary>
        [JsonPropertyName("requestUrl")]
        public string RequestUrl { get; set; }
        /// <summary>
        /// 请求类型
        /// </summary>
        [JsonPropertyName("requestType")] public string RequestType { get; set; }
        /// <summary>
        /// 请求的内容
        /// </summary>
        [JsonPropertyName("requestContent")] public string RequestContent { get; set; }
        /// <summary>
        /// 解密后的内容
        /// </summary>
        [JsonPropertyName("decryptContent")] public string DecryptContent { get; set; }

        [JsonPropertyName("dataType")] public string DataType { get; set; } = "xml";
    }
}
