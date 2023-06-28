/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using RsCode.WeChat.Message;
using System.Linq;
using System.Text.Json.Serialization;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 获取已上传的代码页面列表
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/getCodePage.html"/>
    /// </summary>
    public class GetCodePageResponse : WeChatResponse
    {
        [JsonPropertyName("page_list")]
        public string PageList { get; set; }
        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(40001, "invalid credential  access_token isinvalid or not latest", "获取 access_token 时 AppSecret 错误，或者 access_token 无效。请开发者认真比对 AppSecret 的正确性，或查看是否正在为恰当的公众号调用接口"));
            ResponseMessages.Add(new WeChatResponseMessage(-1, "system error", "系统繁忙，此时请开发者稍候再试"));
            ResponseMessages.Add(new WeChatResponseMessage(86000, "should be called only from third party", "不是由第三方代小程序进行调用"));
            ResponseMessages.Add(new WeChatResponseMessage(86001, "component experience version not exists", "不存在第三方的已经提交的代码"));

            return ResponseMessages.LastOrDefault(c => c.Code==Code);
        }
    }
}
