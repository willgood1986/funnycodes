﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigIntoString
{
	
	// IFormattable -> ToString
	class Program
	{
		// IFormatProvider.GetFormat()
		// IFormattable.ToString(String format, IFormatProvider formatProvider)

		private static Byte ConvertToByte(
			String s
			)
		{
			try
			{
				return Convert.ToByte(s, 16);
			}
			catch (Exception exception)
			{
				Console.WriteLine("Invalid input: {0}", s);

				throw;
			}
		}

		private static void TestEncoding()
		{
			var greeting = "Hello world.";

			var encodingUTF8 = Encoding.UTF8;

			Byte[] encodedBytes = encodingUTF8.GetBytes(greeting);

			var str = encodingUTF8.GetString(encodedBytes);

			Console.WriteLine("Encoding.GetString result is:" + str);

			var encodedString = BitConverter.ToString(encodedBytes);

			var results = encodedString.Split(new Char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).Select(b => Convert.ToByte(b, 16)).ToArray<Byte>();

			Console.WriteLine("Encoded bytes:" + BitConverter.ToString(encodedBytes));

			Console.WriteLine("Decoded result: {0}", encodingUTF8.GetString(results));
		}


		private static void EncodeAndDecodeWithBase64()
		{
			var greeting = "Hello, World";

			var bytes = Encoding.UTF8.GetBytes(greeting);

			var base64String = Convert.ToBase64String(bytes);

			Console.WriteLine("Base64String is: {0}", base64String);

			bytes = Convert.FromBase64String(base64String);

			var decodedString = Encoding.UTF8.GetString(bytes);

			Console.WriteLine("decoded string: {0}", decodedString);
		}

		static void Main(string[] args)
		{
			FileStream fs = null;

			StreamWriter sw = null;

			TextWriter tw = Console.Out;

			try
			{
				fs = new FileStream(@".\Console.log", FileMode.OpenOrCreate, FileAccess.Write);
				sw = new StreamWriter(fs);
				Console.WriteLine("Successfully redirect");
			}
			catch
			{ 
				Console.WriteLine("Can not redirect console..");
			}

			Console.SetOut(sw);

			// DifferentFormats.FormatDateTime();

			// DifferentFormats.FormatEnumerateType();

			 //DifferentFormats.FormatNumbers();

			//System.Globalization.CultureInfo.CurrentCulture

			//Console.WriteLine(String.Format(null, sample));

			//var sb = new StringBuilder();
			//sb.AppendFormat();

			// TestEncoding();

			//EncodeAndDecodeWithBase64();

			Console.SetOut(tw);
			
			sw.Close();
			fs.Close();

			Console.ReadLine();
		}
	}
}