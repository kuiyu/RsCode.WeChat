/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 开源协议：MIT
 */
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RsCode.WeChat.Core
{
    public class WechatStore : IWechatStore
    {
        IMemoryCache cache;
        public WechatStore(IMemoryCache _memoryCache)
        {
            cache = _memoryCache;
        }
        public T Get<T>(string key)
        {
            T t = default(T);
            if(cache.TryGetValue(key, out t))
            {
                return t;
            }
            else
                return default(T);
        }
        string cacheKey = "wechat-request-data";
       

        public void SaveData(WeChatRequestData data)
        { 
            var cacheData = Get<List<WeChatRequestData>>(cacheKey);

            if (cacheData == null)
                cacheData = new List<WeChatRequestData>();

            cacheData.Add(data);
            if (cacheData.Count > 20)
            {
                cacheData.RemoveAt(0);
            }

            Set(cacheKey, cacheData, -1);
        }

        public void Set(string key, object obj, int seconds = 7000)
        {
            if (seconds == -1)
            {
                cache.Set(key, obj, DateTime.MaxValue);
            }
            else
            {
                DateTimeOffset dateTimeOffset = DateTime.Now.AddSeconds(seconds);
                cache.Set(key, obj, dateTimeOffset);
            }
        }

        public List<WeChatRequestData> GetData(int page = 1, int pageSize = 20)
        {
            return Get<List<WeChatRequestData>>(cacheKey);
        }

        public Task SaveDataAsync(WeChatRequestData data)
        {
            SaveData(data);
            return Task.CompletedTask;
        }

        public async Task<List<WeChatRequestData>> GetDataAsync(int page = 1, int pageSize = 20)
        {
            List<WeChatRequestData> data=null;
            await Task.Run(() =>
            {
               data= GetData();
            });
            return data;
        }
    }
}
