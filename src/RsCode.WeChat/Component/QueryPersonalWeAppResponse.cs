/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Text.Json.Serialization;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 查询个人小程序任务注册状态
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/register-management/fast-registration-ind/fastRegisterPersonalMp.html"/>
    /// </summary>
    public class QueryPersonalWeAppResponse:WeChatResponse
    {
        [JsonPropertyName("taskid")]
        public string TaskId { get; set; }

        [JsonPropertyName("authorize_url")]
        public string AuthorizeUrl { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }
    }
}
