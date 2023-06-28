/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace RsCode.WeChat.Util
{
    public class JsonHelper
    {

        public static void Save<T>(string path,T obj,bool clear=false) where T:class
        {
            dynamic jObject;

            if(!clear)
            {
                //读取json文件内容
                using (StreamReader sr = new StreamReader(path))
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    jObject = JToken.ReadFrom(reader) as JObject;
                }
            }else
            {
                jObject = JToken.FromObject(obj);
            }
            

            //动态赋值
            jObject.Tencent.WeChat = JObject.FromObject(obj);
            //序列化原内容
            var jsonContent = JsonConvert.SerializeObject(jObject, Formatting.Indented);
            //保存
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
            {
                sw.WriteLine(jsonContent);
            }
        }

        /// <summary>  
        /// 把对象序列化为字节数组  
        /// </summary>  
        public static byte[] SerializeObject(object obj)
        {
            if (obj == null)
                return null;
            //内存实例
            MemoryStream ms = new MemoryStream();
            //创建序列化的实例
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);//序列化对象，写入ms流中  
            ms.Position = 0;
            //byte[] bytes = new byte[ms.Length];//这个有错误
            byte[] bytes = ms.GetBuffer();
            ms.Read(bytes, 0, bytes.Length);
            ms.Close();
            return bytes;
        }
    }
}
