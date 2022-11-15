using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Utility
{
	public class Crud
	{
		public SqlDbHelper Insert(SqlParameter[]parameters)
		{
			string sql = @"INSERT INTO Users(Name,Account,Password,DateOfBirth,Height)
							VALUES 
							(@Name,@Account,@Password,@DateOfBirth,@Height)";
			return Excute(sql, parameters);
		}
		public SqlDbHelper Update(SqlParameter[] parameters)
		{
			string sql = @"UPDATE Users SET Name=@Name,Account=@Account,Password=@Password,
							DateOfBirth=@DateOfBirth,Height=@Height WHERE Id=@Id";
							
			return Excute(sql, parameters);
		}
		public SqlDbHelper Delete(SqlParameter[] parameters)
		{
			string sql = @"Delete Users where Id=@Id";

			return Excute(sql, parameters);
		}
		private SqlDbHelper Excute(string sql,SqlParameter[]parameters) {
			var dbhelper = new SqlDbHelper("default");
			dbhelper.ExecuteNonQuery(sql,parameters);
			return dbhelper;
		}
		public void select(SqlParameter[] parameters) 
		{
			string sql = "SELECT * FROM Users WHERE Id>@Id ORDER BY Id";
			var dbhelper = new SqlDbHelper("default");
			DataTable news = dbhelper.Select(sql,parameters);

			foreach(DataRow row in news.Rows) 
			{
				int id = row.Field<int>("id");
				string name = row.Field<string>("name");
				string account = row.Field<string>("account");
				string password=row.Field<string>("password");
				DateTime dateOfBirth=row.Field<DateTime>("dateOfBirth");
				int height = row.Field<int>("height");
				Console.WriteLine($"Id={id},Name={name},Account={account},Password={password}" +
									$",DateOfBirth={dateOfBirth},height={height}");
			}
		}
	}
}
