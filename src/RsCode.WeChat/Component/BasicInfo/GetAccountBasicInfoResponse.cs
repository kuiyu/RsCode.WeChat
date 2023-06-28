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
    /// 获取基本信息
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/basic-info-management/getAccountBasicInfo.html"/>
    /// </summary>
    public class GetAccountBasicInfoResponse : WeChatResponse
    {

        /// <summary>
        /// 帐号 appid
        /// </summary>
        [JsonPropertyName("appid")]
        public string AppId { get; set; }
        /// <summary>
        /// 帐号类型（1：订阅号，2：服务号，3：小程序）
        /// </summary>
        [JsonPropertyName("account_type")]
        public int AccountType { get; set; }
        /// <summary>
        /// 主体类型 0个人 1企业 2媒体 3政府 4其它组织
        /// </summary>
        [JsonPropertyName("principal_type")]
        public int PrincipalType { get; set; }
        /// <summary>
        /// 主体名称
        /// </summary>
        [JsonPropertyName("principal_name")]
        public string PrincipalName { get; set; }
        /// <summary>
        /// 实名验证状态 1验证成功 2验证中 3 验证失败
        /// </summary>
        [JsonPropertyName("realname_status")]
        public int RealNameStatus { get; set; }
        /// <summary>
        /// 微信认证信息
        /// </summary>
        [JsonPropertyName("wx_verify_info")]
        public WxVerifyInfo WxVerifyInfo { get; set; }
        /// <summary>
        /// 功能介绍信息
        /// </summary>
        [JsonPropertyName("signature_info")]
        public SignatureInfo SignatureInfo { get; set; }
        /// <summary>
        /// 头像信息
        /// </summary>
        [JsonPropertyName("head_image_info")]
        public HeadImageInfo HeadImageInfo { get; set; }
        /// <summary>
        /// 小程序名称
        /// </summary>
        [JsonPropertyName("nickname")]
        public string NickName { get; set; }
        /// <summary>
        /// 注册国家
        /// </summary>
        [JsonPropertyName("registered_country")]
        public int RegisteredCountry { get; set; }
        /// <summary>
        /// 名称信息
        /// </summary>
        [JsonPropertyName("nickname_info")]
        public NickNameInfo NickNameInfo { get; set; }
        /// <summary>
        /// 非个人主体时返回的是企业或者政府或其他组织的代号
        /// </summary>
        [JsonPropertyName("credential")]
        public string Credential { get; set; }
        /// <summary>
        /// 认证类型；如果未完成微信认证则返回0；
        /// 0个人 1企业 2媒体 3政府 4其他组织 5民营 6盈利组织 8社会团体 9事业媒体 11事业单位 12个体户 14海外企业
        /// </summary>
        [JsonPropertyName("customer_type")]
        public int CustomerType { get; set; }
       

        public override WeChatResponseMessage GetResponseMessage()
        {
            //ResponseMessages.Add(new ResponseMessage(, "", ""));
            return base.GetResponseMessage();
        }
    }
    /// <summary>
    /// 微信认证信息
    /// </summary>
    public class WxVerifyInfo
    {
        /// <summary>
        /// 是否资质认证，若是，拥有微信认证相关的权限。
        /// </summary>
        [JsonPropertyName("qualification_verify")]
        public bool QualificationVerify { get; set; }
        /// <summary>
        /// 是否名称认证
        /// </summary>
        [JsonPropertyName("naming_verify")]
        public bool NamingVerify { get; set; }
        /// <summary>
        /// 是否需要年审（qualification_verify == true 时才有该字段）
        /// </summary>
        [JsonPropertyName("annual_review")]
        public bool AnnualReview { get; set; }
        /// <summary>
        /// 年审开始时间，时间戳（qualification_verify == true 时才有该字段）
        /// </summary>
        [JsonPropertyName("annual_review_begin_time")]
        public int AnnualReviewBeginTime { get; set; }
        /// <summary>
        /// 年审截止时间，时间戳（qualification_verify == true 时才有该字段）
        /// </summary>
        [JsonPropertyName("annual_review_end_time")]
        public int AnnualReviewEndTime { get; set; }
    }
    /// <summary>
    /// 功能介绍信息
    /// </summary>
    public class SignatureInfo
    {
        /// <summary>
        /// 功能介绍
        /// </summary>
        [JsonPropertyName("signature")]
        public string Signature { get; set; }
        /// <summary>
        /// 功能介绍已使用修改次数（本月）
        /// </summary>
        [JsonPropertyName("modify_used_count")]
        public int ModifyUsedCount { get; set; }
        /// <summary>
        /// 功能介绍修改次数总额度（本月）
        /// </summary>
        [JsonPropertyName("modify_quota")]
        public int ModifyQuota { get; set; }
    }
    /// <summary>
    /// 头像信息
    /// </summary>
    public class HeadImageInfo
    {
        /// <summary>
        /// 头像 url
        /// </summary>
        [JsonPropertyName("head_image_url")]
        public string HeadImageUrl { get; set; }
        /// <summary>
        /// 头像已使用修改次数（本年）
        /// </summary>
        [JsonPropertyName("modify_used_count")]
        public int ModifyUsedCount { get; set; }
        /// <summary>
        /// 头像修改次数总额度（本年）
        /// </summary>
        [JsonPropertyName("modify_quota")]
        public int ModifyQuota { get; set; }
    }
    /// <summary>
    /// 名称信息
    /// </summary>
    public class NickNameInfo
    {
        /// <summary>
        /// 小程序/公众号帐号名称
        /// </summary>
        [JsonPropertyName("nickname")]
        public string Nickanme { get; set; }
        /// <summary>
        /// 小程序名称已使用修改次数（本年）
        /// </summary>
        [JsonPropertyName("modify_used_count")]
        public int ModifyUsedCount { get; set; }
        /// <summary>
        /// 小程序名称修改次数总额度（本年）
        /// </summary>
        [JsonPropertyName("modify_quota")]
        public int ModifyQuota { get; set; }
    }

}
