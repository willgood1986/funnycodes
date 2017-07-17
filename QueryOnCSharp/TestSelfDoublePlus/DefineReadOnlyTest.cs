using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSelfDoublePlus
{
	class DefineReadOnlyTest
	{
		private readonly List<Int32> MyNumbers = new List<Int32>();

		internal DefineReadOnlyTest()
		{
			MyNumbers = null;
		}

		internal Int32 GetItemCount()
		{
			var result = 0;

			if (MyNumbers != null)
			{
				result = MyNumbers.Count;
			}
			else
			{
				Console.WriteLine("Readonly field can be edited in the constructor.");
			}
			return result;
		}
	}
}
