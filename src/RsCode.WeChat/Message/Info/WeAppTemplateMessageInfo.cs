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

namespace RsCode.WeChat.Message
{
    /// <summary>
    /// 发小程序消息 
    /// </summary>
    public class WeAppTemplateMessageInfo
    {
        /// <summary>
        /// 小程序模板ID
        /// </summary>
        [JsonPropertyName("template_id")]
        public string TemplateId { get; set; } = "";
        /// <summary>
        /// 小程序页面路径
        /// </summary>
        [JsonPropertyName("page")]
        public string Page { get; set; } = "";
        /// <summary>
        /// 小程序模板消息formid
        /// </summary>
        [JsonPropertyName("form_id")]
        public string FormId { get; set; } = "";
        /// <summary>
        /// 小程序模板数据
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; } = "";
        /// <summary>
        /// 小程序模板放大关键词
        /// </summary>
        [JsonPropertyName("emphasis_keyword")]
        public string EmphasisKeyword { get; set; } = "";


    }
}
