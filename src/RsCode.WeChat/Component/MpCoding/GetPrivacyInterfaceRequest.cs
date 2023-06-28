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
    /// 获取地理位置接口列表
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/privacy-api-management/getPrivacyInterface.html"/>
    /// </summary>
    public class GetPrivacyInterfaceRequest : WeChatRequest
    {
        public GetPrivacyInterfaceRequest(string authorizerAccessToken)
        {
            AuthorizerAccessToken= authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";

    
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/security/get_privacy_interface?access_token={AuthorizerAccessToken}";
        }

        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
