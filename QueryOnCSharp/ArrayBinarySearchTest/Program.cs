using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayBinarySearchTest
{
	class Program
	{
		internal static void ArrayBinarySearchTest()
		{
			const Int32 TargetValue = 3;

			var array = new Int32[] { 1, 2, 6, 3, 4, 5 };

			var foundIndex = Array.BinarySearch(array, 3);

			Console.WriteLine("The item {0}, found index:{1}", TargetValue, foundIndex);
		}

		static void Main(string[] args)
		{
			ArrayBinarySearchTest();

			Console.ReadKey();
		}
	}
}
