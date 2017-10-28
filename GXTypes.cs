
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;
using System.Collections.ObjectModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;


//[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
//[assembly: PermissionSet(SecurityAction.RequestOptional, Name = "Nothing")]
[assembly: CLSCompliant(false)]

namespace GX.Common
{
    public delegate void VoidParameterRoutine();
    public delegate void BoolParemeterRoutine(bool b);
    public delegate void StringParameterRoutine(string msg);
    public delegate void DualStringParameterRoutine(string p1, string p2);

    public delegate void Action();
    /// <summary>
    /// 数据库是否可用信息
    /// </summary>
    [Serializable]
    public class UTDatabaseInfo
    {
        private DatabaseTypes dbType;
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseTypes DatabaseType
        {
            get
            {
                return dbType;
            }
            set
            {
                dbType = value;
            }
        }


        private bool connectionChecked;
        public bool ConnectionChecked
        {
            get
            {
                return connectionChecked;
            }
            set
            {
                connectionChecked = value;
            }
        }


        private UTDatabaseInformationCode code = UTDatabaseInformationCode.Unchecked;
        /// <summary>
        /// 类型码
        /// </summary>
        public UTDatabaseInformationCode Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }
        /// <summary>
        /// 类型文本
        /// </summary>
        public string Text
        {
            get
            {
                switch (code)
                {
                    case UTDatabaseInformationCode.Available:
                        return ("正常");
                    case UTDatabaseInformationCode.Unchecked:
                        return ("尚未对配置的数据库进行检查");
                    case UTDatabaseInformationCode.ConnectionChecking:
                        return ("正在进行连接检查");
                    case UTDatabaseInformationCode.NoConfigFile:
                        return ("数据库配置文件不存在");
                    case UTDatabaseInformationCode.NoDefaultEnvironment:
                        return ("缺省环境变量不存在");
                    case UTDatabaseInformationCode.MultiEnvironment:
                        return ("数据库环境重复配置");
                    case UTDatabaseInformationCode.ConfigError:
                        return ("配置有错误：") + exceptionMessage;
                    case UTDatabaseInformationCode.NoEnvironment:
                        return ("环境变量不存在:") + dbEnv;
                    case UTDatabaseInformationCode.NotInstalled:
                        return ("未安装数据库系统");
                    case UTDatabaseInformationCode.ConnectFailure:
                        return ("连接失败");
                    case UTDatabaseInformationCode.NoCatalog:
                        return string.Format(("数据库:{0} 尚未创建"), DatabaseCatalog);
                    default:
                        return ("UTDatabaseInfo类需要重写了");

                }
            }
        }

        private string user = "";
        /// <summary>
        /// 配置的登录用户
        /// </summary>
        public string User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }

        private string userPassword = "";
        /// <summary>
        /// 登录用户密码
        /// </summary>
        public string UserPassword
        {
            get
            {
                return userPassword;
            }
            set
            {
                userPassword = value;
            }
        }

        private bool trustedConnection;
        /// <summary>
        /// 是否是集成验证
        /// </summary>
        public bool TrustedConnection
        {
            get
            {
                return trustedConnection;
            }
            set
            {
                trustedConnection = value;
            }
        }

        private string dbEnv = "";
        /// <summary>
        /// 配置的数据库环境
        /// </summary>
        public string DatabaseEnvironment
        {
            get
            {
                return dbEnv;
            }
            set
            {
                dbEnv = value;
            }
        }

        private string envDesc = "";
        public string EnvironmentDescription
        {
            get
            {
                return envDesc;
            }
            set
            {
                envDesc = value;
            }
        }


        private string databaseCatalog = "";
        /// <summary>
        /// 数据库名
        /// </summary>
        public string DatabaseCatalog
        {
            get
            {
                if (databaseCatalog.Length == 0)
                {
                    return "GXDB";
                }
                return databaseCatalog;
            }
            set
            {
                databaseCatalog = value;
            }
        }

        private string dataSourceDesc = "";
        /// <summary>
        /// 数据库连接描述(Oracle用)
        /// </summary>
        public string DataSourceDescription
        {
            get
            {
                return dataSourceDesc;
            }
            set
            {
                dataSourceDesc = value;
            }
        }

        /// <summary>
        /// 上次连接串中的服务器及端口，用于缺省连接串的生成
        /// </summary>
        public static string PreviousDatabaseInstanceName = "";

        private string databaseInstanceName = "";
        /// <summary>
        /// 数据库服务器实例名或服务器实例名及端口（仅需要指明端口时）
        /// </summary>
        public string DatabaseInstanceName
        {
            get
            {
                return databaseInstanceName;
            }
            set
            {
                databaseInstanceName = value;
                if (!string.IsNullOrEmpty(value))
                {
                    PreviousDatabaseInstanceName = value;
                }
            }
        }

        private string databaseMachineName = "";
        /// <summary>
        /// 数据库机器名
        /// </summary>
        public string DatabaseMachineName
        {
            get
            {
                return databaseMachineName;
            }
            set
            {
                databaseMachineName = value;
            }
        }

        private string exceptionMessage = "";
        /// <summary>
        /// 扑捉到的例外错误信息
        /// </summary>
        public string ExceptionMessage
        {
            get
            {
                return exceptionMessage;
            }
            set
            {
                exceptionMessage = value;
            }

        }

        private string dotNetProviderName = "";
        /// <summary>
        /// DataProviderInvariantName,缺省不需要赋值
        /// 如果计算机安装有多个，可以通过赋值来选择其中的一个
        /// </summary>
        public string DotNetProviderName
        {
            get
            {
                return dotNetProviderName;
            }
            set
            {
                dotNetProviderName = value;
            }
        }

        public UTDatabaseInfo()
        {
        }

        public UTDatabaseInfo(UTDatabaseInfo src)
        {
            this.dbType = src.dbType;
            this.code = src.code;
            this.connectionChecked = src.connectionChecked;
            this.databaseCatalog = src.databaseCatalog;
            this.dbEnv = src.dbEnv;
            this.envDesc = src.envDesc;
            this.exceptionMessage = src.exceptionMessage;
            this.databaseInstanceName = src.databaseInstanceName;
            this.trustedConnection = src.trustedConnection;
            this.user = src.user;
            this.userPassword = src.userPassword;
            this.dotNetProviderName = src.dotNetProviderName;
            this.DataSourceDescription = src.DataSourceDescription;
        }

    }


    /// <summary>
    /// “五防”系统的部分配置信息
    /// </summary>
    sealed public class SystemSets
    {
        static private int matrixCountSupported = 18;       //系统中每个设备的最多锁编码数
        static private int matrixProprtyCount = 0x44;       //目前定义的锁码属性数量  lym E匙通改为0x44
        //static private int bytesKeyCanDisplay = 250;        //1D电脑钥匙可显示的字符数
        //static private int maxTaskCountEachStation = 6;

        /// <summary>
        /// 数据库中每条记录定义的锁码数
        /// </summary>
        static public int MatrixCountSupported
        {
            get
            {
                return matrixCountSupported;
            }
            set
            {
                matrixCountSupported = value;
            }
        }
        /// <summary>
        /// 每个设备可以使用的最大最多锁码，系统不同数量也可能不同
        /// </summary>
        static public int MatrixProprtyCount
        {
            get
            {
                return matrixProprtyCount;
            }
            set
            {
                matrixProprtyCount = value;
            }
        }
        ///// <summary>
        ///// 电脑钥匙可显示的字符数
        ///// </summary>
        //static public int BytesKeyCanDisplay
        //{
        //    get
        //    {
        //        return bytesKeyCanDisplay;
        //    }
        //    set
        //    {
        //        bytesKeyCanDisplay = value;
        //    }
        //}
        ///// <summary>
        ///// 每个站可开的最大并行任务数
        ///// </summary>
        //static public int MaxTaskCountEachStation
        //{
        //    get
        //    {
        //        return maxTaskCountEachStation;
        //    }
        //    set
        //    {
        //        maxTaskCountEachStation = value;
        //    }

        //}



        ///// <summary>
        ///// 获取锁码名称
        ///// </summary>
        ///// <param name="codeIdx">锁码位置编号</param>
        ///// <param name="key">钥匙类型</param>
        ///// <returns></returns>
        //static public string GetMatrixCodeName(int codeIdx, UTKeyType key)
        //{
        //    return string.Format("({0}){1}", codeIdx, Get1DMatrixCodeName(codeIdx));

        //}

        private SystemSets()
        {
        }

    }

    [Serializable]
    sealed public class SystemLogFileInfo
    {
        private int logFileIndex;
        /// <summary>
        /// 日志文件编号
        /// </summary>
        public int LogFileIndex
        {
            get
            {
                return logFileIndex;
            }
        }

        private string logFileName;
        public string LogFileName
        {
            get
            {
                return logFileName;
            }
        }

        private string logText;
        /// <summary>
        /// 日志内容
        /// </summary>
        public string LogText
        {
            get
            {
                return logText;
            }
        }
        public SystemLogFileInfo(int fileIdx, string fileName, string logInfo)
        {
            logFileIndex = fileIdx;
            logFileName = fileName;
            logText = logInfo;
        }
    }

    /// <summary>
    /// 系统日志读取命令
    /// </summary>
    [Serializable]
    public class SystemLogReadCommand
    {
        int fileIndex;
        public int FileIndex
        {
            get
            {
                return fileIndex;
            }
        }
        string readingClient;
        public string ReadingClient
        {
            get
            {
                return readingClient;
            }
        }

        private bool readPrevious;
        public bool ReadPrevious
        {
            get
            {
                return readPrevious;
            }
        }

        public SystemLogReadCommand(int fileIdx, string client, bool readNext)
        {
            fileIndex = fileIdx;
            readingClient = client;
            readPrevious = !readNext;
        }

    }

    /// <summary>
    /// 客户端注册信息
    /// </summary>
    [Serializable]
    sealed public class ClientRegistertingInformation
    {
        private JoyoClientClassification clientClass = JoyoClientClassification.Unknown;
        /// <summary>
        /// 注册客户端类型
        /// </summary>
        public JoyoClientClassification ClientClass
        {
            get
            {
                return clientClass;
            }
            set
            {
                clientClass = value;
            }
        }

        private ClientRegisterInfoType registerType;
        public ClientRegisterInfoType RegisterType
        {
            get
            {
                return registerType;
            }
        }
        private string clientName = "";
        public string ClientName
        {
            get
            {
                return clientName;
            }
        }

        private string clientDescription = "";
        public string ClientDescription
        {
            get
            {
                if (string.IsNullOrEmpty(clientDescription))
                {
                    return clientName;
                }
                return clientDescription;
            }
        }

        private CommunicationChannelInfo channelInfo;
        public CommunicationChannelInfo ChannelInfo
        {
            get
            {
                return channelInfo;
            }
        }

        public ClientRegistertingInformation(JoyoClientClassification regClass, ClientRegisterInfoType regType, string name,
            string desc, CommunicationChannelInfo chlInfo)
        {
            clientClass = regClass;
            registerType = regType;
            clientName = name;
            clientDescription = desc;
            channelInfo = chlInfo;
        }


    }

    /// <summary>
    /// 一个简单的名称（键）、值封装类
    /// </summary>
    [Serializable]
    public class KeyValuePair
    {
        private string keyName;
        private string keyValue;

        public KeyValuePair(string name, string valueOfKey)
        {
            keyName = name;
            keyValue = valueOfKey;
        }
        /// <summary>
        /// 值
        /// </summary>
        public string KeyValue
        {
            get
            {
                return keyValue;
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string KeyName
        {

            get
            {
                return keyName;
            }
        }

    }

    /// <summary>
    /// 显示内容、值封装类,前面定义的KeyValuePair可以取代该类，因模块重新整理得以保留
    /// </summary>
    [Serializable]
    public class DisplayValuePair
    {
        private string relatedValue;
        private string display;
        private string extraData;//扩展参数 add by wdp for 危险点关联设备 2013-08-13

        public DisplayValuePair(string strDisplay, string strValue)
        {

            this.display = strDisplay;
            this.relatedValue = strValue;
        }

        //add by wdp for 危险点关联设备 2013-08-13
        /// <summary>
        /// 构造函数(多传入一个扩展参数)
        /// </summary>
        /// <param name="strDisplay">显示值</param>
        /// <param name="strValue">真实值</param>
        /// <param name="strExtraData">扩展参数</param>
        public DisplayValuePair(string strDisplay, string strValue, string strExtraData)
        {
            this.display = strDisplay;
            this.relatedValue = strValue;
            this.extraData = strExtraData;
        }

        /// <summary>
        /// 显示内容
        /// </summary>
        public string DisplayText
        {
            get
            {
                return this.display;
            }
            set
            {
                display = value;
            }
        }
        /// <summary>
        /// 实际值
        /// </summary>
        public string Value
        {

            get
            {
                return this.relatedValue;
            }
            set
            {
                relatedValue = value;
            }
        }
        /// <summary>
        /// 设备类型 add by wdp for 危险点关联设备 2013-08-13
        /// </summary>
        public string ExtraData
        {

            get
            {
                return this.extraData;
            }
            set
            {
                extraData = value;
            }
        }

        public override string ToString()
        {
            return this.display;
        }
    }
    /// <summary>
    /// 显示内容、值封装类的集合
    /// </summary>
    public class DisplayValuePairGroup
    {
        private List<DisplayValuePair> valuePaires;

        public DisplayValuePairGroup()
        {
            valuePaires = new List<DisplayValuePair>();
        }

        public void Add(DisplayValuePair valuePair)
        {
            valuePaires.Add(valuePair);
        }

        public bool InsertAt(DisplayValuePair pair, int index)
        {
            if (index < 0 || index > valuePaires.Count)
            {
                return false;
            }
            if (index == valuePaires.Count)
            {
                valuePaires.Add(pair);
                return true;
            }

            valuePaires.Insert(index, pair);
            return true;
        }

        public bool RemoveAt(int index)
        {
            if (index >= valuePaires.Count)
            {
                return false;
            }

            valuePaires.RemoveAt(index);
            return true;
        }

        public int ContainsValueText(string valueText, bool ignoreCase)
        {
            for (int i = 0; i < valuePaires.Count; i++)
            {
                if (string.Compare(valuePaires[i].Value, valueText, ignoreCase) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        //add by wdp for 危险点关联设备 2013-08-13
        /// <summary>
        /// 根据真实值和扩展参数查找是否有关联数据
        /// </summary>
        /// <param name="valueText">真实值</param>
        /// <param name="extraData">扩展参数</param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public int ContainsValueText(string valueText, string extraData, bool ignoreCase)
        {
            for (int i = 0; i < valuePaires.Count; i++)
            {
                if ((string.Compare(valuePaires[i].Value, valueText, ignoreCase) == 0)
                    && (string.Compare(valuePaires[i].ExtraData, extraData, ignoreCase) == 0))
                {
                    return i;
                }
            }
            return -1;
        }

        public int ContainsDisplayText(string displayText, bool ignoreCase)
        {
            for (int i = 0; i < valuePaires.Count; i++)
            {
                if (string.Compare(valuePaires[i].DisplayText, displayText, ignoreCase) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        //add by wdp for 危险点关联设备 2013-08-13
        /// <summary>
        /// 根据显示值和扩展参数查找是否有关联数据
        /// </summary>
        /// <param name="displayText">显示值</param>
        /// <param name="extraData">扩展参数</param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public int ContainsDisplayText(string displayText, string extraData, bool ignoreCase)
        {
            for (int i = 0; i < valuePaires.Count; i++)
            {
                if ((string.Compare(valuePaires[i].DisplayText, displayText, ignoreCase) == 0)
                    && (string.Compare(valuePaires[i].ExtraData, extraData, ignoreCase) == 0))
                {
                    return i;
                }
            }
            return -1;
        }

        public string ValueToDisplayText(string valueText)
        {
            if (valueText == null)
            {
                valueText = "";
            }
            else
            {
                valueText = valueText.Trim();
            }
            foreach (DisplayValuePair pair in valuePaires)
            {
                if (string.Compare(pair.Value, valueText, true) == 0)
                {
                    return pair.DisplayText;
                }
            }
            return valueText;
        }

        //add by wdp for 危险点关联设备 2013-08-13
        /// <summary>
        /// 根据真实值和扩展参数获取显示值
        /// </summary>
        /// <param name="valueText">真实值</param>
        /// <param name="extraData">扩展参数</param>
        /// <returns></returns>
        public string ValueToDisplayText(string valueText, string extraData)
        {
            if (valueText == null)
            {
                valueText = "";
            }
            else
            {
                valueText = valueText.Trim();
            }
            if (extraData == null)
            {
                extraData = "";
            }
            else
            {
                extraData = extraData.Trim();
            }
            foreach (DisplayValuePair pair in valuePaires)
            {
                if ((string.Compare(pair.Value, valueText, true) == 0)
                    && (string.Compare(pair.ExtraData, extraData, true) == 0))
                {
                    return pair.DisplayText;
                }
            }
            return valueText;
        }

        public string DisplayTextToValue(string displayText)
        {
            if (displayText == null)
            {
                displayText = "";
            }
            else
            {
                displayText = displayText.Trim();
            }
            foreach (DisplayValuePair pair in valuePaires)
            {

                if (string.Compare(pair.DisplayText, displayText, true) == 0)
                {
                    return pair.Value;
                }
            }
            return displayText;
        }

        //add by wdp for 危险点关联设备 2013-08-13
        /// <summary>
        /// 根据显示值和扩展参数获取真实值
        /// </summary>
        /// <param name="displayText">显示值</param>
        /// <param name="extraData">扩展参数</param>
        /// <returns></returns>
        public string DisplayTextToValue(string displayText, string extraData)
        {
            if (displayText == null)
            {
                displayText = "";
            }
            else
            {
                displayText = displayText.Trim();
            }
            if (extraData == null)
            {
                extraData = "";
            }
            else
            {
                extraData = extraData.Trim();
            }
            foreach (DisplayValuePair pair in valuePaires)
            {

                if ((string.Compare(pair.DisplayText, displayText, true) == 0)
                    && (string.Compare(pair.ExtraData, extraData, true) == 0))
                {
                    return pair.Value;
                }
            }
            return displayText;
        }

        public int Count
        {
            get
            {
                return valuePaires.Count;
            }
        }

        public void Clear()
        {
            valuePaires.Clear();
        }

        public DisplayValuePair this[int idx]
        {
            get
            {
                if (idx < 0 || idx >= valuePaires.Count)
                {
                    return null;
                }
                return valuePaires[idx];
            }
        }

        /// <summary>
        /// 根据扩展参数得到数据集 add by wdp for 危险点关联设备 2013-08-14
        /// </summary>
        /// <param name="extraData"></param>
        /// <returns></returns>
        public List<DisplayValuePair> GetContentByExtraData(string extraData)
        {
            List<DisplayValuePair> ListResult = new List<DisplayValuePair>();

            foreach (DisplayValuePair pair in valuePaires)
            {
                if (string.Compare(pair.ExtraData, extraData, true) == 0)
                {
                    DisplayValuePair p = new DisplayValuePair(pair.DisplayText, pair.Value, pair.ExtraData);
                    ListResult.Add(p);
                }
            }

            return ListResult;
        }
    }

    [Serializable]
    public class StructuredTableInfo
    {
        private string clientName = "";
        /// <summary>
        /// 覆盖该表的客户端
        /// </summary>
        public string ClientName
        {
            get
            {
                return clientName;
            }
        }
        private DataTable table;
        /// <summary>
        /// 表内容
        /// </summary>
        public DataTable Table
        {
            get
            {
                return table;
            }
        }
        private int structureId;
        /// <summary>
        /// 表结构编号
        /// </summary>
        public int StructureId
        {
            get
            {
                return structureId;
            }
        }

        private string tableDesc = "";
        /// <summary>
        /// 对表的描述
        /// </summary>
        public string TableDesc
        {
            get
            {
                return tableDesc;
            }
        }

        private bool isSequenceTable;
        /// <summary>
        /// 是否是通讯用顺序表
        /// </summary>
        public bool IsSequenceTable
        {
            get
            {
                return isSequenceTable;
            }
        }

        public StructuredTableInfo(string client, int tableStructureId, DataTable struturedTable, string desc, bool sequenceTable)
        {
            clientName = client;
            structureId = tableStructureId;
            table = struturedTable;
            tableDesc = desc;
            isSequenceTable = sequenceTable;
        }
    }

    /// <summary>
    /// 用做返布尔型返回结果＋信息
    /// </summary>
    [Serializable]
    public class BoolResult
    {
        private bool result;
        public bool Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }

        private string msg = "";
        public string Msg
        {
            get
            {
                return msg;
            }
            set
            {
                msg = value;
            }
        }

        private string msg2 = "";
        public string Msg2
        {
            get
            {
                return msg2;
            }
            set
            {
                msg2 = value;
            }
        }

        private object tag;
        public object Tag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
            }
        }

        public void Clear()
        {
            msg = "";
            msg2 = "";
            tag = null;
            result = false;
        }

        public BoolResult(bool r)
        {
            result = r;
        }
        public BoolResult(bool r, string m)
        {
            result = r;
            msg = m;
        }

        public BoolResult(string m)
        {
            msg = m;
        }

        public BoolResult()
            : this(false)
        {
        }

        public static BoolResult operator &(BoolResult b1, BoolResult b2)
        {
            if (!b1.result)
            {
                return b1;
            }
            if (!b2.result)
            {
                return b2;
            }
            return new BoolResult(true);
        }

        public static BoolResult operator |(BoolResult b1, BoolResult b2)
        {
            if (b1.result)
            {
                return b1;
            }
            if (b2.result)
            {
                return b2;
            }
            return new BoolResult(false, string.Format("{0}并且{1}", b1.Msg, b2.Msg));
        }
    }


    /// <summary>
    /// 运行系统信息
    /// </summary>
    [Serializable]
    public class RunningSystemInfo
    {
        private int taskSystemId;
        /// <summary>
        /// 开票系统Id，生成操作票时使用
        /// </summary>
        public int TaskSystemId
        {
            get
            {
                return taskSystemId;
            }
            set
            {
                taskSystemId = value;
            }
        }
        private int taskSystemType = 0x07;
        /// <summary>
        /// 开票系统类型，生成操作票时使用
        /// </summary>
        public int TaskSystemType
        {
            get
            {
                return taskSystemType;
            }
            set
            {
                taskSystemType = value;
            }
        }
        private string serverDescription = "";
        /// <summary>
        /// “五防”服务器名（描述）
        /// </summary>
        public string ServerDescription
        {
            get
            {
                return serverDescription;
            }
            set
            {
                serverDescription = value;
            }
        }

        private string serverVersion = "";
        /// <summary>
        /// 服务器版本
        /// </summary>
        public string ServerVersion
        {
            get
            {
                return serverVersion;
            }
            set
            {
                serverVersion = value;
            }
        }

        private string clientName;
        /// <summary>
        /// 客户端名
        /// </summary>
        public string ClientName
        {
            get
            {
                if (string.IsNullOrEmpty(clientName))
                {
                    clientName = System.Environment.MachineName;
                }
                return clientName;
            }
            set
            {
                clientName = value;
            }
        }

        private int clientId;
        /// <summary>
        /// 客户端Id
        /// </summary>
        public int ClientId
        {
            get
            {
                return clientId;
            }
            set
            {
                clientId = value;
            }
        }

        private string clientVersion = "";
        /// <summary>
        /// 客户端版本
        /// </summary>
        public string ClientVersion
        {
            get
            {
                return clientVersion;
            }
            set
            {
                clientVersion = value;
            }
        }

        private UTDatabaseInfo serverDatabaseInfo;
        /// <summary>
        /// 服务器用数据库信息
        /// </summary>
        public UTDatabaseInfo ServerDatabaseInfo
        {
            get
            {
                return serverDatabaseInfo;
            }
            set
            {
                serverDatabaseInfo = value;
            }
        }

        //private string serverDatabaseServerMachine = "";
        ///// <summary>
        ///// 数据库服务器机器名
        ///// </summary>
        //public string ServerDatabaseServerMachine
        //{
        //    get
        //    {
        //        return serverDatabaseServerMachine;
        //    }
        //    set
        //    {
        //        serverDatabaseServerMachine = value;
        //    }
        //}

        //private string serverDatabaseCatalog = "";
        ///// <summary>
        ///// 服务器数据库名
        ///// </summary>
        //public string ServerDatabaseCatalog
        //{
        //    get
        //    {
        //        return serverDatabaseCatalog;
        //    }
        //    set
        //    {
        //        serverDatabaseCatalog = value;
        //    }
        //}

        private string serverMachineName = "";
        /// <summary>
        /// 服务器机器名
        /// </summary>
        public string ServerMachineName
        {
            get
            {
                return serverMachineName;
            }
            set
            {
                serverMachineName = value;
            }
        }

        private string serverApplicationPath = "";
        /// <summary>
        /// 服务器应用程序启动路径
        /// </summary>
        public string ServerApplicationPath
        {
            get
            {
                return serverApplicationPath;
            }
            set
            {
                serverApplicationPath = value;
            }
        }

        private bool clientSideDatabaseAvailable;
        /// <summary>
        /// 客户端数据库连接是否可用
        /// </summary>
        public bool ClientSideDatabaseAvailable
        {
            get
            {
                return clientSideDatabaseAvailable;
            }
            set
            {
                clientSideDatabaseAvailable = value;
            }
        }


        public RunningSystemInfo()
        {
        }
    }


    /// <summary>
    /// 通讯用端口信息
    /// </summary>
    [Serializable]
    public class CommunicationPortInfo
    {
        private ChannelInfoType channelType;
        public ChannelInfoType ChannelType
        {
            get
            {
                return channelType;
            }
            set
            {
                channelType = value;
            }
        }

        private PortIconType portType;
        /// <summary>
        /// 传票端口类型
        /// </summary>
        public PortIconType PortType
        {
            get
            {
                return portType;
            }
            set
            {
                portType = value;
            }
        }

        private bool isPortOpened;
        /// <summary>
        /// 端口是否被打开
        /// </summary>
        public bool IsPortOpened
        {
            get
            {
                return isPortOpened;
            }
            set
            {
                isPortOpened = value;
            }
        }

        private bool isPortConnected;
        /// <summary>
        /// 端口是否处于连接状态
        /// </summary>
        public bool IsPortConnected
        {
            get
            {
                return isPortConnected;
            }
            set
            {
                isPortConnected = value;
            }
        }

        private bool reachable = true;
        /// <summary>
        /// 状态是否可以被访问到（是否客户端中断造成不能访问）
        /// </summary>
        public bool Reachable
        {
            get
            {
                return reachable;
            }
            set
            {
                reachable = value;
            }
        }


        public CommunicationPortInfo(PortIconType portClass, bool isOpened, bool isConnected)
            : this(ChannelInfoType.Communication, portClass, isOpened, isConnected)
        {
        }

        public CommunicationPortInfo(ChannelInfoType chlType, PortIconType portClass, bool isOpened, bool isConnected)
        {
            channelType = chlType;
            portType = portClass;
            isPortOpened = isOpened;
            isPortConnected = isConnected;
        }
    }

    /// <summary>
    /// 通讯用通道信息
    /// </summary>
    [Serializable]
    public class CommunicationChannelInfo
    {
        private int channelId = -1;
        /// <summary>
        /// 通道号
        /// </summary>
        public int ChannelId
        {
            get
            {
                return channelId;
            }
            set
            {
                channelId = value;
            }
        }

        private string channelName = "";
        /// <summary>
        /// 通道名
        /// </summary>
        public string ChannelName
        {
            get
            {
                return channelName;
            }
            set
            {
                channelName = value;
            }
        }

        private string protocolName = "";
        /// <summary>
        /// 协议名
        /// </summary>
        public string ProtocolName
        {
            get
            {
                return protocolName;
            }
            set
            {
                protocolName = value;
            }
        }

        private string clientName = "";
        public string ClientName
        {
            get
            {
                return clientName;
            }
            set
            {
                clientName = value;
            }
        }

        private CommunicationPortInfo portInfo;
        /// <summary>
        /// 通讯端口信息
        /// </summary>
        public CommunicationPortInfo PortInfo
        {
            get
            {
                return portInfo;
            }
            set
            {
                portInfo = value;
            }
        }

        [NonSerialized]
        private bool isOnDraw;
        /// <summary>
        /// 通道状态是否在接线图上显示
        /// </summary>
        public bool IsOnDraw
        {
            get
            {
                return isOnDraw;
            }
            set
            {
                isOnDraw = value;
            }
        }

        public CommunicationChannelInfo()
        {
        }

        public CommunicationChannelInfo(int chlId, string chlName, string chlClient)
        {
            channelId = chlId;
            channelName = chlName;
            clientName = chlClient;
        }

        private bool workableProtocol;
        /// <summary>
        /// 该通道的协议是否必须工作
        /// </summary>
        public bool WorkableProtocol
        {
            get
            {
                return workableProtocol;
            }
            set
            {
                workableProtocol = value;
            }
        }

        private bool isChannelWorking;
        /// <summary>
        /// 通道是否处于工作状态
        /// </summary>
        public bool IsChannelWorking
        {
            get
            {
                return isChannelWorking;
            }
            set
            {
                isChannelWorking = value;
            }
        }

        private ChannelStateChangeType stateChangeType = ChannelStateChangeType.Refresh;
        /// <summary>
        /// 该通道是否已经被移除
        /// </summary>
        public ChannelStateChangeType StateChangeType
        {
            get
            {
                return stateChangeType;
            }
            set
            {
                stateChangeType = value;
            }
        }

        private bool stateUnknown;
        /// <summary>
        /// 通道状态是否处于未知（不能获取）状态
        /// </summary>
        public bool StateUnknown
        {
            get
            {
                return stateUnknown;
            }
            set
            {
                stateUnknown = value;
            }
        }

        public int StateValue
        {
            get
            {
                if (StateUnknown)
                {
                    return 2;
                }
                if (IsChannelWorking)
                {
                    return 1;
                }
                return 0;
            }
        }

        private bool stationUnlocked;
        /// <summary>
        /// 是否站总解锁
        /// </summary>
        public bool StationUnlocked
        {
            get
            {
                return stationUnlocked;
            }
            set
            {
                stationUnlocked = value;
            }
        }

        private string registeredStation = "";
        public string RegisteredStation
        {
            get
            {
                return registeredStation;
            }
            set
            {
                registeredStation = value;
            }
        }

        private string logedUser = "";
        /// <summary>
        /// 当前是登录用户
        /// </summary>
        public string LogedUser
        {
            get
            {
                return logedUser;
            }
            set
            {
                logedUser = value;
            }
        }

        private int taskCount;
        /// <summary>
        /// 当前任务数
        /// </summary>
        public int TaskCount
        {
            get
            {
                return taskCount;
            }
            set
            {
                taskCount = value;
            }
        }

        private bool taskingNow;
        /// <summary>
        /// 该客户端是否正在开票
        /// </summary>
        public bool TaskingNow
        {
            get
            {
                return taskingNow;
            }
            set
            {
                taskingNow = value;
            }
        }

        //public override string ToString()
        //{
        //    return string.Format(string.Format("通道名：{0},通道号：{1},客户端：{2}", channelId, channelName, clientName));
        //}

        /// <summary>
        /// 纯通道名，异常后面的端口号
        /// </summary>
        /// <param name="chlName"></param>
        /// <returns></returns>
        static private string PureChannelName(string chlName)
        {
            if (!string.IsNullOrEmpty(chlName))
            {
                int idx = chlName.IndexOf(":");
                if (idx > 0)
                {
                    chlName = chlName.Substring(0, idx);
                }
                return chlName.Replace(" ", "");
            }
            return chlName;
        }
        /// <summary>
        /// 判断两个通道名是否相同，判断时不比较端口
        /// </summary>
        /// <param name="chlName"></param>
        /// <returns></returns>
        public bool ChannelNameEqual(string chlName)
        {
            if (portInfo != null && portInfo.PortType == PortIconType.TcpSocket)
            {
                return ChannelNameEqual(PureChannelName(channelName), PureChannelName(chlName));
            }
            return ChannelNameEqual(channelName, chlName);
        }

        /// <summary>
        /// 判断两个通道名是否相同
        /// </summary>
        /// <param name="name1"></param>
        /// <param name="name2"></param>
        /// <returns></returns>
        static private bool ChannelNameEqual(string name1, string name2)
        {
            if (!string.IsNullOrEmpty(name1) && !string.IsNullOrEmpty(name1))
            {
                return name1.Equals(name2, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }
    }

    /// <summary>
    /// 通道发送、接收数据信息
    /// </summary>
    [Serializable]
    public class ChannelCommunicationData : CommunicationChannelInfo
    {
        private bool sending;
        /// <summary>
        /// 是发送还是接收数据
        /// </summary>
        public bool SendingData
        {
            get
            {
                return sending;
            }
            set
            {
                sending = value;
            }
        }

        private int sequenceId;
        /// <summary>
        /// 数据顺序号
        /// </summary>
        public int SequenceId
        {
            get
            {
                return sequenceId;
            }
            set
            {
                sequenceId = value;
            }
        }

        private DateTime dataTime = DateTime.Now;
        /// <summary>
        /// 接收（发送）数据时间
        /// </summary>
        public DateTime DataTime
        {
            get
            {
                return dataTime;
            }
            set
            {
                dataTime = value;
            }
        }

        object data;
        /// <summary>
        /// 接收（发送）数据内容
        /// </summary>
        public object CommunicationData
        {
            get
            {

                return data;
            }
            //set
            //{
            //    data = value;
            //}
        }

        public ChannelCommunicationData(int chlId, string chlName, string chlClient, object attachedData)
            : base(chlId, chlName, chlClient)
        {
            data = attachedData;
        }

    }





    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes"), StructLayout(LayoutKind.Sequential)]
    public struct SystemTime
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMiliseconds;
    }

    [Serializable]
    public class MessageTable
    {
        private DataTable table;
        public DataTable Table
        {
            get
            {
                return table;
            }
        }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
        }
        public MessageTable(DataTable msgTable, string msgTitle)
        {
            table = msgTable;
            title = msgTitle;
        }


    }




    /// <summary>
    /// 通道用特殊功能信息
    /// </summary>
    [Serializable]
    public class ChannelSpecialFunctionInfo
    {
        private string callClient = "";
        /// <summary>
        /// 特殊功能调用的客户端
        /// </summary>
        public string CallingClient
        {
            get
            {
                return callClient;
            }
        }

        private int functionId;
        /// <summary>
        /// 功能id
        /// </summary>
        public int FunctionId
        {
            get
            {
                return functionId;
            }
        }
        private object functionPara;
        /// <summary>
        /// 特殊功能所需参数
        /// </summary>
        public object FunctionPara
        {
            get
            {
                return functionPara;
            }
            set
            {
                functionPara = value;
            }
        }

        private Guid waitingGuid;
        /// <summary>
        /// 等待结果的标示
        /// </summary>
        public Guid WaitingGuid
        {
            get
            {
                return waitingGuid;
            }
        }


        public ChannelSpecialFunctionInfo(string clientName, int funcId, object funcPara, Guid gui)
        {
            callClient = clientName;
            functionId = funcId;
            functionPara = funcPara;
            waitingGuid = gui;
        }

        public ChannelSpecialFunctionInfo(int funcId, object funcPara)
            : this("", funcId, funcPara, Guid.Empty)
        {
        }
    }








    #region 数据同步相关类

    /// <summary>
    /// 同步时返回该进度条相关信息
    /// </summary>
    public class SyncProgressInfo
    {
        private int position;
        /// <summary>
        /// 进度条位置
        /// </summary>
        public int Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        private int maxinum;
        /// <summary>
        /// 进度条最大值
        /// </summary>
        public int Maxinum
        {
            get
            {
                return maxinum;
            }

            set
            {
                maxinum = value;
            }
        }

        private int mininum;
        /// <summary>
        /// 进度条最小值
        /// </summary>
        public int Mininum
        {
            get
            {
                return mininum;
            }

            set
            {
                mininum = value;
            }
        }

        private string syncDesc;

        /// <summary>
        /// 同步信息描述
        /// </summary>
        public string SyncDesc
        {
            get
            {
                return syncDesc;
            }

            set
            {
                syncDesc = value;
            }
        }

    }

    /// <summary>
    /// 更新进度条信息和日志信息
    /// </summary>
    /// <param name="progressInfo"></param>
    public delegate void UpdateProgressInfoDelegate(SyncProgressInfo progressInfo);

    #endregion

   














}
