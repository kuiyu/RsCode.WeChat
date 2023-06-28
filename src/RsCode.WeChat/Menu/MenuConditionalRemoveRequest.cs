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

namespace RsCode.WeChat
{
    /// <summary>
    /// 删除个性化菜单
    /// </summary>
    public class MenuConditionalRemoveRequest:WeChatRequest
    {
        /// <summary>
        /// 删除某个个性化菜单
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="menuId"></param>
        public MenuConditionalRemoveRequest(string accessToken,string menuId)
        {
            MenuId = menuId;
            AccessToken = accessToken;
        }
        string AccessToken;
         public string MenuId { get; set; }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/menu/delconditional?access_token={AccessToken}";
        }
    }
}
