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
	public  class ImageMessage : MessageBase
    {
		public ImageMessage()
		{
			this.MsgType = "image";
		}
		public ImageMessage(string toUserName, string fromUserName, string mediaId)
		{
			this.MsgType = "image";
			ToUserName = toUserName;
			FromUserName = fromUserName;
			CreateTime = GetTimeStamp();
			Image = new ImageContent(mediaId);
		}


		public ImageContent Image { get; set; }
	}
	public class ImageContent
	{
		public ImageContent(string mediaId)
		{
			MediaId = mediaId;
		}
		public string MediaId { get; set; } = "";
	}
}
