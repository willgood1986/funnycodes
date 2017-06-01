using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Program
	{
		private static void InsertDuplicateRecord()
		{
			var sqlConnectionBuilder = new SqlConnectionStringBuilder();
			sqlConnectionBuilder.ConnectTimeout = 30;
			sqlConnectionBuilder.DataSource = "localhost";
			sqlConnectionBuilder.InitialCatalog = "Rtest";
			sqlConnectionBuilder.UserID = "sa";
			sqlConnectionBuilder.Password = "I@mroot";

			var sqlConnection = new SqlConnection(sqlConnectionBuilder.ToString());

			sqlConnection.Open();

			try
			{
				Console.WriteLine("Successfully connect to database");

				var sqlCmd = sqlConnection.CreateCommand();
				sqlCmd.CommandType = System.Data.CommandType.Text;


				var UserName = "Jim1";
				var Address = "address";

				var insertScript = String.Format("Insert into Users(name, address) values('{0}', '{1}')", UserName, Address);

				var duplicatedScript = String.Format("Select id From users where name='{0}'", UserName);
				sqlCmd.CommandText = insertScript;

				//var result = sqlCmd.ExecuteNonQuery();

				var result = sqlCmd.ExecuteScalar();

				Console.WriteLine("Affected row count {0}", result);

			}
			catch (SqlException e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine(e.GetType());
				Console.WriteLine(e.InnerException != null);
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		static void Main(string[] args)
		{
			InsertDuplicateRecord();

			Console.ReadKey();
		}
	}
}
