using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GCTEST
{
	class Program
	{
		private static void TimerCallback(
			Object i_object
			)
		{
			Console.WriteLine("In TimerCallback:" + DateTime.Now);

			GC.Collect();
		}

		static void Main(string[] args)
		{
			var timer = new Timer(TimerCallback, null, 0, 2000);

			Console.ReadLine();


			// Make sure the timer variable is referred in the lifetime of this method.
			timer.Dispose();
		}
	}
}
