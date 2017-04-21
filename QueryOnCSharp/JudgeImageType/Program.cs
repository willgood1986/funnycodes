using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace JudgeImageType
{
	class Program
	{
		static void Main(string[] args)
		{
			var image = @"C:\SelfPractice\TFSCodeManager\RainySelfTool\JudgeImageType\wrong.bmp";

			using (var img = Image.FromFile(image))
			{
				if (System.Drawing.Imaging.ImageFormat.Bmp.Equals(img.RawFormat))
				{
					Console.WriteLine("The real format: {0}", "bmp");
				}

				if (System.Drawing.Imaging.ImageFormat.Jpeg.Equals(img.RawFormat))
				{
					Console.WriteLine("The real format: {0}", "jpeg");
				}
			}

			Console.ReadKey();
		}
	}
}
