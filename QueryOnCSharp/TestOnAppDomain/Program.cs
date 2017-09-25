using System;
using System.Collections.Generic;
using System.Linq;

namespace TestOnAppDomain
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			BasicAppDomain.PrintCurrentDomain();

			Console.ReadKey();
		}
	}
}
