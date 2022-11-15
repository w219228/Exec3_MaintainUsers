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
			try
			{
				var Parameters = new SqlParameterBuilder().AddNVarchar("name",50,"willy")
															.AddNVarchar("account",50,"base")
															.AddNVarchar("password",50,"in")
															.AddNDateTime("dateOfBirth",DateTime.Today)
															.AddNInt("height",175)
															.AddNInt("id",10)
															.Build();
				var SelectParameters = new SqlParameterBuilder().AddNInt("id",0).Build();
				Crud crud= new Crud();
				crud.Insert(Parameters);
				Console.WriteLine("成功");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"失敗原因 :{ex.Message}");
			}

		}
	}
}
