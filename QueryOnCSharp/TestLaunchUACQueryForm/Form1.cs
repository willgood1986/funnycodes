using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestLaunchUACQueryForm
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(
			Object i_sender, 
			EventArgs i_eventArgs
			)
		{
			var isRunningUnderAdmin = GeneralLibrary.WindowsManagement.IsUserAdministrator();

			if (isRunningUnderAdmin)
			{
				MessageBox.Show("It's running under Administrator!");
			}
			else
			{
				MessageBox.Show("It's running under non-Administrator!");
			}
		}
	}
}
