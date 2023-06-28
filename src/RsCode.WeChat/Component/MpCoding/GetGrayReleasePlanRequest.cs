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
    /// 获取分阶段发布详情
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/getGrayReleasePlan.html"/>
    /// </summary>
    public class GetGrayReleasePlanRequest : WeChatRequest
    {
        public GetGrayReleasePlanRequest(string authorizerAccessToken)
        {
           AuthorizerAccessToken= authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/getgrayreleaseplan?access_token={AuthorizerAccessToken}";
        }
        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
