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

namespace RsCode.WeChat.MP.Auth
{
    /// <summary>
    /// 小程序用户信息
    /// </summary>
    public class Code2SessionResponse:WeChatResponse
    {
        [JsonPropertyName("openid")]
        public string OpenId { get; set; }
        /// <summary>
        /// 会话密钥
        /// </summary>
        [JsonPropertyName("session_key")]
        public string SessionKey { get; set; }

        [JsonPropertyName("unionid")]
        public string UnionId { get; set; }

 

    }
}
