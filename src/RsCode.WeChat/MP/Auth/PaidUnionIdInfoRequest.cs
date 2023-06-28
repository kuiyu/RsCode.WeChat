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

namespace RsCode.WeChat.MP.Auth
{
    public class PaidUnionIdInfoRequest:WeChatRequest
    {
        public string AccessToken { get; set; }

        public string OpenId { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/getpaidunionid?access_token={AccessToken}&openid={OpenId}";
        }

        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
