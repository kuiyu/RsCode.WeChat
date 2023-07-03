/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 开源协议：MIT
 */
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RsCode.WeChat.Core;
using RsCode.WeChat.Message;
using RsCode.WeChat.Message.CommonMessage;
using RsCode.WeChat.Message.EventMessage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Tencent;

namespace RsCode.WeChat
{
    /// <summary>
    /// 与微信服务器通信的消息中间件
    /// </summary>
    public class WeChatMiddleware
    {

        ILogger logger;
        WeChatOptions wechat;
        IWeChatEventHandler weChatEventHandler;
        List<WeChatOptions> WeChatOptions;
        IWechatStore wechatStore;

        private readonly RequestDelegate _next;

        public WeChatMiddleware(RequestDelegate next,
            IOptionsSnapshot<List<WeChatOptions>> _wechatOptions,
            ILogger<WeChatMiddleware> _logger,
          IWeChatEventHandler _weChatEventHandler,
          IWechatStore wechatStore
            )
        {
            _next = next;
            logger = _logger;

            if (_wechatOptions.Value == null)
            {
                logger.LogInformation("_wechatOptions is null");
                throw new Exception("not find WeCaht config");
            }
            WeChatOptions = _wechatOptions.Value;
            weChatEventHandler = _weChatEventHandler;
            this.wechatStore = wechatStore;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            WeChatRequestData wxRequestData = new WeChatRequestData();
            wxRequestData.RequestUrl = context.Request.GetDisplayUrl();
            try
            {
                //验证消息的确来自微信服务器 接收微信的GET请求
                //https://developers.weixin.qq.com/doc/offiaccount/Basic_Information/Access_Overview.html

                if (context.Request.Method == "GET")
                {
                    string signature = context.Request.Query["signature"].ToString();
                    string timestamp = context.Request.Query["timestamp"].ToString();
                    string nonce = context.Request.Query["nonce"].ToString();
                    string echostr = context.Request.Query["echostr"].ToString();

                    wxRequestData.RequestType = "GET";
                    wechatStore.SaveData(wxRequestData);

                    await context.Response.WriteAsync(echostr);
                    return;
                }

                if (context.Request.Method == "POST")
                {
                    string signature = context.Request.Query["signature"].ToString();
                    string timestamp = context.Request.Query["timestamp"].ToString();
                    string nonce = context.Request.Query["nonce"].ToString();
                    string msg_signature = context.Request.Query["msg_signature"].ToString();
                    string openid = context.Request.Query["openid"].ToString();
                    string encrypt_type = context.Request.Query["encrypt_type"].ToString();

                    logger.LogDebug($"收到微信消息 url参数信息signature={signature},timestamp={timestamp},nonce={nonce},msg_signature={msg_signature},openid={openid},encrypt_type={encrypt_type}");

                    string sPostData = string.Empty;
                    var reader = new StreamReader(context.Request.Body);
                    sPostData = await reader.ReadToEndAsync();

                    logger.LogDebug($"Receive bodyData={sPostData}");
                    wxRequestData.RequestType = "POST";
                    wxRequestData.RequestContent = sPostData;
                    if (!sPostData.StartsWith("<xml>"))
                    {
                        wxRequestData.DataType = "json";
                    }

                    EncryptMsg encryptMsg = GetEncryptMsg(sPostData);


                    WeChatMessageType messageType = WeChatMessageType.WxUser;
                    string id = encryptMsg.ToUserName;
                    if (string.IsNullOrEmpty(id))
                    {
                        //消息属于第三方平台
                        id = encryptMsg.AppId;
                        messageType = WeChatMessageType.ThirdPlatform;
                    }
                    wechat = WeChatOptions.FirstOrDefault(o => o.Id == id);
                    if (wechat == null)
                    {
                        wxRequestData.DecryptContent = $"未找到原始Id={id}的配置信息";
                        wechatStore.SaveData(wxRequestData);
                        throw new Exception($"未找到原始Id={id}的配置信息");
                    }



                    if (encrypt_type == "aes")
                    {
                        string data = "";
                        WXBizMsgCrypt crypt = new WXBizMsgCrypt(wechat.Token, wechat.EncodingAESKey, wechat.AppId, wechat.DataTransferFormatter);
                        int ret = crypt.DecryptMsg(msg_signature, timestamp, nonce, sPostData, ref data);
                        logger.LogDebug("解密后微信明文消息=" + data);
                        wxRequestData.DecryptContent = data;
                        wechatStore.SaveData(wxRequestData);

                        if (ret == 0)
                        {
                            if (messageType == WeChatMessageType.WxUser)
                            {
                                var msg = new WxUserMessage();
                                msg.LoadData(data, wechat.DataTransferFormatter);
                                //进入会话事件,处理会话消息  
                                string actionName = "";
                                if (msg.MsgType == "event")
                                {
                                    actionName = msg.Event;
                                }
                                else
                                {
                                    actionName = msg.MsgType;
                                }
                                var dic = MessageAction(data, wechat.DataTransferFormatter);
                                if (dic == null)
                                    logger.LogError("dic is null");

                                var action = dic[actionName];
                                if (action == null)
                                    logger.LogError($"action is null actionName={actionName}");
                                if (action == null)
                                {
                                    action = dic["custom"];
                                }
                                var result = await action.Invoke();
                                //被动回复用户消息https://developers.weixin.qq.com/doc/offiaccount/Message_Management/Passive_user_reply_message.html
                                await context.Response.WriteAsync(result);
                            }
                            if (messageType == WeChatMessageType.ThirdPlatform)
                            {
                                var msg = new ThirdPlatformMessage();
                                msg.LoadData(data, wechat.DataTransferFormatter);

                                await weChatEventHandler.OnComponentVerifyTicketEvent(msg);
                                await context.Response.WriteAsync("success");
                            }
                        }
                        else
                        {
                            logger.LogDebug($"ret={ret}POST DATA={sPostData}");
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(ret.ToString());
                        }
                    }
                    else
                    {
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync("");

                    }
                }

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {

                    logger.LogError(ex.InnerException.Message);
                }
                else
                {
                    logger.LogError(ex.Message);

                }

            }

        }




        Dictionary<string, Func<Task<string>>> MessageAction(string data, DataTransferFormatter dataTransferFormatter)
        {
            Dictionary<string, Func<Task<string>>> dic = new Dictionary<string, Func<Task<string>>>();

            dic.Add("SCAN", async () =>
            {
                ScanEventMessage msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<ScanEventMessage>(data);
                }
                else
                {
                    msg = new ScanEventMessage();
                    msg.FromXml(data);
                    msg.SetValues();
                }

                return await weChatEventHandler.OnCanEvent(msg);
            });
            dic.Add("LOCATION", async () =>
            {
                LocationEventMessage msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<LocationEventMessage>(data);
                }
                else
                {
                    msg = new LocationEventMessage();
                    msg.FromXml(data);
                    msg.SetValues();
                }
                return await weChatEventHandler.OnLocationEvent(msg);
            });
            dic.Add("CLICK", async () =>
            {
                MenuClickEventMessage msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<MenuClickEventMessage>(data);
                }
                else
                {
                    msg = new MenuClickEventMessage();
                    msg.FromXml(data);
                    msg.SetValues();
                }
                return await weChatEventHandler.OnMenuClickEvent(msg);
            });
            dic.Add("VIEW", async () =>
            {
                MenuViewEventMessage msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<MenuViewEventMessage>(data);
                }
                else
                {
                    msg = new MenuViewEventMessage();
                    msg.FromXml(data);
                    msg.SetValues();
                }
                return await weChatEventHandler.OnMenuViewEvent(msg);
            });
            dic.Add("subscribe", async () =>
            {
                SubscribeEventMessage msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<SubscribeEventMessage>(data);
                }
                else
                {
                    msg = new SubscribeEventMessage();
                    msg.FromXml(data); msg.SetValues();
                }

                return await weChatEventHandler.OnSubscribeEvent(msg);
            });
            dic.Add("unsubscribe", async () =>
            {
                UnSubscribeEventMessage msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<UnSubscribeEventMessage>(data);
                }
                else
                {
                    msg = new UnSubscribeEventMessage();
                    msg.FromXml(data); msg.SetValues();
                }

                return await weChatEventHandler.OnUnSubscribeEvent(msg);
            });

            dic.Add("image", async () =>
            {
                ImageMessage msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<ImageMessage>(data);
                }
                else
                {
                    msg = new ImageMessage();
                    msg.FromXml(data); msg.SetValues();
                }

                return await weChatEventHandler.OnReceiveImageMessageEvent(msg);
            });
            dic.Add("link", async () =>
            {
                LinkMessage msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<LinkMessage>(data);
                }
                else
                {
                    msg = new LinkMessage();
                    msg.FromXml(data); msg.SetValues();
                }

                return await weChatEventHandler.OnReceiveLinkMessageEvent(msg);
            });
            dic.Add("location", async () =>
            {
                LocationMessage msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<LocationMessage>(data);
                }
                else
                {
                    msg = new LocationMessage();
                    msg.FromXml(data); msg.SetValues();
                }

                return await weChatEventHandler.OnReceiveLocationMessageEvent(msg);
            });
            dic.Add("transfer_customer_service", async () =>
            {
                TransferCustomerServiceMessage msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<TransferCustomerServiceMessage>(data);
                }
                else
                {
                    msg = new TransferCustomerServiceMessage();
                    msg.FromXml(data); msg.SetValues();
                }

                return await weChatEventHandler.OnTransferCustomerServiceMessageEvent(msg);
            });
            dic.Add("showvideo", async () =>
            {
                ShortVideoMessage msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<ShortVideoMessage>(data);
                }
                else
                {
                    msg = new ShortVideoMessage();
                    msg.FromXml(data); msg.SetValues();
                }

                return await weChatEventHandler.OnReceiveShortVideoMessageEvent(msg);
            });
            dic.Add("text", async () =>
            {
                TextMessage msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<TextMessage>(data);
                }
                else
                {
                    msg = new TextMessage();
                    msg.FromXml(data); msg.SetValues();
                }

                return await weChatEventHandler.OnReceiveTextMessageEvent(msg);
            });
            dic.Add("video", async () =>
            {
                VideoMessage msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<VideoMessage>(data);
                }
                else
                {
                    msg = new VideoMessage();
                    msg.FromXml(data); msg.SetValues();
                }

                return await weChatEventHandler.OnReceiveVideoMessageEvent(msg);
            });
            dic.Add("voice", async () =>
            {
                VoiceMessage msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<VoiceMessage>(data);
                }
                else
                {
                    msg = new VoiceMessage();
                    msg.FromXml(data); msg.SetValues();
                }

                return await weChatEventHandler.OnReceiveVoiceMessageEvent(msg);
            });
            dic.Add("custom", async () =>
            {
                MessageBase msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<MessageBase>(data);
                }
                else
                {
                    msg = new MessageBase();
                    msg.FromXml(data); msg.SetValues();
                }

                return await weChatEventHandler.OnCustomEvent(msg);
            });

            //用户进入客服会话
            dic.Add("user_enter_tempsession", async () =>
            {
                MessageBase msg = null;
                if (dataTransferFormatter == DataTransferFormatter.JSON)
                {
                    msg = JsonSerializer.Deserialize<MessageBase>(data);
                }
                else
                {
                    msg = new MessageBase();
                    msg.FromXml(data); msg.SetValues();
                }

                return await weChatEventHandler.OnUserEnterTempSessionEvent(msg);
            });


            return dic;

        }
        /// <summary>
        /// 获取加密信息
        /// </summary>
        /// <param name="sPostData"></param> 
        /// <returns></returns>
        EncryptMsg GetEncryptMsg(string sPostData)
        {

            /* sPostData=
             * <xml>
<ToUserName><![CDATA[gh_e1c613eee4a2]]></ToUserName>
<Encrypt><![CDATA[U4So4DtPJMiKV9Y4k7H8fIvwxZl91CLvFMgGwEMz/5LfF9I5AcLcgTJlovUtCR3id4MR1A7fWeaQMeS6Qw9iEw3hbyXl80111uZ2Ekvo82OCqwpJSRlqWK/4e0jXhrPrM5Eg2lgbJIBMUaxGV3HEKidA916QHvlLOw9MuRDaw2VRZL7ihPGgQAnghXzxvQ/TC1dMEMJ9vPLTo92AMAR3x2xpx0/CL9Ybp00QOc0x8/S6N3r+Y2qn+gyFCSZuAkVX45KxZspb+l8Cc7RfOD0LfCdeU1VAbJ2b7y55vyclU1YPSgKQQtgGV7RpsXimVQOwZ3dYY2vy8r0Fa/5QIugkBMFTd9Yn6Wx+/uyaOytIpHdALmDAOupgkaU/TdJnTw0hSP2gpj+MOKxH+a4JcXJeldkr9HmQ0VmUBdTOEaO0rRg=]]></Encrypt>
</xml>
             */
            EncryptMsg encryptMsg = null;
            if (sPostData.StartsWith("<xml>"))
            {
                XmlDocument doc = new XmlDocument();
                XmlNode root;

                try
                {
                    doc.LoadXml(sPostData);
                    root = doc.FirstChild;

                    encryptMsg = new EncryptMsg();
                    encryptMsg.ToUserName = root["ToUserName"]?.InnerText;
                    encryptMsg.AppId = root["AppId"]?.InnerText;
                    encryptMsg.Encrypt = root["Encrypt"].InnerText;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }
            }
            else
            {
                encryptMsg = JsonSerializer.Deserialize<EncryptMsg>(sPostData);
            }

            return encryptMsg;
        }


    }
}