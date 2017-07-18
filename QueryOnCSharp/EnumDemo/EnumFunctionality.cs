using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo
{
    class EnumFunctionality
    {
        internal static void TestGetUnderlying()
        {
            var type = Enum.GetUnderlyingType(typeof(MailboxType));

            Console.WriteLine("Underlying type: {0}", type);
        }

        internal static void TestEnumFormat()
        {
            Byte value = 4;

            var result = Enum.Format(typeof(MailboxType), value, "G");

            Console.WriteLine("value:{0}, format:'G', result:{1}", value, result);
        }

        //internal TEnum[] GetValues<TEnum>() where TEnum ： struct
        //{
        //    Type typeInfo = typeof(TEnum);
        //    return (TEnum[])Enum.GetValues(typeinfo);
        //}

        internal static void PrintAllNames()
        {
            var names = Enum.GetNames(typeof(MailboxType));

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        internal static void PrintAllMembers()
        {
            MailboxType[] values = (MailboxType[])Enum.GetValues(typeof(MailboxType));

            Console.WriteLine("value\tSymbol");
            Console.WriteLine("-----\t----");

            foreach (var value in values)
            {
                Console.WriteLine("{0,5:D}\t{0:G}", value);
            }
        }
    }
}
