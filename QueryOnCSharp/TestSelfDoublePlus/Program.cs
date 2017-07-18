using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSelfDoublePlus
{
	class Program
	{
		private static void TestSelfDoublePlus()
		{
			var start = 0;

			Console.WriteLine("start++:{0}", start++);

			Console.WriteLine("start:{0}", start);

			Console.WriteLine("++Start:{0}", ++start);
		}

		private static void TestReadonlyIdentifier()
		{
			var readOnlyObject = new DefineReadOnlyTest();

			readOnlyObject.GetItemCount();
		}

		static void Main(string[] args)
		{
			// TestSelfDoublePlus();

			TestReadonlyIdentifier();

			Console.ReadKey();
		}
	}
}
