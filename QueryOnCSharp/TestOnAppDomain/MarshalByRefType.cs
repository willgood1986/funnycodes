using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestOnAppDomain
{
	public class MarshalByRefType : MarshalByRefObject
	{
		public MarshalByRefType()
		{
			Console.WriteLine(
				"{0} ctor running in {1}", this.GetType(), Thread.GetDomain().FriendlyName);
		}

		public void SomeMethod()
		{
			Console.WriteLine("Executing in " + Thread.GetDomain().FriendlyName);
		}

		public MarshalByValType MethodWithReturn()
		{
			Console.WriteLine("Executing in" + Thread.GetDomain().FriendlyName);
			var result = new MarshalByValType();
			return result;
		}
	}
}
