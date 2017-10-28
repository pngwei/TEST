using System;
using System.Collections.Generic;
using System.Text;

namespace GX.Common
{
    /// <summary>
    ///  数据采集程序中的网络报文码定义
    /// </summary>
    public class NetCodeDefine
    {
        public const uint taskBack = 100;   //规约任务结果回传
        public const uint channelManagerSyn = 101; //通信管理之间的同步通讯
        public const uint codeView = 102;           //发送有原码的报文
        public const uint valueView = 103;          //发送有码值的报文
        public const uint taskStepBack = 104;          //传票步骤回传
        public const uint protocolInfo = 105;          //规约发往通讯管理的附加信息
        public const uint extendtaskBack = 106;         //扩展任务返回
        
        public const uint OnlineEditTableModify = 200;  //数据表被编辑后向其他模块发送的网络报文
        public const uint MessageServer = 201;          //消息服务之间的网络报文
        public const uint StartUpPointMessage = 202;
        public const uint RecordPointMessage = 203;
        public const uint OnlineEditToWeb = 204;         



        public const uint ykManager = 301;              //遥控管理之间的数据报文

        public const uint ZBSwitch = 401;               //主备切换模块

        

    }
}
