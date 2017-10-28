using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace GX.Common
{
    /// <summary>
    /// ά��������SystemConfig.xml�ļ��е�ϵͳ������Ϣ
    /// Ĭ����һ��items���ñ����Name��Value�����ֶΣ�����ReadValue���Լ����ñ��е�����
    /// </summary>
    public class SystemConfig : DataSet
    {
        static private bool disableUTConfigPath =true;
        /// <summary>
        /// �Ƿ��ֹʹ��GXConfigPath��������
        /// </summary>
        static public bool DisableUTConfigPath
        {
            get
            {
                return disableUTConfigPath;
            }
            set
            {
                disableUTConfigPath = value;
            }
        }

        /// <summary>
        /// �����ļ�������
        /// </summary>
        static public string SystemConfigFileName
        {
            get
            {
                return "SystemConfig.XML";
            }
        }


        static private string configFilePath = "";
        /// <summary>
        /// �����ļ�·��
        /// </summary>
        static public string SystemConfigFilePath
        {
            get
            {
                if (string.IsNullOrEmpty(configFilePath))
                {
                    configFilePath = GetSystemConfigFilePath();
                }
                return configFilePath;
            }
        }

        /// <summary>
        /// ��ָ����·���¼�����·��"GXData"���Ƿ���������ļ������򷵻��ļ�·�������򷵻�""
        /// </summary>
        /// <param name="searchPath">����·��</param>
        /// <returns>�����ļ����ڵ�·��</returns>
        static private string SearchConfigFilePath(string searchPath)
        {
            if (searchPath == null || searchPath.Length == 0)
            {
                return "";
            }
            string s = string.Format("{0}{1}GXData{1}{2}", searchPath, Path.DirectorySeparatorChar, SystemConfigFileName);
            if (File.Exists(string.Format("{0}{1}GXData{1}{2}", searchPath,Path.DirectorySeparatorChar, SystemConfigFileName)))
            {
                return string.Format("{0}{1}GXData", searchPath, Path.DirectorySeparatorChar);
            }

            if (File.Exists(string.Format("{0}{1}{2}", searchPath, Path.DirectorySeparatorChar, SystemConfigFileName)))
            {
                return searchPath;
            }

            return "";

        }
        /// <summary>
        /// ��ȡ�����ļ�·��
        /// </summary>
        /// <returns></returns>
        static private string GetSystemConfigFilePath()
        {
            //GetDirectoryName �Ὣdebug·��ȥ��
            string dllPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //������̬�������·��
            configFilePath = SearchConfigFilePath(dllPath);
            if (configFilePath.Length > 0)
            {
                return configFilePath;
            }
           
            if (!System.IO.Directory.Exists(dllPath + Path.DirectorySeparatorChar + "GXData"))
            {
               // System.IO.Directory.CreateDirectory(dllPath + Path.DirectorySeparatorChar + "GXData");
            }
            if (DisableUTConfigPath && System.IO.Directory.Exists(dllPath + Path.DirectorySeparatorChar + "GXData"))
            {
                return dllPath + Path.DirectorySeparatorChar + "GXData";
            }

            dllPath = Assembly.GetExecutingAssembly().CodeBase.Replace('/', Path.DirectorySeparatorChar);
            if (dllPath.StartsWith("file:", StringComparison.InvariantCultureIgnoreCase))
            {
                dllPath = dllPath.Substring(5);
                while (dllPath[0]==Path.DirectorySeparatorChar)
                {
                    dllPath = dllPath.Substring(1);
                }
            }
            int pos = dllPath.LastIndexOf(Path.DirectorySeparatorChar);
            dllPath = dllPath.Substring(0, pos);
            configFilePath = SearchConfigFilePath(dllPath);
            if (configFilePath.Length > 0)
            {
                return configFilePath;
            }

            //����Ӧ�ó�������·��
            configFilePath = SearchConfigFilePath(Application.StartupPath);
            if (configFilePath.Length > 0)
            {
                return configFilePath;
            }

            //�����������������õ�·��
            string defaultPath = System.Environment.GetEnvironmentVariable("GXConfigPath");
            if (!disableUTConfigPath && !string.IsNullOrEmpty(defaultPath) && Directory.Exists(defaultPath))
            {
                if (defaultPath[defaultPath.Length - 1] == Path.DirectorySeparatorChar)
                {
                    defaultPath = defaultPath.Substring(0, defaultPath.Length - 1);
                }
                configFilePath = SearchConfigFilePath(defaultPath);
                if (configFilePath.Length > 0)
                {
                    return configFilePath;
                }
            }

            //��web�� Who add this?
            configFilePath = SearchConfigFilePath(System.Web.Configuration.WebConfigurationManager.AppSettings["FilePath"]);
            if (configFilePath.Length > 0)
            {
                return configFilePath;
            }
            if (defaultPath == null || defaultPath.Length == 0)
            {
                defaultPath = Application.StartupPath;
            }


            if (System.IO.Directory.Exists(defaultPath + Path.DirectorySeparatorChar+"GXData"))
            {
                return defaultPath +Path.DirectorySeparatorChar+ "GXData";
            }
            return defaultPath;
        }

        /// <summary>
        /// �ж�����·����ĳ�ļ��Ƿ����
        /// </summary>
        /// <param name="configFileName">�ļ�����Ӧ����չ��������·����</param>
        /// <returns>�Ƿ����</returns>
        static public bool IsConfigFileExist(string configFileName)
        {
            return File.Exists(SystemConfigFilePath + Path.DirectorySeparatorChar + configFileName);
        }
        /// <summary>
        /// �ж�ϵͳ�����ļ��Ƿ����
        /// </summary>
        static public bool IsSystemConfigFileExist
        {
            get
            {
                return IsConfigFileExist(SystemConfigFileName);
            }
        }

        /// <summary>
        /// ����ȱʡ��SystemConfig.xml��SystemConfig.xsd����ϵͳ���ö���
        /// </summary>
        public SystemConfig()
        {
            if (IsSystemConfigFileExist)
            {
                ReadXml(SystemConfigFilePath + Path.DirectorySeparatorChar + SystemConfigFileName);
            }
            else
            {
                throw new FileLoadException("�Ҳ����ļ�", SystemConfigFilePath + Path.DirectorySeparatorChar + SystemConfigFileName);
            }
        }

        public SystemConfig(Stream stream)
        {
            ReadXml(stream);
        }
        /// <summary>
        /// ͨ��ָ����XML�����ļ����������ö��󣬳���XML�ļ��⻹Ҫ��XSD�ļ������Ǳ������ͬһĿ¼��
        /// </summary>
        /// <param name="xmlConfigFileName">xml�����ļ���</param>
        public SystemConfig(string xmlConfigFileName)
        {
            xmlConfigFileName = SystemConfigFilePath + Path.DirectorySeparatorChar + Path.ChangeExtension(xmlConfigFileName, ".xml");
            if (File.Exists(xmlConfigFileName))
            {
                ReadXml(xmlConfigFileName);
            }
            else
            {
                throw new FileLoadException("�Ҳ����ļ�", xmlConfigFileName);
            }
        }
        /// <summary>
        /// ����tableNameָ���ı�������condition�����ļ�¼
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataRow[] ReadRows(string tableName, string condition)
        {
            DataTable table = Tables[tableName];
            if (table != null)		//û�й��ڵ��Ե�������Ϣ
            {
                DataRow[] result = table.Select(condition);
                if (result.Length == 0)
                {
                    result = null;
                }
                return result;
            }
            //���ҵ�¼��
            return null;
        }
        /// <summary>
        /// ��ȡitems���У�����ΪitemName�ļ�¼��ֵ
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public string ReadValue(string itemName)
        {
            DataRow[] items = ReadRows("items", "name = '" + itemName + "'");
            if (items == null || items.Length == 0)
            {
                return null;
            }
            return Convert.ToString(items[0]["value"]);
        }

        public string ReadValue(string itemName, string defaultValue)
        {
            DataRow[] items = ReadRows("items", "name = '" + itemName + "'");
            if (items == null || items.Length == 0)
            {
                return defaultValue;
            }
            return items[0]["value"].ToString();
        }

        public string DefaultDbEnvironment
        {
            get
            {
                return ReadValue("DefaultDbEnvironment");
            }
        }
        public string WorkDir
        {
            get
            {
                return ReadValue("WorkDir");
            }
        }
    }
}
