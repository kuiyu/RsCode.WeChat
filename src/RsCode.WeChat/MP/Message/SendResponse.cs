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

namespace RsCode.WeChat.MP.Message
{
    public class SendResponse
    {
        [JsonPropertyName("errCode")]
        public int ErrCode { get; set; }

        [JsonPropertyName("errMsg")]
        public string ErrMsg { get; set; }
    }
}
