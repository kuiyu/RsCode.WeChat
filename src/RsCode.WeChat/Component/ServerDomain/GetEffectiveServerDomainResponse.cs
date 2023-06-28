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
    /// 获取发布后生效服务器域名列表
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/domain-management/getEffectiveServerDomain.html"/>
    /// </summary>
    public class GetEffectiveServerDomainResponse : WeChatResponse
    {

        /// <summary>
        /// 通过公众平台配置的服务器域名列表
        /// </summary>
        [JsonPropertyName("mp_domain")]
        public MpDomain MpDomain { get; set; }
        /// <summary>
        /// 通过第三方平台接口modify_domain 配置的服务器域名
        /// </summary>
        [JsonPropertyName("third_domain")]
        public ThirdDomain ThirdDomain { get; set; }
        /// <summary>
        /// 通过“modify_domain_directly”接口配置的服务器域名列表
        /// </summary>
        [JsonPropertyName("direct_domain")]
        public DirectDomain DirectDomain { get; set; }
        /// <summary>
        /// 最后提交代码或者发布上线后生效的域名列表
        /// </summary>
        [JsonPropertyName("effective_domain")]
        public EffectiveDomain EffectiveDomain { get; set; }
        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(44002, "empty post data", "POST 的数据包为空。post请求 body 参数不能为空"));
            return base.GetResponseMessage();
        }
    }

    public class MpDomain
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
    }
    public class ThirdDomain
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
    }
    public class DirectDomain
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
    }
    public class EffectiveDomain
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
    }
}
