using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainy.Work
{
	public class TestEws : ITester
	{
		public String Title
		{
			get
			{
				return "Test Ews";
			}
		}

		public void BeforeRunningTest()
		{
			Console.WriteLine("Test starts, test name:" + Title);
		}

		public void PostRunningTest()
		{
			Console.WriteLine("Test ends, test name:" + Title);
		}

		public void Run()
		{
			var ews = new EwsWorkLibrary("willgood1986@outlook.com", "#######", false);
			ews.AutoDiscover("willgood1986@outlook.com", true);

			Console.WriteLine("Auto discover result url:" + ews.ServiceUrl);

			Console.WriteLine("Run Send email");

			// send mail
			var recepients = new List<String>
			{
				"rainy.chen@test.com",
				"rainychan@yeah.net",
				"willgood1986@outlook.com"
			};

			String errorMessage = "";
			var sendResult = ews.SendAMail(
				recepients, "This is a test mail", "Hello, here is EWS!", out errorMessage);

			if (!sendResult)
			{
				Console.WriteLine("Send mail failed, message:" + errorMessage);
			}
			else
			{
				Console.WriteLine("Mail sends successfully!");
			}

			Console.WriteLine("Test Collect emails");

			var results = ews.CollectEmailHeadersByFolderType("DeletedItems");

			foreach (var item in results)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine("Start to delete...");
			ews.DeleteEmailsByFolderType("DeletedItems");

			Console.WriteLine("Delete email from rotest@ucdzhuhai.site");
			ews.DeleteInboxMailsBySender("rotest@ucdzhuhai.site");
		}
	}
}
