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
using static System.Net.WebRequestMethods;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 获取业务域名校验文件
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/domain-management/getJumpDomainConfirmFile.html"/>
    /// </summary>
    public class GetJumpDomainConfirmFileResponse : WeChatResponse
    {

        /// <summary>
        /// 文件名
        /// </summary>
        [JsonPropertyName("file_name")]
        public string FileName { get; set; }
        /// <summary>
        /// 文件内容
        /// </summary>
        [JsonPropertyName("file_content")]
        public string FileContent { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(44002, "empty post data", "POST 的数据包为空。post请求 body 参数不能为空"));
            return base.GetResponseMessage();
        }
    }
}
