

using System;
using System.Collections.Generic;
using System.Linq;

// -------------------------------------------------------------------------------------------------
using Microsoft.Exchange.WebServices.Data;

// =================================================================================================
// CLASSES

namespace Rainy.Work
{
	public class EwsWorkLibrary
	{
		// -----------------------------------------------------------------------------------------
		// Fields

		private ExchangeService m_service;
		private String m_serviceUrl;
		private Int32 m_serverVersionID;
		private String m_serverVersion;

		private String m_credentialAccount;

		private static EwsWorkLibrary sm_ewsWorkLibrary;

		private static readonly MessageBody sm_messageBody =
			new MessageBody("Auto reply for test.");

		// -----------------------------------------------------------------------------------------
		// Constructors

		public EwsWorkLibrary()
		{
			m_service = new ExchangeService(ExchangeVersion.Exchange2010);
		}

		public EwsWorkLibrary(
			String i_userName,
			String i_password,
			Boolean i_useDefaultCredentials
			)
			: this()
		{
			m_service.Credentials = new WebCredentials(i_userName, i_password);
			m_service.UseDefaultCredentials = i_useDefaultCredentials;
			m_credentialAccount = i_userName;
		}

		// -----------------------------------------------------------------------------------------
		// Properties

		public String CredentialAccount
		{
			get
			{
				return m_credentialAccount;
			}
		}

		public String ServiceUrl
		{
			get
			{
				return m_serviceUrl;
			}
		}

		public Int32 ServerVersionID
		{
			get
			{
				return m_serverVersionID;
			}
		}

		public String ServerVersion
		{
			get
			{
				return GetServerVersionFromID(m_serverVersionID);
			}
		}

		// -----------------------------------------------------------------------------------------
		// Functions

		/// <exception cref="ArgumentException"/>
		/// <exception cref="InvalidOperationException">This instance represents a relative URI,
		/// and this property is valid only for absolute URIs.</exception>
		public static EwsWorkLibrary Init(
			String i_account,
			String i_password,
			String i_ewsUrl
			)
		{
			if (sm_ewsWorkLibrary != null)
			{
				return sm_ewsWorkLibrary;
			}
			else
			{
				var result = new EwsWorkLibrary(i_account, i_password, false);

				if (!TryToDiscover(result, i_ewsUrl))
				{
					var exceptionMessage = String.Format(
						"Failed to initialize Ews work library by account:{0}", i_account);

					throw new ArgumentException(exceptionMessage);
				}

				sm_ewsWorkLibrary = result;

				return result;
			}
		}

		/// <exception cref="InvalidOperationException">This instance represents a relative URI,
		/// and this property is valid only for absolute URIs.</exception>
		public void AutoDiscover(
			String i_smtpPrimaryAddress,
			Boolean i_authenticationNeeded
			)
		{
			m_service.AutodiscoverUrl(
				i_smtpPrimaryAddress, AutodiscoverRedirectionUrlValidationCallback);

			m_serviceUrl = m_service.Url.AbsoluteUri;

			if (i_authenticationNeeded)
			{
				// Just invoke and check out if the service is ready
				m_service.ResolveName("test@QQ.COM");
			}
		}

		public void DiscoverWithSpecificUrl(
			String i_url,
			Boolean i_authenticationNeeded
			)
		{
			m_service.Url = new Uri(i_url);

			Console.WriteLine("next tro authentication");

			if (i_authenticationNeeded)
			{
				// Just invoke and check out if the service is ready
				m_service.ResolveName("test@QQ.COM");
			}
		}

		public Boolean SendAMail(
			IEnumerable<String> i_receipients,
			String i_subject,
			String i_body,
			out String io_error
			)
		{
			var result = false;
			io_error = String.Empty;

			try
			{
				var email = new EmailMessage(m_service);
				email.ToRecipients.AddRange(i_receipients);
				email.Subject = i_subject;
				email.Body = i_body;
				email.Send();
				result = true;
			}
			catch (Exception e)
			{
				io_error = e.Message;
			}

			return result;
		}

		public IEnumerable<EmailMessage> CollectEmailsByFolderType(
			String i_wellKnownFolderName
			)
		{
			var folderNameType = ResolveFolderNameTypesByFolderName(i_wellKnownFolderName);

			var folderId = new FolderId(folderNameType);
			var view = new ItemView(Int32.MaxValue);
			var findItems = m_service.FindItems(folderId, view);

			var results = findItems.Cast<EmailMessage>();

			return results;
		}

		public IEnumerable<String> CollectEmailHeadersByFolderType(
			String i_wellKnownFolderName
			)
		{
			var emails = CollectEmailsByFolderType(i_wellKnownFolderName);

			var lists = emails.ToList<EmailMessage>();

			var results = new List<String>();

			foreach (var email in emails)
			{
				results.Add(email.Subject);
			}

			return results;
		}

		public void DeleteInboxMailsBySender(
			String i_sernder
			)
		{
			var results = CollectEmailsByFolderType("Inbox");

			foreach (var email in results)
			{
				if (email.Sender != null &&
					email.Sender.Address != null &&
					email.Sender.Address.ToLower().Contains(i_sernder.ToLower()))
				{
					Console.WriteLine("Delete email from {0}", email.Sender.Address);
					email.Delete(DeleteMode.HardDelete);
				}
			}
		}

		public void DeleteEmailsByFolderType(
			String i_wellKnownFolderName
			)
		{
			var emails = CollectEmailsByFolderType(i_wellKnownFolderName);
			foreach (var email in emails)
			{
				email.Delete(DeleteMode.HardDelete);
			}
		}

		public void GetMessagesFromInbox(
			String i_accountName,
			Int32 i_maxCount
			)
		{
			var inbox = Folder.Bind(m_service, WellKnownFolderName.Inbox);

			var filter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));

			var results = m_service.FindItems(WellKnownFolderName.Inbox, new ItemView(i_maxCount));

			Console.WriteLine("Number of found message: {0}", results.Count());

			foreach (var item in results.Cast<EmailMessage>())
			{

				Console.WriteLine("Message subject: {0}, isRead:{1}", item.Subject, item.IsRead);

				if (item.Subject.StartsWith("ss"))
				{
					item.Delete(DeleteMode.MoveToDeletedItems);
				}
			}

			//return results;
		}

		public void ConfigureAutoReply(
			String i_mailbox
			)
		{
			var oofSetting = new OofSettings();
			oofSetting.State = OofState.Scheduled;
			oofSetting.Duration = new TimeWindow(DateTime.Now, DateTime.Now.AddDays(1));
			oofSetting.ExternalAudience = OofExternalAudience.All;
			oofSetting.InternalReply = new OofReply("Auto reply, don't reply it.");
			oofSetting.ExternalReply = oofSetting.InternalReply;
			m_service.SetUserOofSettings(i_mailbox, oofSetting);
		}

		public void RemoveMessage(
			Int32 i_maxNumber
			)
		{
			const String TestMailSubjectToken = "UC Diagnostics";

			var results = QueryMessagesWithSpecificSubject(TestMailSubjectToken, i_maxNumber);

			var foundCount = results.Count();

			Console.WriteLine("{1}: Number of found message: {0}", foundCount, DateTime.Now);

			DeleteMessages(results);
		}

		public Boolean ReplyAndRemove(
			Int32 i_maxNumber
			)
		{
			const String TestMailSubjectToken = "UC Diagnostics";

			var results = QueryMessagesWithSpecificSubject(TestMailSubjectToken, i_maxNumber);

			var foundCount = results.Count();

			Console.WriteLine("{1}: Number of found message: {0}", foundCount, DateTime.Now);

			if (foundCount == 0)
			{
				return false;
			}

			ReplyTestMessages(results);

			DeleteMessages(results);

			return true;
		}

		// -----------------------------------------------------------------------------------------
		// Helper Functions

		/// <exception cref="InvalidOperationException">This instance represents a relative URI,
		/// and this property is valid only for absolute URIs.</exception>
		private static Boolean TryToDiscover(
			EwsWorkLibrary i_ewsWorkLibrary,
			String i_ewsUrl
			)
		{
			var result = true;

			try
			{
				if (!String.IsNullOrEmpty(i_ewsUrl))
				{
					i_ewsWorkLibrary.DiscoverWithSpecificUrl(i_ewsUrl, true);
				}
				else
				{
					i_ewsWorkLibrary.AutoDiscover(i_ewsWorkLibrary.CredentialAccount, true);
				}
			}
			catch
			{
				result = false;
			}

			return result;
		}

		private void FindAllSubFolders(
			FolderId i_parentFolderId,
			List<Folder> i_completeListOfFolderIds
			)
		{
			var folderView = new FolderView(Int32.MaxValue);
			var foundFolders = m_service.FindFolders(i_parentFolderId, folderView);

			i_completeListOfFolderIds.AddRange(foundFolders);

			foreach (var folder in foundFolders)
			{
				FindAllSubFolders(folder.Id, i_completeListOfFolderIds);
			}
		}

		/// <exception cref="ArgumentException"/>
		private WellKnownFolderName ResolveFolderNameTypesByFolderName(
			String i_folderName
			)
		{
			var result = (WellKnownFolderName)Enum.Parse(typeof(WellKnownFolderName), i_folderName);

			if (result == null)
			{
				throw new ArgumentException(String.Format("Failed to resolve {0} to any member " +
					"of WellKnownFolderName", i_folderName));
			}

			return result;
		}

		private String GetServerVersionFromID(
			Int32 i_serverVersionID
			)
		{
			switch (i_serverVersionID)
			{
				case 12: return "Exchange Server 2007";
				case 14: return "Exchange Server 2010";
				default: return "Unknown Version";
			}
		}

		private Boolean AutodiscoverRedirectionUrlValidationCallback(
			String i_redirectionUrl
			)
		{
			return true;
		}

		private IEnumerable<EmailMessage> QueryMessagesWithSpecificSubject(
			String i_subjectStartPart,
			Int32 i_maxSize
			)
		{
			var folders = Folder.Bind(
				m_service, WellKnownFolderName.Inbox | WellKnownFolderName.JunkEmail);

			var results = folders.FindItems(new ItemView(i_maxSize)).Cast<EmailMessage>().Where(
				mail => mail.Subject.StartsWith(i_subjectStartPart));

			return results;
		}

		private void ReplyTestMessages(
			IEnumerable<EmailMessage> i_results)
		{
			foreach (var email in i_results)
			{
				email.Reply(sm_messageBody, false);
			}
		}

		private void DeleteMessages(
			IEnumerable<EmailMessage> i_results)
		{
			foreach (var email in i_results)
			{
				email.Delete(DeleteMode.HardDelete);

				Console.WriteLine(
					"Subject: {0}, received time: {1} was deleted!",
					email.Subject,
					email.DateTimeReceived);
			}
		}
	}
}