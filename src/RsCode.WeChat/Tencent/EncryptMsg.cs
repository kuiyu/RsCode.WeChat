/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using System.Text.Json.Serialization;

namespace Tencent
{
    /// <summary>
    /// 收到的消息体（加密）
    /// </summary>
    public class EncryptMsg
    {
        [JsonPropertyName("ToUserName")]
        public string ToUserName { get; set; }
        [JsonPropertyName("Encrypt")]
        public string Encrypt { get; set; }

        #region 第三方平台参数
        [JsonPropertyName("AppId")]
        public string AppId { get; set; }
       
        #endregion


    }
}
