using System;
using DatabaseMigrator.DBContext;
using DatabaseMigrator.Helper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace DatabaseMigrator
{
    class Program
    {
        static MySQLContext _MySQLContext = MySQLContext.GetInstance;
        static LogHelper _LogHelper = LogHelper.GetInstance;

        static void Main(string[] args)
        {
            // _MySQLContext.Database.CanConnect();

            using (var command = _MySQLContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"select * from @p1";

                command.Parameters.Add(new SqlParameter { ParameterName = "@p1", Value = "tableAAA" });
                _MySQLContext.Database.OpenConnection();

                using var result = command.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(result);
                var rows = dataTable.AsEnumerable();
                rows.ToList().ForEach(_ =>{
                    _.ItemArray
                });
            }
        }
    }
}
