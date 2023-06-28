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
    /// 获取业务域名校验文件
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/domain-management/getJumpDomainConfirmFile.html"/>
    /// </summary>
    public class GetJumpDomainConfirmFileRequest : WeChatRequest
    {
        public GetJumpDomainConfirmFileRequest(string authorizerAccessToken)
        {
            AuthorizerAccessToken= authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonPropertyName("")]
        //public int MyProperty { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/get_webviewdomain_confirmfile?access_token={AuthorizerAccessToken}";
        }
    }
}
