﻿/*
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
    /// 微信公众号获取用户基本信息(UnionID机制)
    /// <see cref="https://developers.weixin.qq.com/doc/offiaccount/User_Management/Get_users_basic_information_UnionID.html#UinonId"/>
    /// </summary>
    public class WeChatUserBaseInfoResponse:WeChatResponse
    {
        /// <summary>
        /// 用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息。
        /// </summary>
        [JsonPropertyName("subscribe")] public int Subscribe { get; set; }
        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        [JsonPropertyName("openid")] public string OpenId { get; set; }
        /// <summary>
        /// 用户的昵称
        /// </summary>
        [JsonPropertyName("nickname")] public string NickName { get; set; } = "微信用户";
        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        [JsonPropertyName("sex")] public int Sex { get; set; }

        [JsonPropertyName("language")] public string Language { get; set; }
        /// <summary>
        /// 用户所在城市
        /// </summary>
        [JsonPropertyName("city")] public string City { get; set; }
        /// <summary>
        /// 用户所在省份
        /// </summary>
        [JsonPropertyName("province")] public string Province { get; set; }
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
        /// <summary>
        /// 用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间
        /// </summary>
        [JsonPropertyName("subscribe_time")] public long SubscribeTime { get; set; }
        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。
        /// </summary>
        [JsonPropertyName("unionid")] public string UnionId { get; set; }
        /// <summary>
        /// 公众号运营者对粉丝的备注，公众号运营者可在微信公众平台用户管理界面对粉丝添加备注
        /// </summary>
        [JsonPropertyName("remark")] public string Remark { get; set; }

        
        /// <summary>
        /// 用户所在的分组ID（兼容旧的用户分组接口）
        /// </summary>
        [JsonPropertyName("groupid")] public int GroupId { get; set; }
        /// <summary>
        /// 用户被打上的标签ID列表
        /// </summary>
        [JsonPropertyName("tagid_list")] public int[] TagIdList { get; set; }

        /// <summary>
        /// 返回用户关注的渠道来源，ADD_SCENE_SEARCH 公众号搜索，ADD_SCENE_ACCOUNT_MIGRATION 公众号迁移，
        /// ADD_SCENE_PROFILE_CARD 名片分享，ADD_SCENE_QR_CODE 扫描二维码，
        /// ADD_SCENE_PROFILE_LINK 图文页内名称点击，ADD_SCENE_PROFILE_ITEM 图文页右上角菜单，ADD_SCENE_PAID 支付后关注，
        /// ADD_SCENE_OTHERS 其他
        /// </summary>
        [JsonPropertyName("subscribe_scene")] public string SubScribeScene { get; set; }
        /// <summary>
        /// 二维码扫码场景（开发者自定义）
        /// </summary>
        [JsonPropertyName("qr_scene")] public int QrScene { get; set; }
        /// <summary>
        /// 二维码扫码场景描述（开发者自定义）
        /// </summary>
        [JsonPropertyName("qr_scene_str")]public string QrSceneStr { get; set; }
    }
}
