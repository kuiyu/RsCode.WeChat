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
    /// 获取发布后生效业务域名列表
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/domain-management/getEffectiveJumpDomain.html"/>
    /// </summary>
    public class GetEffectiveJumpDomainResponse : WeChatResponse
    {

        /// <summary>
        /// 通过公众平台配置的服务器域名列表
        /// </summary>
        [JsonPropertyName("mp_webviewdomain")]
        public string[] MpWebViewDomain { get; set; }
        /// <summary>
        /// 通过第三方平台接口modifyServerDomain 配置的服务器域名
        /// </summary>
        [JsonPropertyName("third_webviewdomain")]
        public string[] ThirdWebViewDomain { get; set; }
        /// <summary>
        /// 通过modifyJumpDomainDirectly接口配置的业务域名列表
        /// </summary>
        [JsonPropertyName("direct_webviewdomain")]
        public string[] DirectWebViewDomain { get; set; }
        /// <summary>
        /// 最后提交代码或者发布上线后生效的域名列表
        /// </summary>
        [JsonPropertyName("effective_webviewdomain")]
        public string[] EffectiveWebViewDomain { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            //ResponseMessages.Add(new ResponseMessage(, "", ""));
            return base.GetResponseMessage();
        }
    }
}
