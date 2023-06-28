/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using RsCode.WeChat.Message;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 设置搜索状态
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/basic-info-management/setSearchStatus.html"/>
    /// </summary>
    public class SetSearchStatusResponse : WeChatResponse
    {

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonPropertyName("")]
        //public int MyProperty { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(40001, "invalid credential  access_token isinvalid or not latest", "获取 access_token 时 AppSecret 错误，或者 access_token 无效。请开发者认真比对 AppSecret 的正确性，或查看是否正在为恰当的公众号调用接口"));
            ResponseMessages.Add(new WeChatResponseMessage(85083, "search status is banned", "搜索标记位被封禁，无法修改"));
            return base.GetResponseMessage();
        }
    }
}
