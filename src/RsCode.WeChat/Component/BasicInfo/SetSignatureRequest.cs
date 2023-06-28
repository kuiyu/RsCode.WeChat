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
    /// 设置小程序介绍
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/basic-info-management/setSignature.html"/>
    /// </summary>
    public class SetSignatureRequest : WeChatRequest
    {
        public SetSignatureRequest(string authorizerAccessToken, string signature)
        {
            AuthorizerAccessToken = authorizerAccessToken;
            Signature = signature;
        }
        string AuthorizerAccessToken = "";

        /// <summary>
        ///功能介绍（简介）
        /// </summary>
        [JsonPropertyName("signature")]
        public string Signature { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/account/modifysignature?access_token={AuthorizerAccessToken}";
        }
    }
}
