using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEquality
{
	class Student
	{
		private void DoAction(
			String i_actionDescription
			)
		{
			if (Action != null)
			{
				Action(i_actionDescription);
			}
		}

		public Student()
			: this(0, String.Empty, null)
		{ 
		}

		public Student(
			Int32 i_id,
			String i_name
			) : 
			this(i_id, i_name, null)
		{
			ID = i_id;
			Name = i_name;
		}

		public Student(
			Int32 i_id,
			String i_name,
			Action<String> i_action
			)
		{
			ID = i_id;
			Name = i_name;
			Action = i_action;
		}

		public Action<String> Action { get; set; }

		public Int32 ID { get; set; }

		public String Name { get; set; }

		public override Boolean Equals(
			Object i_obj
			)
		{
			DoAction("Enter equals");

			var student = i_obj as Student;

			if (student == null)
			{
				return false;
			}

			if (student.ID == ID && student.Name == Name)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			DoAction("Enter GetHashCode.");

			var token = String.Format("{0}_{1}", Name, ID);

			return token.GetHashCode();
		}

		public static Boolean operator ==(
			Student i_first,
			Student i_second
			)
		{
			if (Object.ReferenceEquals(i_first, null))
			{
				return Object.ReferenceEquals(i_second, null);
			}

			return i_first.Equals(i_second);
		}

		public static Boolean operator !=(
			Student i_first,
			Student i_second
			)
		{
			if (Object.ReferenceEquals(i_first, null))
			{
				return !Object.ReferenceEquals(i_second, null);
			}

			return !i_first.Equals(i_second);
		}
	}
}
