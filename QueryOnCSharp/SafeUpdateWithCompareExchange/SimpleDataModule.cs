using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SafeUpdateWithCompareExchange
{
	class SimpleDataModule
	{
		private Double m_total;

		internal Double Total 
		{ 
			get 
			{ 
				return m_total; 
			} 
		}

		internal Double AddTotal(
			Double i_increment
			)
		{
			Double init;
			Double computed;
			do
			{
				init = m_total;
				computed = m_total + i_increment;
			} while (init != Interlocked.CompareExchange(ref m_total, computed, init));

			return computed;
		}
	}
}
