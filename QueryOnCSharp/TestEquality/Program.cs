using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEquality
{
	class Program
	{
		private static String[] StudentNames = new String[10]
		{"Jim", "Lucy", "Kate", "William", "Dogelas", "Bruce", "Joy", "Grace", "Keivin", "Burdle"};

		private static Student NewStudent(
			Int32 i_id,
			String i_name
			)
		{
			// var student = new Student(i_id, i_name, message => Console.WriteLine(message));

			var student = new Student(i_id, i_name);

			return student;
		}

		static void TestEquality()
		{
 			var student = new Student {
			ID = 1,
			Name = "Jim"
			};

			var student1 = new Student
			{
				ID = 1,
				Name = "Jim"
			};

			if (student == student1)
			{
				Console.WriteLine(" == The same!");
			}
			else
			{
				Console.WriteLine(" == Not The same!");
			}

			if (student.Equals(student1))
			{
				Console.WriteLine(" Equals The same!");
			}
			else
			{
				Console.WriteLine(" Equals Not The same!");
			}
		}

		private static void TestHashSet()
		{
			
			//var students = new HashSet<Student>();

			var students = new List<Student>();

			var random = new Random(StudentNames.Length);

			var firstStudent = NewStudent(1, "Jim");
			var secondStudent = NewStudent(1, "Jim");

			students.Add(firstStudent);

			if (!students.Contains(secondStudent))
			{
				students.Add(secondStudent); 
			}
		}

		static void Main(string[] args)
		{
			// TestEquality();

			TestHashSet();

			Console.ReadLine();
		}
	}
}
