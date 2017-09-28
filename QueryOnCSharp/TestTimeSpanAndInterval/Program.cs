using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTimeSpanAndInterval
{
	class Program
	{
		static void Main(string[] args)
		{
			var t = new TimeSpan(0, 0, 1);
			Console.WriteLine(t.Ticks);
		}
	}
}
