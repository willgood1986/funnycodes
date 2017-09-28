using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Threading;

// -------------------------------------------------------------------------------------------------
using Rainy.Work;

// =================================================================================================
// CLASSES

namespace SendBatchMails
{
	class Program
	{
		// -----------------------------------------------------------------------------------------
		// Fields

		private const String UserItem = "user";

		private const String PasswordItem = "password";

		private const String RecipientsItem = "recipients";

		private const String MailCountItem = "mailcount";

		private const String IntervalItem = "interval";

		private const String EwsUrlItem = "url";

		private const String LastingByHour = "lastingbyhour";

		private const String CheckIntervalInSecond = "intervalbysecond";

		private const String MaxCheckNumber = "checknumber";

		private const String Action = "action";

		// -----------------------------------------------------------------------------------------
		// Helper Functions

		private static readonly Dictionary<Int32, String> SupportedCommands = 
			new Dictionary<Int32, String> 
			{ 
				{1, "Send batch emails"},
				{2, "Auto reply"},
				{3, "Remove test emails"},
				{4, "Exit"},
			};

		private static void SendMails(
			EwsWorkLibrary i_ews,
			IEnumerable<String> i_recipients
			)
		{
			String errorMessage = "";

			var sendResult = i_ews.SendAMail(
				i_recipients, "This is a test mail", "Hello, here is EWS!", out errorMessage);

			if (!sendResult)
			{
				Console.WriteLine("Send mail failed, message:" + errorMessage);
			}
			else
			{
				Console.WriteLine("Success!");
			}
		}

		/// <exception cref="ConfigurationErrorsException">Could not retrieve a 'System.
		/// Collections.Specialized.NameValueCollection' object with the application settings
		/// data.</exception>
		private static String GetItemFromConfiguration(
			String i_itemName
			)
		{
			var appSettings = ConfigurationManager.AppSettings;

			var result = appSettings.Get(i_itemName);

			return result;
		}

		/// <exception cref="ConfigurationErrorsException">Could not retrieve a 'System.
		/// Collections.Specialized.NameValueCollection' object with the application settings
		/// data.</exception>
		private static void SendBatchMails()
		{
			var appSettings = ConfigurationManager.AppSettings;
			var user = GetItemFromConfiguration(UserItem);
			var password = GetItemFromConfiguration(PasswordItem);

			var splits = new Char[] { ',' };

			var recipients = GetItemFromConfiguration(RecipientsItem).Split(
				splits, StringSplitOptions.RemoveEmptyEntries);
			var sendCount = Convert.ToInt32(GetItemFromConfiguration(MailCountItem));
			var interval = Convert.ToInt32(GetItemFromConfiguration(IntervalItem));
			var url = GetItemFromConfiguration(EwsUrlItem);

			Console.WriteLine("user:{0}, send count: {1}", user, sendCount);

			var ews = new EwsWorkLibrary(user, password, false);
			try
			{
				if (String.IsNullOrEmpty(url))
				{
					Console.WriteLine("Do AutoDiscover");
					ews.AutoDiscover(user, true);
				}
				else
				{
					Console.WriteLine("Do DiscoverWithSpecificUrl, url:{0}", url);
					ews.DiscoverWithSpecificUrl(url, true);
				}

				Console.WriteLine("Logon on success, url:{0}", ews.ServiceUrl.ToString());

				Console.ReadKey();

				for (var i = 1; i < sendCount; i++)
				{
					Console.WriteLine("Current index is {0}", i);
					SendMails(ews, recipients);

					Thread.Sleep(interval);
				}

				Console.WriteLine("Send Mail Over!");
			}
			catch (Exception exception)
			{
				Console.WriteLine("Auto discovery failed! message:" + exception.Message);
			}

		}

		/// <exception cref="ConfigurationErrorsException">Could not retrieve a 'System.
		/// Collections.Specialized.NameValueCollection' object with the application settings
		/// data.</exception>
		private static void ConfigureAutoReply()
		{
			var user = GetItemFromConfiguration(UserItem);

			var password = GetItemFromConfiguration(PasswordItem);

			var ews = EwsWorkLibrary.Init(user, password, null);

			ews.ConfigureAutoReply(user);

			Console.WriteLine("Configure auto reply over");
		}

		/// <exception cref="ConfigurationErrorsException">Could not retrieve a 'System.
		/// Collections.Specialized.NameValueCollection' object with the application settings
		/// data.</exception>
		private static void TestGetMailsFromInbox()
		{
			var user = GetItemFromConfiguration(UserItem);

			var password = GetItemFromConfiguration(PasswordItem);

			var maxNumberItem = GetItemFromConfiguration(MaxCheckNumber);
			var maxNumber = Convert.ToInt32(maxNumberItem);

			var ews = EwsWorkLibrary.Init(user, password, null);

			ews.GetMessagesFromInbox(user, maxNumber);
		}

		/// <exception cref="ConfigurationErrorsException">Could not retrieve a 'System.
		/// Collections.Specialized.NameValueCollection' object with the application settings
		/// data.</exception>
		private static void CheckAndAutoReply()
		{
			const Int32 MilliSecondsOfOneSecond = 1000;

			var checkIntervalBySecond = GetItemFromConfiguration(CheckIntervalInSecond);

			var lastingHours = GetItemFromConfiguration(LastingByHour);

			var until = DateTime.Now.AddHours(Int32.Parse(lastingHours));

			while (DateTime.Now < until)
			{
				try
				{
					if (!ReplyTestMessage())
					{
						Thread.Sleep(Int32.Parse(checkIntervalBySecond) * MilliSecondsOfOneSecond);
					}
				}
				catch (Exception exception)
				{
					Console.WriteLine("{1}: Encounter an exception, message: {0}", exception.Message, DateTime.Now); 
				}
			}
		}

		private static void InvalidChoiceInput()
		{
			Console.WriteLine("Invalid choice input!");
		}

		private static Int32 GetChoice()
		{
			var result = -1;

			var printMenuAgain = true;

			while (printMenuAgain)
			{
				PrintMenu();

			    var choice = Console.ReadLine();

				if (!Int32.TryParse(choice, out result))
				{
					InvalidChoiceInput();
					printMenuAgain = true;
				}
				else
				{
					if (IsChoiceInvalid(result))
					{
						InvalidChoiceInput();
						printMenuAgain = true;
					}
					else
					{
						printMenuAgain = false;
					}
				}
			}

			return result;
		}

		private static Boolean IsChoiceInvalid(
			Int32 i_choiceIndex
			)
		{
			if (SupportedCommands.ContainsKey(i_choiceIndex))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <exception cref="ConfigurationErrorsException">Could not retrieve a 'System.
		/// Collections.Specialized.NameValueCollection' object with the application settings
		/// data.</exception>
		/// <exception cref="InvalidOperationException">The 'System.Console.In' property is
		/// redirected from some stream other than the console.</exception>
		private static void Main(string[] args)
		{
			// ConfigureAutoReply();

			// TestGetMailsFromInbox();

			//CheckAndAutoReply();

			var choiceFlag = GetChoice();

			if (choiceFlag == 2)
			{
				CheckAndAutoReply();
			}
			else
			{
				if (choiceFlag == 1)
				{
					;
				}
				else
				{
					if (choiceFlag == 4)
					{
						return;
					}
					else
					{
						if (choiceFlag == 3)
						{
							RemoveTestMessage();
						}
					}
				}
			}

			Console.ReadKey();
		}

		private static void PrintMenu()
		{
			Console.WriteLine("\t -- Function Menu ---\t");

			foreach (var item in SupportedCommands)
			{
 				Console.WriteLine(
					"***>\t[{0}]  {1}\t", item.Key, item.Value);
			}

			Console.WriteLine("Please input your choice >\t");
		}

		/// <exception cref="ConfigurationErrorsException">Could not retrieve a 'System.
		/// Collections.Specialized.NameValueCollection' object with the application settings
		/// data.</exception>
		private static Boolean ReplyTestMessage()
		{
			var user = GetItemFromConfiguration(UserItem);

			var password = GetItemFromConfiguration(PasswordItem);

			var maxNumberItem = GetItemFromConfiguration(MaxCheckNumber);
			var maxNumber = Int32.Parse(maxNumberItem);

			var urlItem = GetItemFromConfiguration(EwsUrlItem);

			String url = null;
			if (!String.IsNullOrEmpty(urlItem))
			{
				url = urlItem;
			}

			var ews = EwsWorkLibrary.Init(user, password, url);

			var result = ews.ReplyAndRemove(maxNumber);

			return result;
		}

		private static void RemoveTestMessage()
		{
			var user = GetItemFromConfiguration(UserItem);

			var password = GetItemFromConfiguration(PasswordItem);

			var maxNumberItem = GetItemFromConfiguration(MaxCheckNumber);
			var maxNumber = Int32.Parse(maxNumberItem);

			var ews = EwsWorkLibrary.Init(user, password, null);

			ews.RemoveMessage(maxNumber);
		}
	}
}