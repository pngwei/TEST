
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace GX.Common
{

    //�ļ�  WFTypesEnumesPart1.cs ��WFTypesEnumesPart2.cs ����������ö������
    //      WFTypesEnumesPart1.cs �е��������ֹ������
    //      WFTypesEnumesPart2.cs �е��������ɹ����Զ����ɵ�

    public enum OSFamily { Unknown, Windows, Uniux, Apple };


    /// <summary>
    /// ����������ģʽ
    /// </summary>
    public enum JoyoServerApplicationRunMode
    {
        /// <summary>
        /// δ֪
        /// </summary>
        Unknown,
        /// <summary>
        /// Windows����
        /// </summary>
        WindowService,
        /// <summary>
        /// WindowsӦ�ó���
        /// </summary>
        WindowsApplication,
        /// <summary>
        /// Linux����
        /// </summary>
        LinuxDaemon,
        /// <summary>
        /// LinuxӦ�ó���
        /// </summary>
        LinuxApplication
    }


    public enum DatabaseTypes { Unknown, Sql, Oracle, MySql, Sqlite };

    /// <summary>
    /// ���ݿ������Ϣ����
    /// </summary>
    public enum UTDatabaseInformationCode
    {
        /// <summary>
        /// ���ݿ����
        /// </summary>
        Available,
        /// <summary>
        /// ��δ�����õ����ݿ���м��
        /// </summary>
        Unchecked,
        /// <summary>
        /// ���ڽ������Ӽ��
        /// </summary>
        ConnectionChecking,
        /// <summary>
        /// ���ݿ������ļ�������
        /// </summary>
        NoConfigFile,
        /// <summary>
        /// ȱʡ��������������
        /// </summary>
        NoDefaultEnvironment,
        /// <summary>
        /// ��������������
        /// </summary>
        NoEnvironment,
        /// <summary>
        /// ���������ظ�
        /// </summary>
        MultiEnvironment,
        /// <summary>
        /// �����д���
        /// </summary>
        ConfigError,
        /// <summary>
        /// δ��װ���ݿ�ϵͳ
        /// </summary>
        NotInstalled,
        /// <summary>
        /// ����ʧ��
        /// </summary>
        ConnectFailure,
        /// <summary>
        /// ָ�������ݿ���δ����
        /// </summary>
        NoCatalog
    }

    /// <summary>
    /// ͨ����Ϣ����
    /// </summary>
    public enum ChannelInfoType
    {
        /// <summary>
        /// δ֪
        /// </summary>
        Unknown,
        /// <summary>
        /// ͨѶͨ��
        /// </summary>
        Communication,
        /// <summary>
        /// �ͻ���ͨ��
        /// </summary>
        JoyoClient,
        /// <summary>
        /// ������ͨ��
        /// </summary>
        JoyoSever
    }

    /// <summary>
    /// ͨ��״̬�仯����
    /// </summary>
    public enum ChannelStateChangeType
    {
        /// <summary>
        /// ״̬ˢ��
        /// </summary>
        Refresh,
        /// <summary>
        /// ͨ������
        /// </summary>
        Added,
        /// <summary>
        /// ͨ���Ƴ�
        /// </summary>
        Removed
    }

    /// <summary>
    /// �ͻ���ע����Ϣ����
    /// </summary>
    public enum ClientRegisterInfoType
    {
        /// <summary>
        /// ע��
        /// </summary>
        Register,
        /// <summary>
        /// ע��
        /// </summary>
        Unregister,
        /// <summary>
        /// �ж�
        /// </summary>
        LostConnection,
        /// <summary>
        /// ���ӻָ�
        /// </summary>
        ResumeConnection,
        /// <summary>
        /// ע�ᣨ�л���վ
        /// </summary>
        RegisterStation
    }

    /// <summary>
    ///  ��Ʊͨ������ͼ������
    /// </summary>
    public enum PortIconType
    {
        /// <summary>
        /// ��ͼ��
        /// </summary>
        None,
        /// <summary>
        /// ����ֱ��ִ��ͼ��
        /// </summary>
        ExecGXe,
        /// <summary>
        /// ����
        /// </summary>
        RS232,
        TcpServer,
        TcpClient,
        Udp,
        /// <summary>
        /// ��Ʊ��ģ����
        /// </summary>
        RemoteScreen,
        RemotePC,
        /// <summary>
        /// ����Modem
        /// </summary>
        Modem,
        /// <summary>
        /// ����
        /// </summary>
        Wireless,
        Cdma,
        Gprs,
        /// <summary>
        /// ͨѶ��
        /// </summary>
        Rtu,
        Usb,
        TcpSocket,
        /// <summary>
        /// ����ͨ��
        /// </summary>
        Shared,
        /// <summary>
        /// ����
        /// </summary>
        Bluetooth
    }


    /// <summary>
    /// ���ϵͳ�����Զ�������
    /// </summary>
    public enum CustomServiceCommand
    {
        SetJoyoPCServerWrapperInstance,
    }

    /// <summary>
    /// ���������״̬
    /// </summary>
    public enum WFServerState
    {
        /// <summary>
        /// ͨ���Ͽ�
        /// </summary>
        Disconnected,
        /// <summary>
        /// ���������������ͨ
        /// </summary>
        Connected,
        /// <summary>
        /// ���������������ʱ�ж�
        /// </summary>
        Break,
        /// <summary>
        /// �������ر�
        /// </summary>
        ServerClosed,
        /// <summary>
        /// ���ʴ���ر�
        /// </summary>
        ProxyClosed,
        /// <summary>
        /// ��������������
        /// </summary>
        ServerRestarting,
        /// <summary>
        /// ����������ʧ��
        /// </summary>
        ServerStartError,
        /// <summary>
        /// ֹͣ������ʧ��
        /// </summary>
        ServerStoppedError,
    }








    ///// <summary>
    ///// �û�У�鷽ʽ
    ///// </summary>
    //public enum UserVerifyMode
    //{
    //    /// <summary>
    //    /// ���뷽ʽ
    //    /// </summary>
    //    Password = 0,
    //    /// <summary>
    //    /// ָ�Ʒ�ʽ
    //    /// </summary>
    //    FingerPrint = 1,
    //    /// <summary>
    //    /// ��Ĥ
    //    /// </summary>
    //    Iris=2,
    //    /// <summary>
    //    /// �Ѿ������֤
    //    /// </summary>
    //    Verfied = 9
    //}


    ///// <summary>
    ///// �������������������ģʽ(�������������ض������С�������ʱ����))
    ///// </summary>
    //[FlagsAttribGXe]
    //public enum JoyoServerRunMode
    //{
    //    /// <summary>
    //    /// δ����
    //    /// </summary>
    //    Undefined = 0,
    //    /// <summary>
    //    /// ����������Զ�̷�������
    //    /// </summary>
    //    RemoteServer = 0x01,
    //    /// <summary>
    //    /// ���ط������������棩
    //    /// </summary>
    //    LocalServer = 0x02,
    //    /// <summary>
    //    /// ���ر��÷��������ͻ��˶������У�
    //    /// </summary>
    //    LocalStandby = 0x04,
    //    ///// <summary>
    //    ///// ��ʱ����
    //    ///// </summary>
    //    //Temporary
    //}



    /// <summary>
    /// ��������ͻ��˷���
    /// </summary>
    public enum JoyoClientClassification
    {
        /// <summary>
        /// δ��������
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// ģ�����ͻ���
        /// </summary>
        Screen = 1,
        /// <summary>
        /// PC���ͻ���
        /// </summary>
        CompGXer = 2,
        /// <summary>
        /// ��������PC���ϵͳ
        /// </summary>
        StandAloneCompGXer = 3,
        /// <summary>
        /// GX-200IV��
        /// </summary>
        StandAlongGX200IV = 4,

        /// <summary>
        /// �������е�ģ���������ػ��������
        /// </summary>
        StandAloneScreen = 90,
        /// <summary>
        /// �������е�����ģ����
        /// </summary>
        StandAloneUnitechScreen = 100,
        /// <summary>
        /// �������еĹ���ģ����
        /// </summary>
        StandAloneContrlScreen = 110,
        /// <summary>
        /// ����
        /// </summary>
        StandAloneTuoXin = 120,
        /// <summary>
        /// �������е�����ģ����
        /// </summary>
        StandAloneNariScreen = 130,
        /// <summary>
        /// �差
        /// </summary>
        StandAloneXiangFan = 140,
        /// <summary>
        /// ����ģ����
        /// </summary>
        StandAloneJinZhouScreen = 150,

        #region wangjinhui Added at 20160428
        /// <summary>
        /// ��׿Ӧ�ÿͻ���
        /// </summary>
        AndroidApp = 151,
        /// <summary>
        /// IOSӦ�ÿͻ���
        /// </summary>
        IOSApp = 152,
        /// <summary>
        /// WPӦ�ÿͻ���
        /// </summary>
        WPApp = 153,
        /// <summary>
        /// Linux����ͻ���
        /// </summary>
        LinuxDesktop = 154,
        /// <summary>
        /// Windows����ͻ���
        /// </summary>
        WindowsDesktop = 155,
        /// <summary>
        /// Mac����ͻ���
        /// </summary>
        MacDesktop = 156,
        /// <summary>
        /// Est����Ӧ��App
        /// </summary>
        EstNavigationApp = 157,
        /// <summary>
        /// Web������ͻ���
        /// </summary>
        WebBrowser = 158,
        #endregion
    }



    /// <summary>
    /// PC�ͻ�������
    /// </summary>
    public enum ClientType
    {
        /// <summary>
        /// �ܾ�
        /// </summary>
        Deny = -1,
        /// <summary>
        /// δ����
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// վ��
        /// </summary>
        OneStationMode = 1,
        /// <summary>
        /// ����ģʽ1
        /// </summary>
        MultiStationMode1 = 2,
        /// <summary>
        /// ����ģʽ2
        /// </summary>
        MultiStationMode2 = 3,
        /// <summary>
        /// ����ģʽ3
        /// </summary>
        MultiStationMode3 = 4,
        /// <summary>
        /// ����ģʽ4
        /// </summary>
        MultiStationMode4 = 5,
        /// <summary>
        /// ����ģʽ5
        /// </summary>
        MultiStationMode5 = 6,
        /// <summary>
        /// ����ģʽ6
        /// </summary>
        MultiStationMode6 = 7,
        /// <summary>
        /// ����ģʽ7
        /// </summary>
        MultiStationMode7 = 8,
        /// <summary>
        /// ����վģʽ
        /// </summary>
        AllStationMode = 100
    }

    /// <summary>
    /// �ͻ���ע����
    /// </summary>
    public enum ClientRegistrationResult
    {
        /// <summary>
        /// ������������
        /// </summary>
        ServerUnavailable,
        /// <summary>
        /// δ��Ȩ�ͻ���
        /// </summary>
        Unauthorized,
        /// <summary>
        /// ��δע�ᣬ�ָ�����ʱʹ��
        /// </summary>
        Unregistered,
        /// <summary>
        /// �Ѿ�ע��Ŀͻ��˳����涨������
        /// </summary>
        OverLimit,
        /// <summary>
        /// �ͻ����Ѿ�ע��
        /// </summary>
        RegistedAlready,
        /// <summary>
        /// �ͻ�����������汾��һ��
        /// </summary>
        IncorrectVersion,
        /// <summary>
        /// ע��ɹ�
        /// </summary>
        Success
    }

    /// <summary>
    /// ���������������ִ�л�������
    /// </summary>
    public enum DeviceLockUnlockOperator
    {
        /// <summary>
        /// Ӳ������������
        /// </summary>
        Hardware,
        /// <summary>
        /// �������������
        /// </summary>
        SoftWare
    }

    /// <summary>
    /// ��÷������¼�����
    /// </summary>
    public enum WFServerEventType
    {
        /// <summary>
        /// �豸״̬�����仯
        /// </summary>
        DeviceStateChange,
        /// <summary>
        /// ң��ֵ�����仯
        /// </summary>
        YCValueChange,
        /// <summary>
        /// ��������Ϣ
        /// </summary>
        ServerInformation,
        /// <summary>
        /// �ͻ�����Ϣ
        /// </summary>
        ClientInformation
    }



    /// <summary>
    /// Remotingͨ�����Ͷ���
    /// </summary>
    public enum RemotingChannelType
    {
        /// <summary>
        /// δ��
        /// </summary>
        Unsued = -2,
        /// <summary>
        /// δ֪
        /// </summary>
        Unknown = -1,
        Tcp = 0,
        Http = 1,
        Ipc = 2,
        Rs232 = 3,
        //Cdma
        Btcp = 4
    }

    public enum SystemActivationMode
    {
        /// <summary>
        /// �����뷽ʽ����
        /// </summary>
        Code = 0,
        /// <summary>
        /// ϵ�кŷ�ʽ
        /// </summary>
        Serial = 1,
        /// <summary>
        /// ���ܹ���ʽ
        /// </summary>
        Dog = 2,
        /// <summary>
        /// ����
        /// </summary>
        Trial = 3,
        /// <summary>
        /// ������2��ʽ����
        /// </summary>
        Code2 = 4,
        /// <summary>
        /// �Ѿ�����
        /// </summary>
        Actived = 10,
        /// <summary>
        /// ��Ȩ�ļ�ʧЧ
        /// </summary>
        Expired = 11,
        /// <summary>
        /// ���ܹ�ʧЧ
        /// </summary>
        DogLocked = 12,
        /// <summary>
        /// �Ѿ����ϵ���Ȩ�ļ���ʽ
        /// </summary>
        Obsoleted = 13
    }

    /// <summary>
    /// �ӷ�������ȡ�ļ������Ͷ���
    /// </summary>
    public enum FileReadType
    {
        /// <summary>
        /// �ض��ļ�����������������
        /// </summary>
        Special = 0,
        /// <summary>
        /// ϵͳ·���µ��ļ�
        /// </summary>
        System = 1,
        /// <summary>
        /// ����·���µ��ļ�
        /// </summary>
        Data = 2,
        /// <summary>
        /// �����ļ�
        /// </summary>
        ClientUpdate = 3,
        /// <summary>
        /// ��װ�ļ�
        /// </summary>
        Install = 4,
        /// <summary>
        /// ����·��
        /// </summary>
        AbsolGXe = 5,
        /// <summary>
        /// �������·��
        /// </summary>
        RelativeToData = 6,
        /// <summary>
        /// �൱ϵͳ·��
        /// </summary>
        RelativeToSystem = 7,
        /// <summary>
        /// ϵͳ����
        /// </summary>
        SystemUpdate

    }




    /// <summary>
    /// ͨѶͨ���û�ȷ�����
    /// </summary>
    public enum ChannelStateConfirmValue
    {
        Uninitialied = 0,
        NotConfirmed = 1,
        Confirmed = 2
    }

    /// <summary>
    /// ͻ����ʾ������������
    /// </summary>
    public enum StressShowType
    {
        /// <summary>
        /// ��
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// ������ʾ
        /// </summary>
        Normal = 1,
        /// <summary>
        ///���� 
        /// </summary>
        Bold = 2,
        /// <summary>
        /// б��
        /// </summary>
        Italic = 3,
        /// <summary>
        /// ����б��
        /// </summary>
        BoldItalic = 4,
    }


    /// <summary>
    /// ϵͳ��־����
    /// </summary>
    public enum SystemLogType
    {
        /// <summary>
        /// δ����
        /// </summary>
        [Description("δ����")]
        None = 0,
        /// <summary>
        /// �û�������־
        /// </summary>
        [Description("�û�������־")]
        UserOperLog = 1,
        /// <summary>
        /// ϵͳ������־
        /// </summary>
        [Description("ϵͳ������־")]
        SystemRunLog = 2,
        /// <summary>
        /// ϵͳά����־
        /// </summary>
        [Description("ϵͳά����־")]
        SystemMaintLog = 3
    }
}
