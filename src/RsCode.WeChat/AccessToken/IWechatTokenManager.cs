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
    public interface IWechatTokenManager
    {
         /// <summary>
         /// 获取应用token
         /// </summary>
         /// <param name="appId"></param>
         /// <returns></returns>
         Task<string> GetAccessTokenAsync(string appId);
        /// <summary>
        /// 微信用户授权后获取到的token
        /// </summary>
        /// <param name="code">用户code</param>
        /// <param name="appId"></param>
        /// <returns></returns>
        Task<string> GetAccessTokenAsync( string appId,string code);


        /// <summary>
        /// 获取第三方平台调用凭证 
        /// </summary>
        /// <param name="componentAppId"></param>
        /// <returns></returns>
        Task<string> GetComponentTokenAsync(string componentAppId);
        /// <summary>
        /// 第三方平台获取预授权码
        /// </summary>
        /// <param name="componentAppId"></param>
        /// <param name="componentAccessToken"></param>
        /// <returns></returns>
        Task<string> GetPreAuthCodeAsync(string componentAppId, string componentAccessToken);

        
    }
}