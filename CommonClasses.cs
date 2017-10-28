using System;

namespace GX.Common
{
    /// <summary>
    /// 信息分类
    /// </summary>
    public enum PopupMessageType
    {
        /// <summary>
        /// 一般提示信息
        /// </summary>
        Info,
        /// <summary>
        /// 重要提示信息
        /// </summary>
        ImportantInfo,
        /// <summary>
        /// 警告信息
        /// </summary>
        Warning,
        /// <summary>
        /// 通知
        /// </summary>
        Notice,
        /// <summary>
        /// 运行错误信息
        /// </summary>
        Error,
        /// <summary>
        /// 扑捉到的例外
        /// </summary>
        Exception,
        /// <summary>
        
        /// </summary>
        JoyoServer
       
    }

    public delegate void UTMessageShow(string msg, PopupMessageType msgType);
    public delegate void UTMessageShowEx(string title,string msg, PopupMessageType msgType,int showTime);
    public delegate void UTProgressShow(int doneCount, int totalCount, string msg);
    /// <summary>
    /// 基础类，该类提供显示错误信息和提示信息的机制
    /// </summary>
    public sealed class UTMessageBase
    {
        static private event UTMessageShow showMessage = null;
        /// <summary>
        /// ShowMessage属性
        /// </summary>
        static public event UTMessageShow ShowMessage
        {
            add
            {
                if (value != null)
                {
                    bool alreadExist = false;
                    if (showMessage != null)
                    {
                        foreach (UTMessageShow d in showMessage.GetInvocationList())
                        {//防治重复产生事件
                            if (d.Method.Name == value.Method.Name)
                            {
                                alreadExist = true;
                            }
                        }
                    }
                    if (!alreadExist)
                    {
                        showMessage += value;
                    }
                }

            }
            remove
            {
                if (value != null)
                {
                    showMessage -= value;
                }
            }
        }

        static private event UTMessageShowEx showMessageEx = null;
        /// <summary>
        /// ShowMessageEx属性
        /// </summary>
        static public event UTMessageShowEx ShowMessageEx
        {
            add
            {
                if (value != null)
                {
                    bool alreadExist = false;
                    if (showMessageEx != null)
                    {
                        foreach (UTMessageShowEx d in showMessageEx.GetInvocationList())
                        {//防治重复产生事件
                            if (d.Method.Name == value.Method.Name)
                            {
                                alreadExist = true;
                            }
                        }
                    }
                    if (!alreadExist)
                    {
                        showMessageEx += value;
                    }
                }

            }
            remove
            {
                if (value != null)
                {
                    showMessageEx -= value;
                }
            }
        }

        static private UTProgressShow showPercentDone = null;

        private UTMessageBase()
        {

        }

        static public void ShowProgress(int doneCount, int totalCount, string msg)
        {
            if (showPercentDone != null)
            {
                showPercentDone(doneCount, totalCount, msg);
            }
        }

        /// <summary>
        /// 显示一错误或提示信息
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="msg"></param>
        /// <param name="msgType"></param>
        /// <param name="showTime"></param>
        static public void ShowOneMessage(string caption, string msg, PopupMessageType msgType, int showTime)
        {
            if (showMessageEx != null)
            {
                showMessageEx(caption, msg, msgType, showTime);
            }
            else
            {
                if (showMessage != null)
                {
                    showMessage(string.IsNullOrEmpty(caption) ? msg : string.Format("{0}|{1}", caption, msg), msgType);
                }
                else
                {
                    if (msgType == PopupMessageType.Error || msgType == PopupMessageType.Exception)
                    {
                        //System.Windows.Forms.MessageBox.Show(msg);
                        System.Diagnostics.Trace.WriteLine(msg);
                    }
                }
            }

        }

        /// <summary>
        /// 显示一条提示信息或错误信息
        /// </summary>
        /// <param name="msg">提示或错误信息</param>
        /// <param name="msgType">信息类型1-提示 2-错误 3-例外中的错误</param>
        static public void ShowOneMessage(string msg, PopupMessageType msgType)
        {
            ShowOneMessage("", msg, msgType, 0);

        }



        /// <summary>
        /// ShowPercentDone属性
        /// </summary>
        static public UTProgressShow ShowPercentDone
        {
            get
            {
                return showPercentDone;
            }
            set
            {
                showPercentDone = value;
            }
        }

    }


}
