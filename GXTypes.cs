
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
    /// ���ݿ��Ƿ������Ϣ
    /// </summary>
    [Serializable]
    public class UTDatabaseInfo
    {
        private DatabaseTypes dbType;
        /// <summary>
        /// ���ݿ�����
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
        /// ������
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
        /// �����ı�
        /// </summary>
        public string Text
        {
            get
            {
                switch (code)
                {
                    case UTDatabaseInformationCode.Available:
                        return ("����");
                    case UTDatabaseInformationCode.Unchecked:
                        return ("��δ�����õ����ݿ���м��");
                    case UTDatabaseInformationCode.ConnectionChecking:
                        return ("���ڽ������Ӽ��");
                    case UTDatabaseInformationCode.NoConfigFile:
                        return ("���ݿ������ļ�������");
                    case UTDatabaseInformationCode.NoDefaultEnvironment:
                        return ("ȱʡ��������������");
                    case UTDatabaseInformationCode.MultiEnvironment:
                        return ("���ݿ⻷���ظ�����");
                    case UTDatabaseInformationCode.ConfigError:
                        return ("�����д���") + exceptionMessage;
                    case UTDatabaseInformationCode.NoEnvironment:
                        return ("��������������:") + dbEnv;
                    case UTDatabaseInformationCode.NotInstalled:
                        return ("δ��װ���ݿ�ϵͳ");
                    case UTDatabaseInformationCode.ConnectFailure:
                        return ("����ʧ��");
                    case UTDatabaseInformationCode.NoCatalog:
                        return string.Format(("���ݿ�:{0} ��δ����"), DatabaseCatalog);
                    default:
                        return ("UTDatabaseInfo����Ҫ��д��");

                }
            }
        }

        private string user = "";
        /// <summary>
        /// ���õĵ�¼�û�
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
        /// ��¼�û�����
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
        /// �Ƿ��Ǽ�����֤
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
        /// ���õ����ݿ⻷��
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
        /// ���ݿ���
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
        /// ���ݿ���������(Oracle��)
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
        /// �ϴ����Ӵ��еķ��������˿ڣ�����ȱʡ���Ӵ�������
        /// </summary>
        public static string PreviousDatabaseInstanceName = "";

        private string databaseInstanceName = "";
        /// <summary>
        /// ���ݿ������ʵ�����������ʵ�������˿ڣ�����Ҫָ���˿�ʱ��
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
        /// ���ݿ������
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
        /// ��׽�������������Ϣ
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
        /// DataProviderInvariantName,ȱʡ����Ҫ��ֵ
        /// ����������װ�ж��������ͨ����ֵ��ѡ�����е�һ��
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
    /// �������ϵͳ�Ĳ���������Ϣ
    /// </summary>
    sealed public class SystemSets
    {
        static private int matrixCountSupported = 18;       //ϵͳ��ÿ���豸�������������
        static private int matrixProprtyCount = 0x44;       //Ŀǰ�����������������  lym E��ͨ��Ϊ0x44
        //static private int bytesKeyCanDisplay = 250;        //1D����Կ�׿���ʾ���ַ���
        //static private int maxTaskCountEachStation = 6;

        /// <summary>
        /// ���ݿ���ÿ����¼�����������
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
        /// ÿ���豸����ʹ�õ����������룬ϵͳ��ͬ����Ҳ���ܲ�ͬ
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
        ///// ����Կ�׿���ʾ���ַ���
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
        ///// ÿ��վ�ɿ��������������
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
        ///// ��ȡ��������
        ///// </summary>
        ///// <param name="codeIdx">����λ�ñ��</param>
        ///// <param name="key">Կ������</param>
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
        /// ��־�ļ����
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
        /// ��־����
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
    /// ϵͳ��־��ȡ����
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
    /// �ͻ���ע����Ϣ
    /// </summary>
    [Serializable]
    sealed public class ClientRegistertingInformation
    {
        private JoyoClientClassification clientClass = JoyoClientClassification.Unknown;
        /// <summary>
        /// ע��ͻ�������
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
    /// һ���򵥵����ƣ�������ֵ��װ��
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
        /// ֵ
        /// </summary>
        public string KeyValue
        {
            get
            {
                return keyValue;
            }
        }
        /// <summary>
        /// ����
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
    /// ��ʾ���ݡ�ֵ��װ��,ǰ�涨���KeyValuePair����ȡ�����࣬��ģ������������Ա���
    /// </summary>
    [Serializable]
    public class DisplayValuePair
    {
        private string relatedValue;
        private string display;
        private string extraData;//��չ���� add by wdp for Σ�յ�����豸 2013-08-13

        public DisplayValuePair(string strDisplay, string strValue)
        {

            this.display = strDisplay;
            this.relatedValue = strValue;
        }

        //add by wdp for Σ�յ�����豸 2013-08-13
        /// <summary>
        /// ���캯��(�ഫ��һ����չ����)
        /// </summary>
        /// <param name="strDisplay">��ʾֵ</param>
        /// <param name="strValue">��ʵֵ</param>
        /// <param name="strExtraData">��չ����</param>
        public DisplayValuePair(string strDisplay, string strValue, string strExtraData)
        {
            this.display = strDisplay;
            this.relatedValue = strValue;
            this.extraData = strExtraData;
        }

        /// <summary>
        /// ��ʾ����
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
        /// ʵ��ֵ
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
        /// �豸���� add by wdp for Σ�յ�����豸 2013-08-13
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
    /// ��ʾ���ݡ�ֵ��װ��ļ���
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

        //add by wdp for Σ�յ�����豸 2013-08-13
        /// <summary>
        /// ������ʵֵ����չ���������Ƿ��й�������
        /// </summary>
        /// <param name="valueText">��ʵֵ</param>
        /// <param name="extraData">��չ����</param>
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

        //add by wdp for Σ�յ�����豸 2013-08-13
        /// <summary>
        /// ������ʾֵ����չ���������Ƿ��й�������
        /// </summary>
        /// <param name="displayText">��ʾֵ</param>
        /// <param name="extraData">��չ����</param>
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

        //add by wdp for Σ�յ�����豸 2013-08-13
        /// <summary>
        /// ������ʵֵ����չ������ȡ��ʾֵ
        /// </summary>
        /// <param name="valueText">��ʵֵ</param>
        /// <param name="extraData">��չ����</param>
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

        //add by wdp for Σ�յ�����豸 2013-08-13
        /// <summary>
        /// ������ʾֵ����չ������ȡ��ʵֵ
        /// </summary>
        /// <param name="displayText">��ʾֵ</param>
        /// <param name="extraData">��չ����</param>
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
        /// ������չ�����õ����ݼ� add by wdp for Σ�յ�����豸 2013-08-14
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
        /// ���Ǹñ�Ŀͻ���
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
        /// ������
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
        /// ��ṹ���
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
        /// �Ա������
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
        /// �Ƿ���ͨѶ��˳���
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
    /// �����������ͷ��ؽ������Ϣ
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
            return new BoolResult(false, string.Format("{0}����{1}", b1.Msg, b2.Msg));
        }
    }


    /// <summary>
    /// ����ϵͳ��Ϣ
    /// </summary>
    [Serializable]
    public class RunningSystemInfo
    {
        private int taskSystemId;
        /// <summary>
        /// ��ƱϵͳId�����ɲ���Ʊʱʹ��
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
        /// ��Ʊϵͳ���ͣ����ɲ���Ʊʱʹ��
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
        /// �����������������������
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
        /// �������汾
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
        /// �ͻ�����
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
        /// �ͻ���Id
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
        /// �ͻ��˰汾
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
        /// �����������ݿ���Ϣ
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
        ///// ���ݿ������������
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
        ///// ���������ݿ���
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
        /// ������������
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
        /// ������Ӧ�ó�������·��
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
        /// �ͻ������ݿ������Ƿ����
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
    /// ͨѶ�ö˿���Ϣ
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
        /// ��Ʊ�˿�����
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
        /// �˿��Ƿ񱻴�
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
        /// �˿��Ƿ�������״̬
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
        /// ״̬�Ƿ���Ա����ʵ����Ƿ�ͻ����ж���ɲ��ܷ��ʣ�
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
    /// ͨѶ��ͨ����Ϣ
    /// </summary>
    [Serializable]
    public class CommunicationChannelInfo
    {
        private int channelId = -1;
        /// <summary>
        /// ͨ����
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
        /// ͨ����
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
        /// Э����
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
        /// ͨѶ�˿���Ϣ
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
        /// ͨ��״̬�Ƿ��ڽ���ͼ����ʾ
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
        /// ��ͨ����Э���Ƿ���빤��
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
        /// ͨ���Ƿ��ڹ���״̬
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
        /// ��ͨ���Ƿ��Ѿ����Ƴ�
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
        /// ͨ��״̬�Ƿ���δ֪�����ܻ�ȡ��״̬
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
        /// �Ƿ�վ�ܽ���
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
        /// ��ǰ�ǵ�¼�û�
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
        /// ��ǰ������
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
        /// �ÿͻ����Ƿ����ڿ�Ʊ
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
        //    return string.Format(string.Format("ͨ������{0},ͨ���ţ�{1},�ͻ��ˣ�{2}", channelId, channelName, clientName));
        //}

        /// <summary>
        /// ��ͨ�������쳣����Ķ˿ں�
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
        /// �ж�����ͨ�����Ƿ���ͬ���ж�ʱ���Ƚ϶˿�
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
        /// �ж�����ͨ�����Ƿ���ͬ
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
    /// ͨ�����͡�����������Ϣ
    /// </summary>
    [Serializable]
    public class ChannelCommunicationData : CommunicationChannelInfo
    {
        private bool sending;
        /// <summary>
        /// �Ƿ��ͻ��ǽ�������
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
        /// ����˳���
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
        /// ���գ����ͣ�����ʱ��
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
        /// ���գ����ͣ���������
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
    /// ͨ�������⹦����Ϣ
    /// </summary>
    [Serializable]
    public class ChannelSpecialFunctionInfo
    {
        private string callClient = "";
        /// <summary>
        /// ���⹦�ܵ��õĿͻ���
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
        /// ����id
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
        /// ���⹦���������
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
        /// �ȴ�����ı�ʾ
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








    #region ����ͬ�������

    /// <summary>
    /// ͬ��ʱ���ظý����������Ϣ
    /// </summary>
    public class SyncProgressInfo
    {
        private int position;
        /// <summary>
        /// ������λ��
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
        /// ���������ֵ
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
        /// ��������Сֵ
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
        /// ͬ����Ϣ����
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
    /// ���½�������Ϣ����־��Ϣ
    /// </summary>
    /// <param name="progressInfo"></param>
    public delegate void UpdateProgressInfoDelegate(SyncProgressInfo progressInfo);

    #endregion

   














}
