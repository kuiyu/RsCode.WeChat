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
    /// 创建个性化菜单
    /// <see cref="https://developers.weixin.qq.com/doc/offiaccount/Custom_Menus/Personalized_menu_interface.html"/>
    /// </summary>
    public class MenuConditionalCreateRequest:WeChatRequest
    {
        string AccessToken;
        /// <summary>
        /// 创建个性化菜单
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="menuBtn"></param>
        /// <param name="matchRule"></param>
        public MenuConditionalCreateRequest(string accessToken, ConditionalMenuCreate menuCreate)
        {
            AccessToken = accessToken;
            MenuButtonInfo = menuCreate.MenuButtons;
            MatchRule =menuCreate.MatchRule;
        } 
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/menu/addconditional?access_token={AccessToken}";
        }
      
        /// <summary>
        /// 个性化菜单
        /// </summary>
        [JsonPropertyName("button")]
        public ConditionalMenuButton[] MenuButtonInfo { get; set; }
        /// <summary>
        /// 个性菜单规则
        /// </summary>
        [JsonPropertyName("matchrule")]
        public MatchRule MatchRule { get; set; }

    }
}
