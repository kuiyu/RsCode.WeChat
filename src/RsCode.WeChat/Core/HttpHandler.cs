/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 开源协议：MIT
 */
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.WeChat
{
    public class HttpHandler: DelegatingHandler
    {
        WeChatOptions wechatOption;
        public HttpHandler(WeChatOptions _options)
        { 
            wechatOption = _options;
            HttpClientHandler handler = new HttpClientHandler(); 
            InnerHandler = handler; 
        }

        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        { 
            request.Headers.Add("Accept", "application/json");
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue("Unknown"))); 
            return await base.SendAsync(request, cancellationToken);
        }

         

    }
}
