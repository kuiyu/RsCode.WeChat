/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using System.Text.Json.Serialization;

namespace RsCode.WeChat.Message
{
    /// <summary>
    /// 微信业务结果信息
    /// </summary>
    public class WeChatResponseMessage
    {
        public WeChatResponseMessage(int code, string msg, string cnMsg)
        {
            Code = code;
            Msg = msg;
            CnMsg = cnMsg;
        }
        /// <summary>
        /// 错误码
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }
        /// <summary>
        /// 错误码取值
        /// </summary>
        [JsonPropertyName("msg")]
        public string Msg { get; set; }
        /// <summary>
        /// 解决方案
        /// </summary>
        [JsonPropertyName("cnMsg")] public string CnMsg { get; set; }
    }
}
