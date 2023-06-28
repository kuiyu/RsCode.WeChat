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
using static System.Net.WebRequestMethods;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 快速配置小程序业务域名
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/domain-management/modifyJumpDomainDirectly.html"/>
    /// </summary>
    public class ModifyJumpDomainDirectlyResponse : WeChatResponse
    {

        /// <summary>
        /// 小程序业务域名，当 action 参数是 get 时不需要此字段
        /// </summary>
        [JsonPropertyName("webviewdomain")]
        public string[] WebViewDomain { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            //ResponseMessages.Add(new ResponseMessage(, "", ""));
            return base.GetResponseMessage();
        }
    }
}
