using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormat
{
	class Program
	{
		static void Main(string[] args)
		{
			var outputString = "Can you see me?";

			var stringFormat = "Output data: {}";

			try
			{
				Console.WriteLine(stringFormat, outputString);
			}
			catch (Exception e)
			{
				Console.WriteLine(
					"Exception caught, type:{0}, invalid format: {1}", e.GetType(), stringFormat);
			}
			Console.ReadLine();
		}
	}
}
