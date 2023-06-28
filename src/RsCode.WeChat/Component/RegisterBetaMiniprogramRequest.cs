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
    /// 注册试用小程序
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/register-management/fast-regist-beta/registerBetaMiniprogram.html"/>
    /// </summary>
    public class RegisterBetaMiniProgramRequest:WeChatRequest
    {
        public RegisterBetaMiniProgramRequest(string componentAccessToken,string name,string openId)
        {
            AccessToken = componentAccessToken;
            Name = name;
            OpenId = openId;
        }
        /// <summary>
        /// 小程序名称，昵称半自动设定，强制后缀“的体验小程序”。且该参数会进行关键字检查，如果命中品牌关键字则会报错。 如遇到品牌大客户要用试用小程序，建议用户先换个名字，认证后再修改成品牌名。 只支持4-30个字符
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 微信用户的openid（不是微信号），试用小程序创建成功后会默认将该用户设置为小程序管理员
        /// </summary>
        [JsonPropertyName("openid")]
        public string OpenId { get; set; }

        string AccessToken = "";
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/component/fastregisterbetaweapp?access_token={AccessToken}";
        }
    }
}
