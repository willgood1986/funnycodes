using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableType
{
	class Program
	{
		static void Main(string[] args)
		{
			NullableToInterface.TestIComparable();

			NullableToInterface.ShowInternalType();

			Console.WriteLine();

			Console.WriteLine(NullableToInterface.ToString());

			Console.ReadKey();
		}

	}
}
