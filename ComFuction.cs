using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace GX.Common
{
    /// <summary>
    /// 网络报文和类的序列化与反序列化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataTOClass<T>
    {
        /// <summary>
        /// 把数据反序列为类
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static T ConvertToClass(byte[] datas)
        {
            try
            {
                Stream stream = new MemoryStream();
                stream.Write(datas, 0, datas.Length);
                stream.Position = 0;
                BinaryFormatter formater = new BinaryFormatter();
                T t = (T)formater.Deserialize(stream);
                stream.Close();
                return t;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ConvertToClass：数据转换成类时出现异常" + ex.Message);
            }
            return default(T);
        }
        /// <summary>
        ///  把类序列为数据
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static byte[] ConvertToDatas(T t)
        {
            try
            {
                Stream streamFile = new MemoryStream();
                BinaryFormatter formater = new BinaryFormatter();
                formater.Serialize(streamFile, t);
                byte[] filedata = new byte[streamFile.Length];
                streamFile.Position = 0;
                streamFile.Read(filedata, 0, filedata.Length);
                streamFile.Close();
                return filedata;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ConvertToDatasT：类转换成数据时出现异常" + ex.Message);
            }
            return null;
        }
    }
}
