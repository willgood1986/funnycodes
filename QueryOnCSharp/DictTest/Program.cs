using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictTest
{
	class Program
	{
		static void TestDictionary()
		{
			var map = new Dictionary<String, List<Int32>>();

			Console.WriteLine("Add a key for dictionary.");

			map["jim"] = new List<Int32>();

			Console.WriteLine("Add a key for dictionary.");

			map["jim"] = new List<Int32>();
		}

		static void Main(string[] args)
		{
	
			TestDictionary();

			Console.ReadKey();
		}
	}
}
