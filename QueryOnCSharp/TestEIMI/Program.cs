using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEIMI
{
    class Program
    {
        private static TestConvert()
        {
            var numberString = "280";

            try
            {
                var byteValue = Convert.ToByte(numberString);

                Console.WriteLine("Convert result:{0}", byteValue);
            }
            catch(Exception exception)
            {
                Console.WriteLine(
                    "Convert.ToByte raises an exception, type:{0}, message:{1}", 
                    exception.GetType(), 
                    exception.Message); 
            }
        }

        static void Main(string[] args)
        {
            TestConvert();

            Console.ReadKey();
        }
    }
}
