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
    /// <summary>
    /// 帐号管理
    /// </summary>
    public interface IWechatAccountManager
    {

          AccessTokenContainer AccessToken { get; }
         

        Task<WxQrCodeResponse> CreateQrCodeAsync(string access_token, WxQrCodeRequest request);

    }



     
}
