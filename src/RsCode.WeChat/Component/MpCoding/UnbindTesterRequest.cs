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
    /// 解除绑定体验者
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/member-management/unbindTester.html"/>
    /// </summary>
    public class UnbindTesterRequest:WeChatRequest
    {
        public UnbindTesterRequest(string authorizerAccessToken,string wechatId,string userStr)
        {
            AuthorizerAccessToken= authorizerAccessToken;
            WechatId= wechatId;
            UserStr= userStr;
        }
        string AuthorizerAccessToken = "";

        /// <summary>
        /// 微信号。 userstr 和 wechatid 填写其中一个即可
        /// </summary>
        [JsonPropertyName("wechatid")]
        public string WechatId { get; set; }
        /// <summary>
        /// 人员对应的唯一字符串， 可通过 getTester 接口获取人员对应的字符串
         /// </summary>
        [JsonPropertyName("userstr")]
        public string UserStr { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/unbind_tester?access_token={AuthorizerAccessToken}";
        }
    }
}
