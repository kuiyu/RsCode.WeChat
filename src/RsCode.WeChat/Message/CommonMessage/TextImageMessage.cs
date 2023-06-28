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
  public  class TextImageMessage:MessageBase
    {
        /// <summary>
        /// 图文消息个数，限制为8条以内
        /// </summary>
        public int ArticleCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Article> Articles { get; set; }

        /// <summary>
        /// 图文消息标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }
    }
}
