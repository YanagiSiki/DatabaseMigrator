using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DatabaseMigrator.Helper;
using DatabaseMigrator.Tools;

namespace DatabaseMigrator.Helper{
    public class LogHelper : LoggerFactory
    {
        private static LogHelper instance = new LogHelper();
        public static LogHelper GetInstance
        {
            get
            {
                return instance;
            }
        }
    }
}