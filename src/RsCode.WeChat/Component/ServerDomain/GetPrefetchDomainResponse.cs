/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using RsCode.WeChat.Message;
using System.Text.Json.Serialization;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 获取 DNS 预解析域名
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/domain-management/getPrefetchDomain.html"/>
    /// </summary>
    public class GetPrefetchDomainResponse : WeChatResponse
    {

        /// <summary>
        /// 预解析 dns 域名
        /// </summary>
        [JsonPropertyName("prefetch_dns_domain")]
        public string[] PrefetchDnsDomain { get; set; }
        /// <summary>
        /// 总共可配置域名个数
        /// </summary>
        [JsonPropertyName("size_limit")]
        public int SizeLimit { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            //ResponseMessages.Add(new ResponseMessage(, "", ""));
            return base.GetResponseMessage();
        }
    }
}
