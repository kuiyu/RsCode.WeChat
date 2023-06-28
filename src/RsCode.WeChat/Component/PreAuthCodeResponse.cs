/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Text.Json.Serialization;

namespace RsCode.WeChat
{
    /// <summary>
    /// 第三方平台获取预授权码
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/ticket-token/getPreAuthCode.html"/>
    /// </summary>
    public class PreAuthCodeResponse:WeChatResponse
    {
        /// <summary>
        /// 有效期，单位：秒
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int Expires { get; set; }

        /// <summary>
        /// 预授权码
        /// </summary>
        [JsonPropertyName("pre_auth_code")]
        public string PreAuthCode { get; set; }
    }
}
