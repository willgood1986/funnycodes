using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace StartAProgramAndWait
{
	internal static class StartProgramHelper
	{
		// -----------------------------------------------------------------------------------------
		// Internal Functions

		/// <exception cref="InvalidOperationException">The process has already exited.
		/// -or-There is no process associated with this 'System.Diagnostics.Process' object.
		/// </exception>
		/// <exception cref="NotSupportedException">You are attempting to call 'System.
		/// Diagnostics.Process.Kill' for a process that is running on a remote computer. The
		/// method is available only for processes running on the local computer.</exception>
		/// <exception cref="Win32Exception">The associated process could not be terminated.
		/// -or-The process is terminating.-or- The associated process is a Win16 executable.
		/// </exception>
		internal static void ForceKillAllProcessesByName(
			String i_processName
			)
		{
			var processFileName = Path.GetFileName(i_processName);
			var processes = Process.GetProcesses();
			foreach (var process in Process.GetProcessesByName(processFileName))
			{
				process.Kill();
			}
		}

		internal static void StartAndWait(
			String i_fileName,
			String i_arguments,
			Boolean i_wailtTillTerminated
			)
		{
			var startInfo = new ProcessStartInfo();
			startInfo.FileName = i_fileName;
			startInfo.Arguments = i_arguments;

			try
			{
				var process = Process.Start(startInfo);

				if (i_wailtTillTerminated)
				{
					process.WaitForExit();
				}

				var executableName = Path.GetFileName(i_fileName);
				Console.WriteLine("The program {0} has terminated", executableName);
			}
			catch (Exception exception)
			{
				Console.WriteLine("An exception occurred, message:{0}", exception.Message);
			}
		}
	}
}