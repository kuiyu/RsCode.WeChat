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
    /// 删除菜单 
    /// <see cref="https://developers.weixin.qq.com/doc/offiaccount/Custom_Menus/Deleting_Custom-Defined_Menu.html"/>
    /// </summary>
    public class MenuRemoveRequest:WeChatRequest
    {
        string AccessToken;
        /// <summary>
        /// 删除所有菜单（包含个性化菜单）
        /// </summary>
        /// <param name="accessToken"></param>
        public MenuRemoveRequest(string accessToken)
        {
            AccessToken = accessToken;
        }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={AccessToken}";
        }
        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
