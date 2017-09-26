using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTesting
{
	class StringComparisonTesting
	{
		internal static Boolean TestComparisonWithOrdinal()
		{
			var testText1 = "A";
			var testText2 = "a";

			// First check length, second check ordinal value of each char in the string
			// It returns at the first difference.
			// This function is case-sensitive
			var result = String.CompareOrdinal(testText1, testText2);

			Console.WriteLine(
				"'{0}' CompareOrdinal with {1} result is {2}", 
				testText1, 
				testText2, 
				result);

			// Ony convert a 16 based string to a byte, a, A does not matter. They are same.
			var bytea = Convert.ToByte("a", 16);
			var byteA = Convert.ToByte("A", 16);

			Console.WriteLine("bytea is {0}, byteA is {1}", bytea, byteA);

			// If the char represents a real number, it returns the real number
 			// Otherwise it always returns -1, so 'B' and 'b' get -1 at last
			Console.WriteLine("A.GetNumericValue is : {0}", Char.GetNumericValue("B", 0));
			Console.WriteLine("a.GetNumericValue is : {0}", Char.GetNumericValue("b", 0));
			Console.WriteLine(
				"32.Index 0.GetNumericValue is : {0}", Char.GetNumericValue("32", 0));


			var bytes4A = UTF8Encoding.UTF8.GetBytes("A");
			var bytes4a = UTF8Encoding.UTF32.GetBytes("a");

			// Get a 16 based byte string
			Console.WriteLine(
				"UTF8.GetBytes('A') result is :{0}, UTF8.GetBytes('a') result is :{1}", 
				BitConverter.ToString(bytes4A), 
				BitConverter.ToString(bytes4a));

			return result == 0;
		}
	}
}
