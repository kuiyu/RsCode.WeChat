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
    /// 代商家小程序登录
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/login/thirdpartyCode2Session.html"/>
    /// </summary>
    public class ThirdpartyCode2SessionRequest : WeChatRequest
    {
        /// <summary>
        /// 代商家小程序登录
        /// </summary>
        /// <param name="componentAppId"></param>
        /// <param name="componentAccessToken"></param>
        /// <param name="appid"></param>
        /// <param name="jscode"></param>
        /// <param name="grantType"></param>
        public ThirdpartyCode2SessionRequest(string componentAppId,string componentAccessToken,string appid,string jscode,string grantType= "authorization_code")
        {
            ComponentAccessToken= componentAccessToken;
            AppId= appid;
            GrantType = grantType;
            ComponentAppId=  componentAppId;
            JsCode= jscode;
        }
        string ComponentAccessToken = "";

        /// <summary>
        /// 小程序的 AppID
        /// </summary>
        [JsonPropertyName("appid")]
        public string AppId { get; set; }
        /// <summary>
        /// 填 authorization_code
        /// </summary>
        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; }
        /// <summary>
        /// 第三方平台 appid
        /// </summary>
        [JsonPropertyName("component_appid")]
        public string ComponentAppId { get; set; }
        /// <summary>
        /// wx.login 获取的 code
        /// </summary>
        [JsonPropertyName("js_code")]
        public string JsCode { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/sns/component/jscode2session?component_access_token={ComponentAccessToken}";
        }
        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
