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
    /// 提交代码审核
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/submitAudit.html"/>
    /// </summary>
    public class SubmitAuditRequest : WeChatRequest
    {
        /// <summary>
        /// 提交代码审核
        /// </summary>
        /// <param name="authorizerAccessToken">authorizer_access_token</param>
        /// <param name="itemList">审核项列表（选填，至多填写 5 项）；类目是必填的，且要填写已经在小程序配置好的类目</param>
        /// <param name="privacyapinotuse">用于声明是否不使用“代码中检测出但是未配置的隐私相关接口</param>
        /// <param name="feedbackInfo">反馈内容，至多 200 字</param>
        /// <param name="feedbackStuff">用 | 分割的 media_id 列表，至多 5 张图片, 可以通过新增临时素材接口上传而得到</param>
        /// <param name="versiondesc">小程序版本说明和功能解释</param>
        /// <param name="previewInfo">预览信息（小程序页面截图和操作录屏）</param>
        /// <param name="ugcDeclare">用户生成内容场景（UGC）信息安全声明</param>
        public SubmitAuditRequest(string authorizerAccessToken, CodeAuditItem[] itemList,bool privacyapinotuse,string feedbackInfo,string feedbackStuff,string versiondesc,PreviewInfo previewInfo=null,UgcDeclare ugcDeclare=null)
        {
           AuthorizerAccessToken= authorizerAccessToken;
            ItemList= itemList;
            PrivacyApiNotUse= privacyapinotuse;
            FeedbackInfo = feedbackInfo;
            FeedbackStuff= feedbackStuff;
            VersionDesc= versiondesc;
            PreviewInfo= previewInfo;
            UgcDeclare= ugcDeclare;
        }
        string AuthorizerAccessToken = "";

        [JsonPropertyName("item_list")]
        public CodeAuditItem[] ItemList { get; set; }
        /// <summary>
        /// 反馈内容，至多 200 字
        /// </summary>
        [JsonPropertyName("feedback_info")]
        public string FeedbackInfo { get; set; }
        /// <summary>
        /// 用 | 分割的 media_id 列表，至多 5 张图片, 可以通过新增临时素材接口上传而得到
        /// </summary>
        [JsonPropertyName("feedback_stuff")]
        public string FeedbackStuff { get; set; }
        /// <summary>
        /// 小程序版本说明和功能解释
        /// </summary>
        [JsonPropertyName("version_desc")]
        public string VersionDesc { get; set; }
        /// <summary>
        /// 预览信息（小程序页面截图和操作录屏）
        /// </summary>
        [JsonPropertyName("preview_info")]
        public PreviewInfo PreviewInfo { get; set; }
        /// <summary>
        /// 用户生成内容场景（UGC）信息安全声明
        /// </summary>
        [JsonPropertyName("ugc_declare")]
        public UgcDeclare UgcDeclare { get; set; }
        /// <summary>
        /// 用于声明是否不使用“代码中检测出但是未配置的隐私相关接口”
        /// </summary>
        [JsonPropertyName("privacy_api_not_use")]
        public bool PrivacyApiNotUse { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/submit_audit?access_token={AuthorizerAccessToken}";
        }
    }

    public class CodeAuditItem
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
        public string SendClass { get; set; }
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

    /// <summary>
    /// 预览信息（小程序页面截图和操作录屏）
    /// </summary>
    public class PreviewInfo
    {
        /// <summary>
        /// 录屏 mediaid 列表，可以通过提审素材上传接口获得
        /// </summary>
        [JsonPropertyName("video_id_list")]
        public string[] VideoIdList { get; set; }
        /// <summary>
        /// 截屏 mediaid 列表，可以通过提审素材上传接口获得
        /// </summary>
        [JsonPropertyName("pic_id_list")]
        public string[] PicIdList { get; set; }
    }

    public class UgcDeclare
    {
        /// <summary>
        /// UGC场景 0,不涉及用户生成内容, 1.用户资料,2.图片,3.视频,4.文本,5其他, 可多选,当 scene 填0时无需填写下列字段
        /// </summary>
        [JsonPropertyName("scene")]
        public int[] Scene { get; set; }
        /// <summary>
        /// 内容安全机制 1.使用平台建议的内容安全 API ,2.使用其他的内容审核产品,3.通过人工审核把关,4.未做内容审核把关
        /// </summary>
        [JsonPropertyName("method")]
        public int[] Method { get; set; }
        /// <summary>
        /// 当 scene 选其他时的说明,不超时256字
        /// </summary>
        [JsonPropertyName("other_scene_desc")]
        public string OthrerScenDesc { get; set; }
        /// <summary>
        /// 是否有审核团队, 0.无,1.有,默认0
        /// </summary>
        [JsonPropertyName("has_audit_team")]
        public int HasAuditTeam { get; set; }
        /// <summary>
        /// 说明当前对 UGC 内容的审核机制,不超过256字
        /// </summary>
        [JsonPropertyName("audit_desc")]
        public string AuditDesc { get; set; }
    }
}
