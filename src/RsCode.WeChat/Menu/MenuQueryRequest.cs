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
    /// 获取默认菜单和全部个性化菜单信息
    /// <see cref="https://developers.weixin.qq.com/doc/offiaccount/Custom_Menus/Getting_Custom_Menu_Configurations.html"/>
    /// </summary>
    public class MenuQueryRequest:WeChatRequest
    {
        string AccessToken;
        /// <summary>
        /// 获取默认菜单和全部个性化菜单信息
        /// </summary>
        /// <param name="accessToken"></param>
        public MenuQueryRequest(string accessToken)
        {
            AccessToken = accessToken;
        }
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/menu/get?access_token={AccessToken}";
        }
        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
