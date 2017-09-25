using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDispose
{
	class Program
	{
		static void Main(string[] args)
		{
			CloseNativeResource.AccessObjectPostDispose();

			Console.ReadKey();
		}
	}
}
