using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainyTool.ClassLib.FileHelper
{
    public struct RenameFileArgument
    {
        public IEnumerable<String> Files { get; set; }

        public String MatchPattern { get; set; }

        public String ReplacePattern { get; set; }

        public Boolean ContinueIfFailed { get; set; }

        public Action<String, String, Int32, Int32> Action { get; set; }
    }
}
