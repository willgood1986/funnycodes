using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainy.Work
{
	interface ITester
	{
		String Title
		{
			get;
		}

		void BeforeRunningTest();

		void Run();

		void PostRunningTest();
	}
}
