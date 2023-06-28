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
    /// 快速注册企业小程序
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/register-management/fast-registration-ent/registerMiniprogram.html"/>
    /// </summary>
    public class RegisterMiniprogramRequest:WeChatRequest
    {
        /// <summary>
        ///  快速注册企业小程序
        /// </summary>
        /// <param name="componentAccessToken">第三方平台接口调用凭证component_access_token</param>
        /// <param name="name">企业名（需与工商部门登记信息一致）</param>
        /// <param name="code">企业代码</param>
        /// <param name="codeType">企业代码类型 1：统一社会信用代码（18 位） 2：组织机构代码（9 位 xxxxxxxx-x） 3：营业执照注册号(15 位)</param>
        /// <param name="legalPersnaleWechat">法人微信号</param>
        /// <param name="presonalName">法人姓名（绑定银行卡）</param>
        /// <param name="componentPhone">第三方联系电话</param>
        public RegisterMiniprogramRequest(string componentAccessToken,string name,string code,string codeType,string legalPersnaleWechat,string presonalName,string componentPhone="")
        {
            AccessToken = componentAccessToken;
            Name = name;
            Code = code;
            CodeType = codeType;
            LegaPersonalWeChat = legalPersnaleWechat;
            LegalPersonalName= presonalName;
            ComponentPhone = componentPhone;
        }

        string AccessToken = "";

        /// <summary>
        /// 企业名（需与工商部门登记信息一致）；如果是“无主体名称个体工商户”则填“个体户+法人姓名”，例如“个体户张三”
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// 企业代码
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }
        /// <summary>
        /// 企业代码类型 1：统一社会信用代码（18 位） 2：组织机构代码（9 位 xxxxxxxx-x） 3：营业执照注册号(15 位)
        /// </summary>
        [JsonPropertyName("code_type")]
        public string CodeType { get; set; }
        /// <summary>
        /// 法人微信号
        /// </summary>
        [JsonPropertyName("legal_persona_wechat")]
        public string LegaPersonalWeChat { get; set; }
        /// <summary>
        /// 法人姓名（绑定银行卡）
        /// </summary>
        [JsonPropertyName("legal_persona_name")]
        public string LegalPersonalName { get; set; }
        /// <summary>
        /// 第三方联系电话
        /// </summary>
        [JsonPropertyName("component_phone")]
        public string ComponentPhone { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/component/fastregisterweapp?action=create&component_access_token={AccessToken}";
        }

      
    }
}
