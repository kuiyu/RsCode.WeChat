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
    /// 小程序名称检测
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/basic-info-management/checkNickName.html"/>
    /// </summary>
    public class CheckNickNameRequest : WeChatRequest
    {
        public CheckNickNameRequest(string authorizerAccessToken,string nickName)
        {
            AuthorizerAccessToken= authorizerAccessToken;
            NickName= nickName;
        }
        string AuthorizerAccessToken = "";

        /// <summary>
        /// 名称（昵称）
        /// </summary>
        [JsonPropertyName("nick_name")]
        public string   NickName { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/wxverify/checkwxverifynickname?access_token={AuthorizerAccessToken}";
        }
    }
}
