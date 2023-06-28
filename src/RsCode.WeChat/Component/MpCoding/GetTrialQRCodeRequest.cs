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
    /// 获取体验版二维码
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/getTrialQRCode.html"/>
    /// </summary>
    public class GetTrialQRCodeRequest : WeChatRequest
    {
        public GetTrialQRCodeRequest(string authorizerAccessToken,string path)
        {
           AuthorizerAccessToken= authorizerAccessToken;
            Path= path; 
        }
        string AuthorizerAccessToken = "";
        [JsonPropertyName("path")]
        public string Path { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/get_qrcode?access_token={AuthorizerAccessToken}";
        }
        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
