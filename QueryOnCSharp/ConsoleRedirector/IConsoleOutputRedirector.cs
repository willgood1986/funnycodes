using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRedirector
{
    public interface IConsoleOutputRedirector
    {
        Boolean OpenOutput();

        void SetOutput();

        void RestoreOutput();

        void CloseOutput();

        Boolean IsOutputOpened
        {
            get;
        }
    }
}
