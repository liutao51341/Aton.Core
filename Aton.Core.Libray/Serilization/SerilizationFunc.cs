using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Script.Serialization;

namespace Aton.Core.Library.Serilization
{
    /// <summary>
    /// 序列化帮助类
    /// </summary>
    public class SerilizationFunc
    {
        #region xml序列化函数

        #region Xml序列化函数
        /// <summary>
        /// Xml序列化函数
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string XmlSerializerHelper(object message, Type type)
        {
            XmlSerializer ser = new XmlSerializer(type);
            MemoryStream _memory = new MemoryStream();
            ser.Serialize(_memory, message);
            _memory.Position = 0;
            byte[] read = new byte[_memory.Length];
            _memory.Read(read, 0, read.Length);
            _memory.Close();
            return Convert.ToBase64String(read);
        }
        #endregion

        /// <summary>
        /// 序列化函数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            return Serialize(obj, null);
        }

        /// <summary>
        /// 序列化函数
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="rootName"></param>
        /// <returns></returns>
        public static string Serialize(object obj, string rootName)
        {
            //初始化
            MemoryStream stream = new MemoryStream();
            System.Xml.Serialization.XmlSerializer serializer;
            if (string.IsNullOrEmpty(rootName))
            {
                serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            }
            else
            {
                serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType(), new XmlRootAttribute(rootName));
            }
            //为了添加编码
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8);
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlTextWriter.Indentation = 4;
            //xmlTextWriter.Namespaces = false;

            //去除跟节点命名空间
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);

            //序列化
            serializer.Serialize(xmlTextWriter, obj, xmlns);

            //去除UTF8生成的3个字节EF,BB,BF
            byte[] streamBuffer = stream.ToArray();
            byte[] serializerBuffer;
            if (streamBuffer[0] == 0xEF && streamBuffer[1] == 0xBB && streamBuffer[2] == 0xBF)
            {
                serializerBuffer = new byte[streamBuffer.Length - 3];
                Array.Copy(streamBuffer, 3, serializerBuffer, 0, serializerBuffer.Length);
            }
            else
            {
                serializerBuffer = streamBuffer;
            }

            //编码
            return System.Text.UTF8Encoding.UTF8.GetString(serializerBuffer);
        }
        #endregion

        #region xml反序列化函数
        /// <summary>
        /// 反序列化函数
        /// </summary>
        /// <param name="sourceXML"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(string sourceXML, Type type)
        {
            //实例化
            XmlSerializer serializer = new XmlSerializer(type);
            Stream stream = new MemoryStream(System.Text.UTF8Encoding.UTF8.GetBytes(sourceXML));

            //反序列化
            return serializer.Deserialize(stream);
        }
        #endregion

        #region 二进制序列化函数
        /// <summary>
        /// 二进制序列化函数
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string BinarySerializerHelper(object message, Type type)
        {
            System.IO.MemoryStream _memory = new System.IO.MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(_memory, message);
            _memory.Position = 0;
            byte[] read = new byte[_memory.Length];
            _memory.Read(read, 0, read.Length);
            _memory.Close();
            return Convert.ToBase64String(read);
        }
        #endregion

        #region 二进制反序列化函数
        /// <summary>
        /// 二进制反序列化函数
        /// </summary>
        /// <param name="xmlString"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object BinaryDeSerializerHelper(string xmlString, Type type)
        {
            System.IO.MemoryStream _memory = new System.IO.MemoryStream(Convert.FromBase64String(xmlString));
            _memory.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            object _newOjb = formatter.Deserialize(_memory);
            _memory.Close();
            return _newOjb;
        }
        #endregion

        #region 将对象序列化成JSON字符串
        /// <summary>
        /// 将对象序列化成JSON字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string JsonSerialize(object obj)
        {
            try
            {
                var jsonSerializer = new JavaScriptSerializer();

                //注册自定义日期转换
                jsonSerializer.RegisterConverters(new[] { new DateTimeConverter() });

                //执行序列化
                return jsonSerializer.Serialize(obj);
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        #endregion

        #region 将JSON字符串反序列为对象
        /// <summary>
        /// 将JSON字符串反序列为对象
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T JsonDeSerialize<T>(string s)
        {
            byte[] b = Encoding.UTF8.GetBytes(s);
            try
            {
                var jsonSerializer = new JavaScriptSerializer();

                //注册自定义日期转换
                jsonSerializer.RegisterConverters(new[] { new DateTimeConverter() });

                //返回
                return jsonSerializer.Deserialize<T>(s);
            }
            catch (Exception ex)
            {

            }
            return default(T);
        }
        #endregion
    }

    /// <summary>
    /// DateTime 类型转换器
    /// </summary>
    public class DateTimeConverter : JavaScriptConverter
    {
        #region 反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="type"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object Deserialize(
                IDictionary<string, object> dictionary,
                Type type,
                JavaScriptSerializer serializer)
        {
            if (dictionary.ContainsKey("Date"))
            {
                //((DateTime) dictionary["DateTime"]).ToLocalTime();
                return new DateTime((long)dictionary["Date"], DateTimeKind.Local);
            }

            return null;
        }
        #endregion

        #region 序列化
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override IDictionary<string, object> Serialize(object obj,
                JavaScriptSerializer serializer)
        {
            var result = new Dictionary<string, object>();
            if (obj == null) return result;
            result["Date"] = ((DateTime)obj).ToLocalTime().Ticks;

            return result;
        }
        #endregion

        #region 获取受支持类型的集合
        /// <summary>
        /// 获取受支持类型的集合
        /// </summary>
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new List<Type>() { typeof(DateTime?), typeof(DateTime) }; }
        }
        #endregion
    }
}
