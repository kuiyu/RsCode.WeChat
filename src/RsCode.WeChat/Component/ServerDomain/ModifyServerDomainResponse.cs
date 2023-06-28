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
    /// 配置小程序服务器域名
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/domain-management/modifyServerDomain.html"/>
    /// </summary>
    public class ModifyServerDomainResponse : WeChatResponse
    {

      
        /// <summary>
        /// request 合法域名；当 action 是 get 时不需要此字段
        /// </summary>
        [JsonPropertyName("requestdomain")]
        public string[] RequestDomain { get; set; }
        /// <summary>
        /// socket 合法域名；当 action 是 get 时不需要此字段
        /// </summary>
        [JsonPropertyName("wsrequestdomain")]
        public string[] WsrequestDomain { get; set; }
        /// <summary>
        /// uploadFile 合法域名；当 action 是 get 时不需要此字段
        /// </summary>
        [JsonPropertyName("uploaddomain")]
        public string[] UploadDomain { get; set; }
        /// <summary>
        /// downloadFile 合法域名；当 action 是 get 时不需要此字段
        /// </summary>
        [JsonPropertyName("downloaddomain")]
        public string[] DownloadDomain { get; set; }
        /// <summary>
        /// udp 合法域名；当 action 是 get 时不需要此字段
        /// </summary>
        [JsonPropertyName("udpdomain")]
        public string[] UpdDomain { get; set; }
        /// <summary>
        /// tcp 合法域名；当 action 是 get 时不需要此字段
        /// </summary>
        [JsonPropertyName("tcpdomain")]
        public string[] TcpDomain { get; set; }

        /// <summary>
        /// request 不合法域名
        /// </summary>
        [JsonPropertyName("invalid_requestdomain")]
        public string[] InvalidRequestDomain { get; set; }
        /// <summary>
        /// socket 不合法域名
        /// </summary>
        [JsonPropertyName("invalid_wsrequestdomain")]
        public string[] InvalidWsRequestDomain { get; set; }
        /// <summary>
        /// uploadFile 不合法域名
        /// </summary>
        [JsonPropertyName("invalid_uploaddomain")]
        public string[] InvalidUploadDomain { get; set; }
        /// <summary>
        /// downloadFile 不合法域名
        /// </summary>
        [JsonPropertyName("invalid_downloaddomain")]
        public string[] InvalidDownloadDomain { get; set; }
        /// <summary>
        /// udp 不合法域名
        /// </summary>
        [JsonPropertyName("invalid_udpdomain")]
        public string[] InvalidUpdDomain { get; set; }
        /// <summary>
        /// tcp 不合法域名
        /// </summary>
        [JsonPropertyName("invalid_tcpdomain")]
        public string[] InvalidTcpDomain { get; set; }
        /// <summary>
        /// 没有经过 icp 备案的域名
        /// </summary>
        [JsonPropertyName("no_icp_domain")]
        public string[] NoIcpDomain { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(40001, "invalid credential  access_token isinvalid or not latest", "获取 access_token 时 AppSecret 错误，或者 access_token 无效。请开发者认真比对 AppSecret 的正确性，或查看是否正在为恰当的公众号调用接口"));
            ResponseMessages.Add(new WeChatResponseMessage(40014, "invalid access_token", "不合法的 access_token ，请开发者认真比对 access_token 的有效性（如是否过期），或查看是否正在为恰当的公众号调用接口"));
            ResponseMessages.Add(new WeChatResponseMessage(85015, "该账号不是小程序账号", "该账号不是小程序账号"));
            ResponseMessages.Add(new WeChatResponseMessage(85017, "no domain to modify after filtered please confirm the domain has been set in miniprogram or open", "域名输入为空，或者没有新增域名，请确认小程序已经添加了域名或该域名是否没有在第三方平台添加"));
            ResponseMessages.Add(new WeChatResponseMessage(85018, "域名没有在第三方平台设置", "域名没有在第三方平台设置"));
            ResponseMessages.Add(new WeChatResponseMessage(85301, "no domain to modify after filtered, please confirm the domain has been set in miniprogram or open, and follows the rule of domains；存在 “不符合域名规则的域名”导致无修改。", "no domain to modify after filtered, please confirm the domain has been set in miniprogram or open, and follows the rule of domains；存在 “不符合域名规则的域名”导致无修改。"));
            ResponseMessages.Add(new WeChatResponseMessage(85302, "o domain to modify after filtered, please confirm all domains have ICP licenses；存在 “ 缺少 ICP 备案的域名”导致无修改", "o domain to modify after filtered, please confirm all domains have ICP licenses；存在 “ 缺少 ICP 备案的域名”导致无修改"));
            ResponseMessages.Add(new WeChatResponseMessage(85303, "no domain to modify after filtered, please confirm the domain has been set in miniprogram or open, and follows the rule of domains. Besides, please confirm all domains have ICP licenses", "同时存在“不符合域名规则的域名”以及“ 缺少 ICP 备案的域名”导致无修改"));
            return base.GetResponseMessage();
        }
    }
}
