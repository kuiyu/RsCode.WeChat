---
home: false
editLink: false  #是否在底部显示编辑页面
lang: zh-CN
title: 微信平台SDK
description: 微信平台SDK简介
---

## 前言

`RsCode.WeChat` 是河南软商网络科技有限公司开发的微信平台SDK，使用.net技术封装微信业务API,实现快速开发微信平台相关业务  

###  源码托管


- [Gitee](https://gitee.com/kuiyu/RsCode.WeChat/)

- [GitHub](https://github.com/kuiyu/RsCode.WeChat/)

  

### 支持环境

- .NET Core 3.1以上

###  当前版本

- 正式发布: [![RsCode.WeChat](https://img.shields.io/nuget/v/RsCode.WeChat.svg?color=red&style=flat-square)](https://www.nuget.org/packages/RsCode.WeChat/)

## 使用步骤

只需三步，完成使用`RsCode.WeChat`调用微信业务

1. appsettings.json中配置申请的微信参数

```json
"Tencent": {
    "WeChat": [
      {
        "Id": "gh_e1cxxx",
        "AppId": "wxxxxxx",
        "AppSecret": "xxx",
        "Token": "xxx",
        "EncodingAESKey": "xxx",
        "DataFormatter": "xml" //与微信通信消息格式
      }
    ]
  }
```
2. 使用NuGet 引用`RsCode.WeChat`

添加代码

```csharp
//添加微信服务 
services.AddWeChat();

//添加微信服务中间件
app.UseWeChat();
```


3. 打开微信平台，配置与微信通信相关的url为 指定的地址

`http://{your domain}/wxcallback`  

例如：

登录微信公众号后台--设置与开发--基本配置--服务器配置,设置，服务器地址(URL) 为  `https://xxx/wxcallback`

登录微信小程序--开发--开发管理--消息推送，

第三方平台-开发配置--开发资料 设置 授权事件接收配置 `https://xx.cn/wxcallback/component`  , 消息与事件接收配置`https://xx.cn/wxcallback/biz/$APPID$`



#### 调用微信SDK实例

```csharp
public class HomeController:ControllerBase
{
    IWeChatClient wechat;
    public HomeController(IWeChatClient _wechat)
    {
        wechat=_wechat;
    }
    
    public async Task<string> Test()
    {
        string appId="wx1323123412";
        string token="abc";
        var res=await wechat.SendAsync<JsapiTicketResponse>(new JsapiTicketRequest(accessToken));
    }
}
```

