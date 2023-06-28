/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */


using RsCode.WeChat.Message;
using RsCode.WeChat.Message.CommonMessage;
using RsCode.WeChat.Message.EventMessage;
using System.Threading.Tasks;

namespace RsCode.WeChat
{
    public class WeChatEventHandler : IWeChatEventHandler
    {
        public  virtual Task<string> OnCanEvent(ScanEventMessage scanEventMessage)
        {
            return Task.FromResult("success");
        }

        public virtual Task<string> OnLocationEvent(LocationEventMessage locationEventMessage)
        {
            return Task.FromResult("success");
        }

        public virtual Task<string> OnMenuClickEvent(MenuClickEventMessage menuClickEventt)
        { 
            return Task.FromResult("success");
        }

        public virtual Task<string> OnMenuViewEvent(MenuViewEventMessage menuViewEvent)
        {
            return Task.FromResult("success");
        }

        public virtual Task<string> OnReceiveImageMessageEvent(ImageMessage receiveMessage)
        {
            return Task.FromResult("success");
        }

        public virtual Task<string> OnReceiveLinkMessageEvent(LinkMessage receiveMessage)
        {
            return Task.FromResult("success");
        }

        public virtual Task<string> OnReceiveLocationMessageEvent(LocationMessage receiveMessage)
        {
            return Task.FromResult("success");
        }
        public virtual Task<string> OnTransferCustomerServiceMessageEvent(TransferCustomerServiceMessage customerServiceMessage)
        {
            return Task.FromResult("");
        }
        public virtual Task<string> OnReceiveShortVideoMessageEvent(ShortVideoMessage receiveMessage)
        {
            return Task.FromResult("success");
        }

        public virtual Task<string> OnReceiveTextMessageEvent(TextMessage receiveMessage)
        {
            return Task.FromResult("success");
        }

        public virtual Task<string> OnReceiveVideoMessageEvent(VideoMessage receiveMessage)
        {
            return Task.FromResult("success");
        }

        public virtual Task<string> OnReceiveVoiceMessageEvent(VoiceMessage receiveMessage)
        {
            return Task.FromResult("success");
        }

        public virtual Task<string> OnSubscribeEvent(SubscribeEventMessage subscribeEventMessage)
        {
            return Task.FromResult("success");
        }

        public virtual Task<string> OnUnSubscribeEvent(UnSubscribeEventMessage subscribeEventMessage)
        {
            return Task.FromResult("success");
        }


        public virtual Task<string> OnUserEnterTempSessionEvent(MessageBase data)
        {
            return Task.FromResult("success");
        }

        public virtual Task<string> OnCustomEvent(MessageBase data)
        {
            return Task.FromResult("success");
        }

        public virtual Task<string> OnComponentVerifyTicketEvent(ThirdPlatformMessage data)
        {
            return Task.FromResult("success");
        }

        public virtual Task<string>OnNotifyThirdFasteregisterEvent(ThirdFasteRegisterNotifyData data)
         {
            return Task.FromResult("success");
        }
    }
}
