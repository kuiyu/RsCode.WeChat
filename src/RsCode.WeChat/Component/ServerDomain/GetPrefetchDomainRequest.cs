/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 获取 DNS 预解析域名
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/domain-management/getPrefetchDomain.html"/>
    /// </summary>
    public class GetPrefetchDomainRequest : WeChatRequest
    {
        public GetPrefetchDomainRequest(string authorizerAccessToken)
        {
            AuthorizerAccessToken= authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";
 
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/get_prefetchdnsdomain?access_token={AuthorizerAccessToken}";
        }
    }
}
