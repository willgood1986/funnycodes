using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConstructor
{
	class Program
	{
		private static Pen CreateAPenInstance()
		{
			var pen = new Pen(10D, 10D, 10D);

			return pen;
		}

		private static void Test()
		{
			var pen = new Pen()
			{
				Length = 1D,
				Weight = 1D,
				Price = 0.5D
			};

			Console.WriteLine(
				"Pen(Length:{0}, Weight:{1}, Price:{2})", pen.Length, pen.Weight, pen.Price);
		}

		static void Main(string[] args)
		{
			Test();
			Console.ReadLine();
		}
	}
}
