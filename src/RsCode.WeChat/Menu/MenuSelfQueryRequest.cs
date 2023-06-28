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
    /// 提供公众号当前使用的自定义菜单的配置，
    /// 如果公众号是通过API调用设置的菜单，则返回菜单的开发配置，
    /// 如果公众号是在公众平台官网通过网站功能发布菜单，则本接口返回运营者设置的菜单配置。
    /// <see cref="https://developers.weixin.qq.com/doc/offiaccount/Custom_Menus/Querying_Custom_Menus.html"/>
    /// </summary>
    public class MenuSelfQueryRequest:WeChatRequest
    {
        string AccessToken;
        /// <summary>
        /// 公众号当前使用的自定义菜单的配置
        /// </summary>
        /// <param name="accessToken"></param>
        public MenuSelfQueryRequest(string accessToken)
        {
            AccessToken = accessToken;
        }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/get_current_selfmenu_info?access_token={AccessToken}";
        }
        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
