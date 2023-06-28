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
    /// 查询绑定的开放平台帐号
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/basic-info-management/getBindOpenAccount.html"/>
    /// </summary>
    public class GetBindOpenAccountResponse : WeChatResponse
    {

        /// <summary>
        /// 是否绑定 open 帐号，true表示绑定；false表示未绑定任何 open 帐号
        /// </summary>
        [JsonPropertyName("have_open")]
        public bool HaveOpen { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            //ResponseMessages.Add(new ResponseMessage(, "", ""));
            return base.GetResponseMessage();
        }
    }
}
