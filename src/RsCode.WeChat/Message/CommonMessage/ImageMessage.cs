/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace RsCode.WeChat.Message.CommonMessage
{
  public  class ImageMessage : MessageBase
    {
        /// <summary>
        /// 	图片链接（由系统生成）
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 图片消息媒体id，可以调用获取临时素材接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public long MsgId { get; set; }
    }
}
