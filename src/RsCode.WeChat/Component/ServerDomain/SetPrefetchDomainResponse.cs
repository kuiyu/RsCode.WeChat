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
    /// 设置 DNS 预解析域名
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/domain-management/setPrefetchDomain.html"/>
    /// </summary>
    public class SetPrefetchDomainResponse : WeChatResponse
    {

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonPropertyName("")]
        //public int MyProperty { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(9420000, "no quota", "超出每月可修改50次的次数限制"));
            ResponseMessages.Add(new WeChatResponseMessage(9420001, "invalid domain", "非法域名，如新增域名未备案"));
            ResponseMessages.Add(new WeChatResponseMessage(9420002, "out of size limit", "域名总数大于size_limit（默认为5）"));
            return base.GetResponseMessage();
        }
    }
}
