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
    /// 上传代码并生成体验版
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/commit.html"/>
    /// </summary>
    public class CodeCommitRequest:WeChatRequest
    {
        /// <summary>
        /// 上传代码并生成体验版
        /// </summary>
        /// <param name="authorizerAccessToken"></param>
        /// <param name="templateId">代码库中的代码模板 ID</param>
        /// <param name="extJson">ext.json 配置文件的内容</param>
        /// <param name="codeVersion">代码版本号，开发者可自定义（长度不要超过 64 个字符）</param>
        /// <param name="codeDesc">代码描述，开发者可自定义</param>
        public CodeCommitRequest(string authorizerAccessToken,int templateId,string extJson,string codeVersion,string codeDesc)
        {
           AuthorizerAccessToken= authorizerAccessToken;
            TemplateId = templateId;
            ExtJson = extJson;
            UserDesc = codeDesc;
            UserVersion = codeVersion;
        }
        string AuthorizerAccessToken = "";

        [JsonPropertyName("template_id")]
        public int TemplateId { get; set; }
        [JsonPropertyName("ext_json")]
        public string ExtJson { get; set; }
        [JsonPropertyName("user_version")]
        public string UserVersion { get; set; }
        [JsonPropertyName("user_desc")]
        public string UserDesc { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/commit?access_token={AuthorizerAccessToken}";
        }
    }
}
