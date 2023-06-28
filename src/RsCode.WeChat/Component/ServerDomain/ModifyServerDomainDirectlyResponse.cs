/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using RsCode.WeChat.Message;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 快速配置小程序服务器域名
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/domain-management/modifyServerDomainDirectly.html"/>
    /// </summary>
    public class ModifyServerDomainDirectlyResponse : WeChatResponse
    {

         

        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(85015, "该账号不是小程序账号", "该账号不是小程序账号"));
            ResponseMessages.Add(new WeChatResponseMessage(86100, "invalid url protocol", "该 URL 的协议头有误"));
            ResponseMessages.Add(new WeChatResponseMessage(45082, "need icp license for the url domain", "need icp license for the url domain"));
            ResponseMessages.Add(new WeChatResponseMessage(86101, "不支持配置api.weixin.qq.com", "不支持配置api.weixin.qq.com"));
            ResponseMessages.Add(new WeChatResponseMessage(85016, "exceed valid domain count", "域名数量超限制"));
            ResponseMessages.Add(new WeChatResponseMessage(86102, "每个月只能修改50次，超过域名修改次数限制", "每个月只能修改50次，超过域名修改次数限制"));
            return base.GetResponseMessage();
        }
    }
}
