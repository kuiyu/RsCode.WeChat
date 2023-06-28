/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RsCode.WeChat
{
    public  class WeChatHttpClient
    {
        public HttpClient Client { get; private set; }

        public WeChatHttpClient(HttpClient client)
        {
            Client = client;
        }
        static object locker = new object();
        public void LoadHandler(HttpHandler httpHandler)
        {
            Client = new HttpClient(httpHandler);
            Client.BaseAddress = new Uri("https://api.mch.weixin.qq.com");
        }





        public async Task<T> GetAsync<T>(string url)
            where T : WeChatResponse
        {
            using (var response = await Client.GetAsync(url))
            {
                int statusCode = Convert.ToInt32(response.StatusCode);
                if (statusCode == 200)
                {
                    //string s = await response.Content.ReadAsStringAsync(); 
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        return await JsonSerializer.DeserializeAsync<T>(responseStream);
                    }
                }
                else
                {
                    var s = await response.Content.ReadAsStringAsync();
                    var t = JsonSerializer.Deserialize<T>(s); 
                    return t;
                }

            }

        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {

            var response = await Client.GetAsync(url);
            return response;
        }



        public async Task<T> PostAsync<T>(string url, HttpContent httpContent)
            where T : WeChatResponse
        {
            
            using (httpContent)
            using (var response = await Client.PostAsync(url, httpContent))
            {
                int statusCode = Convert.ToInt32(response.StatusCode);
                if (statusCode == 200)
                {
                    string json =await response.Content.ReadAsStringAsync();
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        return await JsonSerializer.DeserializeAsync
                         <T>(responseStream);
                    }
                }
                else
                {
                    
                    var s = await response.Content.ReadAsStringAsync();
                    var t = JsonSerializer.Deserialize<T>(s); 
                    return t;
                }

            }

        }


        public async Task<HttpResponseMessage>PostAsync(string url,HttpContent httpContent)
        {
            using (httpContent)
              return await Client.PostAsync(url, httpContent);  
        }

    }
}
