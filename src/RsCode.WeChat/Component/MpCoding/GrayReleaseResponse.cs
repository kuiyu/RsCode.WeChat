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
    /// 分阶段发布
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/grayRelease.html"/>
    /// </summary>
    public class GrayReleaseResponse : WeChatResponse
    {
        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(40001, "invalid credential  access_token isinvalid or not latest", "获取 access_token 时 AppSecret 错误，或者 access_token 无效。请开发者认真比对 AppSecret 的正确性，或查看是否正在为恰当的公众号调用接口"));
            ResponseMessages.Add(new WeChatResponseMessage(86002, "miniprogram have not completed init procedure", "小程序还未设置昵称、头像、简介。请先设置完后再重新提交"));
            ResponseMessages.Add(new WeChatResponseMessage(-1, "system error", "系统繁忙，此时请开发者稍候再试"));
            ResponseMessages.Add(new WeChatResponseMessage(85079, "miniprogram has no online release", "小程序没有线上版本，即小程序尚未发布，不可进行该操作"));
            ResponseMessages.Add(new WeChatResponseMessage(85080, "miniprogram commit not approved", "小程序提交的审核未审核通过"));
            ResponseMessages.Add(new WeChatResponseMessage(85081, "invalid gray percentage", "无效的发布比例"));
            ResponseMessages.Add(new WeChatResponseMessage(85082, "gray percentage too low", "当前的发布比例需要比之前设置的高"));

            return base.GetResponseMessage();
        }
    }
}
