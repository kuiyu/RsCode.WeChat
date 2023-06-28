/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Text.Json.Serialization;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 设置 DNS 预解析域名
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/domain-management/setPrefetchDomain.html"/>
    /// </summary>
    public class SetPrefetchDomainRequest : WeChatRequest
    {
        public SetPrefetchDomainRequest(string authorizerAccessToken, string[]dnsDomain)
        {
            AuthorizerAccessToken= authorizerAccessToken;
            PrefetchDnsDomain= dnsDomain;
        }
        string AuthorizerAccessToken = "";

        /// <summary>
        /// 预解析 dns 域名
        /// </summary>
        [JsonPropertyName("prefetch_dns_domain")]
        public string[] PrefetchDnsDomain { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/set_prefetchdnsdomain?access_token={AuthorizerAccessToken}";
        }
    }
}
