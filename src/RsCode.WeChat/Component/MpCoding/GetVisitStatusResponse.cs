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
    /// 查询小程序服务状态
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/getVisitStatus.html"/>
    /// </summary>
    public class GetVisitStatusResponse : WeChatResponse
    {
        /// <summary>
        /// 服务状态。0表示已暂停服务（包含主动暂停服务违规被暂停服务）。1表示未暂停服务
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }
        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(-1, "system error", "系统繁忙，此时请开发者稍候再试"));
            ResponseMessages.Add(new WeChatResponseMessage(44002, "empty post data", "POST 的数据包为空。post请求 body 参数不能为空。"));
            return base.GetResponseMessage();
        }
    }
}
