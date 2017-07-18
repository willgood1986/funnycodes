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
			var testText1 = "abcdef";
			var testText2 = "Abcdef";

			var result = String.CompareOrdinal(testText1, testText2);

			return result == 0;
		}
	}
}
