using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTesting
{
	class Program
	{
		private static void ExecuteTesting()
		{
			Console.WriteLine("Test string equality by ordinal");

			var ordinalResult = StringComparisonTesting.TestComparisonWithOrdinal();

			Console.WriteLine("TestComparisonWithOrdinal testing result:{0}", ordinalResult);
		}

		static void Main(string[] args)
		{
			ExecuteTesting();

			Console.ReadLine();
		}
	}
}
