/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

namespace RsCode.WeChat
{
     
    /// <summary>
    /// 
    /// </summary>
    public class OAuthTokenRequest:WeChatRequest
    {
        public OAuthTokenRequest(string appId,string appSecret,string code)
        {
            AppId = appId;
            AppSecret = appSecret;
            Code = code;
        }
        public string Code { get; set; }

        public string AppId { get; set; }

        public string AppSecret { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/sns/oauth2/access_token?appid={AppId}&secret={AppSecret}&code={Code}&grant_type=authorization_code";
        }
        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
