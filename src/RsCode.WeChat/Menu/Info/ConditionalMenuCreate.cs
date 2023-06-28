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
    public class ConditionalMenuCreate
    {
        [JsonPropertyName("button")]
        public ConditionalMenuButton[] MenuButtons { get; set; }

        [JsonPropertyName("matchrule")]
        public MatchRule MatchRule { get; set; }
    }

    /// <summary>
    /// 个性化菜单规则
    /// </summary>
    public class MatchRule
    {
        [JsonPropertyName("tag_id")]
        public string TagId { get; set; }
        [JsonPropertyName("sex")]
        public string Sex { get; set; }
        [JsonPropertyName("client_platform_type")]
        public string ClientPlatFormType { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("province")]
        public string Province { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("language")]
        public string Language { get; set; }
    }

    /// <summary>
    /// 个性化菜单一级菜单 
    /// </summary>
    public class ConditionalMenuButton
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("key")]
        public string Key { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        [JsonPropertyName("pagepath")]
        public string PagePath { get; set; }
        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }
        /// <summary>
        /// 个性货菜单二级菜单 
        /// </summary>
        [JsonPropertyName("sub_button")]
        public ConditionalMenuButton2[] MenuButtons { get; set; }
    }
    /// <summary>
    /// 个性化菜单二级菜单
    /// </summary>
    public class ConditionalMenuButton2
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("key")]
        public string Key { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        [JsonPropertyName("pagepath")]
        public string PagePath { get; set; }
        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }
    }
}
