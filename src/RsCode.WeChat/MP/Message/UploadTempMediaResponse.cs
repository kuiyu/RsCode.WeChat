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
    public class UploadTempMediaResponse:WeChatResponse
    {
        

        /// <summary>
        /// 文件类型
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }

        /// <summary>
        /// 媒体文件上传时间戳
        /// </summary>
        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }

        
      
    }
}
