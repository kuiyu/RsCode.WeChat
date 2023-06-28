/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Threading.Tasks;

namespace RsCode.WeChat.Account
{
    public interface IAccountManager
    {
        /// <summary>
        /// 创建二维码信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WxQrCodeResponse> CreateQrCodeAsync(string access_token, WxQrCodeRequest request);
        /// <summary>
        /// 获取微信用户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WeChatUserBaseInfoResponse> GetWxUserInfoAsync(WeChatUserBaseInfoRequest request);

        /// <summary>
        /// 获取开放平台微信用户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WeChatUserBaseInfoResponse> GetSnsApiUserInfoAsync(SnsUserInfoRequest request);
    }
}