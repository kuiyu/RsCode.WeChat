/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;


namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 第三方平台调用凭证 /获取刷新令牌
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/Third-party_Platforms/2.0/api/ThirdParty/token/authorization_info.html"/>
    /// </summary>
    public class AuthorizerQueryResponse:WeChatResponse
    {
        /// <summary>
        /// 刷新令牌信息
        /// </summary>
        [JsonPropertyName("authorization_info")]
        public AuthorizationInfo AuthorizationInfo { get; set; }
    }

}
