/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using System.Text.Json.Serialization;

namespace RsCode.WeChat.Account
{
    /// <summary>
    /// 二维码响应内容 
    /// 获取二维码ticket后，开发者可用ticket换取二维码图片。请注意，本接口无须登录态即可调用。
    /// <see cref="https://developers.weixin.qq.com/doc/offiaccount/Account_Management/Generating_a_Parametric_QR_Code.html"/>
    /// </summary>
    public class WxQrCodeResponse : WeChatResponse
    {
        /// <summary>
        /// 获取的二维码ticket，凭借此ticket可以在有效时间内换取二维码。
        /// </summary>
        [JsonPropertyName("ticket")]
        public string  Ticket { get; set; }

        /// <summary>
        /// 该二维码有效时间，以秒为单位。 最大不超过2592000（即30天）。
        /// </summary>
        [JsonPropertyName("expire_seconds")]
        public int ExpireSeconds { get; set; }

        /// <summary>
        /// 二维码图片解析后的地址，开发者可根据该地址自行生成需要的二维码图片
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

         
    }
}
