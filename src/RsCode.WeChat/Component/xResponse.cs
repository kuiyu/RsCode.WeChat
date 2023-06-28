/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using RsCode.WeChat.Message;
using System.Text.Json.Serialization;
namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 
    /// <see cref=""/>
    /// </summary>
    public class xResponse:WeChatResponse
    {

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonPropertyName("")]
        //public int MyProperty { get; set; }

        public override WeChatResponseMessage GetResponseMessage()
        {
            //ResponseMessages.Add(new ResponseMessage(, "", ""));
            return base.GetResponseMessage();
        }
    }
}
