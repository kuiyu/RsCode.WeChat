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
    /// 申请地理位置接口
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/privacy-api-management/applyPrivacyInterface.html"/>
    /// </summary>
    public class ApplyPrivacyInterfaceRequest : WeChatRequest
    {
        public ApplyPrivacyInterfaceRequest(string authorizerAccessToken)
        {
            AuthorizerAccessToken= authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";

       
        /// <summary>
        /// 申请的 api 英文名，例如wx.choosePoi，严格区分大小写
        /// </summary>
        [JsonPropertyName("api_name")]
        public string ApiName { get; set; }
        /// <summary>
        /// 申请说原因，不超过300个字符；需要以utf-8编码提交，否则会出现审核失败
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }
        /// <summary>
        /// (辅助网页)例如，上传官网网页链接用于辅助审核
        /// </summary>
        [JsonPropertyName("url_list")]
        public string[] UrlList { get; set; }
        /// <summary>
        /// (辅助图片)填写图片的url ，最多10个
        /// </summary>
        [JsonPropertyName("pic_list")]
        public string[] PicList { get; set; }
        /// <summary>
        /// (辅助视频)填写视频的链接 ，最多支持1个；视频格式只支持mp4格式
        /// </summary>
        [JsonPropertyName("video_list")]
        public string[] VideoList { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/security/apply_privacy_interface?access_token={AuthorizerAccessToken}";
        }
    }
}
