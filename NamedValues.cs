using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Drawing;

namespace GX.Common
{

    /// <summary>
    /// ���ó���
    /// </summary>
    static public class NamedConst
    {
        static private OSFamily operationSystem = OSFamily.Unknown;
        /// <summary>
        /// ����ϵͳ�Ĳ���ϵͳ
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
        /// ������������ģʽ����ֵ�ڿͻ�����Ч
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
        /// ϵͳ��ɫ
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
        /// ϵͳ�Ƿ�������Monoƽ̨��
        /// </summary>
        static public bool IsRunningOnMono
        {
            get
            {
                return isRunningOnMono;
            }
        }

        public const int SystemAdministratorGroupId = 1000;         //ϵͳ����Ա��ɫId
        public const String DeviceNameField = "Name";               //ң�ű����豸��ŵ��ֶ�����
        public const int TaskSheetStructureId = 109;                //����Ʊ��Ľṹ���
        public const int DisSheetStructureId = 111;                 //����Ʊ��Ľṹ���
        public const int TaskLogStructureId = 110;                  //����Ʊ��¼��ṹ���
        public const int TypicalTaskId = 230;                       //����Ʊ��Ԥ��Ʊ�ṹ���
        public const int WlkzqStructureId = 87;                     //������������ñ�ṹId
        public const int YCInOGXTableStructureId = 86;              //ң�����롢���˳���Id
        public const int InOGXTableStructureId = 88;                //ң�����롢���˳���Id
        public const int SignatureLength = 366;                     //��Ȩ�ļ�����ֽڳ���
        public const int StateSetTaskId = 999;                      // ��λʱ�õ������
        //public const int BSByOtherTaskId = 1000;                    //������ϵͳ��������ʼ�����
        public const int HintProperty = 0x10;                       //ȱʡ��ʾ����Ϣ����
        //public const int LinkageOperationProperty = 0x0FFF;         //����������������

        public const string WFServerDataArchiveTableName = "WFServerDataArchive"; //���ݱ���ʱ���ڱ�������ļ��ı���

        public const string ClientUpdateFileName = "ClientUpdate.zip";     //�ͻ�����ѹ����������


        

        public const int AbortLabel = 0;                            //��ʾλ��
        public const int SystemInfoLabel = 1;                       //��ʾλ��
        public const int ServerInfoLabel = 2;                       //��������Ϣ��ʾλ��
        public const int StationInfoLabel = 3;                      //��ǰվ��Ϣ��ʾλ��
        public const int TaskInfoLabel = 4;                         //��ǰ������Ϣ��ʾλ��
        public const int ProgressBarLabel = 5;                      //��������Ϣ��ʾλ��
        public const int LogonUserLabel = 6;                        //�û���¼��Ϣ��ʾλ��
        public const int UserMessageInfoLabel = 7;                  //�û���Ϣ
        public const int DrawInvalidState = 2000;                   //ͼ����Ч״̬
        public const int DrawNoWorkingFirstState = 2001;            //ͼ��δͶ��״̬
        //public const int ConditionLimit = 100;                      //ϵͳ���Դ�������������������������ϵͳ����������ȷ�����

        public const string ChineseDateFormat = "yyyy��M��d��";
        public const string ChineseDateTimeFormat = "yyyy��M��d�� Hʱm��s��";

        public const string SystemName = "GX-J";         //��ϵͳ�����֣�����ϵͳ����ʱ�ã�����webƽ̨

        public const int JsDoorDNBS = 0x3FB;         //�����Ž�ϵͳ������ŵı�������
        
        public const int GzpFinishedFlowStepId = 1000;   //����Ʊ����������ϵĲ���ID 
        public static string PCWFServerConsoleName
        {
            get
            { 
                return "PC����������̨";    //PC��������ʶ
            }
        }

        public const string inJoyoServerSeviceName = "PCService";      //���ϵͳ��������
        public const string inJoyoCommunicationServiceName = "CommunicationService";  //ͨ�ŷ�������
        public static string extJoyoServerSeviceName = "";
        public static string extJoyoCommunicationServiceName = "";
        public static string JoyoServerSeviceName
        {
            get
            {
                return inJoyoServerSeviceName + extJoyoServerSeviceName;      //���ϵͳ��������
            }
        }

        public static string JoyoCommunicationServiceName
        {
            get
            {
                return inJoyoCommunicationServiceName + extJoyoServerSeviceName;      //���ϵͳ��������
            }
        }

        //public const string JoyoCommunicationServiceName = "JOYOCommunicationService";  //ͨ�ŷ�������

        public static string CommunicationClientName
        {
            get
            {
                return "ͨѶ�ͻ���";                     //ͨѶ�ͻ�����
            }
        }

        public const string ClientLocalParameterFileName = "LocalParameters";           //�ͻ��������ļ���
        public const string ServerLocalParameterFileName = "LocalParametersServer";     //�����������ļ���
        public const string CommunicationConfigFileName = "CommunicationChannels.txt";  //ͨ��ͨ�������ļ���


        public const string GraphicFileInfoSelectCmd = "select RUNMODE_ID,SHOWORDER,GRAPHTYPE_ID,STATION,GRAPHNAME,GRAPHPATH,MD5,WriteTime,Client1,Client2,Client3,Client4,Client5,Client6,Client7,GroupName,HideMenu,GraphType,HideInWebMenu,WriteUser,GraphFileVer,GraphFormatVer from GraphFileInfo";//add by lxg for һ��ͨ 2012.8.7 //add by bx 2014.9.18 for���Ӱ汾��Ϣ

        //����ľ�̬����������ʹ�ù淶 CA2211����ֵ����Ƶ���Ķ�������
        static public int UnoccupiedTaskId;                         //��ʾû�й���������ض������񣩱�ţ���Щϵͳ��-1
        static public bool ExpertSystem = true;                     //�в���Ʊר��ϵͳ�Ĺ���
        static public bool InterlockSystem = true;                  //�С����������
        static public bool ElecSystem = true;                       //�е���Ʊ����
        static public int DefaultTaskTermTemplate = 1;              //ȱʡ����Ʊ��������ģ��
        static public bool ExtendedSpecialCharacter;                //��������������ַ��Ƿ���չ
        static public bool DeviceMultiStationMode;                  //ϵͳ���Ƿ����豸���ڶ��վ
        static public Collection<string> MultiDeviceStation;        //������վ�豸��վ
        static public Collection<string> MultiStationDevice;        //��վ������豸
        static public Collection<string> RelatedStations;           //����վ�������豸��Ϣ��ã�
        static public readonly byte[] Entropy = { 24, 8, 19, 3, 2, 7 };
        //���֧�ֵ���̬����ʱ������ǰ��״̬��
        static public readonly int[,] CommonOperationPathes = new int[,] { { 0, 1 }, { 0, 2 }, { 1, 0 }, { 1, 2 }, { 2, 0 }, { 2, 1 } };
    
        public const string HistorylogBackTableName = "HistoryLogbak"; //ԭʼ����Ʊ��ı��ݱ���

        static private int screenIdx;

        public static int GzpSpecialId = -1; ///����ƱרҵIDֵ
        /// <summary>
        /// �ͻ��˽���������ʾ��
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
        /// ���ӵ����ݿ��Ƿ����´�����
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
    /// ���۲�ı�ļ�¼�仯��
    /// </summary>
    static public class NamedIntegers
    {
        static public int WatchedTableRecordChangeCount;
    }


    /// <summary>
    /// ϵͳ��ʹ�õ��������ִ�����Щ������������ʾ�⻹�����˴��ıȽ�
    /// ������ʱ��Ҫ��Щ�����ģ���ʼ����Ϊ��Ӧ������
    /// </summary>
    static public class NamedStrings
    {

        static public string FieldInfoName = "FieldInfo";			//���ֶ����ݿ������	
        static public string TableInfoName = "TableInfo";
        static public string IndexInfoName = "IndexInfo";


        public static string NoLogic
        {
            get
            {
                return "���߼�";    //PC��������ʶ
            }
        }

        public static string DrawStartShowMode
        {
            get
            {
                return "ȱʡ��������";    //PC��������ʶ
            }
        }

        public static string TopologyAnalysis
        {
            get
            {
               return "���˷�����";    //PC��������ʶ
            }
        }
        static public string ChineseDateTimePrintFormat = "yyyy��MM��dd�� HHʱmm��ss��";
        static public string EnglishUSDateTimePrintFormat = "yyyy.MM.dd. HH:mm:ss";
        /// <summary>
        /// �豸������ʱ����Ч�ַ�����ֵ���ڷ��������������޸�
        /// </summary>
        static public string NameExcludedCharacters = "`~$%^&* |/,.;<>[]{}()=+��\"'\\";  //ע�⣺ͼԪ��Ӧ����ʹ��-#��:

        /// <summary>
        /// ����ʱָ���Ŀͻ������ƣ���ݼ�����ָ���Ŀͻ������ƣ�����ͬһ̨���������������ͻ���ʱ����
        /// ���������������£�
        /// ����1 ������ 0-ȱʡ��1-��IV�ͷ��2-��������3-�������¡�10-�ֳֵ��ߡ�11����Web���ƽ̨�����Ŀͻ���
        /// ����2 �ͻ��˱����
        /// ����3 ������ʾ������0��ʼ��ţ�
        /// </summary>
        static public string StartLocalTag = "";

        ///// <summary>
        ///// ����Ҫ�ϴ����������ļ�
        ///// </summary>
        //static public string[] UnupdatableFiles = new string[] { "System.Data.SQLite.DLL" };


        /// <summary>
        /// ϵͳ��־���ɸ�����Ҫ��������
        /// </summary>
        static public string SystemLogo = "joyojlogo.png";

        /// <summary>
        /// ��ҵ��־���ɸ�����Ҫ��������
        /// </summary>
        static public string CompanyLogo = "unitechlogo.png";

        /// <summary>
        /// ϵͳ��ʾ�ı����ɸ�����Ҫ��������
        /// </summary>
        static public string SystemLogoText = "GX-J";     

        /// <summary>
        /// ͨ�����������������ļ�ָ������ʾ����ͼ
        /// </summary>
        static public string StartDrawName = "";

        static private string dllPath = "";
        /// <summary>
        /// Ӧ�ó��������·��
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
