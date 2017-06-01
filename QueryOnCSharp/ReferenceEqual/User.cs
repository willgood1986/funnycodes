using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceEqual
{
	class User
	{
		private String m_name;

		private String m_id;

		internal User(
			String i_name,
			String i_id
			)
		{
			m_id = i_id;
			m_name = i_name;
		}

		internal User()
			: this(String.Empty, String.Empty)
		{ }

		public override string ToString()
		{
			return String.Format("Id:{0}, Name:{1}", m_id, m_name);
		}
	}
}
