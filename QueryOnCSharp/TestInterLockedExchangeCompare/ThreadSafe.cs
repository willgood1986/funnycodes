using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TestInterLockedExchangeCompare
{
	class ThreadSafe
	{
		private Double totalValue = 0.0;

		public Double Total
		{
			get
			{
				return totalValue;
			}
		}

		public Double AddTotal(
			Double i_addend
			)
		{
			Double initialValue, computedValue;

			do
			{
				initialValue = this.totalValue;

				computedValue = initialValue + i_addend;

			} while (initialValue != Interlocked.CompareExchange(ref this.totalValue, computedValue, initialValue));

			return computedValue;
		}
	}
}
