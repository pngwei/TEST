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
	/// ������ΪTrace����һ�������ļ�,�����ļ���Ϊ"Ӧ�ó�����+.txt"
	/// ��Trace��WriteLine����ʱ������Ϣǰ��ʱ����Ϣ
	/// ���ļ�����ָ���Ĵ�С(Ĭ��Ϊ4M)ʱ,�ļ�ǰ�벿�ֱ����
	/// ҪʹTrace��Ϣ������ļ��У����ȵ��ñ������Initialize������SystemConfig.xml��DebugInfo��������
	/// �ó����GenerateTraceΪtrue
	/// </summary>
	public sealed class TraceAngel
	{
		private int MAX_TRACEFILE_SIZE;		//ָ��Trace�ļ������ֵ(Ĭ��Ϊ4M)
		private int checkFileSizeInterval;	//����ļ��ߴ�ʱ����(Ĭ��Ϊ24Сʱ)
		private string application;			//Ӧ�ó�����,������չ������
		private Timer sizeCheckTimer;		//�ļ���С��ⶨʱ��,��ص�������ϵͳ�̳߳�����
		private StreamWriter traceWriter;	//Trace�ļ�����д����
		private int position = -1;			//�ļ���Trace�����б��е�λ��

		/// <summary>
		/// ��ʼ��TraceAngel����
		/// </summary>
		/// <param name="maxFileSize">�ļ��������ֵ</param>
		/// <param name="checkFileSizeInterval">�ļ����ȼ��ʱ����</param>
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
		/// ʹ��ȱʡ������ʼ��TraceAngel����,�ļ�����Ϊ4M,���ʱ����Ϊ24Сʱ
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
			//���ҵ�¼��
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
				//����һ������ļ���С�Ķ�ʱ��
				TimerCallback timerDelegate = new TimerCallback(CheckFileSize);
				sizeCheckTimer = new Timer(timerDelegate, null, checkFileSizeInterval, checkFileSizeInterval);
			}
		}
		/// <summary>
		/// //��Trace����һ�������ļ�
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
		/// �Ƴ���������
		/// </summary>
		void RemoveTraceListener()
		{
			Trace.Listeners.RemoveAt(position);
			Thread.Sleep(5000);			//�ȴ������߳����trace����
			traceWriter.Close();
		}
		/// <summary>
		/// ��ʱ�ص�����,����ļ���С,��Ҫʱ�����ļ��ߴ�
		/// </summary>
		/// <param name="state">δʹ��</param>
		void CheckFileSize(Object state)
		{
			lock(this) 
			{
				FileInfo traceFile = new FileInfo(application + ".txt");
				if(traceFile.Exists && traceFile.Length > MAX_TRACEFILE_SIZE)
				{
					//��Trace���������Ƴ�����	
					if(position != -1)
					{
						RemoveTraceListener();
					}
					//ɾ���ļ���һ�������
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
					//�������Trace����
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
	/// TraceAngelʹ�õļ�����,����WriteLineʱ��¼ʱ��
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
