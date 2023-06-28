/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Text.Json.Serialization;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 删除代码模板
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/thirdparty-management/template-management/deleteTemplate.html"/>
    /// </summary>
    public class DeleteTemplateRequest : WeChatRequest
    {
        public DeleteTemplateRequest(string componentAccessToken,int templateId)
        {
            ComponentAccessToken= componentAccessToken;
            TemplateId = templateId;
        }
        string ComponentAccessToken = "";

        /// <summary>
        /// 要删除的模板 ID ，可通过获取模板列表接口
        /// </summary>
        [JsonPropertyName("template_id")]
        public int TemplateId { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/deletetemplate?access_token={ComponentAccessToken}";
        }
    }
}
