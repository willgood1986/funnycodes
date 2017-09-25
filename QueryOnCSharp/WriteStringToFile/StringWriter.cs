using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteStringToFile
{
	class StringWriter
	{
		internal static void WriteString(
			String i_content
			)
		{
			const String FileName = "TestWriteString.log";

			var fileStream = new FileStream(FileName, FileMode.OpenOrCreate);
			fileStream.Seek(0, SeekOrigin.End);

			var streamWriter = new StreamWriter(fileStream);
			streamWriter.WriteLine(i_content);

			// streamWriter.Dispose is enough
			// Content will not be flushed into file if this method is not called.
			streamWriter.Dispose();
		}
	}
}
