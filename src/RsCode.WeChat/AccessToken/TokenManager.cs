/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using RsCode.WeChat.Component;
using RsCode.WeChat.Message;
using System.Threading.Tasks;

namespace RsCode.WeChat.AccessToken
{

    public class TokenManager : IWechatTokenManager
    { 
        
        IWeChatClient wechat;
        IWechatStore cache;
        public TokenManager(  
            IWeChatClient _weChatClient,
            IWechatStore _cacheService
            )
        {  
            wechat = _weChatClient;
            cache = _cacheService;
        }

       
        /// <summary>
        /// 获取指定Appid的token
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<string> GetAccessTokenAsync(string appId)
        {
            string cacheKey = $"WechatAppToken_{appId}";
            var token = cache.Get<string>(cacheKey);
            if (!string.IsNullOrWhiteSpace(token))
                return token;

            var option = wechat.UseAppId(appId);
            var tokenInfo = await wechat.SendAsync<AppAccessTokenResponse>(new AppAccessTokenRequest( option.AppId, option.AppSecret));
            if (tokenInfo.Code == 0)
            {
                cache.Set(cacheKey, tokenInfo.AccessToken);
                return tokenInfo.AccessToken;
            }
            return null;
        }

        


        public async Task<string>GetAccessTokenAsync(string appId,string code)
        {
            string cacheKey = $"WechatOAuthToken_{appId}";
            var token = cache.Get<string>(cacheKey);
            if (!string.IsNullOrWhiteSpace(token))
                return token;

            var option = wechat.UseAppId(appId);
            var tokenInfo= await wechat.SendAsync<OAuthTokenResponse>(new OAuthTokenRequest(option.AppId,option.AppSecret,code)) ;
            if (tokenInfo.Code == 0)
            {
                cache.Set(cacheKey, tokenInfo.AccessToken);
                return tokenInfo.AccessToken;
            }
            return null;
        }

        public async Task<string>GetComponentTokenAsync(string componentAppId)
        {
            string cacheKey = $"component-token-{componentAppId}";
            string token = cache.Get<string>(cacheKey);
            if (!string.IsNullOrEmpty(token))
            {
                return token;
            }

            var ticketInfo = await GetTicketAsync(componentAppId);
            if(ticketInfo==null)
            {
                throw new System.Exception("component ticket is null");
            }
             
            var  componentVerifyTicket = ticketInfo.ComponentVerifyTicket;
            var option = wechat.UseAppId(componentAppId); 
            var tokenInfo=await wechat.SendAsync<ComponentAccessTokenResponse>(new ComponentAccessTokenRequest(componentAppId,option.AppSecret, componentVerifyTicket)) ;
            if(tokenInfo.Code == 0)
            {
                cache.Set(cacheKey, tokenInfo.AccessToken);
                return tokenInfo.AccessToken;
            }
            return null;
        }

        async Task<ThirdPlatformMessage> GetTicketAsync(string componentAppId)
        {
            var key = $"component_verify_ticket-{componentAppId}";

            var ticketInfo = cache.Get<ThirdPlatformMessage>(key);
            if (ticketInfo != null)
            {
                var dt = WeChatHelper.ConvertDateTime(ticketInfo.CreateTime);
                if (dt > System.DateTime.Now)
                {
                    return ticketInfo;
                }
            }

            var weChatOption = wechat.UseAppId(componentAppId);
            var res = await wechat.SendAsync<StartPushTicketResponse>(new StartPushTicketRequest(componentAppId, weChatOption.AppSecret));
            if (res.Code != 0)
            {
                throw new System.Exception($"code={res.Code} message={res.Message}");
            }

            ticketInfo = cache.Get<ThirdPlatformMessage>(key);
            return ticketInfo;
        }

        public async Task<string> GetPreAuthCodeAsync(string componentAppId, string accessToken)
        {
            string cacheKey = $"pre_auth_code-{componentAppId}";
            string token = cache.Get<string>(cacheKey);
            if (!string.IsNullOrEmpty(token))
            {
                return token;
            }

            var option = wechat.UseAppId(componentAppId);
            var res = await wechat.SendAsync<PreAuthCodeResponse>(new PreAuthCodeRequest(componentAppId, accessToken));
            if (res.Code == 0)
            {
                cache.Set(cacheKey, res.PreAuthCode,1750);
                return res.PreAuthCode;
            }
            return null;
        }


    }
}
