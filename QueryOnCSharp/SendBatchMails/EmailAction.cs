using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithEws
{
	[Flags]
	enum EmailAction
	{
		Query = 0,
		Reply = 1,
		Delte = 2
	}
}
