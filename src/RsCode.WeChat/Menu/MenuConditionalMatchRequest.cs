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
    /// 测试个性化菜单匹配结果
    /// <see cref="https://developers.weixin.qq.com/doc/offiaccount/Custom_Menus/Personalized_menu_interface.html"/>
    /// </summary>
    public class MenuConditionalMatchRequest:WeChatRequest
    {
        string AccessToken;
        /// <summary>
        /// 测试个性化菜单匹配结果
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userid">userid可以是粉丝的OpenID，也可以是粉丝的微信号</param>
        public MenuConditionalMatchRequest(string accessToken,string userid)
        {
            AccessToken = accessToken;
            UserId = userid;
        }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/menu/trymatch?access_token={AccessToken}";
        }

        public string UserId { get; set; }
    }
}
