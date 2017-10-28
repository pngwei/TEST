using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace GX.Common
{
    /// <summary>
    /// 维护保存在SystemConfig.xml文件中的系统配置信息
    /// 默认有一个items表，该表包含Name和Value两个字段，函数ReadValue可以检索该表中的数据
    /// </summary>
    public class SystemConfig : DataSet
    {
        static private bool disableUTConfigPath =true;
        /// <summary>
        /// 是否禁止使用GXConfigPath环境变量
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
        /// 配置文件的名称
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
        /// 配置文件路径
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
        /// 在指定的路径下及其子路径"GXData"下是否存在配置文件，有则返回文件路径，无则返回""
        /// </summary>
        /// <param name="searchPath">搜索路径</param>
        /// <returns>配置文件所在的路径</returns>
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
        /// 获取配置文件路径
        /// </summary>
        /// <returns></returns>
        static private string GetSystemConfigFilePath()
        {
            //GetDirectoryName 会将debug路径去掉
            string dllPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //搜索动态库的启动路径
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

            //搜索应用程序运行路径
            configFilePath = SearchConfigFilePath(Application.StartupPath);
            if (configFilePath.Length > 0)
            {
                return configFilePath;
            }

            //再搜索环境变量配置的路径
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

            //在web中 Who add this?
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
        /// 判断数据路径下某文件是否存在
        /// </summary>
        /// <param name="configFileName">文件名（应含扩展名，不含路径）</param>
        /// <returns>是否存在</returns>
        static public bool IsConfigFileExist(string configFileName)
        {
            return File.Exists(SystemConfigFilePath + Path.DirectorySeparatorChar + configFileName);
        }
        /// <summary>
        /// 判断系统配置文件是否存在
        /// </summary>
        static public bool IsSystemConfigFileExist
        {
            get
            {
                return IsConfigFileExist(SystemConfigFileName);
            }
        }

        /// <summary>
        /// 依据缺省的SystemConfig.xml和SystemConfig.xsd创建系统配置对象
        /// </summary>
        public SystemConfig()
        {
            if (IsSystemConfigFileExist)
            {
                ReadXml(SystemConfigFilePath + Path.DirectorySeparatorChar + SystemConfigFileName);
            }
            else
            {
                throw new FileLoadException("找不到文件", SystemConfigFilePath + Path.DirectorySeparatorChar + SystemConfigFileName);
            }
        }

        public SystemConfig(Stream stream)
        {
            ReadXml(stream);
        }
        /// <summary>
        /// 通过指定的XML配置文件名创建配置对象，除了XML文件外还要求XSD文件，它们必须放在同一目录下
        /// </summary>
        /// <param name="xmlConfigFileName">xml配置文件名</param>
        public SystemConfig(string xmlConfigFileName)
        {
            xmlConfigFileName = SystemConfigFilePath + Path.DirectorySeparatorChar + Path.ChangeExtension(xmlConfigFileName, ".xml");
            if (File.Exists(xmlConfigFileName))
            {
                ReadXml(xmlConfigFileName);
            }
            else
            {
                throw new FileLoadException("找不到文件", xmlConfigFileName);
            }
        }
        /// <summary>
        /// 检索tableName指定的表中满足condition条件的记录
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataRow[] ReadRows(string tableName, string condition)
        {
            DataTable table = Tables[tableName];
            if (table != null)		//没有关于调试的配置信息
            {
                DataRow[] result = table.Select(condition);
                if (result.Length == 0)
                {
                    result = null;
                }
                return result;
            }
            //查找登录项
            return null;
        }
        /// <summary>
        /// 读取items表中，名字为itemName的记录的值
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
