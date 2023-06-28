/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RsCode.WeChat.MP
{
    public class WxMpClient
    {
        public HttpClient Client { get; }

        string apiUrl = "https://api.weixin.qq.com";
         public WxMpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(apiUrl);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            //httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            Client = httpClient;
        } 

        public async Task<T>GetAsync<T>(string url)
            where T:class
        {
            url = url.Replace(apiUrl, "");
            var response = await Client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                   return await JsonSerializer.DeserializeAsync
                    <T>(responseStream);
            }
               
        }

        public async Task<T> PostAsync<T>(string url,HttpContent httpContent)
            where T : class
        {
            url = url.Replace(apiUrl, "");
            var response = await Client.PostAsync(url,httpContent);

            response.EnsureSuccessStatusCode();

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                return await JsonSerializer.DeserializeAsync
                 <T>(responseStream);
            }

        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent httpContent)            
        {
            url = url.Replace(apiUrl, "");
            var response = await Client.PostAsync(url, httpContent);

            response.EnsureSuccessStatusCode();
            return response;
              
        }
    }
}
