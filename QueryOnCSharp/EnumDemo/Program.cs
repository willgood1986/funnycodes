using ConsoleRedirector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsoleOutputRedirector consoleRedirector = new ConsoleRedirectToFile();

            consoleRedirector.OpenOutput();

            if (consoleRedirector.IsOutputOpened)
            {
                try
                {
                    consoleRedirector.SetOutput();

                    // EnumFunctionality.TestGetUnderlying();

                    // EnumFunctionality.TestEnumFormat();

                    //EnumFunctionality.PrintAllMembers();

                    EnumFunctionality.PrintAllNames();
                }
                finally
                {
                    consoleRedirector.RestoreOutput();
                    consoleRedirector.CloseOutput();
                }
            }

            Console.ReadLine();
        }
    }
}
