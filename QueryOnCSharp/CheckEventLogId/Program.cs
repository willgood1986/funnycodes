using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckEventLogId
{
	class Program
	{
		static void ListAllEvents()
		{
			var eventLogManager = new EventLogManager();

			Console.WriteLine("Before Load EventLogs");

			eventLogManager.LoadEventLogs();

			for (var i = 0; i < eventLogManager.EventCount; i++)
			{
				var eventLog = eventLogManager[i];

				if (eventLog != null)
				{
					Console.WriteLine(
						"Event instance Id:{0}, index: {1}", 
						eventLog.EventLogId, 
						eventLog.EventLogIndex);
					break;
				}
				else
				{
					Console.WriteLine("Event log is Null.");
				}
			}
		}

		static void Test()
		{
			var a = 3;
			var b = 4;

			if (a > 1 && a < 3 || b > 4 && b < 5)
			{
				Console.WriteLine("True");
			}
			else
			{
 				Console.WriteLine("False");
			}
		}

		static void CompareDateTime()
		{
			var time1 = new DateTime(2017, 6, 7, 8, 9, 2, 30, DateTimeKind.Local);
			var time2 = new DateTime(2017, 6, 7, 8, 9, 2, 31, DateTimeKind.Local);

			if (time1 == time2)
			{
				Console.WriteLine("The same! Error.");
			}
			else
			{
				Console.WriteLine("Not the same! Right!");
			}
		}

		static void Main(string[] args)
		{
			//ListAllEvents();

			//Test();

			CompareDateTime();

			Console.ReadLine();
		}
	}
}
