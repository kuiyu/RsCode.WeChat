/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using RsCode.WeChat.Menu;
using System.Text.Json.Serialization;

namespace RsCode.WeChat
{
    /// <summary>
    /// 创建菜单
    /// <see cref="https://developers.weixin.qq.com/doc/offiaccount/Custom_Menus/Creating_Custom-Defined_Menu.html"/>
    /// </summary>
    public class MenuCreateRequest:WeChatRequest
    {
        string AccessToken;
        /// <summary>
        /// 创建菜单 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="btns"></param>
        public MenuCreateRequest(string accessToken, SelfMenuCreate selfMenu)
        {
            AccessToken = accessToken;
            MenuButtonInfos = selfMenu.MenuButtons;
        }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/menu/create?access_token={AccessToken}";
        }

        [JsonPropertyName("button")]
        public MenuButtonInfo[] MenuButtonInfos { get; set;}
    }
}
