using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Threading;

namespace TestOnAppDomain
{
	internal class BasicAppDomain
	{
		internal static void PrintCurrentDomain()
		{
			var adCallingThreadDomain = Thread.GetDomain();

			Console.WriteLine("Domain name: {0}", adCallingThreadDomain.FriendlyName);

			var callingDomainName = adCallingThreadDomain.FriendlyName;
			Console.WriteLine("Default AppDomain's friendly name={0}", callingDomainName);

			var exeAssembly = Assembly.GetEntryAssembly().FullName;
			Console.WriteLine("Main assembly={0}", exeAssembly);

			AppDomain ad2 = null;

			Console.WriteLine("{0} Demo #1", Environment.NewLine);

			ad2 = AppDomain.CreateDomain("AD #2", null, null);

			MarshalByRefType mbrt = null;

			// It needs the Full Qualified Domain Name Namespace + Class Name
			var typeFullName = typeof(MarshalByRefType).FullName;

			Console.WriteLine("Marshal by ref type full name: {0}", typeFullName);

			mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, typeFullName);

			Console.WriteLine("Type={0}", mbrt.GetType());

			Console.WriteLine("Is proxy={0}", RemotingServices.IsTransparentProxy(mbrt));

			mbrt.SomeMethod();

			AppDomain.Unload(ad2);

			try
			{
				mbrt.SomeMethod();
				Console.WriteLine("Failed call.");
			}
			catch (AppDomainUnloadedException)
			{
				Console.WriteLine("Failed call due to unloaded app domain");
			}

			Console.WriteLine("{0}Demo # 2", Environment.NewLine);

			var secondDomain = AppDomain.CreateDomain("AD #2", null, null);

			mbrt = (MarshalByRefType)secondDomain.CreateInstanceAndUnwrap(
				exeAssembly, typeof(MarshalByRefType).FullName);

			// Ref by value is totally a copy
			var mbvt = mbrt.MethodWithReturn();

			Console.WriteLine("Returned object created " + mbvt.ToString());

			AppDomain.Unload(secondDomain);

			try
			{
				Console.WriteLine("Returned object created " + mbvt.ToString());
				Console.WriteLine("Successful call.");
			}
			catch (AppDomainUnloadedException)
			{
				Console.WriteLine("Failed call due to app unloaded");
			}
		}
	}
}
