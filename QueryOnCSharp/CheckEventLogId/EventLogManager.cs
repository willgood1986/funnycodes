using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckEventLogId
{
	class EventLogManager
	{
		private readonly List<SimpleEventLog> m_eventLogs = new List<SimpleEventLog>();

		private String ApplicationEventLog = "Application";
		private String LocalHost = "LocalHost";

		public void LoadEventLogs()
		{
			if (EventLog.Exists(ApplicationEventLog, LocalHost))
			{
				var eventLog = new EventLog(ApplicationEventLog, LocalHost);

				m_eventLogs.Clear();

				foreach (EventLogEntry entry in eventLog.Entries)
				{
					m_eventLogs.Add(
						new SimpleEventLog
						{
							EventLogId = entry.InstanceId,
							EventLogIndex = entry.Index,
							Source = entry.Source,
							Description = entry.Message
						});
				}
			}

		}

		public Int32 EventCount
		{
			get
			{
				return m_eventLogs.Count;
			}
		}

		public SimpleEventLog this[Int32 index]
		{
			get
			{
				if (index < EventCount)
				{
					return m_eventLogs[index];
				}
				else
				{
					return null;
				}
			}
		}
	}
}
