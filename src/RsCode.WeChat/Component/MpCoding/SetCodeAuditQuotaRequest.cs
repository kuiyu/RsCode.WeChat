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
    /// 查询服务商审核额度
    /// <see cref=""/>
    /// </summary>
    public class SetCodeAuditQuotaRequest : WeChatRequest
    {
        public SetCodeAuditQuotaRequest(string authorizerAccessToken)
        {
           AuthorizerAccessToken= authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/queryquota?access_token={AuthorizerAccessToken}";
        }

        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
