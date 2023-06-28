﻿/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace RsCode.WeChat.Util
{
    /// <summary>
    ///xml序列化
    /// </summary>
    public sealed class XmlSerializer
    {
        #region Member
        /// <summary>
        /// 
        /// </summary>
        private Type _objType = null;

        /// <summary>
        /// 
        /// </summary>
        private PropertyInfo[] _properties = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public XmlSerializer(Type type)
        {
            _objType = type;
            _properties = GetProperties(_objType);
        }
        #endregion Member

        /// <summary>
        /// <![CDATA[序列化]]>
        /// </summary>
        /// <param name="write"></param>
        /// <param name="obj"></param>
        public void Serialize(TextWriter write, object obj)
        {
            //设置
            var xwSettings = new XmlWriterSettings()
            {
                CheckCharacters = false,
                NewLineHandling = NewLineHandling.None,
                Encoding = System.Text.Encoding.UTF8,
            };

            //写入XML
            using (XmlWriter xmlWriter = XmlWriter.Create(write, xwSettings))
            {
                xmlWriter.WriteStartElement("xml");
                WriteProperty(xmlWriter, _properties, obj: obj);
                xmlWriter.WriteEndElement();
                xmlWriter.Flush();
            }
        }

        public string Serializer<T>(T t) where T:class
        {
            using (StringWriter writer = new StringWriter())
            {
                var xmlSerializer = new XmlSerializer(t.GetType());
                xmlSerializer.Serialize(writer, t);
                string strResponseContent = writer.ToString();
                strResponseContent = ClearXmlHeader(strResponseContent);//过滤xml声明
                return strResponseContent;
            }
        }

        /// <summary>
        /// <![CDATA[反序列化]]>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public object Deserialize(TextReader reader)
        {
            object obj = Activator.CreateInstance(_objType);
            using (XmlTextReader xmlReader = new XmlTextReader(reader))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        var propertyInfo = _properties.FirstOrDefault((n) => n.Name == xmlReader.Name);
                        if (null != propertyInfo)
                        {
                            if (propertyInfo.PropertyType == typeof(Int64))
                            {
                                propertyInfo.SetValue(obj, Convert.ToInt64(xmlReader.ReadString()));
                            }
                            else
                            {
                                propertyInfo.SetValue(obj, xmlReader.ReadString());
                            }
                        }
                    }
                }
            }
            return obj;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public object Deserialize(string input)
        {
            StringReader reader = new StringReader(input);
            return Deserialize(reader);
        }

        /// <summary>
        /// <![CDATA[清除xml头部声明]]>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected  string ClearXmlHeader(string input)
        {
            return Regex.Replace(input, @"<\?xml([^>]+)\?>", string.Empty, RegexOptions.IgnoreCase);//过滤xml声明
        }
        #region 私有方法
        /// <summary>
        /// <![CDATA[获取属性集合]]>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlags"></param>
        /// <returns></returns>
        private PropertyInfo[] GetProperties(Type type, System.Reflection.BindingFlags bindingFlags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
        {
            return type.GetProperties(bindingFlags);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="properties"></param>
        /// <param name="obj"></param>
        private void WriteProperty(XmlWriter writer, PropertyInfo[] properties, object obj)
        {
            foreach (var property in properties)
            {

                writer.WriteStartElement(property.Name);

                //值类型
                if (property.PropertyType.IsValueType)
                {

                    writer.WriteString(property.GetValue(obj).ToString());

                }
                //字符串
                else if (property.PropertyType == typeof(string))
                {
                    var value = property.GetValue(obj);
                    if (value!=null)
                    writer.WriteCData(property.GetValue(obj).ToString());
                }
                //属性
                else
                {
                    var that = property.GetValue(obj);
                    if (that is IEnumerable)//判断是否是迭代类型
                    {
                        var enumerator = ((IEnumerable)that).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            var _obj = enumerator.Current;
                            var _objType = _obj.GetType();
                            var xmlType = _objType.GetCustomAttribute<System.Xml.Serialization.XmlTypeAttribute>();

                            var poperties = GetProperties(_objType);
                            writer.WriteStartElement(xmlType.TypeName ?? _objType.Name);
                            WriteProperty(writer, poperties, _obj);//递归调用
                            writer.WriteEndElement();
                        }
                    }
                    else
                    {
                        var poperties = GetProperties(property.PropertyType);
                        WriteProperty(writer, poperties, that);
                    }
                }
                writer.WriteEndElement();
            }
             
        }
        #endregion
    }

     
}
