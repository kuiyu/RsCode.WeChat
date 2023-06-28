/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using RsCode.WeChat.Message;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;


namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 快速注册个人小程序
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/register-management/fast-registration-ind/fastRegisterPersonalMp.html"/>
    /// </summary>
    public class RegisterPersonalMpResponse:WeChatResponse
    {
        /// <summary>
        /// 任务id，后面 query 查询需要用到
        /// </summary>
        [JsonPropertyName("taskid")]
        public string TaskId { get; set; }

        /// <summary>
        /// 给用户扫码认证的验证url
        /// </summary>
        [JsonPropertyName("authorize_url")]
        public string AuthorizeUrl { get; set; }

        /// <summary>
        /// 任务的状态
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(0, "ok", "ok"));
            ResponseMessages.Add(new WeChatResponseMessage(-1, "system error", "系统繁忙，此时请开发者稍候再试"));
            ResponseMessages.Add(new WeChatResponseMessage(40001, "invalid credential  access_token isinvalid or not latest", "获取 access_token 时 AppSecret 错误，或者 access_token 无效。请开发者认真比对 AppSecret 的正确性，或查看是否正在为恰当的公众号调用接口"));
            ResponseMessages.Add(new WeChatResponseMessage(86030, "提交的 json 数据缺少需要的参数；缺少参数", "提交的 json 数据缺少需要的参数；缺少参数"));
            ResponseMessages.Add(new WeChatResponseMessage(86031, "内部错误；第三方号无效或未全网发布", "内部错误；第三方号无效或未全网发布"));
            ResponseMessages.Add(new WeChatResponseMessage(86032, "无效微信号；微信 id 无效", "无效微信号；微信 id 无效"));
            ResponseMessages.Add(new WeChatResponseMessage(86033, "第三方号的缺少所需权限集；第三方号的权限集缺失", "第三方号的缺少所需权限集；第三方号的权限集缺失"));
            ResponseMessages.Add(new WeChatResponseMessage(86036, "姓名与微信号不一致", "姓名与微信号不一致"));
    
            return ResponseMessages.LastOrDefault(c => c.Code == Code);
        }
    }
}
