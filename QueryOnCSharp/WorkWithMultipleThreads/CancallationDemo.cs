using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkWithMultipleThreads
{
	internal static class CancallationDemo
	{
		private static void Count(
			CancellationToken i_token,
			Int32 i_countTo
			)
		{
			for (var count = 0; count < i_countTo; count++)
			{
				if (i_token.IsCancellationRequested)
				{
					Console.Write("Count is cancelled");
					break;
				}

				Console.WriteLine(count);
				Thread.Sleep(200);
			}

			Console.WriteLine("Count is done.");
		}

		internal static void TestCancellation()
		{
			var cts = new CancellationTokenSource();

			ThreadPool.QueueUserWorkItem(argument => Count(cts.Token, 1000));

			Console.WriteLine("Press <Enter> to cancel the operation");
			Console.ReadLine();

			cts.Cancel();	
		}
	}
}
