/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Text.Json.Serialization;

namespace RsCode.WeChat.MP.QrCode
{
    /// <summary>
    /// 获取小程序码，适用于需要的码数量极多的业务场景。通过该接口生成的小程序码，永久有效，数量暂无限制。
    /// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/qr-code/wxacode.getUnlimited.html
    /// </summary>
    public class GetUnlimitedRequest:WeChatRequest
    {
        [JsonIgnore]
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 最大32个可见字符，只支持数字，大小写英文以及部分特殊字符：!#$&'()*+,/:;=?@-._~，其它字符请自行编码为合法字符（因不支持%，中文无法使用 urlencode 处理，请使用其他编码方式）
        /// </summary>
        [JsonPropertyName("scene")]
        public string Scene { get; set; }

        /// <summary>
        /// 必须是已经发布的小程序存在的页面（否则报错），例如 pages/index/index, 根路径前不要填加 /,不能携带参数（参数请放在scene字段里），如果不填写这个字段，默认跳主页面
        /// </summary>
        [JsonPropertyName("page")]
        public string Page { get; set; }

        /// <summary>
        /// 二维码的宽度，单位 px，最小 280px，最大 1280px
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; set; } = 430;

        /// <summary>
        /// 自动配置线条颜色，如果颜色依然是黑色，则说明不建议配置主色调，默认 false
        /// </summary>
        [JsonPropertyName("auto_color")]
        public bool AutoColor { get; set; }

        /// <summary>
        /// auto_color 为 false 时生效，使用 rgb 设置颜色 例如 {"r":"xxx","g":"xxx","b":"xxx"} 十进制表示
        /// </summary>
        [JsonPropertyName("line_color")]
        public object LineColor { get; set; }

        /// <summary>
        /// 是否需要透明底色，为 true 时，生成透明底色的小程序
        /// </summary>
        [JsonPropertyName("is_hyaline")]
        public bool IsHyaline { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/getwxacodeunlimit?access_token={AccessToken}";
        }
        public override string RequestMethod()
        {
            return "POST";
        }
    }
}
