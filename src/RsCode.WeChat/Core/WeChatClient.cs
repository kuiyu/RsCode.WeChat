/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RsCode.WeChat.Message;
using RsCode.WeChat.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace RsCode.WeChat
{
    /// <summary>
    /// 微信公众号客户端
    /// </summary>
    public class WeChatClient:IWeChatClient
    {
        readonly WeChatHttpClient httpClient;

        List<WeChatOptions> WeChatOptions;
        WeChatOptions currentWeChatOptions;
        ILogger log;
        public WeChatClient(
            ILogger<WeChatClient> _logger, 
            WeChatHttpClient _httpClient,
            IOptionsSnapshot<List<WeChatOptions>> _wechatOptions)
        {
            httpClient = _httpClient;
            WeChatOptions = _wechatOptions.Value;
            log = _logger;
        }

        public WeChatOptions UseAppId(string appId)
        {
            currentWeChatOptions = WeChatOptions.FirstOrDefault(o => o.AppId == appId);
            if (currentWeChatOptions == null)
                throw new Exception($"微信应用参数配置有误,未找到AppId={appId}的配置信息");

            var httpHandler = new HttpHandler(currentWeChatOptions);
            httpClient.LoadHandler(httpHandler);
            return currentWeChatOptions;
        }

        public async Task<T> SendAsync<T>(WeChatRequest request) where T : WeChatResponse
        {
            var url = request.GetApiUrl();
            var method = request.RequestMethod().ToUpper();
            if (method == "GET")
            {
                var res = await httpClient.GetAsync<T>(url);
                return res;
            }
            
            if (method == "POST")
            {
                //保持中文不被编码
                var jsonOptions = new JsonSerializerOptions() {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    IgnoreNullValues = true,
                    AllowTrailingCommas = true,
                     PropertyNamingPolicy=JsonNamingPolicy.CamelCase
                };
                string s = JsonSerializer.Serialize(request, request.GetType(), jsonOptions);
                HttpContent httpContent = new StringContent(s, Encoding.UTF8, "application/json");
                var formData = request.RequestForm();
                if (formData != null)
                {
                    using (formData)
                    {
                      var res= await httpClient.PostAsync<T>(url, formData);
                      return res;
                    }
                  
                }
                else
                {
                    var res = await httpClient.PostAsync<T>(url, httpContent);
                    return res;
                } 
            }
            return default(T);
        } 

        public async Task<HttpResponseMessage> SendAsync(WeChatRequest request)
        {
            var url = request.GetApiUrl();
            var method = request.RequestMethod().ToUpper();
            if (method == "GET")
            {
                var res = await httpClient.GetAsync(url);
                return res;
            }
            else
            {
				string s = JsonSerializer.Serialize(request, request.GetType(), new JsonSerializerOptions { Encoder = JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All) });
				HttpContent httpContent = new StringContent(s, Encoding.UTF8, "application/json");

                var res = await httpClient.PostAsync(url, httpContent);
                return res;
            }
            
        }

        public async Task<string> SendMessageAsync<T>(T t) where T : MessageBase
        {
            try
            {
                //加密后密文
                string sMsg = "";
                int code = -1;
                await Task.Run(() =>
                {
                    //消息加密后返回
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    string str = xmlSerializer.Serializer<T>(t);

                    //xml密文
                    Tencent.WXBizMsgCrypt wxcpt = new Tencent.WXBizMsgCrypt(currentWeChatOptions.Token, currentWeChatOptions.EncodingAESKey, currentWeChatOptions.AppId, currentWeChatOptions.DataTransferFormatter);
                    code = wxcpt.EncryptMsg(str,WeChatHelper.GetTimeStamp(), WeChatHelper.GetNonceStr(), ref sMsg);
                    //log.LogInformation($"code={code}");
                    //log.LogInformation($"msg={sMsg}");
                });


                if (code == 0)
                {
                    return sMsg;
                }
                else
                {
                    // logger.LogError("send msg to wechat err=" + code);
                    return "";
                }
            }
            catch (System.Exception ex)
            {
               
                log.LogError("send msg to wechat err=" + ex.Message);
                return "";
            }
        }

    
    }
}
