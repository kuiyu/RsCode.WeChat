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
    /// 获取发布后生效服务器域名列表
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/domain-management/getEffectiveServerDomain.html"/>
    /// </summary>
    public class GetEffectiveServerDomainRequest : WeChatRequest
    {
        public GetEffectiveServerDomainRequest(string authorizerAccessToken)
        {
            AuthorizerAccessToken= authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";

         
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/get_effective_domain?access_token={AuthorizerAccessToken}";
        }
    }
}
