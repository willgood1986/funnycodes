using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;

namespace StartAProgramAndWait
{
	class Program
	{
		// -----------------------------------------------------------------------------------------
		// Helper Functions

		/// <exception cref="IOException">An I/O error occurred.</exception>
		/// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a
		/// buffer for the returned string.</exception>
		static void Main(string[] args)
		{
			var executeCount = Convert.ToInt32(
				ConfigurationSettings.AppSettings[Properties.Resources.Configure_ExecuteCount]);

			var program =
				ConfigurationSettings.AppSettings[Properties.Resources.Configure_Program];

			var arguments =
				ConfigurationSettings.AppSettings[Properties.Resources.Configure_Arguments];

			for (var index = 0; index < executeCount; index++)
			{
				try
				{
					Console.WriteLine("Index {0},Before ...", index);

					StartProgramHelper.StartAndWait(program, arguments, true);

					Console.WriteLine("End ...");

					Thread.Sleep(500);
				}
				catch (Exception e)
				{
					Console.WriteLine("Caught exception, sleep 2 seconds, message:{0}", e.Message);
					Thread.Sleep(1000 * 2);
				}
			}

			Console.ReadLine();
		}
	}
}