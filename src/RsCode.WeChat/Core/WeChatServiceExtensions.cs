/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using RsCode.WeChat;
using RsCode.WeChat.AccessToken;
using RsCode.WeChat.Account;
using RsCode.WeChat.MP;
using RsCode.WeChat.MP.Analysis;
using RsCode.WeChat.MP.Message;
using RsCode.WeChat.MP.Plugins;
using RsCode.WeChat.MP.QrCode;
using System;
using System.Collections.Generic;

public static class WeChatServiceExtensions
{

    /// <summary>
    /// 微信SDK服务
    /// </summary>
    /// <param name="services"></param>
    /// <param name="action"></param>
    public static void AddWeChat(this IServiceCollection services, Action<List<WeChatOptions>> action)
    {
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        
        var options = new List<WeChatOptions>();
        action(options);
        services.Configure<List<WeChatOptions>>(action);

        
        services.AddMemoryCache();
        services.AddHttpClient<WeChatHttpClient>();
        services.AddScoped<IWeChatClient, WeChatClient>();

        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.TryAddScoped<IWechatTokenManager, TokenManager>();
        services.TryAddScoped<IUrlSignatureManager, RsCode.WeChat.Ticket.UrlSignatureManager>();

        //自定义消息处理
        services.TryAddScoped<IWeChatEventHandler, WeChatEventHandler>();
        //微信消息存储
        services.TryAddScoped<IWechatStore, RsCode.WeChat.Core.WechatStore>();

        #region  帐号管理  
        services.AddScoped<IAccountManager, AccountManager>();

        #endregion

        #region 用户管理

        #endregion

        #region 小程序 

        services.AddScoped(typeof(WxMpClient));
        services.AddScoped<AnalysisManager>();
        services.AddScoped<MpMessageManager>();
        services.AddScoped<PluginManager>();
        services.AddScoped<MpQrCodeManager>();

        #endregion



    }

    public static void AddWeChat(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

        AddWeChat(services, options =>
        {
            configuration.GetSection("Tencent:WeChat").Bind(options);
        });

    
    }
}

