﻿/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 快速配置小程序服务器域名
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/domain-management/modifyServerDomainDirectly.html"/>
    /// </summary>
    public class ModifyServerDomainDirectlyRequest : WeChatRequest
    {
        public ModifyServerDomainDirectlyRequest(string authorizerAccessToken, string action, string[] requestDomain, string[] wsrequestDomain, string[] uploadDomain, string[] downloadDomain, string[] updDomain, string[] tcpDomain)
        {
            AuthorizerAccessToken= authorizerAccessToken;
            Action = action;
            RequestDomain = requestDomain;
            WsrequestDomain = wsrequestDomain;
            UploadDomain = uploadDomain;
            DownloadDomain = downloadDomain;
            UpdDomain = updDomain;
            TcpDomain = tcpDomain;
        }
        string AuthorizerAccessToken = "";

        /// <summary>
        /// 操作类型
        /// </summary>
        [JsonPropertyName("action")]
        public string Action { get; set; }
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
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/modify_domain_directly?access_token={AuthorizerAccessToken}";
        }
    }
}
