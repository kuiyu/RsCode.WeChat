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
    /// 小程序卡片消息
    /// </summary>
    public class MiniProgramPageMessageInfo : SendMessage
    {
        /// <summary>
        /// 消息标题
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// 小程序的页面路径，跟app.json对齐，支持参数，比如pages/index/index?foo=bar
        /// </summary>
        [JsonPropertyName("pagepath")]
        public string PagePath { get; set; }

        /// <summary>
        /// 小程序消息卡片的封面， image 类型的 media_id，通过 新增素材接口 上传图片文件获得，建议大小为 520*416
        /// </summary>
        [JsonPropertyName("thumb_media_id")]
        public string ThumbMediaId { get; set; }
    }
}
