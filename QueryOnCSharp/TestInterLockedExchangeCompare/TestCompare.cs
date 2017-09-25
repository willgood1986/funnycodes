using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestInterLockedExchangeCompare
{
	class TestCompare
	{
		private static ThreadSafe ts = new ThreadSafe();

		private static Double control = 0;

		private static Int64 safeFlag = 0;

		private static Random random = new Random();

		private static ManualResetEvent eventLock = new ManualResetEvent(false);

		private static void TestThread()
		{
			Console.WriteLine("Enter thread {0}, before WaitOne", Thread.CurrentThread.Name);
			eventLock.WaitOne();
			Console.WriteLine("Enter thread {0}, after WaitOne", Thread.CurrentThread.Name);

			for (int i = 1; i <= 4; i++)
			{
				//var testValue = random.NextDouble();

				var testValue = i;

				control += testValue;

				Console.WriteLine("[Before]Safe Flag is {0}, loop index: {1}, thread name:{2}", safeFlag, i, Thread.CurrentThread.Name);

				Interlocked.Increment(ref safeFlag);

				Console.WriteLine("[After]Safe Flag is {0}, loop index: {1}, thread name:{2}", safeFlag, i, Thread.CurrentThread.Name);

				ts.AddTotal(testValue);

				//Console.WriteLine("Enter thread {0}, before WaitOne", Thread.CurrentThread.Name);
				//eventLock.WaitOne();
				//Console.WriteLine("Enter thread {0}, after WaitOne", Thread.CurrentThread.Name);
			}
		}

		internal static void Test()
		{
			Thread t1 = new Thread(TestThread);
			t1.Name = "Test Thread 1";
			t1.Start();

			Thread t2 = new Thread(TestThread);
			t2.Name = "Test Thread 2";
			t2.Start();

			//Thread t3 = new Thread(TestThread);
			//t3.Name = "Test Thread 3";
			//t3.Start();

			//Thread t4 = new Thread(TestThread);
			//t4.Name = "Test Thread 4";
			//t4.Start();

			eventLock.Set();

			t1.Join();
			t2.Join();
			//t3.Join();
			//t4.Join();

			Console.WriteLine("ThreadSafe: {0} Ordinary Double: {1} Safe flag: {2}", ts.Total, control, safeFlag);
		}
	}
}
