/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
namespace RsCode.WeChat.MP.Auth
{
    /// <summary>
    /// 登录凭证校验。通过 wx.login 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程
    /// <see cref="https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/login/auth.code2Session.html"/>
    /// </summary>
    public class Code2SessionRequest:WeChatRequest
    {
        public Code2SessionRequest(string appId,string appSecret,string code)
        {
            AppId = appId;
            AppSecret=appSecret;
            Code = code;
        }
        public string Code { get; set; }

        public string AppId { get; set; }

        public string AppSecret { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/sns/jscode2session?appid={AppId}&secret={AppSecret}&js_code={Code}&grant_type=authorization_code";
        }
        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
