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
    /// 查询绑定的开放平台帐号
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/basic-info-management/getBindOpenAccount.html"/>
    /// </summary>
    public class GetBindOpenAccountRequest : WeChatRequest
    {
        public GetBindOpenAccountRequest(string authorizerAccessToken)
        {
            AuthorizerAccessToken= authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";

        
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/open/have?access_token={AuthorizerAccessToken}";
        }
        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
