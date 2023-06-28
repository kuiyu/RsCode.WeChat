/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using RsCode.WeChat.Message;
using System.Text.Json.Serialization;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 设置小程序名称
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/basic-info-management/setNickName.html"/>
    /// </summary>
    public class SetNickNameResponse : WeChatResponse
    {

        /// <summary>
        /// 材料说明
        /// </summary>
        [JsonPropertyName("wording")]
        public string Wording { get; set; }
        /// <summary>
        /// 审核单 id
        /// </summary>
        [JsonPropertyName("audit_id")]
        public int AuditId { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(91001, "not fast register", "不是复用公众号快速创建的小程序以及不是通过快速注册企业小程序接口注册的小程序"));
            ResponseMessages.Add(new WeChatResponseMessage(91002, "has published", "小程序发布后不可改名"));
            ResponseMessages.Add(new WeChatResponseMessage(91003, "invalid change stat", "改名状态不合法"));
            ResponseMessages.Add(new WeChatResponseMessage(91004, "invalid nickname", "昵称不合法"));
            ResponseMessages.Add(new WeChatResponseMessage(91005, "昵称 15 天主体保护", "昵称 15 天主体保护"));
            ResponseMessages.Add(new WeChatResponseMessage(91007, "nickname used", "昵称已被占用"));
            ResponseMessages.Add(new WeChatResponseMessage(91008, "昵称命中 7 天侵权保护期", "昵称命中 7 天侵权保护期"));
            ResponseMessages.Add(new WeChatResponseMessage(91009, "nickname need proof", "需要提交材料"));
            ResponseMessages.Add(new WeChatResponseMessage(91010, "其他错误", "其他错误"));
            ResponseMessages.Add(new WeChatResponseMessage(91011, "查不到昵称修改审核单信息", "查不到昵称修改审核单信息"));
            ResponseMessages.Add(new WeChatResponseMessage(91012, "其他错误", "其他错误"));
            ResponseMessages.Add(new WeChatResponseMessage(91013, "占用名字过多", "占用名字过多"));
            ResponseMessages.Add(new WeChatResponseMessage(91014, "diff master plus", "+号规则 同一类型关联名主体不一致"));
            ResponseMessages.Add(new WeChatResponseMessage(91015, "diff master", "原始名不同类型主体不一致"));
            ResponseMessages.Add(new WeChatResponseMessage(91016, "name more owner", "名称占用者 ≥2"));
            ResponseMessages.Add(new WeChatResponseMessage(91017, "other diff master plus", "+号规则 不同类型关联名主体不一致"));
        
            return base.GetResponseMessage();
        }
    }
}
