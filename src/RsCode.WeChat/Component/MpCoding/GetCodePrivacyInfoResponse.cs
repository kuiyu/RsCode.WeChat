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
    /// 获取隐私接口检测结果
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/getCodePrivacyInfo.html"/>
    /// </summary>
    public class GetCodePrivacyInfoResponse:WeChatResponse
    {
        /// <summary>
        /// 没权限的隐私接口的 api 英文名
        /// </summary>
        [JsonPropertyName("without_auth_list")]
        public string[] WithoutAuthList { get; set; }

        /// <summary>
        /// 没配置的隐私接口的 api 英文名
        /// </summary>
        [JsonPropertyName("without_conf_list")]
        public string[] WithoutConfList { get; set; }
        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(61040, "ext.json配置的隐私接口 xxx 无权限，请申请权限后再提交审核。或者代码中含有 ext.json 未配置隐私接口xxx(暂无权限)，请配置并申请权限或者承诺不使用这些接口（设置参数privacy_api_not_use为true）后再提交审核。", "ext.json配置的隐私接口 xxx 无权限，请申请权限后再提交审核。或者代码中含有 ext.json 未配置隐私接口xxx(暂无权限)，请配置并申请权限或者承诺不使用这些接口（设置参数privacy_api_not_use为true）后再提交审核。"));
            ResponseMessages.Add(new WeChatResponseMessage(61039, "隐私接口检查任务未完成，请稍等一分钟再重试", "隐私接口检查任务未完成，请稍等一分钟再重试"));
            return base.GetResponseMessage();
        }
    }
}
