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
    /// 设置小程序名称
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/basic-info-management/setNickName.html"/>
    /// </summary>
    public class SetNickNameRequest : WeChatRequest
    {
        public SetNickNameRequest(string authorizerAccessToken,string nickname,string idcard,string license,string other1,string other2,string other3,string other4,string other5)
        {
            AuthorizerAccessToken= authorizerAccessToken;
            NickName= nickname;
            License= license;
            IdCard= idcard;
            NamingOtherStuff1= other1;
            NamingOtherStuff2= other2;
            NamingOtherStuff3= other3;
            NamingOtherStuff4= other4;
                NamingOtherStuff5= other5;

        }
        string AuthorizerAccessToken = "";

        /// <summary>
        /// 昵称，不支持包含“小程序”关键字的昵称
        /// </summary>
        [JsonPropertyName("nick_name")]
        public string NickName { get; set; }
        /// <summary>
        /// 身份证照片 mediaid，个人号必填
        /// </summary>
        [JsonPropertyName("id_card")]
        public string IdCard { get; set; }
        /// <summary>
        /// 组织机构代码证或营业执照 mediaid，组织号必填
        /// </summary>
        [JsonPropertyName("license")]
        public string License { get; set; }
        /// <summary>
        ///其他证明材料 mediaid
        /// </summary>
        [JsonPropertyName("naming_other_stuff_1")]
        public string NamingOtherStuff1 { get; set; }
        /// <summary>
        ///其他证明材料 mediaid
        /// </summary>
        [JsonPropertyName("naming_other_stuff_2")]
        public string NamingOtherStuff2 { get; set; }
        /// <summary>
        /// 其他证明材料 mediaid
        /// </summary>
        [JsonPropertyName("naming_other_stuff_3")]
        public string NamingOtherStuff3 { get; set; }
        /// <summary>
        /// 其他证明材料 mediaid
        /// </summary>
        [JsonPropertyName("naming_other_stuff_4")]
        public string NamingOtherStuff4 { get; set; }
        /// <summary>
        /// 其他证明材料 mediaid
        /// </summary>
        [JsonPropertyName("naming_other_stuff_5")]
        public string NamingOtherStuff5 { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/setnickname?access_token={AuthorizerAccessToken}";
        }
    }
}
