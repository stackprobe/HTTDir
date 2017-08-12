using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace HTTDir
{
	public class AccessMonitor
	{
		private static AccessMonitor _i = null;

		public static AccessMonitor I
		{
			get
			{
				if (_i == null)
					_i = new AccessMonitor();

				return _i;
			}
		}

		private const string LOG_MUTEX = "{19e9d767-ddfc-4377-9af3-88df891847cd}";
		private const string LOG_FILE = "AccessLog.dat";

		private Mutex _logFileMutex;
		private DateTime _lastLogWrTime;

		private AccessMonitor()
		{
			_logFileMutex = new Mutex(false, LOG_MUTEX);
			_lastLogWrTime = DateTime.Now;
		}

		~AccessMonitor()
		{
			_logFileMutex.Close();
		}

		public bool HasAccess()
		{
			try
			{
				if (_logFileMutex.WaitOne(0))
				{
					try
					{
						if (File.Exists(LOG_FILE))
						{
							DateTime currLogWrTime = new FileInfo(LOG_FILE).LastWriteTime;

							if (_lastLogWrTime != currLogWrTime)
							{
								_lastLogWrTime = currLogWrTime;
								return true;
							}
						}
					}
					finally
					{
						_logFileMutex.ReleaseMutex();
					}
				}
			}
			catch
			{ }

			return false;
		}
	}
}
