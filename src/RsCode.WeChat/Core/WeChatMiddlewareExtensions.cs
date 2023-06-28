/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 开源协议：MIT
 */
using Microsoft.AspNetCore.Builder;
using RsCode.WeChat;

public static class WeChatMiddlewareExtensions
{

    public static void UseWeChat(this IApplicationBuilder app)
    {
        //与微信通信的服务器Url 为 https://xx/wxcallback
        app.UseWhen(context =>
        {
            return context.Request.Path.Value.StartsWith("/wxcallback");
        },
         b => b.UseMiddleware<WeChatMiddleware>());
      
    }

}



