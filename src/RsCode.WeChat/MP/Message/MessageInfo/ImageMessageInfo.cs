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
    /// <summary>
    /// 图片消息
    /// </summary>
    public class ImageMessageInfo : SendMessage
    {
        /// <summary>
        /// 发送的图片的媒体ID，通过 新增素材接口 上传图片文件获得。
        /// </summary>
        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }
    }
}
