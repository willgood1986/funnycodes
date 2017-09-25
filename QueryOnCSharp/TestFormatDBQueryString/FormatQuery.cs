using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormatDBQueryString
{
    class FormatQuery
    {
        internal static String Test()
        {
            var nums = new List<Int32> { 1, 3, 4 };

            var queryString = String.Join(",", nums);

            return "(" + queryString + ")";
        }
    }
}
