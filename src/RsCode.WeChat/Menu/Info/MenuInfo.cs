/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using System.Text.Json.Serialization;

namespace RsCode.WeChat.Menu
{
    /// <summary>
    /// 默认菜单
    /// </summary>
    public class MenuInfo
    {
        [JsonPropertyName("menuid")]
        public long  MenuId { get; set; }

        [JsonPropertyName("button")]
        public MenuButtonInfo[] MenuButtonInfo { get; set; }

    }
    /// <summary>
    /// 个性化菜单
    /// </summary>
    public class ConditionalMenuInfo
    {
        [JsonPropertyName("menuid")]
        public long MenuId { get; set; }

        [JsonPropertyName("button")]
        public MenuButtonInfo[] MenuButtonInfo { get; set; }

        [JsonPropertyName("matchrule")]
        public MatchRule MatchRule { get; set; }
    }

    public class MenuButtonInfo
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }
        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }
        [JsonPropertyName("appid")]
        public string AppId { get; set; }
        [JsonPropertyName("pagepath")]
        public string PagePath { get; set; }

        [JsonPropertyName("sub_button")]
        public SubMenuButtonInfo[] SubMenuList { get; set; }

    }


    public class SubButtonList
    {
        [JsonPropertyName("list")]
        public SubMenuButtonInfo[] MenuBtnList { get; set; }
    }
    public class SubMenuButtonInfo
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("key")]
        public string Key { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }
        [JsonPropertyName("appid")]
        public string AppId { get; set; }
        [JsonPropertyName("pagepath")]
        public string PagePath { get; set; }

    }


  
}
