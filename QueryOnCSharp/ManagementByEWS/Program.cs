using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainy.Work
{
	class Program
	{
		static void Main(string[] args)
		{
			for (var i = 0; i < 10; i++)
			{
				LocalLog.LocalLog.LogMessage("Test it", @"c:\mytest.txt");
			}

			Console.ReadKey();
		}
	}
}
