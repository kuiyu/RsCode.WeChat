/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RsCode.WeChat.Ticket
{
    public  class UrlSignatureManager:IUrlSignatureManager
    {
        IWechatTokenManager _tokenManager;
        IWechatStore _cache;
        IWeChatClient wechat;
        public UrlSignatureManager(IWeChatClient _wechat,IWechatTokenManager tokenManager, IWechatStore cacheHelper)
        {
            wechat = _wechat;
            _tokenManager = tokenManager;
            _cache = cacheHelper;
        }

        public async Task<string> GetTicketAsync(string appId,string type)
        {
            var cacheKey = $"jsapi_ticket-{appId}";
            var ticket = _cache.Get<string>(cacheKey);
            if (!string.IsNullOrWhiteSpace(ticket))
                return ticket;


            var token = await _tokenManager.GetAccessTokenAsync(appId);
            var ticketInfo = await wechat.SendAsync<TicketResponse>(new TicketRequest(token, "jsapi"));

            if (ticketInfo.Code == 0)
            {
                _cache.Set(cacheKey, ticketInfo.Ticket);
                return ticketInfo.Ticket;
            }
            return "";
        }

        public async Task<UrlSignatureResult> UrlSignature(string appId, string url)
        {
            string ticket = await GetTicketAsync(appId,"jsapi");
            string noncestr = WeChatHelper.GetNonceStr();
            string timestamp = WeChatHelper.GetTimeStamp();
            string str = $"jsapi_ticket={ticket}&noncestr={noncestr}&timestamp={timestamp}&url={url}";

            SHA1 sha1 = SHA1.Create();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] key = sha1.ComputeHash(bytes);
            StringBuilder sub = new StringBuilder();
            foreach (var t in key)
            {
                sub.Append(t.ToString("x2"));//转16进行显示
            }


            UrlSignatureResult result = new UrlSignatureResult
            {
                AppId = appId,
                Timestamp = timestamp,
                nonceStr = noncestr,
                Signature = sub.ToString()
            };
            return result;
        }
    }
}
