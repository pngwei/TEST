using System;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Text;
using System.Collections;

namespace GX.Common
{
	/// <summary>
	/// 本对象为Trace增加一个监听文件,监听文件名为"应用程序名+.txt"
	/// 对Trace的WriteLine调用时会在消息前加时标信息
	/// 当文件超过指定的大小(默认为4M)时,文件前半部分被清除
	/// 要使Trace信息输出到文件中，需先调用本对象的Initialize，并在SystemConfig.xml的DebugInfo表中设置
	/// 该程序的GenerateTrace为true
	/// </summary>
	public sealed class TraceAngel
	{
		private int MAX_TRACEFILE_SIZE;		//指定Trace文件的最大值(默认为4M)
		private int checkFileSizeInterval;	//检测文件尺寸时间间隔(默认为24小时)
		private string application;			//应用程序名,不带扩展名部分
		private Timer sizeCheckTimer;		//文件大小检测定时器,其回调函数在系统线程池运行
		private StreamWriter traceWriter;	//Trace文件的流写入器
		private int position = -1;			//文件在Trace监听列表中的位置

		/// <summary>
		/// 初始化TraceAngel对象
		/// </summary>
		/// <param name="maxFileSize">文件长度最大值</param>
		/// <param name="checkFileSizeInterval">文件长度检测时间间隔</param>
		/// <returns></returns>
		public static TraceAngel Initialize(int maxFileSize, int checkFileSizeInterval)
		{
			if(instance == null)
			{
				instance = new TraceAngel(maxFileSize, checkFileSizeInterval);
			}
			return instance;
		}
		/// <summary>
		/// 使用缺省参数初始化TraceAngel对象,文件长度为4M,检测时间间隔为24小时
		/// </summary>
		/// <returns></returns>
		public static TraceAngel Initialize()
		{
			return Initialize(4 * 1024 * 1024, 24 * 3600 * 1000);
		}
		private TraceAngel(int maxFileSize, int checkFileSizeInterval)
		{
			MAX_TRACEFILE_SIZE = maxFileSize;
			this.checkFileSizeInterval = checkFileSizeInterval;

			application = Path.GetFileNameWithoutExtension(System.Windows.Forms.Application.ExecutablePath); 
			SystemConfig systemConfig = new SystemConfig();
			//查找登录项
			DataRow[] debugItems = systemConfig.ReadRows("DebugInfo", "Application = '" + application + "'");
			bool toDebug = false;
			if(debugItems!= null)	
			{
				if(Convert.ToBoolean(debugItems[0]["GenerateTrace"]))
				{
					toDebug = true;
				}
			}
			if(toDebug)				 
			{
				application = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + Path.DirectorySeparatorChar + application;
#if(!DEBUG)
				Trace.Listeners.Clear();
#endif
				CheckFileSize(null);
				AddTraceListener();
				//设置一个检查文件大小的定时器
				TimerCallback timerDelegate = new TimerCallback(CheckFileSize);
				sizeCheckTimer = new Timer(timerDelegate, null, checkFileSizeInterval, checkFileSizeInterval);
			}
		}
		/// <summary>
		/// //给Trace增加一个监听文件
		/// </summary>
		void AddTraceListener()
		{
			traceWriter = new StreamWriter(new FileStream(application + ".txt", FileMode.Append, FileAccess.Write, FileShare.Read), System.Text.Encoding.Default);
			TraceListener listener = new GXTextWriterTraceListener(traceWriter);
			listener.Name = application;
			position = Trace.Listeners.Add(listener);
			Trace.AutoFlush = true;
		}
		/// <summary>
		/// 移除本监听器
		/// </summary>
		void RemoveTraceListener()
		{
			Trace.Listeners.RemoveAt(position);
			Thread.Sleep(5000);			//等待其他线程完成trace操作
			traceWriter.Close();
		}
		/// <summary>
		/// 定时回调函数,检测文件大小,必要时调整文件尺寸
		/// </summary>
		/// <param name="state">未使用</param>
		void CheckFileSize(Object state)
		{
			lock(this) 
			{
				FileInfo traceFile = new FileInfo(application + ".txt");
				if(traceFile.Exists && traceFile.Length > MAX_TRACEFILE_SIZE)
				{
					//从Trace监听者中移除本项	
					if(position != -1)
					{
						RemoveTraceListener();
					}
					//删除文件中一半的数据
					File.Delete(application + "tracetemp.txt");
					traceFile.MoveTo(application + "tracetemp.txt");
					FileStream reader = new FileStream(application + "tracetemp.txt", FileMode.Open, FileAccess.Read);
					FileStream writer = new FileStream(application + ".txt", FileMode.Create, FileAccess.Write, FileShare.Read);
					int newSize = MAX_TRACEFILE_SIZE / 2;
					try 
					{
						reader.Seek(reader.Length - newSize, SeekOrigin.Begin);
						byte[] buf = new byte[newSize];
						newSize = reader.Read(buf, 0, newSize);
						writer.Write(buf, 0, newSize);
					}
					finally
					{
						reader.Close();
						writer.Close();
					}
					//重新添加Trace监听
					if(position != -1)
					{
						AddTraceListener();
					}
				}
			}
		}
		static private TraceAngel instance = null;
	}
	/// <summary>
	/// TraceAngel使用的监听器,它在WriteLine时记录时标
	/// </summary>
	class GXTextWriterTraceListener : TextWriterTraceListener
	{
		public GXTextWriterTraceListener(TextWriter textWriter)
			: base(textWriter)
		{
		}

		public override void WriteLine(string message)
		{
			//First record time
			base.Write(DateTime.Now.ToString() + ":  ");
			//then record message
			base.WriteLine(message);
		}
	}
}
