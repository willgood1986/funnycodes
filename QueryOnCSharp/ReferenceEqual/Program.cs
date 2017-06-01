using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceEqual
{
	class Program
	{
		static void Main(string[] args)
		{
			var user = new User("Mike", "1001");
			var user1 = user;

			var users = new List<User>();
			var numbers = new List<Int32>();

			var defaultValue = users.FirstOrDefault();

			var defaultNumber = numbers.DefaultIfEmpty().First();

			Console.WriteLine(defaultValue);

			Console.WriteLine(defaultNumber);

			Console.WriteLine(Object.ReferenceEquals(user, user1));

			Console.ReadKey();
		}
	}
}
