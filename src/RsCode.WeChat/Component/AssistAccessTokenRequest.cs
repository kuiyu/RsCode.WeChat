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
    /// 第三方平台代公众号发起网页授权, 通过 code 换取 access_token
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/Third-party_Platforms/2.0/api/Before_Develop/Official_Accounts/official_account_website_authorization.html"/>
    /// </summary>
    public class AssistAccessTokenRequest:WeChatRequest
    {
        /// <summary>
        /// 第三方平台代公众号发起网页授权,通过 code 换取 access_token
        /// </summary>
        /// <param name="code">填写第一步获取的 code 参数</param>
        /// <param name="appId">公众号的 appid</param>
        /// <param name="componentAppId">服务开发方的 appid</param>
        /// <param name="componentAccessToken">服务开发方的 access_token</param>
        public AssistAccessTokenRequest(string code, string appId, string componentAppId, string componentAccessToken)
        {
            Code = code;
            AppId = appId;
            ComponentAppId = componentAppId;
            ComponentAccessToken = componentAccessToken;
        }

        public string Code { get; set; }
        public string AppId { get; set; }

        public string ComponentAppId { get; set; }

        public string ComponentAccessToken { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/sns/oauth2/component/access_token?appid={AppId}&code={Code}&grant_type=authorization_code&component_appid={ComponentAppId}&component_access_token={ComponentAccessToken}";
        }

        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
