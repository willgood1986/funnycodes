using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseDBInCsharp
{
	class Program
	{
		private static void TestConnectToDB()
		{
			var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

			sqlConnectionStringBuilder.DataSource = ".";
			sqlConnectionStringBuilder.InitialCatalog = "rtest";
			sqlConnectionStringBuilder.IntegratedSecurity = true;

			var sqlConnection = new SqlConnection();
			sqlConnection.ConnectionString = sqlConnectionStringBuilder.ToString();

			try
			{
				sqlConnection.Open();

				Console.WriteLine("Succeed to connect to sql server!");
			}
			catch(Exception e)
			{
				Console.WriteLine("Failed to open database connection, reason:" + e.Message); 
			}

			//var sqlCmd = new SqlCommand();
			
			//sqlCmd.Connection = 
		}

		static void Main(string[] args)
		{
			TestConnectToDB();

			Console.WriteLine();
			Console.ReadLine();
		}
	}
}
