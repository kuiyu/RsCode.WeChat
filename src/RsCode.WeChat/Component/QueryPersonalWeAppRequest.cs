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
    /// 查询个人小程序注册状态
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/register-management/fast-registration-ind/fastRegisterPersonalMp.html"/>
    /// </summary>
    public class QueryPersonalWeAppRequest:WeChatRequest
    {
        public QueryPersonalWeAppRequest(string componentAccessToken,string taskId)
        {
            ComponentAccessToken = componentAccessToken;
            TaskId = taskId;
        }
        string ComponentAccessToken = "";
        /// <summary>
        /// 任务Id
        /// </summary>
        [JsonPropertyName("taskid")]
        public string TaskId { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/component/fastregisterpersonalweapp?action=query&component_access_token={ComponentAccessToken}";
        }
    }
}
