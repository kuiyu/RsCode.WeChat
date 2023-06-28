/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using MediatR;
using RsCode.WeChat.Util;
using System;
using System.Collections.Generic;
using System.Xml;

namespace RsCode.WeChat.Message
{
    public class MessageBase:IRequest<string>
    {
        /// <summary>
        /// 微信号
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public  string MsgType { get;  set; }

        public string Event { get; set; }
        public string EventKey { get; set; }
        public string SessionFrom { get; set; }

        protected SortedDictionary<string, object> m_values = new SortedDictionary<string, object>();
        /**
        * @将xml转为WxPayData对象并返回对象内部的数据
        * @param string 待转换的xml串
        * @return 经转换得到的Dictionary
        * @throws Exception
        */
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

        public string ToXml()
        {
            //数据为空时不能转化为xml格式
            if (0 == m_values.Count)
            {
                //Log.Error(this.GetType().ToString(), "WxPayData数据为空!");
                throw new Exception("WxData数据为空!");
            }

            string xml = "<xml>";
            foreach (KeyValuePair<string, object> pair in m_values)
            {
                //字段值不能为null，会影响后续流程
                if (pair.Value == null)
                {
                    //Log.Error(this.GetType().ToString(), "WxPayData内部含有值为null的字段!");
                    throw new Exception("WxData内部含有值为null的字段!");
                }

                if (pair.Value.GetType() == typeof(int))
                {
                    xml += "<" + pair.Key + ">" + pair.Value + "</" + pair.Key + ">";
                }
                else if (pair.Value.GetType() == typeof(string))
                {
                    xml += "<" + pair.Key + ">" + "<![CDATA[" + pair.Value + "]]></" + pair.Key + ">";
                }
                else//除了string和int类型不能含有其他数据类型
                {
                    //Log.Error(this.GetType().ToString(), "WxPayData字段数据类型错误!");
                    throw new Exception("WxData字段数据类型错误!");
                }
            }
            xml += "</xml>";
            return xml;
        }

        public void SetValue(string key, object value)
        {
            m_values[key] = value;
        }
        public object GetValue(string key)
        {
            object o = null;
            m_values.TryGetValue(key, out o);
            return o;
        }

        public void SetValues()
        { 
            var props = this.GetType().GetProperties();
            foreach (var item in props)
            {
                var value = GetValue(item.Name);
                if(value!=null)
                {
                    string name = item.PropertyType.Name;
                     if (name==  "Int64")
                    {
                        value = Convert.ToInt64(value);
                    }
                     if(name== "Double")
                    {
                        value = Convert.ToDouble(value);
                    }
                     this.GetType().GetProperty(item.Name).SetValue(this, value);
                } 
            }
        }

        /// <summary>
        /// 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
        /// </summary>
        /// <returns></returns>
        public  long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }
    }
}
