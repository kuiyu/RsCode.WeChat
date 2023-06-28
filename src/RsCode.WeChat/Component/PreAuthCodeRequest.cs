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
    /// 第三方平台获取预授权码
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/ticket-token/getPreAuthCode.html"/>
    /// 
    /// </summary>
    public class PreAuthCodeRequest:WeChatRequest
    {
        /// <summary>
        /// 第三方平台获取预授权码
        /// </summary>
        /// <param name="componentAppId"></param>
        /// <param name="componentAccessToken">使用component_access_token</param>
        public PreAuthCodeRequest(string componentAppId, string componentAccessToken)
        {
            AccessToken = componentAccessToken;
            ComponentAppId = componentAppId;
        }

        /// <summary>
        /// 接口调用凭证，该参数为 URL 参数，非 Body 参数。
        /// </summary>
        string AccessToken="";

        /// <summary>
        /// 第三方平台 appid
        /// </summary>
        [JsonPropertyName("component_appid")]
        public string ComponentAppId { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/component/api_create_preauthcode?access_token={AccessToken}";
        }

      
    }
}
