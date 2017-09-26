using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestForeground
{
	class TestEntry
	{
		private static void ThreadWork()
		{
			const Int32 TenSeconds = 10 * 1000;

			Thread.Sleep(TenSeconds);

			Console.WriteLine("Thread work is over.");
		}

		private static void ExecuteWithThread(
			Boolean i_isBackground
			)
		{
			var thread = new Thread(ThreadWork);
			thread.IsBackground = i_isBackground;
			thread.Start();
			thread.Join();
		}

		internal static void TestWithBackground()
		{
			Console.WriteLine("Test with background thread.");

			ExecuteWithThread(true);
		}

		internal static void TestWithForeground()
		{
			Console.WriteLine("Test with foreground thread.");

			ExecuteWithThread(false);

			// CallContext.LogicalSetData();
		}
	}
}
