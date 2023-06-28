﻿/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 数据预拉取和数据周期性更新
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/basic-info-management/getFetchdataSetting.html"/>
    /// </summary>
    public class GetFetchdataSettingRequest : WeChatRequest
    {
        public GetFetchdataSettingRequest(string authorizerAccessToken)
        {
            AuthorizerAccessToken= authorizerAccessToken;
        }
        string AuthorizerAccessToken = "";

        /// <summary>
        /// 可填"get"、“ set_pre_fetch”、"set_period_fetch"
        /// </summary>
        [JsonPropertyName("action")]
        public string Action { get; set; }
        /// <summary>
        /// 数据预拉取是否开启，action=set_pre_fetch时，必填
        /// </summary>
        [JsonPropertyName("is_pre_fetch_open")]
        public bool IsPreFetchOpen { get; set; }
        /// <summary>
        /// 数据来源，0: 开发者服务器；1：云函数。action=set_pre_fetch时，必填
        /// </summary>
        [JsonPropertyName("pre_fetch_type")]
        public int PreFetchType { get; set; }
        /// <summary>
        /// 数据下载地址，当pre_fetch_type=0必填
        /// </summary>
        [JsonPropertyName("pre_fetch_url")]
        public string PreFetchUrl { get; set; }
        /// <summary>
        /// 环境ID，当pre_fetch_type=1必填
        /// </summary>
        [JsonPropertyName("pre_env")]
        public string PreEnv { get; set; }
        /// <summary>
        /// 函数名，当pre_fetch_type=1必填
        /// </summary>
        [JsonPropertyName("pre_function_name")]
        public string PreFunctionName { get; set; }
        /// <summary>
        /// 周期性拉取数据是否开启，true开启，false关闭。action= set_period_fetch时，必填
        /// </summary>
        [JsonPropertyName("is_period_fetch_open")]
        public bool IsPeriodFetchOpen { get; set; }
        /// <summary>
        /// 数据来源，0: 开发者服务器；1：云函数。action= set_period_fetch时，必填
        /// </summary>
        [JsonPropertyName("period_fetch_type")]
        public int PeriodFetchType { get; set; }
        /// <summary>
        /// 数据下载地址，当period_fetch_type=0必填
        /// </summary>
        [JsonPropertyName("period_fetch_url")]
        public string PeriodFetchUrl { get; set; }
        /// <summary>
        /// 环境ID，当period_fetch_type=1必填
        /// </summary>
        [JsonPropertyName("period_env")]
        public string PeriodEnv { get; set; }
        /// <summary>
        /// 函数名，当period_fetch_type=1必填
        /// </summary>
        [JsonPropertyName("period_function_name")]
        public string PeriodFunctionName { get; set; }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/fetchdatasetting?access_token={AuthorizerAccessToken}";
        }
    }
}
