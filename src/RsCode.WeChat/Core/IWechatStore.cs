/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using RsCode.WeChat.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RsCode.WeChat
{
    /// <summary>
    /// 微信业务存储
    /// </summary>
    public interface IWechatStore 
    {
         
        /// <summary>
        /// 缓存数据
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="obj">要缓存的数据</param>
        /// <param name="seconds">默认缓存时长7000秒</param>
        void Set(string key, object obj, int seconds = 7000); 
        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        T Get<T>(string key);
 
        /// <summary>
        /// 保存微信发送的数据
        /// </summary>
        /// <param name="data"></param>
        void SaveData(WeChatRequestData data);
        /// <summary>
        /// 获取微信发送的数据
        /// </summary>
        /// <returns></returns>
        List<WeChatRequestData> GetData(int page=1,int pageSize=20);

        Task SaveDataAsync(WeChatRequestData data);

        Task<List<WeChatRequestData>> GetDataAsync(int page=1,int pageSize=20);
    }
}
