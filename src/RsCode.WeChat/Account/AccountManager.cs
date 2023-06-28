/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RsCode.WeChat.Account
{
    public class AccountManager : IAccountManager
    {
        IWeChatClient weChatClient;

        public AccountManager(

            IWeChatClient _weChatClient
            )
        {
            weChatClient = _weChatClient;
        }
        /// <summary>
        /// 获取微信用户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<WeChatUserBaseInfoResponse> GetWxUserInfoAsync(WeChatUserBaseInfoRequest request)
        { 
            return await weChatClient.SendAsync<WeChatUserBaseInfoResponse>(request); 
        }
        public async Task<WeChatUserBaseInfoResponse> GetSnsApiUserInfoAsync(SnsUserInfoRequest request)
        { 
            return await weChatClient.SendAsync<WeChatUserBaseInfoResponse>(request);
        }


        /// <summary>
        /// 创建二维码信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<WxQrCodeResponse> CreateQrCodeAsync(string access_token, WxQrCodeRequest request)
        {
            string strApiUrl = $"https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={access_token}";

            string postData = JsonSerializer.Serialize(request);
            using (StringContent content = new StringContent(postData))
            {
              // var response = await weChatClient.SendAsync<WxQrCodeResponse>(strApiUrl, content);
                //return response;
            }
            return null;
        }
    }
}
