using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventlogViewer
{
	class EventLogWrapper
	{
		public String EventLogName { get; set; }

		public String ServerName { get; set; }

		private Boolean IsIntializationSuccessful { get; set; }

		private EventLog m_eventLog;

		public static Boolean IsSpecifiedEventLogExisting(
			String i_eventLogName,
			String i_serverName
			)
		{
			var result = EventLog.Exists(i_eventLogName, i_serverName);

			return result;
		}

		public static Boolean IsEventSourceExisting(
			String i_eventSource,
			String i_serverName
			)
		{
			var result = EventLog.SourceExists(i_eventSource, i_serverName);

			return result;
		}

		public EventLogWrapper(
			String i_eventLogName,
			String i_serverName
			)
		{
			EventLogName = i_eventLogName;
			ServerName = i_serverName;

			if (IsEventSourceExisting(i_eventLogName, i_serverName))
			{
				m_eventLog = new EventLog(i_eventLogName, i_serverName);
			}
		}

		public Boolean EventLogFound
		{
			get
			{
				return m_eventLog != null;
			}
		}

		internal EventLogEntryCollection EnumerateAllEvents()
		{
			EventLogEntryCollection result = null;

			if (m_eventLog != null)
			{
				result = m_eventLog.Entries;
			}
			else
			{
				
			}

			return result;
		}
	}
}
