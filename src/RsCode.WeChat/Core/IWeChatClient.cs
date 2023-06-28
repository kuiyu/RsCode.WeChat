/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using RsCode.WeChat.Message;
using System.Net.Http;
using System.Threading.Tasks;

namespace RsCode.WeChat
{
    /// <summary>
    /// 访问微信SDK的终端
    /// </summary>
    public interface IWeChatClient
    {

        /// <summary>
        /// 使用指定客户端
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        WeChatOptions UseAppId(string appId);
        /// <summary>
        /// 发送API请求
        /// </summary>
        /// <typeparam name="T">API响应对象TenpayBaseResponse</typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<T> SendAsync<T>(WeChatRequest request) where T : WeChatResponse;

        Task<HttpResponseMessage> SendAsync(WeChatRequest request);
        Task<string> SendMessageAsync<T>(T t) where T : MessageBase;
    }
}
