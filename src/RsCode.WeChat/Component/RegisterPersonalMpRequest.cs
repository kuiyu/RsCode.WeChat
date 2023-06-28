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
    /// 快速注册个人小程序
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/register-management/fast-registration-ind/fastRegisterPersonalMp.html"/>
    /// </summary>
    public class RegisterPersonalMpRequest:WeChatRequest
    {

        public RegisterPersonalMpRequest(string accessToken,string idName,string wxUser,string componentPhone)
        {
            AccessToken = accessToken;
            IdName = idName;
            WxUser = wxUser;
            ComponentPhone = componentPhone;
        }

        string AccessToken = "";
        /// <summary>
        /// 个人用户名字
        /// </summary>
        [JsonPropertyName("idname")]
        public string IdName { get; set; }
        /// <summary>
        /// 个人用户微信号
        /// </summary>
        [JsonPropertyName("wxuser")]
        public string WxUser { get; set; }
        /// <summary>
        /// 第三方联系电话
        /// </summary>
        [JsonPropertyName("component_phone")]
        public string ComponentPhone { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/component/fastregisterpersonalweapp?action=query&component_access_token={AccessToken}";
        }
    }
}
