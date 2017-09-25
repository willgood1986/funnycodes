using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestOnAppDomain
{
	[Serializable]
	public class MarshalByValType
	{
		private DateTime m_creationTime = DateTime.Now;

		public MarshalByValType()
		{
			Console.WriteLine(
				"{0} octor running in {1}, created on {2:D}",
				this.GetType().ToString(),
				Thread.GetDomain().FriendlyName,
				m_creationTime);
		}

		public override string ToString()
		{
			return m_creationTime.ToLongDateString();
		}
	}
}
