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
    /// 注册试用小程序
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/register-management/fast-regist-beta/registerBetaMiniprogram.html"/>
    /// </summary>
    public class RegisterBetaMiniprogramResponse:WeChatResponse
    {
        /// <summary>
        /// 该请求的唯一标识符，用于关联微信用户和后面产生的appid
        /// </summary>
        [JsonPropertyName("unique_id")]
        public string UniqueId { get; set; }


        /// <summary>
        /// 用户授权确认url，需将该 url 发送给用户，小程序管理员在微信打开并进入授权页面完成授权方可创建小程序
        /// </summary>
        [JsonPropertyName("authorize_url")]
        public string AuthorizeUrl { get; set; }
    }
}
