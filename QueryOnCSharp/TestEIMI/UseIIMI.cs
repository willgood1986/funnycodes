using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEIMI
{
    struct UseIIMI : IComparable
    {
        private Int32 m_value;

        public Int32 CompareTo(
            Object i_object
            )
        {
            var value = ((UseIIMI)i_object).m_value;

            var result = m_value - value;

            return result;
        }
    }
}
