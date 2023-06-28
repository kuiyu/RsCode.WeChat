/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Text.Json.Serialization;

namespace RsCode.WeChat
{
    /// <summary>
    /// 开放平台获取微信用户信息
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/Website_App/WeChat_Login/Authorized_Interface_Calling_UnionID.html"/>
    /// </summary>
    public class SnsUserInfoResponse: WeChatResponse
    { 
        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        [JsonPropertyName("openid")] public string OpenId { get; set; }
        /// <summary>
        /// 用户的昵称
        /// </summary>
        [JsonPropertyName("nickname")] public string NickName { get; set; }
        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        [JsonPropertyName("sex")] public int Sex { get; set; }
        /// <summary>
        /// 用户所在省份
        /// </summary>
        [JsonPropertyName("province")] public string Province { get; set; }
        /// <summary>
        /// 用户所在城市
        /// </summary>
        [JsonPropertyName("city")] public string City { get; set; }
        /// <summary>
        /// 用户所在国家
        /// </summary>
        [JsonPropertyName("country")] public string Country { get; set; }
        /// <summary>
        /// 用户头像，
        /// 最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空。
        /// 若用户更换头像，原有头像URL将失效。
        /// </summary>
        [JsonPropertyName("headimgurl")] public string HeadImgUrl { get; set; }
        [JsonPropertyName("privilege")] public string[] Privilege { get; set; }



        /// <summary>
        /// 用户统一标识。针对一个微信开放平台帐号下的应用，同一用户的unionid是唯一的。
        /// </summary>
        [JsonPropertyName("unionid")] public string UnionId { get; set; }
         

        
        
 
        
    }
}
