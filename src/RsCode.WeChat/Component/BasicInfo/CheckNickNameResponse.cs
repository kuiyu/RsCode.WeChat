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
    /// 小程序名称检测
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/basic-info-management/checkNickName.html"/>
    /// </summary>
    public class CheckNickNameResponse : WeChatResponse
    {

        /// <summary>
        /// 是否命中关键字策略。若命中，可以选填关键字材料
        /// </summary>
        [JsonPropertyName("hit_condition")]
        public bool HitCondition { get; set; }

        /// <summary>
        /// 命中关键字的说明描述
        /// </summary>
        [JsonPropertyName("wording")]
        public string Wording { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(40001, "invalid credential  access_token isinvalid or not latest", "获取 access_token 时 AppSecret 错误，或者 access_token 无效。请开发者认真比对 AppSecret 的正确性，或查看是否正在为恰当的公众号调用接口"));
            ResponseMessages.Add(new WeChatResponseMessage(53010, "nickname invalid", "名称格式不合法"));
            ResponseMessages.Add(new WeChatResponseMessage(53011, "check nickname too frequently", "名称检测命中频率限制"));
            ResponseMessages.Add(new WeChatResponseMessage(53012, "nickname ban", "禁止使用该名称"));
            ResponseMessages.Add(new WeChatResponseMessage(53013, "nickname has been occupied", "公众号：名称与已有公众号名称重复;小程序：该名称与已有小程序名称重复"));
            ResponseMessages.Add(new WeChatResponseMessage(53014, "nickname has been occupied", "公众号：公众号已有{名称 A+}时，需与该帐号相同主体才可申请{名称 A};小程序：小程序已有{名称 A+}时，需与该帐号相同主体才可申请{名称 A}"));
            ResponseMessages.Add(new WeChatResponseMessage(53015, "nickname has been occupied", "公众号：该名称与已有小程序名称重复，需与该小程序帐号相同主体才可申请;小程序：该名称与已有公众号名称重复，需与该公众号帐号相同主体才可申请"));
            ResponseMessages.Add(new WeChatResponseMessage(53016, "nickname has been occupied", "公众号：该名称与已有多个小程序名称重复，暂不支持申请;小程序：该名称与已有多个公众号名称重复，暂不支持申请"));
            ResponseMessages.Add(new WeChatResponseMessage(53017, "nickname has been occupied", "公众号：小程序已有{名称 A+}时，需与该帐号相同主体才可申请{名称 A};小程序：公众号已有{名称 A+}时，需与该帐号相同主体才可申请{名称 A}"));
            ResponseMessages.Add(new WeChatResponseMessage(53018, "名称命中微信号", "名称命中微信号"));
            ResponseMessages.Add(new WeChatResponseMessage(53019, "名称在保护期内", "名称在保护期内"));
           
            return base.GetResponseMessage();
        }
    }
}
