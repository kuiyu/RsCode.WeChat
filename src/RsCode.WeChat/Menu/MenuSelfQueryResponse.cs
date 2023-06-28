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
    /// 公众号当前使用的自定义菜单的配置
    /// </summary>
    public class MenuSelfQueryResponse:WeChatResponse
    {
        [JsonPropertyName("is_menu_open")]
        public int IsMenuOpen { get; set; }
        [JsonPropertyName("selfmenu_info")]
        public SelfMenuInfo SelfMenu { get; set; }
    }

    
}
