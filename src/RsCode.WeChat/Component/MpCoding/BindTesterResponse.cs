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
    /// 绑定体验者
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/member-management/bindTester.html"/>
    /// </summary>
    public class BindTesterResponse:WeChatResponse
    {

        /// <summary>
        /// 人员对应的唯一字符串
        /// </summary>
        [JsonPropertyName("userstr")]
        public string UserStr { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(85001, "user not exist or user cannot be searched", "微信号不存在或微信号设置为不可搜索"));
            ResponseMessages.Add(new WeChatResponseMessage(85002, "number of tester reach bind limit", "小程序绑定的体验者数量达到上限"));
            ResponseMessages.Add(new WeChatResponseMessage(85003, "user already bind too many weapps", "微信号绑定的小程序体验者达到上限"));
            ResponseMessages.Add(new WeChatResponseMessage(85004, "user already bind", "微信号已经绑定"));
            return base.GetResponseMessage();
        }
    }
}
