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
    /// 试用小程序快速认证
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/register-management/fast-regist-beta/verfifyBetaMiniprogram.html"/>
    /// </summary>
    public class VerifyBetaMiniprogramRequest:WeChatRequest
    {
        public VerifyBetaMiniprogramRequest(string accessToken,string authorizerAccessToken,VerifyInfo info)
        {
            AccessToken = accessToken;
            AuthorizerAccessToken = authorizerAccessToken;
            VerifyInfo= info;
        }

        string AccessToken = "";

        /// <summary>
        /// 第三方平台接口调用令牌authorizer_access_token
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AuthorizerAccessToken { get; set; }

        /// <summary>
        /// 企业法人认证需要的信息
        /// </summary>
        [JsonPropertyName("verify_info")]
        public VerifyInfo VerifyInfo { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/verifybetaweapp?access_token={AccessToken}";
        }
    }
    /// <summary>
    /// 企业法人认证需要的信息
    /// </summary>
    public class VerifyInfo
    {
        /// <summary>
        /// 企业名（需与工商部门登记信息一致)；如果是“无主体名称个体工商户”则填“个体户+法人姓名”，例如“个体户张三”
        /// </summary>
        [JsonPropertyName("enterprise_name")]
        public string EnterpriseName { get; set; }
        /// <summary>
        /// 企业代码
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }
        /// <summary>
        /// 企业代码类型 1：统一社会信用代码（18 位） 2：组织机构代码（9 位 xxxxxxxx-x） 3：营业执照注册号(15 位)
        /// </summary>
        [JsonPropertyName("code_type")]
        public int CodeType { get; set; }

        /// <summary>
        /// 法人微信号
        /// </summary>
        [JsonPropertyName("legal_persona_wechat")]
        public string LegalPersonalWechat { get; set; }

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

        /// <summary>
        /// 法人身份证号
        /// </summary>
        [JsonPropertyName("legal_persona_idcard")]
        public string LegalPersonalIdCard { get; set; }
    }
}
