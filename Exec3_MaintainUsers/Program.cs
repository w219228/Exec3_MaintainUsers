using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exec3_MaintainUsers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var dbHelper = new SqlDbHelper("default");
			string sql = "SELECT Id, Title FROM News WHERE Id> @Id  ORDER BY Id ASC";
			Console.WriteLine(sql);
			try
			{
				var parameters = new SqlParameterBuilder().AddNInt("id", 0).Build();
				DataTable news = dbHelper.Select(sql, parameters);
				foreach (DataRow row in news.Rows)
				{
					int id = row.Field<int>("id");
					string title = row.Field<string>("title");
					Console.WriteLine($"Id={id}, Title={title}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"連線失敗, 原因 :{ex.Message}");
			}

		}
	}
}
