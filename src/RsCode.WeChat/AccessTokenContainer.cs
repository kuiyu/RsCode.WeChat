using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RsCode.WeChat
{



    /* 作废
     * 建议公众号开发者使用中控服务器统一获取和刷新access_token，其他业务逻辑服务器所使用的access_token均来自于该中控服务器，
     * 不应该各自去刷新，否则容易造成冲突，导致access_token覆盖而影响业务；
     */
    public class AccessTokenContainer
    {
        IMemoryCache cache;
        HttpClient httpClient;
        WeChatOptions wechat;
         public AccessTokenContainer(HttpClient _httpClient,IMemoryCache _cache,IOptionsSnapshot<WeChatOptions> optionsSnapshot)
        {
            httpClient = _httpClient;
            cache = _cache;
            wechat = optionsSnapshot.Value;
        }

        /// <summary>
        /// 获取当前公众号accesstoken
        /// </summary>
        /// <returns></returns>
        public async Task<string>GetAccessTokenAsync()
        {
            string appId = wechat.AppId;
            return  await GetAccessTokenAsync(appId);
        }
        /// <summary>
        /// 获取指定Appid的token
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<string> GetAccessTokenAsync(string appId)
        {
            string cacheKey = $"accesstoken_{appId}";
            var info= cache.Get<WechatTokenInfo>(cacheKey);
            if(info==null)
            {
                //获取appid的appsecret
                //获取accesstoken
                string appSecret = wechat.AppSecret;
                var ret= await GetAccessTokenAsync("client_credential", appId, appSecret);
                try
                {
                    info = JsonSerializer.Deserialize<WechatTokenInfo>(ret);
                }
                catch (Exception)
                {
                    var err = JsonSerializer.Deserialize<ErrorInfo>(ret);
                    throw new Exception($"ErrCode:{err.ErrCode},{err.ErrMsg}");
                }
              
                cache.Set<WechatTokenInfo>(cacheKey, info, DateTimeOffset.Now.AddSeconds(info.ExpiresIn - 600));
            }
            return info.AccessToken;
        }

        /// <summary>
        /// <![CDATA[GET 获取访问令牌]]>
        /// </summary>
        /// <param name="grant_type"><![CDATA[grant_type默认client_credential]]></param>
        /// <param name="appid"><![CDATA[appid]]></param>
        /// <param name="secret"><![CDATA[秘钥]]></param>
        /// <see cref="https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140183"/>
        /// <returns><![CDATA[正常情况下：{"access_token":"ACCESS_TOKEN","expires_in":7200}；错误情况下：{"errcode":40013,"errmsg":"invalid appid"}]]></returns>
        public async Task<string> GetAccessTokenAsync(string grant_type, string appid, string secret)
        {
            string strApiUrl = $"https://api.weixin.qq.com/cgi-bin/token?grant_type={grant_type}&appid={appid}&secret={secret}";
            {
                string strResponseText = await httpClient.GetStringAsync(requestUri: strApiUrl);
                return strResponseText;
            }
        }

        ///// <summary>
        /////<![CDATA[上传临时素材]]>
        ///// </summary>
        /////<see cref="https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1444738726"/>
        /////<param name="access_token"><![CDATA[访问凭证]]></param>
        /////<param name="filename"><![CDATA[文件名称]]></param>
        /////<param name="type"><![CDATA[媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb）]]></param>
        /////<remarks><![CDATA[http请求方式：POST/FORM，使用https https://api.weixin.qq.com/cgi-bin/media/upload?access_token=ACCESS_TOKEN&type=TYPE]]></remarks>
        /////<returns><![CDATA[正常情况：{"type":"TYPE","media_id":"MEDIA_ID","created_at":123456789};错误：{"errcode":40004,"errmsg":"invalid media type"}]]></returns>
        //public async Task<string> UploadAsync(string access_token, string filename, string type, Stream stream)
        //{
        //    string strApiUrl = string.Format("http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}", access_token, type);
        //    return await Task.Run(() => Common.Util.HttpRequestPost(strApiUrl, type, filename, stream));
        //}

        /// <summary>
        /// <![CDATA[获取素材]]>
        /// </summary>
        /// <param name="access_token"><![CDATA[访问令牌]]></param>
        /// <param name="media_id"><![CDATA[素材ID]]></param>
        /// <see cref="https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1444738727"/>
        /// <returns></returns>
        public async Task<Stream> GetMedia(string access_token, string media_id)
        {
            string strApiUrl = string.Format("https://api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", access_token, media_id);
            {
                return await httpClient.GetStreamAsync(strApiUrl);
            }
        }

        /// <summary>
        /// <![CDATA[GET 获取用户基本信息]]>
        /// </summary>
        /// <param name="access_token"><![CDATA[访问令牌]]></param>
        /// <param name="openid"><![CDATA[openid]]></param>
        /// <param name="lang"><![CDATA[语言 默认：zh_cn]]></param>
        /// <see cref="https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140839"/>
        /// <returns><![CDATA[{
        ///"subscribe": 1, 
        /// "openid": "o6_bmjrPTlm6_2sgVt7hMZOPfL2M", 
        /// "nickname": "Band", 
        ///"sex": 1, 
        ///"language": "zh_CN", 
        /// "city": "广州", 
        ///"province": "广东", 
        ///"country": "中国", 
        ///"headimgurl":"http://thirdwx.qlogo.cn/mmopen/g3MonUZtNHkdmzicIlibx6iaFqAc56vxLSUfpb6n5WKSYVY0ChQKkiaJSgQ1dZuTOgvLLrhJbERQQ4eMsv84eavHiaiceqxibJxCfHe/0",
        ///"subscribe_time": 1382694957,
        ///"unionid": " o6_bmasdasdsad6_2sgVt7hMZOPfL"
        ///"remark": "",
        ///"groupid": 0,
        ///"tagid_list":[128,2],
        ///"subscribe_scene": "ADD_SCENE_QR_CODE",
        ///"qr_scene": 98765,
        ///"qr_scene_str": ""}]]></returns>
        public async Task<string> GetUserInfoAsync(string access_token, string openid, string lang = "zh_CN")
        {
            string strApiUrl = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN", access_token, openid);
            {
                string strResponseText = await httpClient.GetStringAsync(strApiUrl);
                return strResponseText;
            }
        }

        /// <summary>
        /// <![CDATA[下载头像]]>
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public async Task<Stream> DownHeadImage(string requestUri)
        {
            using (HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri))
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Safari/537.36");
                var response = await httpClient.SendAsync(requestMessage);
                var stream = await response.Content.ReadAsStreamAsync();
                return stream;
            }
        }


        /// <summary>
        /// <![CDATA[获取素材列表]]>
        /// </summary>
        /// <param name="access_token"><![CDATA[访问令牌]]></param>
        /// <param name="type"><![CDATA[素材的类型，图片（image）、视频（video）、语音 （voice）、图文（news）]]></param>
        /// <param name="offset"><![CDATA[	从全部素材的该偏移位置开始返回，0表示从第一个素材 返回]]></param>
        /// <param name="count"><![CDATA[返回素材的数量，取值在1到20之间]]></param>
        /// <see cref="https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1444738734"/>
        /// <returns></returns>
        public async Task<string> GetMaterialList(string access_token, string type, int offset, int count)
        {
            string strApiUrl = string.Format("https://api.weixin.qq.com/cgi-bin/material/batchget_material?access_token={0}", access_token);
            {
                string strContentData = "{\"type\":\"" + type + "\",\"offset\":" + offset + ",\"count\":" + count + "}";
                using (StringContent content = new StringContent(strContentData))
                {
                    var response = await httpClient.PostAsync(strApiUrl, content);
                    string strResponseText = await response.Content.ReadAsStringAsync();
                    return strResponseText;
                }
            }
        }


        /// <summary>
        /// <![CDATA[POST JOSN数据]]>
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<string> PostJsonAsync(string requestUri, object data)
        {
            string strJsonData = null;
            if (data is string)
            {
                strJsonData = Convert.ToString(data);
            }
            else
            {
                strJsonData =System.Text.Json.JsonSerializer.Serialize(data);
            }
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(strJsonData);
            using (ByteArrayContent byteArray = new ByteArrayContent(buffer))
            {
                httpClient.DefaultRequestHeaders.Add("content-type", "application/json");
                var response = await httpClient.PostAsync(requestUri: requestUri, content: byteArray);
                string strResponseText = await response.Content.ReadAsStringAsync();
                return strResponseText;
            }
        }


        /// <summary>
        /// <![CDATA[GET请求]]>
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public async Task<string> GetAsync(string requestUri)
        {
            return await httpClient.GetStringAsync(requestUri: requestUri);
        }
    }

    public class WechatTokenInfo
    {
    
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonPropertyName("openid")]
        public string OpenId { get; set; }
        [JsonPropertyName("scope")]
        public string Scope { get; set; }
        [JsonPropertyName("unionid")]
        public string UnionId { get; set; }
    }

    internal class ErrorInfo
    { 
        
        [JsonPropertyName("errcode")]
        public int ErrCode { get; set; }
        [JsonPropertyName("errmsg")]
        public string ErrMsg { get; set; }
    }
}
