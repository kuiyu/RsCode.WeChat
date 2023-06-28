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
    /// 第三方代公众号发起网页授权 第三步刷新accesstoken
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/Third-party_Platforms/2.0/api/Before_Develop/Official_Accounts/official_account_website_authorization.html"/>
    /// </summary>
    public class AssistRefreshTokenRequest: WeChatRequest
    {
        /// <summary>
        /// 刷新 access_token
        /// </summary>
        /// <param name="appId">公众号的 appid</param>
        /// <param name="refreshToken">填写通过 access_token 获取到的 refresh_token 参数</param>
        /// <param name="componentAppId">服务开发商的 appid</param>
        /// <param name="componentAccessToken">服务开发方的 access_toke</param>
        public AssistRefreshTokenRequest(string appId,string refreshToken,string componentAppId,string componentAccessToken)
        {
            AppId = appId;
            RefreshToken = refreshToken;
            ComponentAppId = componentAppId;
            ComponentAccessToken = componentAccessToken;
        }
        
        public string RefreshToken { get; set; }
        public string AppId { get; set; }

        public string ComponentAppId { get; set; }

        public string ComponentAccessToken { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/sns/oauth2/component/refresh_token?appid={AppId}&grant_type=refresh_token&component_appid={ComponentAppId}&component_access_token={ComponentAccessToken}&refresh_token={RefreshToken}";
        }
        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
