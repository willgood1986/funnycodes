using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableType
{
	class NullableToInterface
	{
		internal static void TestIComparable()
		{
			Int32 sourceNum = 5;

			var comparableInterface = (IComparable<Int32>)sourceNum;

			Console.WriteLine("Result {0} to compare with source number {1}", comparableInterface.CompareTo(sourceNum), sourceNum);
		}

		internal static void ShowInternalType()
		{
			Int32? number = 5;

			Console.WriteLine("Type of Int32? is {0}", number.GetType().ToString());
		}

		internal static String ToString()
		{
			var description = "Nullable actually works as a wrapper of value types. " + 
				"When querying its type, it will return the backend real type. " + 
			    "When converting types, it will works complying with the actual type.";

			return description;
		}
	}
}
