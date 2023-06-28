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
    /// 将草稿添加到模板库
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/thirdparty-management/template-management/addToTemplate.html"/>
    /// </summary>
    public class AddToTemplateRequest : WeChatRequest
    {
        public AddToTemplateRequest(string componentAccessToken,int draftId,int templateType)
        {
            ComponentAccessToken = componentAccessToken;
            DraftId = draftId;
            TemplateType = templateType;
        }
        string ComponentAccessToken = "";

        /// <summary>
        /// 草稿 ID
        /// </summary>
        [JsonPropertyName("draft_id")]
        public int DraftId { get; set; }
        /// <summary>
        /// 默认值是0，对应普通模板；可选1，对应标准模板库
        /// </summary>
        [JsonPropertyName("template_type")]
        public int TemplateType { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/addtotemplate?access_token={ComponentAccessToken}";
        }
    }
}
