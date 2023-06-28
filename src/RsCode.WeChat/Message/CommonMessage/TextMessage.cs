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
    public class TextMessage:MessageBase
    {

        public TextMessage()
        {
            this.MsgType = "text";
        }
        public TextMessage(
             string toUserName,
             string fromUserName,
              string content 
            )
        {
            ToUserName = toUserName;
            FromUserName = fromUserName;
            CreateTime = GetTimeStamp();
            MsgType = "text";
            Content = content;
        }
        /// <summary>
        /// 回复的消息内容（换行：在content中能够换行，微信客户端就支持换行显示）
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public long MsgId { get; set; }

        
    }
}
