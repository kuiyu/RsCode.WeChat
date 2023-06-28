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
    /// 获取模板列表
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/thirdparty-management/template-management/getTemplateList.html"/>
    /// </summary>
    public class GetTemplateListResponse:WeChatResponse
    {

        [JsonPropertyName("template_list")]
        public MpTemplate[] TemplateList { get; set; }
        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(0, "未提审核", "未提审核"));
            ResponseMessages.Add(new WeChatResponseMessage(1, "审核中", "审核中"));
            ResponseMessages.Add(new WeChatResponseMessage(2, "审核驳回", "审核驳回"));
            ResponseMessages.Add(new WeChatResponseMessage(3, "审核通过", "审核通过"));
            ResponseMessages.Add(new WeChatResponseMessage(4, "提审中", "提审中"));
            ResponseMessages.Add(new WeChatResponseMessage(5, "提审失败", "提审失败"));

            return base.GetResponseMessage();
        }
    }

    public class MpTemplate
    {
        /// <summary>
        /// 开发者上传草稿时间戳
        /// </summary>
        [JsonPropertyName("create_time")]
        public long CreateTime { get; set; }
        /// <summary>
        /// 版本号，开发者自定义字段
        /// </summary>
        [JsonPropertyName("user_version")]
        public string UserVersion { get; set; }
        /// <summary>
        /// 版本描述 开发者自定义字段
        /// </summary>
        [JsonPropertyName("user_desc")]
        public string  UserDesc { get; set; }
        /// <summary>
        /// 模板 id
        /// </summary>
        [JsonPropertyName("template_id")]
        public int TemplateId { get; set; }
        /// <summary>
        /// 草稿 id
        /// </summary>
        [JsonPropertyName("draft_id")]
        public int DraftId { get; set; }
        /// <summary>
        /// 开发小程序的appid
        /// </summary>
        [JsonPropertyName("source_miniprogram_appid")]
        public string SourceMiniProgramAppId { get; set; }
        /// <summary>
        /// 开发小程序的名称
        /// </summary>
        [JsonPropertyName("source_miniprogram")]
        public string SourceMiniprogram { get; set; }
        /// <summary>
        /// 0对应普通模板，1对应标准模板
        /// </summary>
        [JsonPropertyName("template_type")]
        public int TemplateType { get; set; }

        /// <summary>
        /// 标准模板的类目信息；如果是普通模板则值为空的数组
        /// </summary>
        [JsonPropertyName("category_list")]
        public MpTemplateCategory[] CategoryList { get; set; }
        /// <summary>
        /// 标准模板的场景标签；普通模板不返回该值
        /// </summary>
        [JsonPropertyName("audit_scene")]
        public int AuditScene { get; set; }
        /// <summary>
        /// 标准模板的审核状态；普通模板不返回该值
        /// </summary>
        [JsonPropertyName("audit_status")]
        public int AuditStatus { get; set; }
        /// <summary>
        /// 标准模板的审核驳回的原因，；普通模板不返回该值
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; }

    }

    public class MpTemplateCategory
    {
        /// <summary>
        /// 小程序的页面，可通过"获取小程序的页面列表getCodePage"接口获得
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }
        /// <summary>
        /// 小程序的标签，用空格分隔，标签至多 10 个，标签长度至多 20
        /// </summary>
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
        /// <summary>
        /// 一级类目名称，可通过"getAllCategoryName"接口获取
        /// </summary>
        [JsonPropertyName("first_class")]
        public string FirstClass { get; set; }
        /// <summary>
        /// 二级类目名称，可通过"getAllCategoryName"接口获取
        /// </summary>
        [JsonPropertyName("second_class")]
        public string SecondClass { get; set; }
        /// <summary>
        /// 三级类目名称，可通过"getAllCategoryName"接口获取
        /// </summary>
        [JsonPropertyName("third_class")]
        public string ThirdClass { get; set; }
        /// <summary>
        /// 小程序页面的标题,标题长度至多 32
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// 一级类目id，可通过"getAllCategoryName"接口获取
        /// </summary>
        [JsonPropertyName("first_id")]
        public int FirstId { get; set; }
        /// <summary>
        /// 二级类目id，可通过"getAllCategoryName"接口获取
        /// </summary>
        [JsonPropertyName("second_id")]
        public int SecondId { get; set; }
        /// <summary>
        /// 三级类目id，可通过"getAllCategoryName"接口获取
        /// </summary>
        [JsonPropertyName("third_id")]
        public int ThirdId { get; set; }
    }
}
