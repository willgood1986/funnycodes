using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDispose
{
	class CloseNativeResource
	{
		internal static void AccessObjectPostDispose()
		{
			const String FileName = "Temp.dat";

			// Create the bytes to write to the temporary file.
			Byte[] bytesToWrite = new Byte[] { 1, 2, 3, 5 };

			// Create the temporary file.
			var fs = new FileStream(FileName, FileMode.Create);

			// Write the bytes to the temporary file.
			fs.Write(bytesToWrite, 0, bytesToWrite.Length);

			// Explicitly close the file when finished writing to it.
			// It does not delete the managed object from the managed heap, release native resource
			fs.Dispose();

			// Try to access the file
			Console.WriteLine("File name: {0}", fs.Name);

			// Delete the temporary file.
			File.Delete(FileName);
		}
	}
}
