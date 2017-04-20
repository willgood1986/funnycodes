using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.ComponentModel;
using System.Net;
using System.Configuration;
using System.Globalization;

namespace UseSmtpClient
{
	class Program
	{
		private static readonly String Sender = "sender";

		private static readonly String Recipients = "recipients";

		private static readonly String Credential_User = "credential_user";

		private static readonly String Credential_Password = "credential_password";

		private static readonly String SMTP_Server = "smtp_server";

		private static readonly String SSL = "ssl";

		private static readonly String PORT = "port";


		private static Boolean mailSent = false;

		private static void SendCompletedCallback(
			Object sender, 
			AsyncCompletedEventArgs e
			)
		{
			var token = (String)e.UserState;

			if (e.Cancelled)
			{
				Console.WriteLine("[{0}] send canceled.", token);
			}

			if (e.Error != null)
			{
				Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
			}
			else
			{
				Console.WriteLine("Message sent.");
			}
		}

		private static Int32 GetInt32SettingValue(
			String i_itemName
			)
		{
			var value = GetStringSettingValue(i_itemName);

			var result = Int32.Parse(value);

			return result;
		}

		private static Boolean GetBooleanSettingValue(
			String i_itemName
			)
		{
			var value = GetStringSettingValue(i_itemName);

			var result = Boolean.Parse(value);

			return result;
		}

		private static String GetStringSettingValue(
			String i_itemName
			)
		{
			var result = ConfigurationSettings.AppSettings[i_itemName];

			if (String.IsNullOrEmpty(result))
			{
				throw new Exception(String.Format("No setting item {0}", i_itemName));
			}

			return result;
		}

		private static void SendEmail(
			)
		{
			var smtpHost = GetStringSettingValue(SMTP_Server);

			var port = GetInt32SettingValue(PORT);

			var smtpClient = new SmtpClient(smtpHost, port);

			var useSsl = GetBooleanSettingValue(SSL);

			var credential_user = GetStringSettingValue(Credential_User);

			var credential_password = GetStringSettingValue(Credential_Password);

			var sender = GetStringSettingValue(Sender);

			var recipients = GetStringSettingValue(Recipients);

			var recipientList = new List<String>(recipients.Split(';'));

			smtpClient.EnableSsl = useSsl;

			Console.WriteLine("SSL= {0}", useSsl ? "On" : "Off");

			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential(
				credential_user, credential_password);

			Console.WriteLine("Credential, User: {0}", credential_user);

			var from = new MailAddress(sender, sender);

			var message = new MailMessage();

			message.From = from;
			Console.WriteLine("Sender:" + from.Address);

			foreach (var recipient in recipientList)
			{
				message.To.Add(recipient);
				Console.WriteLine("To:" + recipient);
			}

			message.Body = "Hi," + Environment.NewLine + "Have fun!";
			message.BodyEncoding = System.Text.Encoding.UTF8;
			message.Subject = "Test Mail with Tls";
			message.SubjectEncoding = System.Text.Encoding.UTF8;

			smtpClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

			var userState = "Test Message1";
			smtpClient.SendAsync(message, userState);

			Console.WriteLine(
				"Sending message... Press c to cancel mail. Press any other key to exit.");

			var answer = Console.ReadLine();

			if (answer.StartsWith("c", true, CultureInfo.InvariantCulture) && mailSent == false)
			{
				smtpClient.SendAsyncCancel();
			}

			message.Dispose();
			Console.WriteLine("Goodbye.");
		}

		[Obsolete]
		private static void SplitString(
			)
		{
			var recipients = GetStringSettingValue(Recipients);

			Console.WriteLine("Source string is {0}", recipients);

			var recipientList = recipients.Split(';');

			for (var i = 0; i < recipientList.Length; i++)
			{
				Console.WriteLine(recipientList[i]);
			}
		}

		static void Main(string[] args)
		{
			SendEmail();

			Console.WriteLine();

			Console.ReadKey();
		}
	}
}
