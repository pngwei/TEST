using System;

namespace GX.Common
{
    /// <summary>
    /// ��Ϣ����
    /// </summary>
    public enum PopupMessageType
    {
        /// <summary>
        /// һ����ʾ��Ϣ
        /// </summary>
        Info,
        /// <summary>
        /// ��Ҫ��ʾ��Ϣ
        /// </summary>
        ImportantInfo,
        /// <summary>
        /// ������Ϣ
        /// </summary>
        Warning,
        /// <summary>
        /// ֪ͨ
        /// </summary>
        Notice,
        /// <summary>
        /// ���д�����Ϣ
        /// </summary>
        Error,
        /// <summary>
        /// ��׽��������
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
    /// �����࣬�����ṩ��ʾ������Ϣ����ʾ��Ϣ�Ļ���
    /// </summary>
    public sealed class UTMessageBase
    {
        static private event UTMessageShow showMessage = null;
        /// <summary>
        /// ShowMessage����
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
                        {//�����ظ������¼�
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
        /// ShowMessageEx����
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
                        {//�����ظ������¼�
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
        /// ��ʾһ�������ʾ��Ϣ
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
        /// ��ʾһ����ʾ��Ϣ�������Ϣ
        /// </summary>
        /// <param name="msg">��ʾ�������Ϣ</param>
        /// <param name="msgType">��Ϣ����1-��ʾ 2-���� 3-�����еĴ���</param>
        static public void ShowOneMessage(string msg, PopupMessageType msgType)
        {
            ShowOneMessage("", msg, msgType, 0);

        }



        /// <summary>
        /// ShowPercentDone����
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
