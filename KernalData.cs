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
        /// ��KernalData.xml��DataSet
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
        /// ��Ĭ��Ŀ¼��ȡkernalData.xml
        /// </summary>
        /// <returns></returns>
        public static DataSet ReadKernalData()
        {
            DataSet xmlDataSet = new DataSet();
            xmlDataSet.ReadXml(SystemConfig.SystemConfigFilePath + Path.DirectorySeparatorChar + "KernalData.xml");
            return xmlDataSet;
        }

        /// <summary>
        /// ��DataSet�е�����д��KernalData.xml
        /// </summary>
        /// <param name="kernalDataSet"></param>
        /// <param name="kernalDataFilePath"></param>
        public static void SaveKernalData(DataSet kernalDataSet, string kernalDataFilePath)
        {
            kernalDataSet.WriteXml(kernalDataFilePath);
        }

        /// <summary>
        /// ����kernalData��Ĭ��Ŀ¼
        /// </summary>
        /// <param name="kernalDataSet"></param>
        public static void SaveKernalData(DataSet kernalDataSet)
        {
            kernalDataSet.WriteXml(SystemConfig.SystemConfigFilePath + Path.DirectorySeparatorChar + "KernalData.xml");
        }
    }
}
