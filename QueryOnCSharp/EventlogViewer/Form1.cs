using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventlogViewer
{
	public partial class Form1 : Form
	{
		private EventLogWrapper m_eventLogWrapper;

		public Form1()
		{
			InitializeComponent();
		}

		private EventLogEntryCollection m_eventLogs;

		private void button1_Click(object sender, EventArgs e)
		{
			var logIndexString = tbIndex.Text.Trim();

			if (!string.IsNullOrEmpty(logIndexString))
			{
				var logIndex = Int32.Parse(logIndexString);

				var eventLogEntries = m_eventLogWrapper.EnumerateAllEvents();

				

				if (eventLogEntries == null)
				{
					MessageBox.Show("No event log entries.");
				}
				else
				{
					lbEventlogs.Items.Clear();

					foreach (EventLogEntry entry in eventLogEntries)
					{
						if (entry.Index == logIndex)
						{
							//lbEventlogs.Items.Add(
							//	String.Format(
							//	"Index:{0}, Event id:{1}, Source:{2}, time:{3}, message:{4}", 
							//	entry.Index, 
							//	entry.EventID, 
							//	entry.Source, 
							//	entry.TimeGenerated, 
							//	entry.Message));

							lbEventlogs.Items.Add("-----Item----");
							lbEventlogs.Items.Add(String.Format("Index:{0}", entry.Index));
							lbEventlogs.Items.Add(String.Format("Event Id:{0}", entry.EventID));
							lbEventlogs.Items.Add(String.Format("Source:{0}", entry.Source));
							lbEventlogs.Items.Add(String.Format("Time:{0}", entry.TimeGenerated));
							lbEventlogs.Items.Add(String.Format("Message:{0}", entry.Message));
						}
					}
				}
			}
			else
			{
				MessageBox.Show("Log index is not specified.");
			}
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			var logName = tbLog.Text.Trim();
			var server = tbServer.Text.Trim();

			if (String.IsNullOrEmpty(logName) || String.IsNullOrEmpty(server))
			{
				MessageBox.Show("Event log name or server is not specified.");
			}
			else
			{
				m_eventLogWrapper = new EventLogWrapper(logName, server);
				if (m_eventLogWrapper.EventLogFound)
				{
					m_eventLogs = m_eventLogWrapper.EnumerateAllEvents();

					MessageBox.Show("Event found.");
				}
				else
				{
					MessageBox.Show("Event not found.");
				}
			}
		}

		private void DupliateEvent(
			Int32 i_duplicateTimes,
			EventLogEntry i_sourceEventLogEntry
			)
		{
			var eventLog = i_sourceEventLogEntry;

			for (var i = 0; i < i_duplicateTimes; i++)
			{
				{
					EventLog.WriteEntry(eventLog.Source, eventLog.Message, eventLog.EntryType, eventLog.EventID, eventLog.CategoryNumber, eventLog.Data);
				}
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
		    const Int32 DuplicateTimes = 1000;
			var eventLog = m_eventLogs[0];

			if (eventLog != null)
			{
				DupliateEvent(DuplicateTimes, eventLog);

				MessageBox.Show("Duplicate complete.");
			}
			else
			{
				MessageBox.Show("Event log not found.");
			}
		}

		private void btnPrintIndex_Click(object sender, EventArgs e)
		{
			//var indexString = String.Concat(",", String.Concat(m_eventLogs[0].Index, m_eventLogs[1].Index, m_eventLogs[2].Index, m_eventLogs[3].Index));

			var indexString = String.Empty;

			for (var index = 0; index < 10; index++)
			{
				indexString = String.Concat(indexString, m_eventLogs[index].Index, ";");
			}


			MessageBox.Show("Index from start is:" + indexString);
		}
	}
}
