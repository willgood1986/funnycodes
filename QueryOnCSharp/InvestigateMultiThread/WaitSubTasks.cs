using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvestigateMultiThread
{
	class WaitSubTasks
	{
		internal static void Test()
		{
			var eventLock = new AutoResetEvent(false);

			const Int32 MaxTaskNumber = 20;

			var results = new Int32[MaxTaskNumber];

			var taskLeft = MaxTaskNumber;

			for (Int32 i = 1; i <= MaxTaskNumber; i++)
			{
				Console.WriteLine("Loop at {0}", i);

				ThreadPool.QueueUserWorkItem(
					item =>
					{
						var num = (Int32)item;

						results[num - 1] = num * num;

						if (Interlocked.Decrement(ref taskLeft) == 0)
						{
							eventLock.Set();
						}

						Console.WriteLine("Task left number: {0}", taskLeft);
							
					}, i);
			}

			eventLock.WaitOne();

			//foreach (var item in results)
			//{
			//	Console.WriteLine("item: {0}", item);
			//}

			Array.ForEach(results, Console.WriteLine);
		}

		public override string ToString()
		{
			const String WaitSubTaskDescription = "Use ThreadPool.QueueUserWorkItem, " +
			"create deletegate, use AutoResetEvent to act as a lock; " +
			"It is unsigaled at first, use WaitOne afterwards to watch on the lock";

			return WaitSubTaskDescription;
		}
	}
}
