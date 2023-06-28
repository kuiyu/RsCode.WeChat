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
    /// 获取默认菜单和全部个性化菜单信息
    /// <see cref="https://developers.weixin.qq.com/doc/offiaccount/Custom_Menus/Getting_Custom_Menu_Configurations.html"/>
    /// </summary>
    public class MenuQueryResponse:WeChatResponse
    {
        /// <summary>
        /// 默认菜单 
        /// </summary>
        [JsonPropertyName("menu")]
        public MenuInfo Menu { get; set; }
        /// <summary>
        /// 个性化菜单 
        /// </summary>
        [JsonPropertyName("conditionalmenu")] 
        public ConditionalMenuInfo ConditionalMenu { get; set; }
    }
}
