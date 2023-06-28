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
    /// 测试个性化菜单匹配结果
    /// </summary>
    public class MenuConditionalMatchResponse:WeChatResponse
    {
        [JsonPropertyName("button")]
        public MenuButtonInfo MenuBtn { get; set; }
    }
}
