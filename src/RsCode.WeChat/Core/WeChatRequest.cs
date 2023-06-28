/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 开源协议：MIT
 */
using System.Net.Http;

namespace RsCode.WeChat
{
    public class WeChatRequest
    {
        public virtual string GetApiUrl()
        {
            throw new System.Exception("未指定API地址");
        }

        public  virtual  string RequestMethod()
        {
            return "POST";
        }

        public virtual MultipartFormDataContent RequestForm()
        {
            return null;
        }
    }
}
