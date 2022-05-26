using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DatabaseMigrator.Helper;
using DatabaseMigrator.Tools;

namespace DatabaseMigrator.DBContext
{
    public class MySQLContext : DbContext
    {
        private static MySQLContext instance = new MySQLContext();
        public static MySQLContext GetInstance
        {
            get
            {
                return instance;
            }
        }

        public MySQLContext()
        {
            OnConfiguring(new DbContextOptionsBuilder());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationHelper configurationHelper = new ConfigurationHelper("DBconnection");
            var dbUrl = configurationHelper.GetValue("OracleMySQL");

            if (dbUrl.IsNullOrEmpty())
                dbUrl = Environment.GetEnvironmentVariable("dbUrl");
            Console.WriteLine(dbUrl);
            optionsBuilder.UseMySql(dbUrl);
            /*** https://ohke.hateblo.jp/entry/2017/03/03/000000 ***/
            // var loggerFactory = new LoggerFactory();
            optionsBuilder.UseLoggerFactory(LogHelper.GetInstance);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}