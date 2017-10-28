using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Xml;

namespace GX.Common
{
    public class KernalData : SystemConfig
    {
        private static string DataFilePath
        {
            get
            {
                return SystemConfigFilePath + Path.DirectorySeparatorChar + "KernalData.xml";
            }
        }
        public KernalData()
            : base(DataFilePath)
        {
        }
        public KernalData(Stream kernalDataStream)
            : base(kernalDataStream)
        {
        }

        /// <summary>
        /// 读KernalData.xml到DataSet
        /// </summary>
        /// <param name="kernalDataFilePath"></param>
        /// <returns></returns>
        public static DataSet ReadKernalData(string kernalDataFilePath)
        {
            DataSet xmlDataSet = new DataSet();
            xmlDataSet.ReadXml(kernalDataFilePath);
            return xmlDataSet;
        }

        /// <summary>
        /// 从默认目录读取kernalData.xml
        /// </summary>
        /// <returns></returns>
        public static DataSet ReadKernalData()
        {
            DataSet xmlDataSet = new DataSet();
            xmlDataSet.ReadXml(SystemConfig.SystemConfigFilePath + Path.DirectorySeparatorChar + "KernalData.xml");
            return xmlDataSet;
        }

        /// <summary>
        /// 将DataSet中的内容写入KernalData.xml
        /// </summary>
        /// <param name="kernalDataSet"></param>
        /// <param name="kernalDataFilePath"></param>
        public static void SaveKernalData(DataSet kernalDataSet, string kernalDataFilePath)
        {
            kernalDataSet.WriteXml(kernalDataFilePath);
        }

        /// <summary>
        /// 保存kernalData到默认目录
        /// </summary>
        /// <param name="kernalDataSet"></param>
        public static void SaveKernalData(DataSet kernalDataSet)
        {
            kernalDataSet.WriteXml(SystemConfig.SystemConfigFilePath + Path.DirectorySeparatorChar + "KernalData.xml");
        }
    }
}
