using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalLog
{
    public class LocalLog
    {
		public static void LogMessage(
			String i_message,
			String i_logFile
			)
		{
			using (var file = System.IO.File.Open(i_logFile, System.IO.FileMode.OpenOrCreate))
			{
				file.Seek(0, System.IO.SeekOrigin.End);
				var bytes = System.Text.Encoding.UTF8.GetBytes(i_message + Environment.NewLine);
				file.Write(bytes, 0, bytes.Length);
			}
		}
    }
}
