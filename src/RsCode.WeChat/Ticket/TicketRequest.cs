/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Text.Json.Serialization;

namespace RsCode.WeChat
{
    public class TicketRequest : WeChatRequest
    {
        public TicketRequest(string accessToken, string type)
        {
            AccessToken = accessToken;
            Type = type;
        }
        string Type = "";
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={AccessToken}&type={Type}";
        }
        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
