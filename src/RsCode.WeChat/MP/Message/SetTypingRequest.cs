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
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.WeChat.MP.CustomerMessage
{
    public class SetTypingRequest
    {
        /// <summary>
        /// 接口调用凭证
        /// </summary>
        [Required]
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 用户的 OpenID
        /// </summary>
        [Required]
        [JsonPropertyName("touser")]
        public string ToUser { get; set; }
        /// <summary>
        /// 命令
        /// command的合法值：Typing	对用户下发"正在输入"状态    CancelTyping	取消对用户的"正在输入"状态
        /// </summary>
        [Required]
        [JsonPropertyName("command")]
        public string Command { get; set; }
    }
}
