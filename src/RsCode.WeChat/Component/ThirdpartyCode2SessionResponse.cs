/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using RsCode.WeChat.Message;
using System.Text.Json.Serialization;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 小程序登录
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/login/thirdpartyCode2Session.html"/>
    /// </summary>
    public class ThirdpartyCode2SessionResponse : WeChatResponse
    {

        /// <summary>
        /// 会话密钥
        /// </summary>
        [JsonPropertyName("session_key")]
        public string SessionKey { get; set; }
        /// <summary>
        /// 用户唯一标识的 openid
        /// </summary>
        [JsonPropertyName("openid")]
        public string OpenId { get; set; }
        /// <summary>
        /// 用户在开放平台的唯一标识符，在满足 UnionID 下发条件的情况下会返回，详见 UnionID 机制说明
        /// </summary>
        [JsonPropertyName("unionid")]
        public string UnionId { get; set; }
 

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(45011, "api minute-quota reach limit  mustslower  retry next minute", "API 调用太频繁，请稍候再试"));
            ResponseMessages.Add(new WeChatResponseMessage(40029, "code 无效", "js_code无效"));
            ResponseMessages.Add(new WeChatResponseMessage(61003, "component is not authorized by this account", "component is not authorized by this account"));
            ResponseMessages.Add(new WeChatResponseMessage(41021, "missing component_access_token", "missing component_access_token"));
            return base.GetResponseMessage();
        }
    }
}
