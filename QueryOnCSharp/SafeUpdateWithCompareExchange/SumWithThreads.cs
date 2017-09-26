using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SafeUpdateWithCompareExchange
{
	class SumWithThreads
	{
        private ManualResetEvent m_locker = new ManualResetEvent(false);
        private SimpleDataModule m_data = new SimpleDataModule();
		private Double m_total = 0;

		internal void Sum()
		{
			var thread1 = new Thread(DoUpdate);
			thread1.Name = "Thread1";
			thread1.Start();

			var thread2 = new Thread(DoUpdate);
			thread2.Name = "Thread2";
			thread2.Start();

			m_locker.Set();

			thread1.Join();
			thread2.Join();

			Console.WriteLine(
				"All is done, Total with Lock: {0}, total without lock: {1}", 
				m_data.Total, 
				m_total);
		}

		private void DoUpdate()
		{
			m_locker.WaitOne();

			for (var i = 0; i < 100000; i++)
			{
				m_data.AddTotal(i);
				m_total += i;
			}
		}

		internal static void Test()
		{
			var sumWithThreads = new SumWithThreads();
			sumWithThreads.Sum();
		}
	}
}
