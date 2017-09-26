### What's New From Here ###

1. Array.BinarySearch(array, target). It works on a ordered list.
2. ^(\d{3}).{0,}\.mp3$ -> $1.mp3 替换第一个组 得到的结果（123adsgadg.mp3）123.mp3
3. Console Redirector -> Console.SetOut(StreamWriter); default standard output - Console.Out
4. Dictionary operation, add a key-value pair, Dict[Key] = Value
5. Format Date Time  
   Current format:'d' - short date
   9/25/2017
   Current format:'D' - long date
   Monday, September 25, 2017

   Current format:'G' - general date
   9/25/2017 1:24 AM

   Current format:'M' - general date
   September 25
   Current format:'s' - sortable date
   2017-09-25T01:24:03

   Current format:'T' - long time
   1:24:03 AM

   Current format:'u' - universal time time in ISO 8601
   2017-09-25 01:24:03Z

   Current format:'U' - universal time in full date format
   Monday, September 25, 2017 8:24:03 AM

   Current format:'Y' - year/month
   September 2017  
6. Format Enumerate Type 
   
   Current format:'g' - general 
   Sadness
   
   Current format:'F' - Flags
   Sadness

   Current format:'D' - Decimal
   4
   Current format:'X' - Hexadecimal
   00000004  
7. Format Number
   
Current format:'D' - Decimail
Origin:200 -> 200

Current format:'C' - Currency
Origin:200 -> $200.00

Current format:'E' - exponential notation
Origin:200 -> 2.000000E+002

Current format:'F' - fixed-point
Origin:200 -> 200.00

Current format:'N' - number
Origin:200 -> 200.00

Current format:Origin:{0} -> 'P' - Percent
20,000.00 %

Current format:Origin:{0} -> 'R' - Percent
Origin:2.01 -> 2.01

Current format:Origin:{0} -> 'X' - hexadecimal
Origin:200 -> C8  
8. Format(format-Pattern, content). If format-Pattern is null, it works and ignores the format-pattern
9. String - Encoded Bytes. Encoding.UTF8.GetBytes/GetString
10. Print a byte array we can call BitConverter.ToString(ByteArray)
    Convert.ToByte(Char, 16)
11. Encoding.UTF8.GetBytes(String); Convert.ToBase64String();Convert.FromBase64String; Encoding.UTF8.GetString
12. Use an event as a lock to wait for multiple tasks. var lock = new AutoResetEvent(false); ThreadPool.QueueUserWorkItem(delegate { if () {lock.Set()}}, i); eventLock.WaitOne();
13. To judge the real type of an image:
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
14. Nullable actually works as a wrapper of value type. When querying its type, it will return the backend real type. When converting types, it will work complying with the actual type.
15. var startInfo = new ProcessStartInfo(); var process = Process.Start(startInfo); process.WaitForExit();
16. Char.GetNumericValue only accept a char that represents a number.
17. Convert.ToByte(String, base); If it is a hex string, you should set the base to 16.
18. UTF8.ToByte -> Change the string into a hex based string.
19. Custom Dispose Model(1. Release res once 2. Manual dispose will cover managed and unmanaged, take the current object off Finalization Queue 3. In finalization, only release unmanaged res)
20. AppDomain.CreateInstanceAndUnwrap needs full qualified domain name of asselby and type.
21. var thread = new Thread(Func); It does not create a physical operating system thread. To actually create the operating system thread and have it start executing the callback method, you must call Thread.Start
22. Default Thread object is Foreground thread. That is, it would prevent the process from being terminated.
23. ThreadPool does not provide a way to query the status of background tasks.