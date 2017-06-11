using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckEventLogId
{
	class SimpleEventLog
	{
		public Int64 EventLogId
		{
			get;
			set;
		}

		public Int32 EventLogIndex
		{
			get;
			set;
		}

		public String Source
		{
			get;
			set;
		}

		public String Description
		{
			get;
			set;
		}
	}
}
