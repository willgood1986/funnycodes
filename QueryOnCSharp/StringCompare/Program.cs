using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCompare
{
	class Program
	{
		private static void CompareStringTest()
		{
			String s1 = String.Empty;
			String s2 = null;

			// Console.WriteLine("null.Eqauls(String.Empty) result: {0}", s1.Equals(s2));

			Console.WriteLine("null == String.Empty result: {0}", s1 == s2);
		}

		private static void CheckDefaultValue()
		{
			var defaultObject = new DefaultValueInObject();

			Console.WriteLine("defaultObject.Name is null? {0}", defaultObject.Name == null);
		}

		static void Main(string[] args)
		{
			CompareStringTest();

			CheckDefaultValue();

			var manType = PersonType.Man;

			Console.WriteLine("Person type:{0}", manType.ToString());
			Console.ReadLine();
		}
	}
}
