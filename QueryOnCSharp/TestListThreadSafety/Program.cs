using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestListThreadSafety
{
	class Program
	{
		// -----------------------------------------------------------------------------------------
		// Helper Functions

		/// <exception cref="IOException">A Win32 error occurred with a named semaphore.</exception>
		/// <exception cref="SemaphoreFullException">The semaphore count is already at the
		/// maximum value.</exception>
		/// <exception cref="UnauthorizedAccessException">The current semaphore represents a
		/// named system semaphore, but the user does not have 'System.Security.AccessControl.
		/// SemaphoreRights.Modify'.-or-The current semaphore represents a named system
		/// semaphore, but it was not opened with 'System.Security.AccessControl.SemaphoreRights.
		/// Modify'.</exception>
		private static void Test()
		{
			const Int32 MaxCount = 10000000;

			var counter = 0;

			var semaphere = new System.Threading.Semaphore(8, 8);
			var locker = new Object();

			var nums = new List<Int32>();

			for (var i = 0; i < MaxCount; i++)
			{
				Task.Factory.StartNew(
					() =>
					{
						if (semaphere.WaitOne(5 * 60 * 1000))
						{
							try
							{
								lock (locker)
								{
									nums.Add(i);
								}
								Interlocked.Increment(ref counter);
							}
							finally
							{
								semaphere.Release();
							}
						}
					});
			}

			while (counter < MaxCount)
			{
				Thread.Sleep(500);
			}

			Console.WriteLine("Item count in list expected:{0}, actual:{1}", MaxCount, nums.Count);

		}

		/// <exception cref="InvalidOperationException">The 'System.Console.In' property is
		/// redirected from some stream other than the console.</exception>
		/// <exception cref="IOException">A Win32 error occurred with a named semaphore.</exception>
		/// <exception cref="SemaphoreFullException">The semaphore count is already at the
		/// maximum value.</exception>
		/// <exception cref="UnauthorizedAccessException">The current semaphore represents a
		/// named system semaphore, but the user does not have 'System.Security.AccessControl.
		/// SemaphoreRights.Modify'.-or-The current semaphore represents a named system
		/// semaphore, but it was not opened with 'System.Security.AccessControl.SemaphoreRights.
		/// Modify'.</exception>
		static void Main(string[] args)
		{
			Test();
			Console.ReadKey();
		}
	}
}