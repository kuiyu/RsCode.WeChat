/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
namespace RsCode.WeChat.Message.CommonMessage
{
    /// <summary>
    /// 转发消息到客服
    /// <see cref="https://developers.weixin.qq.com/doc/offiaccount/Customer_Service/Forwarding_of_messages_to_service_center.html"/>
    /// </summary>
    public class TransferCustomerServiceMessage:MessageBase
    {
        public TransferCustomerServiceMessage()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toUserName">接收方帐号（收到的OpenID）</param>
        /// <param name="fromUserName">开发者微信号</param>
        public TransferCustomerServiceMessage(
           string toUserName,
           string fromUserName
          )
        {
            ToUserName = toUserName;
            FromUserName = fromUserName;
            CreateTime = GetTimeStamp();
            MsgType = "transfer_customer_service"; 
        }
         
    }
}
