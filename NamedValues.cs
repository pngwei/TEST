using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Drawing;

namespace GX.Common
{

    /// <summary>
    /// 常用常量
    /// </summary>
    static public class NamedConst
    {
        static private OSFamily operationSystem = OSFamily.Unknown;
        /// <summary>
        /// 运行系统的操作系统
        /// </summary>
        static public OSFamily OperationSystem
        {
            get
            {
                if (operationSystem == OSFamily.Unknown)
                {
            
                     operationSystem = OSFamily.Windows;

                }
                return operationSystem;
            }
        }

        static private JoyoServerApplicationRunMode serverStartMode = JoyoServerApplicationRunMode.WindowsApplication;
        /// <summary>
        /// 服务器的启动模式，此值在客户端无效
        /// </summary>
        static public JoyoServerApplicationRunMode ServerStartMode
        {
            get
            {
                return serverStartMode;
            }
            set
            {
                serverStartMode=value;
        
            }
        }

        static private Color joyojBKColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
        /// <summary>
        /// 系统底色
        /// </summary>
        static public Color JoyoJBackColor
        {
            get
            {
                return joyojBKColor;
            }
            set
            {
                joyojBKColor = value;
            }
        }

        static private bool isRunningOnMono = Type.GetType("Mono.Runtime") != null;
        /// <summary>
        /// 系统是否运行在Mono平台上
        /// </summary>
        static public bool IsRunningOnMono
        {
            get
            {
                return isRunningOnMono;
            }
        }

        public const int SystemAdministratorGroupId = 1000;         //系统调试员角色Id
        public const String DeviceNameField = "Name";               //遥信表中设备编号的字段名称
        public const int TaskSheetStructureId = 109;                //操作票表的结构编号
        public const int DisSheetStructureId = 111;                 //调度票表的结构编号
        public const int TaskLogStructureId = 110;                  //操作票记录表结构编号
        public const int TypicalTaskId = 230;                       //典型票、预存票结构编号
        public const int WlkzqStructureId = 87;                     //网络控制器配置表结构Id
        public const int YCInOGXTableStructureId = 86;              //遥测输入、输出顺序表Id
        public const int InOGXTableStructureId = 88;                //遥信输入、输出顺序表Id
        public const int SignatureLength = 366;                     //授权文件随机字节长度
        public const int StateSetTaskId = 999;                      // 对位时用的任务号
        //public const int BSByOtherTaskId = 1000;                    //被其他系统闭锁的起始任务号
        public const int HintProperty = 0x10;                       //缺省提示型信息属性
        //public const int LinkageOperationProperty = 0x0FFF;         //被联动操作的属性

        public const string WFServerDataArchiveTableName = "WFServerDataArchive"; //数据备份时用于保存服务文件的表名

        public const string ClientUpdateFileName = "ClientUpdate.zip";     //客户端用压缩升级包名


        

        public const int AbortLabel = 0;                            //显示位置
        public const int SystemInfoLabel = 1;                       //显示位置
        public const int ServerInfoLabel = 2;                       //服务器信息显示位置
        public const int StationInfoLabel = 3;                      //当前站信息显示位置
        public const int TaskInfoLabel = 4;                         //当前任务信息显示位置
        public const int ProgressBarLabel = 5;                      //进度条信息显示位置
        public const int LogonUserLabel = 6;                        //用户登录信息显示位置
        public const int UserMessageInfoLabel = 7;                  //用户消息
        public const int DrawInvalidState = 2000;                   //图形无效状态
        public const int DrawNoWorkingFirstState = 2001;            //图形未投运状态
        //public const int ConditionLimit = 100;                      //系统可以处理的最大条件数，超过此数，系统将按算符优先法计算

        public const string ChineseDateFormat = "yyyy年M月d日";
        public const string ChineseDateTimeFormat = "yyyy年M月d日 H时m分s秒";

        public const string SystemName = "GX-J";         //本系统的名字，跟外系统交互时用，比如web平台

        public const int JsDoorDNBS = 0x3FB;         //江苏门禁系统定义的门的闭锁属性
        
        public const int GzpFinishedFlowStepId = 1000;   //工作票审批流程完毕的步骤ID 
        public static string PCWFServerConsoleName
        {
            get
            { 
                return "PC服务器控制台";    //PC服务器标识
            }
        }

        public const string inJoyoServerSeviceName = "PCService";      //五防系统服务名称
        public const string inJoyoCommunicationServiceName = "CommunicationService";  //通信服务名称
        public static string extJoyoServerSeviceName = "";
        public static string extJoyoCommunicationServiceName = "";
        public static string JoyoServerSeviceName
        {
            get
            {
                return inJoyoServerSeviceName + extJoyoServerSeviceName;      //五防系统服务名称
            }
        }

        public static string JoyoCommunicationServiceName
        {
            get
            {
                return inJoyoCommunicationServiceName + extJoyoServerSeviceName;      //五防系统服务名称
            }
        }

        //public const string JoyoCommunicationServiceName = "JOYOCommunicationService";  //通信服务名称

        public static string CommunicationClientName
        {
            get
            {
                return "通讯客户端";                     //通讯客户端名
            }
        }

        public const string ClientLocalParameterFileName = "LocalParameters";           //客户端配置文件名
        public const string ServerLocalParameterFileName = "LocalParametersServer";     //服务器配置文件名
        public const string CommunicationConfigFileName = "CommunicationChannels.txt";  //通道通道配置文件名


        public const string GraphicFileInfoSelectCmd = "select RUNMODE_ID,SHOWORDER,GRAPHTYPE_ID,STATION,GRAPHNAME,GRAPHPATH,MD5,WriteTime,Client1,Client2,Client3,Client4,Client5,Client6,Client7,GroupName,HideMenu,GraphType,HideInWebMenu,WriteUser,GraphFileVer,GraphFormatVer from GraphFileInfo";//add by lxg for 一匙通 2012.8.7 //add by bx 2014.9.18 for增加版本信息

        //下面的静态变量不符合使用规范 CA2211，因值不会频繁改动而保留
        static public int UnoccupiedTaskId;                         //表示没有关联任务的特定（任务）编号，有些系统是-1
        static public bool ExpertSystem = true;                     //有操作票专家系统的功能
        static public bool InterlockSystem = true;                  //有“五防”功能
        static public bool ElecSystem = true;                       //有电子票功能
        static public int DefaultTaskTermTemplate = 1;              //缺省操作票术语生成模板
        static public bool ExtendedSpecialCharacter;                //操作术语的特殊字符是否被扩展
        static public bool DeviceMultiStationMode;                  //系统中是否有设备属于多个站
        static public Collection<string> MultiDeviceStation;        //包含多站设备的站
        static public Collection<string> MultiStationDevice;        //多站共享的设备
        static public Collection<string> RelatedStations;           //关联站（根据设备信息获得）
        static public readonly byte[] Entropy = { 24, 8, 19, 3, 2, 7 };
        //最多支持到三态操作时，操作前后状态表
        static public readonly int[,] CommonOperationPathes = new int[,] { { 0, 1 }, { 0, 2 }, { 1, 0 }, { 1, 2 }, { 2, 0 }, { 2, 1 } };
    
        public const string HistorylogBackTableName = "HistoryLogbak"; //原始索引票表的备份表名

        static private int screenIdx;

        public static int GzpSpecialId = -1; ///工作票专业ID值
        /// <summary>
        /// 客户端界面所用显示器
        /// </summary>
        static public int ScreenIndex
        {
            get
            {
                return screenIdx;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value >= Screen.AllScreens.Length)
                {
                    value = Screen.AllScreens.Length - 1;
                }
                screenIdx = value;
            }
        }
        static public int ScreenLocationOffsetX
        {
            get
            {
                int w = 0;
                for (int i = 0; i < screenIdx; i++)
                {
                    w += Screen.AllScreens[i].WorkingArea.Width;
                }
                return w;
            }
        }

        static bool newCreatedDatabase = false;
        /// <summary>
        /// 连接的数据库是否是新创建的
        /// </summary>
        static public bool NewCreatedDatabase
        {
            get
            {
                return newCreatedDatabase;
            }
            set
            {
                newCreatedDatabase = value;
            }
        }

    }

    /// <summary>
    /// 被观察的表的记录变化数
    /// </summary>
    static public class NamedIntegers
    {
        static public int WatchedTableRecordChangeCount;
    }


    /// <summary>
    /// 系统中使用的命名的字串，这些串除被用于显示外还用在了串的比较
    /// 多语言时需要这些串更改（初始化）为相应的语言
    /// </summary>
    static public class NamedStrings
    {

        static public string FieldInfoName = "FieldInfo";			//表字段数据库的名称	
        static public string TableInfoName = "TableInfo";
        static public string IndexInfoName = "IndexInfo";


        public static string NoLogic
        {
            get
            {
                return "无逻辑";    //PC服务器标识
            }
        }

        public static string DrawStartShowMode
        {
            get
            {
                return "缺省启动画面";    //PC服务器标识
            }
        }

        public static string TopologyAnalysis
        {
            get
            {
               return "拓扑分析：";    //PC服务器标识
            }
        }
        static public string ChineseDateTimePrintFormat = "yyyy年MM月dd日 HH时mm分ss秒";
        static public string EnglishUSDateTimePrintFormat = "yyyy.MM.dd. HH:mm:ss";
        /// <summary>
        /// 设备等命名时的无效字符，该值可在服务器参数表中修改
        /// </summary>
        static public string NameExcludedCharacters = "`~$%^&* |/,.;<>[]{}()=+，\"'\\";  //注意：图元名应允许使用-#及:

        /// <summary>
        /// 启动时指定的客户端名称（快捷键参数指定的客户端名称），在同一台计算机上启动多个客户端时发生
        /// 启动参数定义如下：
        /// 参数1 界面风格 0-缺省、1-老IV型风格、2-触摸屏、3-触摸屏新、10-手持地线、11、跟Web浏览平台交互的客户端
        /// 参数2 客户端标记名
        /// 参数3 所用显示器（从0开始编号）
        /// </summary>
        static public string StartLocalTag = "";

        ///// <summary>
        ///// 不需要上传或升级的文件
        ///// </summary>
        //static public string[] UnupdatableFiles = new string[] { "System.Data.SQLite.DLL" };


        /// <summary>
        /// 系统标志，可根据需要进行配置
        /// </summary>
        static public string SystemLogo = "joyojlogo.png";

        /// <summary>
        /// 企业标志，可根据需要进行配置
        /// </summary>
        static public string CompanyLogo = "unitechlogo.png";

        /// <summary>
        /// 系统标示文本，可根据需要进行配置
        /// </summary>
        static public string SystemLogoText = "GX-J";     

        /// <summary>
        /// 通过启动参数或配置文件指定的显示接线图
        /// </summary>
        static public string StartDrawName = "";

        static private string dllPath = "";
        /// <summary>
        /// 应用程序的启动路径
        /// </summary>
        static public string ApplicationPath
        {
            get
            {
                if(string.IsNullOrEmpty(dllPath))
                {
                    dllPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                }
                return dllPath;
            }
            set
            {
                dllPath = value;
            }
        }

    }

    static public class JoyoRegisteredServiceName
    {
       public const string  FWService="RemotePCService";
       public const string DBService = "DatabaseService";
       public const string FileService = "FileService";

        
    }

}
