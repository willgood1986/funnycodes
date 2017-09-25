using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDelegate
{
	class TestDelegation
	{
		class Utility
		{
			internal static void PrintMetaInfo(Int32 i_num, String i_name)
			{
				Console.WriteLine("Number is {0}, name is {1}", i_num, i_name);
			}
		}

		class Process
		{
			internal void PrintProcessInfo(Int32 i_processId, String i_processName)
			{
				Console.WriteLine(
					"Process Id is {0}, process name is {1}", i_processId, i_processName);
			}
		}

		private static void Invoke(
			Feedback i_feedback,
			Int32 i_number,
			String i_text
			)
		{
			Console.WriteLine("Pre Invoke");

			if (i_feedback != null)
			{
				i_feedback(i_number, i_text);
			}
			else
			{
				Console.WriteLine("Delegate chain is empty!");
			}

			Console.WriteLine("Post Invoke");
		}

		internal static void Test()
		{
			Feedback chain = null;
			Feedback fe = new Feedback(Utility.PrintMetaInfo);

			var process = new Process();

			chain += fe;

			chain += process.PrintProcessInfo;

			//fe = (Feedback)Delegate.Combine(fe, new Feedback(process.PrintProcessInfo));

			Console.WriteLine("Pre Invoke");
			
			Invoke(chain, 1, "Tom");


			Console.WriteLine("Remove process.PrintProcessInfo");
			chain -= Utility.PrintMetaInfo;

			Invoke(chain, 1, "Tom");

			Console.WriteLine("Remove process.PrintProcessInfo");
			chain -= Utility.PrintMetaInfo;

			Invoke(chain, 1, "Tom");
		}
	}
}
