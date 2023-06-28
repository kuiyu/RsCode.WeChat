/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.WeChat
{
    /// <summary>
    /// 获取素材列表
    /// <see cref="https://developers.weixin.qq.com/doc/offiaccount/Asset_Management/Get_materials_list.html"/>
    /// </summary>
    public class MaterialBatchGetRequest:WeChatRequest
    {
        string AccessToken;
        /// <summary>
        /// 获取永久素材的列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="type">素材的类型，图片（image）、视频（video）、语音 （voice）、图文（news）</param>
        /// <param name="offset">从全部素材的该偏移位置开始返回，0表示从第一个素材 返回</param>
        /// <param name="count">返回素材的数量，取值在1到20之间</param>
        public MaterialBatchGetRequest(string accessToken,string type,int offset,int count)
        {
            AccessToken = accessToken;
            Type = type;
            Offset = offset;
            Count = count;
        }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/material/batchget_material?access_token={AccessToken}";
        }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("offset")]
        public int Offset { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
