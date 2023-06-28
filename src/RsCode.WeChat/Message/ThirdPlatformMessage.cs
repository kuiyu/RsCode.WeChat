/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using RsCode.WeChat.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace RsCode.WeChat.Message
{
    /// <summary>
    /// 微信推送的有关第三方平台的消息
    /// </summary>
    public  class ThirdPlatformMessage:WeChatMessage
    {
        /// <summary>
        /// 第三方平台 appid
        /// </summary>
        public string AppId { get; set; } = "";
        /// <summary>
        /// 时间戳，单位：s
        /// </summary>
        public long CreateTime { get; set; }
        /// <summary>
        /// 固定为："component_verify_ticket"
        /// </summary>
        public string InfoType { get; set; } = "";
        /// <summary>
        /// Ticket 内容
        /// </summary>
        public string ComponentVerifyTicket { get; set; } = "";



        protected SortedDictionary<string, object> m_values = new SortedDictionary<string, object>();
        public SortedDictionary<string, object> FromXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                //Log.Error(this.GetType().ToString(), "将空的xml串转换为WxPayData不合法!");
                throw new Exception("将空的xml串转换为WxPayData不合法!");
            }


            SafeXmlDocument xmlDoc = new SafeXmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNode xmlNode = xmlDoc.FirstChild;//获取到根节点<xml>
            XmlNodeList nodes = xmlNode.ChildNodes;
            foreach (XmlNode xn in nodes)
            {
                XmlElement xe = (XmlElement)xn;
                m_values[xe.Name] = xe.InnerText;//获取xml的键值对到WxPayData内部的数据中 
            }


            return m_values;
        }

        public void LoadData(string data,DataTransferFormatter dataTransferFormatter)
        {
            if (dataTransferFormatter == DataTransferFormatter.XML)
            {
                this.FromXml(data);
                AppId =GetValue("AppId")?.ToString();
                CreateTime =this.GetValue("CreateTime") == null ?0 : Convert.ToInt64(GetValue("CreateTime"));
                InfoType = GetValue("InfoType") ?.ToString();
                ComponentVerifyTicket =GetValue("ComponentVerifyTicket") ?.ToString();
            }
            else
            {
                JsonSerializer.Deserialize<ThirdPlatformMessage>(data);
            }
        }

        public override object GetValue(string key)
        {
            object o = null;
            m_values.TryGetValue(key, out o);
            return o;
        }
    }
}
