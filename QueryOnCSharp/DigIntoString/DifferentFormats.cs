using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigIntoString
{
	[Flags]
	enum Feeling
	{
		None = 0,
 		Happiness = 1,
		Angriness = 2,
		Sadness = 4,
		Horror = 8
	}

	class DifferentFormats
	{
		private static void PrintFrameLine()
		{
			Console.WriteLine("--------------------------------------------------------");
		}

		private static void PrintFormat(
			String i_format
			)
		{
			PrintFrameLine();

			Console.WriteLine("Current format:{0}", i_format);
		}

		internal static void FormatNumbers()
		{
			var integerValue = 200;

			PrintFormat("'D' - Decimail");
			Console.WriteLine("Origin:{0} -> {0:D}", integerValue);

			PrintFormat("'C' - Currency");
			Console.WriteLine("Origin:{0} -> {0:C}", integerValue);

			PrintFormat("'E' - exponential notation");
			Console.WriteLine("Origin:{0} -> {0:E}", integerValue);

			PrintFormat("'F' - fixed-point");
			Console.WriteLine("Origin:{0} -> {0:F}", integerValue);

			PrintFormat("'N' - number");
			Console.WriteLine("Origin:{0} -> {0:N}", integerValue);

			PrintFormat("Origin:{0} -> 'P' - Percent");
			Console.WriteLine("{0:P}", integerValue);

			var floatNumber = 2.01;
			PrintFormat("Origin:{0} -> 'R' - Percent");
			Console.WriteLine("Origin:{0} -> {0:R}", floatNumber);

			PrintFormat("Origin:{0} -> 'X' - hexadecimal");
			Console.WriteLine("Origin:{0} -> {0:X}", integerValue);
		}

		internal static void FormatEnumerateType()
		{
			var sadness = Feeling.Sadness;

			PrintFormat("'g' - general ");
			Console.WriteLine("{0:g}", sadness);

			PrintFormat("'F' - Flags");
			Console.WriteLine("{0:F}", sadness);

			PrintFormat("'D' - Decimal");
			Console.WriteLine("{0:D}", sadness);

			PrintFormat("'X' - Hexadecimal");
			Console.WriteLine("{0:X}", sadness);
		}

		internal static void FormatDateTime()
		{
			var now = DateTime.Now;

			PrintFormat("'d' - short date");

			Console.WriteLine("{0:d}", now);

			PrintFormat("'D' - long date");

			Console.WriteLine("{0:D}", now);

			PrintFormat("'G' - general date");

			Console.WriteLine("{0:g}", now);

			PrintFormat("'M' - general date");

			Console.WriteLine("{0:M}", now);

			PrintFormat("'s' - sortable date");

			Console.WriteLine("{0:s}", now);

			PrintFormat("'T' - long time");

			Console.WriteLine("{0:T}", now);

			PrintFormat("'u' - universal time in ISO 8601");

			Console.WriteLine("{0:u}", now);

			PrintFormat("'U' - universal time in full date format");

			Console.WriteLine("{0:U}", now);

			PrintFormat("'Y' - year/month");

			Console.WriteLine("{0:Y}", now);
		}
	}
}
