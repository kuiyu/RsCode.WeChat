/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using MediatR;

namespace RsCode.WeChat
{
    /// <summary>
    /// 微信公众号获取用户基本信息（包括UnionID机制）该接口不返回用户头像昵称,可通过网页授权方式获取头像昵称
    /// 请注意： 20年6月8日起，用户关注来源“微信广告（ADD_SCENE_WECHAT_ADVERTISEMENT）”从“其他（ADD_SCENE_OTHERS）”中拆分给出，2021年12月27日之后，不再输出头像、昵称信息。
    /// <see cref="https://developers.weixin.qq.com/doc/offiaccount/User_Management/Get_users_basic_information_UnionID.html#UinonId"/>
    /// </summary>
    public class WeChatUserBaseInfoRequest:WeChatRequest
    {
        public WeChatUserBaseInfoRequest(string accessToken,string openid,string lang="zh_CN")
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
            return $"https://api.weixin.qq.com/cgi-bin/user/info?access_token={AccessToken}&openid={OpenId}&lang={Lang}";
        }
        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
