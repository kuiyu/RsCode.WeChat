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
    /// 开放平台获取用户基本信息
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/Website_App/WeChat_Login/Authorized_Interface_Calling_UnionID.html"/>
    /// </summary>
    public class SnsUserInfoRequest : WeChatRequest
    {
        public SnsUserInfoRequest(string accessToken,string openid,string lang="zh_CN")
        {
            AccessToken = accessToken;
            OpenId = openid;
            Lang = lang;
        }
        public string AccessToken { get;private set; }

        public string OpenId { get;private set; }

        public string Lang { get; private set; } = "zh_CN";

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/sns/userinfo?access_token={AccessToken}&openid={OpenId}&lang={Lang}";
        }
        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
