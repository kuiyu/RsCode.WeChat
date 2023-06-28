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
    /// 修改头像
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/basic-info-management/setHeadImage.html"/>
    /// </summary>
    public class SetHeadImageResponse : WeChatResponse
    {

       

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(40001, "invalid credential  access_token isinvalid or not latest", "获取 access_token 时 AppSecret 错误，或者 access_token 无效。请开发者认真比对 AppSecret 的正确性，或查看是否正在为恰当的公众号调用接口"));
            ResponseMessages.Add(new WeChatResponseMessage(40007, "invalid media_id", "不合法的媒体文件 id"));
            ResponseMessages.Add(new WeChatResponseMessage(40097, "invalid args", "参数错误"));
            ResponseMessages.Add(new WeChatResponseMessage(41006, "media_id missing", "缺少 media_id 参数"));
            ResponseMessages.Add(new WeChatResponseMessage(40007, "invalid media_id", "不合法的媒体文件 id"));
            ResponseMessages.Add(new WeChatResponseMessage(46001, "media data no exist", "不存在媒体数据，media_id 不存在"));
            ResponseMessages.Add(new WeChatResponseMessage(47001, "data format error", "解析 JSON/XML 内容错误;post 数据中参数缺失;检查修正后重试"));
            ResponseMessages.Add(new WeChatResponseMessage(40009, "invalid image size", "图片尺寸太大"));
            ResponseMessages.Add(new WeChatResponseMessage(53202, "modify avatar quota limit exceed", "本月头像修改次数已用完"));

            return base.GetResponseMessage();
        }
    }
}
