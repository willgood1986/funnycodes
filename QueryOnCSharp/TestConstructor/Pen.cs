using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConstructor
{
	internal class Pen
	{
		private Double m_length;

		private Double m_weight;

		private Double m_price;

		internal Pen()
		{
			Console.WriteLine("Enter constructor.");
			m_length = 0D;
			m_weight = 0D;
			m_price = 0D;
		}

		internal Pen(
			Double i_length,
			Double i_weight,
			Double i_price
			)
		{
			m_length = i_length;
			m_weight = i_weight;
			m_price = i_price;
		}

		internal Double Length 
		{
			get
			{
		        return m_length; 
	        }

			set
			{
				Console.WriteLine("Enter: Set Length.");
				if (value > 0)
				{
					Console.WriteLine("Enter: Set Length. > 0");
					m_length = value;
				}
			}
		}

		internal Double Weight
		{
			get
			{
				return m_weight;
			}

			set
			{
				Console.WriteLine("Enter: Set Weight.");
				if (value > 0)
				{
					m_weight = value;
				}
			}
		}

		internal Double Price
		{
			get
			{
				return m_price;
			}

			set
			{
				if (value > 0)
				{
					m_price = value;
				}
			}
		}

	}
}
