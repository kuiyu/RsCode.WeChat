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

namespace RsCode.WeChat.MP.Analysis
{
    /// <summary>
    /// 留存信息
    /// </summary>
   public class RetainInfo
    {
        [JsonPropertyName("ref_date")]
        public string RefDate { get; set; }

        [JsonPropertyName("visit_uv_new")]
        public KvInfo VisitUvNew { get; set; }
        [JsonPropertyName("visit_uv")]
        public KvInfo VisitUv { get; set; }
    }

    public class KvInfo
    {
        [JsonPropertyName("key")]
        public int Key { get; set; }
        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
}
