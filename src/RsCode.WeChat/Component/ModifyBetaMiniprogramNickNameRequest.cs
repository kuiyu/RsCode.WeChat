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
    /// 修改试用小程序名称
    /// </summary>
    public class ModifyBetaMiniprogramNickNameRequest:WeChatRequest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">接口调用凭证，该参数为 URL 参数，非 Body 参数。使用component_access_token或者使用authorizer_access_token</param>
        /// <param name="name"></param>
        public ModifyBetaMiniprogramNickNameRequest(string accessToken,string name)
        {
            AccessToken = accessToken;
            Name = name;
        }

        string AccessToken = "";

        /// <summary>
        /// 小程序名称，昵称半自动设定，强制后缀“的体验小程序”。
        /// 且该参数会进行关键字检查，如果命中品牌关键字则会报错。 如遇到品牌大客户要用试用小程序，建议用户先换个名字，认证后再修改成品牌名
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/setbetaweappnickname?access_token={AccessToken}";
        }
    }
}
