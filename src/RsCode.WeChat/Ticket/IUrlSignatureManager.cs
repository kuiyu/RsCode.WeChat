/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Threading.Tasks;

namespace RsCode.WeChat
{
    /// <summary>
    /// url签名管理
    /// </summary>
    public interface IUrlSignatureManager
    {
        Task<string> GetTicketAsync(string appId, string type);
        /// <summary>
        /// url签名
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<UrlSignatureResult> UrlSignature(string appId, string url);
    }
}
