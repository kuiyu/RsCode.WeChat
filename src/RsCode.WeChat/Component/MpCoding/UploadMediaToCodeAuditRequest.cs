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
    /// 上传提审素材
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/uploadMediaToCodeAudit.html"/>
    /// </summary>
    public class UploadMediaToCodeAuditRequest : WeChatRequest
    {
        public UploadMediaToCodeAuditRequest(string authorizerAccessToken)
        {
           AuthorizerAccessToken= authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";

        
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/uploadmedia?access_token={AuthorizerAccessToken}";
        }
    }
}
