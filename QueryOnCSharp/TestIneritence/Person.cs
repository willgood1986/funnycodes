using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIneritence
{
	internal class Person
	{
		private String m_name;

		private String m_address;

		internal Person() : this(String.Empty, String.Empty)
		{ 
		}

		internal Person(
			String i_name,
			String i_address
			)
		{
 
		}

		internal Person(
			String i_name
			)
			: this(i_name, String.Empty)
		{
 
		}

	}
}
