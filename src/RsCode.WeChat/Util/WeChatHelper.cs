/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using Microsoft.AspNetCore.Http;
using RsCode.WeChat.Util;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace RsCode.WeChat
{
    /// <summary>
    /// 微信SDK常用hehlp工具类
    /// </summary>
    public class WeChatHelper
    {
        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <returns></returns>
        public static string GetNonceStr()
        {
            var randomGenerator = new RandomGenerator();
            return randomGenerator.GetRandomUInt().ToString();
        }
        /// <summary>
        /// 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// rfc3339标准格式时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ConvertDateTime(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");
        }

        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime ConvertDateTime(long jsTimeStamp)
        {
            System.DateTime startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local); // 当地时区
            DateTime dt = startTime.AddMilliseconds(jsTimeStamp);
            return dt;
        }

        ///<summary>
        /// 计算文件的 SHA256 值
        /// </summary>
        /// <param name="fileName">要计算 SHA256 值的文件名和路径</param>
        /// <returns>SHA256值16进制字符串</returns>
        public static string SHA256File(string fileName)
        {
            return HashFile(fileName, "sha256");
        }

        public static string HashFile(FileStream fs,string algName="sha256")
        {
            using(fs)
            {
                byte[] hashBytes = HashData(fs, algName); 
                return ByteArrayToHexString(hashBytes);
            } 
        }

        /// <summary>
        /// 计算文件的哈希值
        /// </summary>
        /// <param name="fileName">要计算哈希值的文件名和路径</param>
        /// <param name="algName">算法:sha1,md5</param>
        /// <returns>哈希值16进制字符串</returns>
        private static string HashFile(string fileName, string algName)
        {
            if (!System.IO.File.Exists(fileName))
                return string.Empty;

            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            byte[] hashBytes = HashData(fs, algName);
            fs.Close();
            return ByteArrayToHexString(hashBytes);
        }


        /// <summary>
        /// 字节数组转换为16进制表示的字符串
        /// </summary>
        private static string ByteArrayToHexString(byte[] buf)
        {
            string returnStr = "";
            if (buf != null)
            {
                for (int i = 0; i < buf.Length; i++)
                {
                    returnStr += buf[i].ToString("X2");
                }
            }
            return returnStr;
        }


        /// <summary>
        /// 计算哈希值
        /// </summary>
        /// <param name="stream">要计算哈希值的 Stream</param>
        /// <param name="algName">算法:sha1,md5</param>
        /// <returns>哈希值字节数组</returns>
        private static byte[] HashData(Stream stream, string algName)
        {
            HashAlgorithm algorithm;
            if (algName == null)
            {
                throw new ArgumentNullException("algName 不能为 null");
            }
            if (string.Compare(algName, "sha256", true) == 0)
            {
                algorithm = SHA256.Create();
            }
            else
            {
                if (string.Compare(algName, "md5", true) != 0)
                {
                    throw new Exception("algName 只能使用 sha256 或 md5");
                }
                algorithm = System.Security.Cryptography.MD5.Create();
            }
            return algorithm.ComputeHash(stream);
        }

        public static bool IsBase64String(string str)
        {
            try
            {
                  Convert.FromBase64String(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

       
        

        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetIp(HttpContext context)
        {
             
            string ip = "0.0.0.0";
            if (context != null)
            {
                ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
                if (string.IsNullOrEmpty(ip))
                {
                    ip = context.Connection.RemoteIpAddress.ToString();
                }
            }

            return ip;
        }

        
    }
}

