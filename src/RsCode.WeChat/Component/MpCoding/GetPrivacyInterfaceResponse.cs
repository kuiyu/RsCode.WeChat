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
    /// 获取地理位置接口列表
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/privacy-api-management/getPrivacyInterface.html"/>
    /// </summary>
    public class GetPrivacyInterfaceResponse : WeChatResponse
    {

        /// <summary>
        /// 地理位置相关隐私接口
        /// </summary>
        [JsonPropertyName("interface_list")]
        public InterfaceList InterfaceList { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(61031, "our last submission is under review, please do not apply again", "审核中，请不要重复申请"));
            return base.GetResponseMessage();
        }
    }
    /// <summary>
    /// 地理位置相关隐私接口
    /// </summary>
    public class InterfaceList
    {
        /// <summary>
        /// api 英文名
        /// </summary>
        [JsonPropertyName("api_name")]
        public string ApiName { get; set; }
        /// <summary>
        /// api 中文名
        /// </summary>
        [JsonPropertyName("api_ch_name")]
        public string ApiChName { get; set; }
        /// <summary>
        /// api描述
        /// </summary>
        [JsonPropertyName("api_desc")]
        public string ApiDesc { get; set; }
        /// <summary>
        /// 申请时间 ，该字段发起申请后才会有
        /// </summary>
        [JsonPropertyName("apply_time")]
        public int ApplyTime { get; set; }
        /// <summary>
        /// 接口状态，该字段发起申请后才会有
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }
        /// <summary>
        /// 申请单号，该字段发起申请后才会有
        /// </summary>
        [JsonPropertyName("audit_id")]
        public int AuditId { get; set; }
        /// <summary>
        /// 申请被驳回原因或者无权限，该字段申请驳回时才会有
        /// </summary>
        [JsonPropertyName("fail_reason")]
        public string FailReason { get; set; }
        /// <summary>
        /// api文档链接
        /// </summary>
        [JsonPropertyName("api_link")]
        public string ApiLink { get; set; }
        /// <summary>
        /// 分组名
        /// </summary>
        [JsonPropertyName("group_name")]
        public string GroupName { get; set; }
        
    }

}
