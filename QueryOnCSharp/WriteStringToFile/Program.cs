using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteStringToFile
{
	class Program
	{
		static void Main(string[] args)
		{
			StringWriter.WriteString("I am a single line.");

			Console.ReadKey();
		}
	}
}
