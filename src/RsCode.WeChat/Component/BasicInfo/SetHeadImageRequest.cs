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
    /// 修改头像
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/basic-info-management/setHeadImage.html"/>
    /// </summary>
    public class SetHeadImageRequest : WeChatRequest
    {
        public SetHeadImageRequest(string authorizerAccessToken,string headImgMediaId,string x1,string y1,string x2,string y2)
        {
            AuthorizerAccessToken= authorizerAccessToken;
            HeadImgMediaId= headImgMediaId;
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
        string AuthorizerAccessToken = "";

        /// <summary>
        /// 头像素材 media_id
        /// </summary>
        [JsonPropertyName("head_img_media_id")]
        public string HeadImgMediaId { get; set; }
        /// <summary>
        /// 裁剪框左上角 x 坐标（取值范围：[0, 1]）
        /// </summary>
        [JsonPropertyName("x1")]
        public string X1 { get; set; }
        /// <summary>
        /// 裁剪框左上角 y 坐标（取值范围：[0, 1]）
        /// </summary>
        [JsonPropertyName("y1")]
        public string Y1 { get; set; }
        /// <summary>
        /// 裁剪框右下角 x 坐标（取值范围：[0, 1]）
        /// </summary>
        [JsonPropertyName("x2")]
        public string X2 { get; set; }
        /// <summary>
        /// 裁剪框右下角 y 坐标（取值范围：[0, 1]）
        /// </summary>
        [JsonPropertyName("y2")]
        public string Y2 { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/account/modifyheadimage?access_token={AuthorizerAccessToken}";
        }
    }
}
