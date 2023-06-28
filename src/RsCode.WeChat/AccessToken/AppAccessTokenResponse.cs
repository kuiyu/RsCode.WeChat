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
   public  class AppAccessTokenResponse:WeChatResponse
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// 凭证有效时间，单位：秒。目前是7200秒之内的值。
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int Expires { get; set; }
    }
}
