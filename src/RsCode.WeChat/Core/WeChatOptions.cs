/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat
 * 开源协议：MIT
 */
using RsCode.WeChat.Util;
using System;
using System.IO;

namespace RsCode.WeChat
{
    public class WeChatOptions
    {
        
        public string AppId { get; set; }
      
        public string AppSecret { get; set; }

       
        public string Token { get; set; }

        public string RedirectUrl { get; set; }

        /// <summary>
        /// 消息加密密钥
        /// </summary>
      
        public string EncodingAESKey { get; set; }

        /// <summary>
        /// 数据格式
        /// </summary>
        public string DataFormatter { get; set; } = "xml";
        /// <summary>
        /// 原始Id
        /// </summary>
        public string Id { get; set; }

        public DataTransferFormatter DataTransferFormatter { 
            get
            { 
                if(DataFormatter.Trim().ToLower()=="json")
                {
                    return DataTransferFormatter.JSON;
                }else
                {
                    return DataTransferFormatter.XML; 
                }
            }
        }


        //保存信息到appsetting.json
        public void Save()
        { 
            WeChatOptions wechat;
            var path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            JsonHelper.Save<WeChatOptions>(path, this);
             
        }

        

    }
}
