using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEIMI
{
    struct UseEIMI : IComparable
    {
        private Int32 m_value;

        public Int32 CompareTo(
            UseEIMI i_useEIMI
            )
        {
            var result = m_value - i_useEIMI.m_value;

            return result;
        }

        Int32 IComparable.CompareTo(
            Object i_object
            )
        {
            var value = ((UseEIMI)i_object).m_value;

            return m_value - value;
        }
    }
}
