/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.WeChat.Message
{
    public class UniformMessageRequest:WeChatRequest
    {
        /// <summary>
        /// 接口调用凭证
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// 用户openid
        /// </summary>
        [JsonPropertyName("touser")]
        public string ToUser { get; set; }
        /// <summary>
        /// 小程序模板消息相关的信息，可以参考小程序模板消息接口; 有此节点则优先发送小程序模板消息
        /// </summary>
        [JsonPropertyName("weapp_template_msg")]
        public WeAppTemplateMessageInfo WebAppTemplateMsg { get; set; }
        /// <summary>
        /// 公众号模板消息相关的信息，可以参考公众号模板消息接口；有此节点并且没有weapp_template_msg节点时，发送公众号模板消息
        /// </summary>
        [JsonPropertyName("mp_template_msg")]
        public MpTemplateMessageInfo MpTemplateMsg { get; set; }

        public override string GetApiUrl()
        {
            throw new Exception("该API己被微信下架");
            return $"https://api.weixin.qq.com/cgi-bin/message/wxopen/template/uniform_send?access_token={AccessToken}";
        }
    }
}
