
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace GX.Common
{

    //文件  WFTypesEnumesPart1.cs 与WFTypesEnumesPart2.cs 均用来定义枚举类型
    //      WFTypesEnumesPart1.cs 中的内容是手工输入的
    //      WFTypesEnumesPart2.cs 中的内容是由工具自动生成的

    public enum OSFamily { Unknown, Windows, Uniux, Apple };


    /// <summary>
    /// 服务器运行模式
    /// </summary>
    public enum JoyoServerApplicationRunMode
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown,
        /// <summary>
        /// Windows服务
        /// </summary>
        WindowService,
        /// <summary>
        /// Windows应用程序
        /// </summary>
        WindowsApplication,
        /// <summary>
        /// Linux服务
        /// </summary>
        LinuxDaemon,
        /// <summary>
        /// Linux应用程序
        /// </summary>
        LinuxApplication
    }


    public enum DatabaseTypes { Unknown, Sql, Oracle, MySql, Sqlite };

    /// <summary>
    /// 数据库可用信息编码
    /// </summary>
    public enum UTDatabaseInformationCode
    {
        /// <summary>
        /// 数据库可用
        /// </summary>
        Available,
        /// <summary>
        /// 尚未对配置的数据库进行检查
        /// </summary>
        Unchecked,
        /// <summary>
        /// 正在进行连接检查
        /// </summary>
        ConnectionChecking,
        /// <summary>
        /// 数据库配置文件不存在
        /// </summary>
        NoConfigFile,
        /// <summary>
        /// 缺省环境变量不存在
        /// </summary>
        NoDefaultEnvironment,
        /// <summary>
        /// 环境变量不存在
        /// </summary>
        NoEnvironment,
        /// <summary>
        /// 环境变量重复
        /// </summary>
        MultiEnvironment,
        /// <summary>
        /// 配置有错误
        /// </summary>
        ConfigError,
        /// <summary>
        /// 未安装数据库系统
        /// </summary>
        NotInstalled,
        /// <summary>
        /// 连接失败
        /// </summary>
        ConnectFailure,
        /// <summary>
        /// 指定的数据库尚未创建
        /// </summary>
        NoCatalog
    }

    /// <summary>
    /// 通道信息类型
    /// </summary>
    public enum ChannelInfoType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown,
        /// <summary>
        /// 通讯通道
        /// </summary>
        Communication,
        /// <summary>
        /// 客户端通道
        /// </summary>
        JoyoClient,
        /// <summary>
        /// 服务器通道
        /// </summary>
        JoyoSever
    }

    /// <summary>
    /// 通道状态变化类型
    /// </summary>
    public enum ChannelStateChangeType
    {
        /// <summary>
        /// 状态刷新
        /// </summary>
        Refresh,
        /// <summary>
        /// 通道增加
        /// </summary>
        Added,
        /// <summary>
        /// 通道移除
        /// </summary>
        Removed
    }

    /// <summary>
    /// 客户端注册信息类型
    /// </summary>
    public enum ClientRegisterInfoType
    {
        /// <summary>
        /// 注册
        /// </summary>
        Register,
        /// <summary>
        /// 注销
        /// </summary>
        Unregister,
        /// <summary>
        /// 中断
        /// </summary>
        LostConnection,
        /// <summary>
        /// 连接恢复
        /// </summary>
        ResumeConnection,
        /// <summary>
        /// 注册（切换）站
        /// </summary>
        RegisterStation
    }

    /// <summary>
    ///  传票通道所用图标类型
    /// </summary>
    public enum PortIconType
    {
        /// <summary>
        /// 无图标
        /// </summary>
        None,
        /// <summary>
        /// 任务直接执行图标
        /// </summary>
        ExecGXe,
        /// <summary>
        /// 串口
        /// </summary>
        RS232,
        TcpServer,
        TcpClient,
        Udp,
        /// <summary>
        /// 传票到模拟屏
        /// </summary>
        RemoteScreen,
        RemotePC,
        /// <summary>
        /// 有限Modem
        /// </summary>
        Modem,
        /// <summary>
        /// 无线
        /// </summary>
        Wireless,
        Cdma,
        Gprs,
        /// <summary>
        /// 通讯机
        /// </summary>
        Rtu,
        Usb,
        TcpSocket,
        /// <summary>
        /// 共享通道
        /// </summary>
        Shared,
        /// <summary>
        /// 蓝牙
        /// </summary>
        Bluetooth
    }


    /// <summary>
    /// 五防系统服务自定义命令
    /// </summary>
    public enum CustomServiceCommand
    {
        SetJoyoPCServerWrapperInstance,
    }

    /// <summary>
    /// 五防服务器状态
    /// </summary>
    public enum WFServerState
    {
        /// <summary>
        /// 通道断开
        /// </summary>
        Disconnected,
        /// <summary>
        /// “五防”服务器联通
        /// </summary>
        Connected,
        /// <summary>
        /// “五防”服务器临时中断
        /// </summary>
        Break,
        /// <summary>
        /// 服务器关闭
        /// </summary>
        ServerClosed,
        /// <summary>
        /// 访问代理关闭
        /// </summary>
        ProxyClosed,
        /// <summary>
        /// 服务器重新启动
        /// </summary>
        ServerRestarting,
        /// <summary>
        /// 启动服务器失败
        /// </summary>
        ServerStartError,
        /// <summary>
        /// 停止服务器失败
        /// </summary>
        ServerStoppedError,
    }








    ///// <summary>
    ///// 用户校验方式
    ///// </summary>
    //public enum UserVerifyMode
    //{
    //    /// <summary>
    //    /// 密码方式
    //    /// </summary>
    //    Password = 0,
    //    /// <summary>
    //    /// 指纹方式
    //    /// </summary>
    //    FingerPrint = 1,
    //    /// <summary>
    //    /// 虹膜
    //    /// </summary>
    //    Iris=2,
    //    /// <summary>
    //    /// 已经完成验证
    //    /// </summary>
    //    Verfied = 9
    //}


    ///// <summary>
    ///// “五防”服务器的运行模式(主服务器、本地独立运行、本地临时运行))
    ///// </summary>
    //[FlagsAttribGXe]
    //public enum JoyoServerRunMode
    //{
    //    /// <summary>
    //    /// 未定义
    //    /// </summary>
    //    Undefined = 0,
    //    /// <summary>
    //    /// 主服务器（远程服务器）
    //    /// </summary>
    //    RemoteServer = 0x01,
    //    /// <summary>
    //    /// 本地服务器（单机版）
    //    /// </summary>
    //    LocalServer = 0x02,
    //    /// <summary>
    //    /// 本地备用服务器（客户端独立运行）
    //    /// </summary>
    //    LocalStandby = 0x04,
    //    ///// <summary>
    //    ///// 临时代理
    //    ///// </summary>
    //    //Temporary
    //}



    /// <summary>
    /// “五防”客户端分类
    /// </summary>
    public enum JoyoClientClassification
    {
        /// <summary>
        /// 未定义类型
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// 模拟屏客户端
        /// </summary>
        Screen = 1,
        /// <summary>
        /// PC机客户端
        /// </summary>
        CompGXer = 2,
        /// <summary>
        /// 独立运行PC五防系统
        /// </summary>
        StandAloneCompGXer = 3,
        /// <summary>
        /// GX-200IV型
        /// </summary>
        StandAlongGX200IV = 4,

        /// <summary>
        /// 独立运行的模拟屏（优特或第三方）
        /// </summary>
        StandAloneScreen = 90,
        /// <summary>
        /// 独立运行的优特模拟屏
        /// </summary>
        StandAloneUnitechScreen = 100,
        /// <summary>
        /// 独立运行的共创模拟屏
        /// </summary>
        StandAloneContrlScreen = 110,
        /// <summary>
        /// 拓新
        /// </summary>
        StandAloneTuoXin = 120,
        /// <summary>
        /// 独立运行的南瑞模拟屏
        /// </summary>
        StandAloneNariScreen = 130,
        /// <summary>
        /// 襄樊
        /// </summary>
        StandAloneXiangFan = 140,
        /// <summary>
        /// 锦州模拟屏
        /// </summary>
        StandAloneJinZhouScreen = 150,

        #region wangjinhui Added at 20160428
        /// <summary>
        /// 安卓应用客户端
        /// </summary>
        AndroidApp = 151,
        /// <summary>
        /// IOS应用客户端
        /// </summary>
        IOSApp = 152,
        /// <summary>
        /// WP应用客户端
        /// </summary>
        WPApp = 153,
        /// <summary>
        /// Linux桌面客户端
        /// </summary>
        LinuxDesktop = 154,
        /// <summary>
        /// Windows桌面客户端
        /// </summary>
        WindowsDesktop = 155,
        /// <summary>
        /// Mac桌面客户端
        /// </summary>
        MacDesktop = 156,
        /// <summary>
        /// Est导航应用App
        /// </summary>
        EstNavigationApp = 157,
        /// <summary>
        /// Web浏览器客户端
        /// </summary>
        WebBrowser = 158,
        #endregion
    }



    /// <summary>
    /// PC客户端类型
    /// </summary>
    public enum ClientType
    {
        /// <summary>
        /// 拒绝
        /// </summary>
        Deny = -1,
        /// <summary>
        /// 未定义
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// 站端
        /// </summary>
        OneStationMode = 1,
        /// <summary>
        /// 集控模式1
        /// </summary>
        MultiStationMode1 = 2,
        /// <summary>
        /// 集控模式2
        /// </summary>
        MultiStationMode2 = 3,
        /// <summary>
        /// 集控模式3
        /// </summary>
        MultiStationMode3 = 4,
        /// <summary>
        /// 集控模式4
        /// </summary>
        MultiStationMode4 = 5,
        /// <summary>
        /// 集控模式5
        /// </summary>
        MultiStationMode5 = 6,
        /// <summary>
        /// 集控模式6
        /// </summary>
        MultiStationMode6 = 7,
        /// <summary>
        /// 集控模式7
        /// </summary>
        MultiStationMode7 = 8,
        /// <summary>
        /// 所有站模式
        /// </summary>
        AllStationMode = 100
    }

    /// <summary>
    /// 客户端注册结果
    /// </summary>
    public enum ClientRegistrationResult
    {
        /// <summary>
        /// 服务器不可用
        /// </summary>
        ServerUnavailable,
        /// <summary>
        /// 未授权客户端
        /// </summary>
        Unauthorized,
        /// <summary>
        /// 尚未注册，恢复连接时使用
        /// </summary>
        Unregistered,
        /// <summary>
        /// 已经注册的客户端超过规定的数量
        /// </summary>
        OverLimit,
        /// <summary>
        /// 客户端已经注册
        /// </summary>
        RegistedAlready,
        /// <summary>
        /// 客户端与服务器版本吧一致
        /// </summary>
        IncorrectVersion,
        /// <summary>
        /// 注册成功
        /// </summary>
        Success
    }

    /// <summary>
    /// 解锁、闭锁命令的执行机构类型
    /// </summary>
    public enum DeviceLockUnlockOperator
    {
        /// <summary>
        /// 硬件解锁、闭锁
        /// </summary>
        Hardware,
        /// <summary>
        /// 软件解锁、闭锁
        /// </summary>
        SoftWare
    }

    /// <summary>
    /// 五访服务器事件类型
    /// </summary>
    public enum WFServerEventType
    {
        /// <summary>
        /// 设备状态发生变化
        /// </summary>
        DeviceStateChange,
        /// <summary>
        /// 遥测值发生变化
        /// </summary>
        YCValueChange,
        /// <summary>
        /// 服务器信息
        /// </summary>
        ServerInformation,
        /// <summary>
        /// 客户端信息
        /// </summary>
        ClientInformation
    }



    /// <summary>
    /// Remoting通道类型定义
    /// </summary>
    public enum RemotingChannelType
    {
        /// <summary>
        /// 未用
        /// </summary>
        Unsued = -2,
        /// <summary>
        /// 未知
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
        /// 激活码方式激活
        /// </summary>
        Code = 0,
        /// <summary>
        /// 系列号方式
        /// </summary>
        Serial = 1,
        /// <summary>
        /// 加密狗方式
        /// </summary>
        Dog = 2,
        /// <summary>
        /// 试用
        /// </summary>
        Trial = 3,
        /// <summary>
        /// 激活码2方式激活
        /// </summary>
        Code2 = 4,
        /// <summary>
        /// 已经激活
        /// </summary>
        Actived = 10,
        /// <summary>
        /// 授权文件失效
        /// </summary>
        Expired = 11,
        /// <summary>
        /// 加密狗失效
        /// </summary>
        DogLocked = 12,
        /// <summary>
        /// 已经作废的授权文件格式
        /// </summary>
        Obsoleted = 13
    }

    /// <summary>
    /// 从服务器读取文件的类型定义
    /// </summary>
    public enum FileReadType
    {
        /// <summary>
        /// 特定文件，由其它参数决定
        /// </summary>
        Special = 0,
        /// <summary>
        /// 系统路径下的文件
        /// </summary>
        System = 1,
        /// <summary>
        /// 数据路径下的文件
        /// </summary>
        Data = 2,
        /// <summary>
        /// 升级文件
        /// </summary>
        ClientUpdate = 3,
        /// <summary>
        /// 安装文件
        /// </summary>
        Install = 4,
        /// <summary>
        /// 绝对路径
        /// </summary>
        AbsolGXe = 5,
        /// <summary>
        /// 相对数据路径
        /// </summary>
        RelativeToData = 6,
        /// <summary>
        /// 相当系统路径
        /// </summary>
        RelativeToSystem = 7,
        /// <summary>
        /// 系统升级
        /// </summary>
        SystemUpdate

    }




    /// <summary>
    /// 通讯通道用户确认情况
    /// </summary>
    public enum ChannelStateConfirmValue
    {
        Uninitialied = 0,
        NotConfirmed = 1,
        Confirmed = 2
    }

    /// <summary>
    /// 突出显示操作内容类型
    /// </summary>
    public enum StressShowType
    {
        /// <summary>
        /// 无
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// 正常显示
        /// </summary>
        Normal = 1,
        /// <summary>
        ///粗体 
        /// </summary>
        Bold = 2,
        /// <summary>
        /// 斜体
        /// </summary>
        Italic = 3,
        /// <summary>
        /// 粗体斜体
        /// </summary>
        BoldItalic = 4,
    }


    /// <summary>
    /// 系统日志类型
    /// </summary>
    public enum SystemLogType
    {
        /// <summary>
        /// 未定义
        /// </summary>
        [Description("未定义")]
        None = 0,
        /// <summary>
        /// 用户操作日志
        /// </summary>
        [Description("用户操作日志")]
        UserOperLog = 1,
        /// <summary>
        /// 系统运行日志
        /// </summary>
        [Description("系统运行日志")]
        SystemRunLog = 2,
        /// <summary>
        /// 系统维护日志
        /// </summary>
        [Description("系统维护日志")]
        SystemMaintLog = 3
    }
}
