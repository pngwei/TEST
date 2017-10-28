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
    /// ���籨�ĺ�������л��뷴���л�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataTOClass<T>
    {
        /// <summary>
        /// �����ݷ�����Ϊ��
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
                Trace.WriteLine("ConvertToClass������ת������ʱ�����쳣" + ex.Message);
            }
            return default(T);
        }
        /// <summary>
        ///  ��������Ϊ����
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
                Trace.WriteLine("ConvertToDatasT����ת��������ʱ�����쳣" + ex.Message);
            }
            return null;
        }
    }
}
