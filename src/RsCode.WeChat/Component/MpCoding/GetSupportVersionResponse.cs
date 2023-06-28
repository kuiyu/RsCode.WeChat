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
    /// 查询各版本用户占比
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/getSupportVersion.html"/>
    /// </summary>
    public class GetSupportVersionResponse : WeChatResponse
    {
        /// <summary>
        /// 当前版本
        /// </summary>
        [JsonPropertyName("now_version")]
        public string NowVersion { get; set; }
        /// <summary>
        /// 版本的用户占比列表
        /// </summary>
        [JsonPropertyName("uv_info")]
        public UVInfo UvInfo { get; set; }
        public override WeChatResponseMessage GetResponseMessage()
        {
            return base.GetResponseMessage();
        }

         
    }


    public class UVInfo
    {
        [JsonPropertyName("items")]
        public UvItem[] UvItems { get; set; }
    }
    public class UvItem
    {
        /// <summary>
        /// 基础库版本号
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }
        /// <summary>
        /// 该版本用户占比
        /// </summary>
        [JsonPropertyName("percentage")]
        public int Percentage { get; set; }
    }
}
