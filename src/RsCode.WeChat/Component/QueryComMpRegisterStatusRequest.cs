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
    /// 查询企业小程序注册进度
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/register-management/fast-registration-ent/registerMiniprogram.html"/>
    /// </summary>
    public class QueryComMpRegisterStatusRequest:WeChatRequest
    {
        /// <summary>
        /// 
        ///  查询企业小程序注册进度
        /// </summary>
        /// <param name="componentAccessToken"></param>
        /// <param name="name">企业名</param>
        /// <param name="legalPersonalWechat">法人微信</param>
        /// <param name="legalPersonalName">法人姓名</param>
        public QueryComMpRegisterStatusRequest(string componentAccessToken,string name,string legalPersonalWechat,string legalPersonalName)
        {
            AccessToken=componentAccessToken;
            Name=name;
            LegalPersonalWechat=legalPersonalWechat;
            LegalPersonalName=legalPersonalName;
        }
        string AccessToken = "";
        /// <summary>
        /// 企业名（需与工商部门登记信息一致）
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
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

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/component/fastregisterweapp?action=search&component_access_token={AccessToken}";
        }
    }
}
