using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLibrary
{
    public static class WindowsManagement
    {
		public static Boolean IsUserAdministrator()
		{
			Boolean result;

			try
			{
				var identity = WindowsIdentity.GetCurrent();
				var principal = new WindowsPrincipal(identity);

				result = principal.IsInRole(WindowsBuiltInRole.Administrator);
			}
			catch(UnauthorizedAccessException)
			{
				result = false;
			}
			catch(Exception)
			{
				result = false;
			}

			return result;
		}
    }
}
