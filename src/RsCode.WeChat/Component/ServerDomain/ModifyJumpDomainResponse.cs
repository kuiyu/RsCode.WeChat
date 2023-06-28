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
    /// 配置小程序业务域名
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/domain-management/modifyJumpDomain.html"/>
    /// </summary>
    public class ModifyJumpDomainResponse : WeChatResponse
    {

       

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(40001, "invalid credential  access_token isinvalid or not latest", "获取 access_token 时 AppSecret 错误，或者 access_token 无效。请开发者认真比对 AppSecret 的正确性，或查看是否正在为恰当的公众号调用接口"));
            ResponseMessages.Add(new WeChatResponseMessage(89019, "webview domain not change", "业务域名无更改，无需重复设置"));
            ResponseMessages.Add(new WeChatResponseMessage(89020, "open's webview domain is null! Need to set open's webview domain first!", "尚未设置小程序业务域名，请先在第三方平台中设置小程序业务域名后在调用本接口"));
            ResponseMessages.Add(new WeChatResponseMessage(89021, "request domain is not open's webview domain!", "请求保存的域名不是第三方平台中已设置的小程序业务域名或子域名")); 
            ResponseMessages.Add(new WeChatResponseMessage(89029, "业务域名数量超过限制，最多可以添加100个业务域名", "业务域名数量超过限制，最多可以添加100个业务域名"));
            ResponseMessages.Add(new WeChatResponseMessage(89231, "not support single", "个人小程序不支持调用 setwebviewdomain 接口"));
            return base.GetResponseMessage();
        }
    }
}
