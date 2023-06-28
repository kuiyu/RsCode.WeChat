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
    /// 设置小程序介绍
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/basic-info-management/setSignature.html"/>
    /// </summary>
    public class SetSignatureResponse : WeChatResponse
    {
         

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(40001, "invalid credential  access_token isinvalid or not latest", "获取 access_token 时 AppSecret 错误，或者 access_token 无效。请开发者认真比对 AppSecret 的正确性，或查看是否正在为恰当的公众号调用接口"));
            ResponseMessages.Add(new WeChatResponseMessage(40097, "invalid args", "参数错误"));

            ResponseMessages.Add(new WeChatResponseMessage(53200, "modify signature quota limit exceed", "本月功能介绍修改次数已用完"));
            ResponseMessages.Add(new WeChatResponseMessage(53201, "signature in black list  can notuse", "功能介绍内容命中黑名单关键字"));
            return base.GetResponseMessage();
        }
    }
}
