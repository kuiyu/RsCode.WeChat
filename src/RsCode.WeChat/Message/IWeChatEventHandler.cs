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
    /// <summary>
    /// 收到微信消息的事件处理
    /// </summary>
    public interface IWeChatEventHandler
    {
        #region 普通消息
        /// <summary>
        /// 收到微信推送的图片消息时的处理
        /// </summary>
        /// <param name="receiveMessage"></param>
        /// <returns></returns>
        Task<string> OnReceiveImageMessageEvent(ImageMessage receiveMessage);
        /// <summary>
        /// 收到微信推送的文本消息时时的处理
        /// 用户发的消息
        /// </summary>
        /// <param name="receiveMessage"></param>
        /// <returns>返回</returns>
        Task<string> OnReceiveTextMessageEvent(TextMessage receiveMessage);
        /// <summary>
        /// 收到微信推送的链接时的处理
        /// </summary>
        /// <param name="receiveMessage"></param>
        /// <returns></returns>
        Task<string> OnReceiveLinkMessageEvent(LinkMessage receiveMessage);
        /// <summary>
        /// 收到微信推送的短视频消息
        /// </summary>
        /// <param name="receiveMessage"></param>
        /// <returns></returns>
        Task<string> OnReceiveShortVideoMessageEvent(ShortVideoMessage receiveMessage);
       
        /// <summary>
        /// 收到微信推送的视频消息
        /// </summary>
        /// <param name="receiveMessage"></param>
        /// <returns></returns>
        Task<string> OnReceiveVideoMessageEvent(VideoMessage receiveMessage);
        /// <summary>
        /// 收到微信推送的语音消息
        /// </summary>
        /// <param name="receiveMessage"></param>
        /// <returns></returns>
        Task<string> OnReceiveVoiceMessageEvent(VoiceMessage receiveMessage);
        /// <summary>
        /// 收到微信推送的地理位置消息
        /// </summary>
        /// <param name="receiveMessage"></param>
        /// <returns></returns>
        Task<string> OnReceiveLocationMessageEvent(LocationMessage receiveMessage);
        /// <summary>
        /// 转发微信公众号客服消息
        /// </summary>
        /// <param name="customerServiceMessage"></param>
        /// <returns></returns>
        Task<string> OnTransferCustomerServiceMessageEvent(TransferCustomerServiceMessage customerServiceMessage);
        #endregion
        #region 事件推送
        /// <summary>
        /// 关注公众号时
        /// </summary>
        /// <param name="subscribeEventMessage">收到的信息</param>
        /// <returns></returns>
        Task<string> OnSubscribeEvent(SubscribeEventMessage subscribeEventMessage);

        /// <summary>
        /// 取消订阅时
        /// </summary>
        /// <param name="subscribeEventMessage"></param>
        /// <returns></returns>
        Task<string> OnUnSubscribeEvent(UnSubscribeEventMessage subscribeEventMessage);

        /// <summary>
        /// 用户已关注时的扫描带参数的二维码
        /// </summary>
        /// <param name="scanEventMessage"></param>
        /// <returns></returns>
        Task<string> OnCanEvent(ScanEventMessage scanEventMessage);
        /// <summary>
        /// 上报地理位置事件
        /// </summary>
        /// <param name="locationEventMessage"></param>
        /// <returns></returns>
        Task<string> OnLocationEvent(LocationEventMessage locationEventMessage);
        /// <summary>
        /// 点击菜单拉取消息时的事件推送  
        /// </summary>
        /// <param name="menuClickEvent"></param>
        /// <returns></returns>
        Task<string> OnMenuClickEvent(MenuClickEventMessage menuClickEvent);
        /// <summary>
        /// 点击菜单跳转链接时的事件推送 
        /// </summary>
        /// <param name="menuViewEvent"></param>
        /// <returns></returns>
        Task<string> OnMenuViewEvent(MenuViewEventMessage menuViewEvent);

        /// <summary>
        /// 用户进入客服会话
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> OnUserEnterTempSessionEvent(MessageBase data);

        /// <summary>
        /// 用户自定义事件
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> OnCustomEvent(MessageBase data);

        /// <summary>
        /// 第三方平台收到的ticket
        /// </summary>
        /// <param name="weChatRequestData"></param>
        /// <returns></returns>
        Task<string> OnComponentVerifyTicketEvent(ThirdPlatformMessage data);

        /// <summary>
        /// 注册审核事件推送
        /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/register-management/fast-registration-ent/registerMiniprogram.html"/>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string>OnNotifyThirdFasteregisterEvent(ThirdFasteRegisterNotifyData data);
        #endregion
    }
}
