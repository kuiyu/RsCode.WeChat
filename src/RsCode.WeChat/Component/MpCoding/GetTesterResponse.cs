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
    /// 获取体验者列表
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/member-management/getTester.html"/>
    /// </summary>
    public class GetTesterResponse : WeChatResponse
    {

        /// <summary>
        /// 人员信息列表
        /// </summary>
        [JsonPropertyName("members")]
        public Members[] Members { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(-1, "system error", "系统繁忙，此时请开发者稍候再试"));
            return base.GetResponseMessage();
        }
    }

    public class Members
    {
        /// <summary>
        /// 人员对应的唯一字符串
        /// </summary>
        [JsonPropertyName("userstr")]
        public string UserStr { get; set; }
    }
}
