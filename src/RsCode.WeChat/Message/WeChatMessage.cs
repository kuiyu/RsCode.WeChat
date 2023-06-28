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
using System.Xml;

namespace RsCode.WeChat.Message
{
    /// <summary>
    /// 微信推送的消息
    /// </summary>
    public class WeChatMessage
    {
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

        public virtual object GetValue(string key)
        {
            object o = null;
            m_values.TryGetValue(key, out o);
            return o;
        }


    }
}
