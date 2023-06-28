/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 获取模板列表
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/thirdparty-management/template-management/getTemplateList.html"/>
    /// </summary>
    public class GetTemplateListRequest : WeChatRequest
    {
        /// <summary>
        /// 获取模板列表
        /// </summary>
        /// <param name="componentAccessToken"></param>
        /// <param name="templateType">可选是0（对应普通模板）和1（对应标准模板），如果不填，则返回全部的</param>
        public GetTemplateListRequest(string componentAccessToken, int templateType)
        {
            ComponentAccessToken = componentAccessToken;
            TemplateType = templateType;
        }
        string ComponentAccessToken = "";

        /// <summary>
        /// 可选是0（对应普通模板）和1（对应标准模板），如果不填，则返回全部的。
        /// </summary>
        [JsonPropertyName("template_type")]
        public int TemplateType { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/gettemplatelist?access_token={ComponentAccessToken}";
        }
        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
