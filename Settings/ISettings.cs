using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerdisc.Settings
{
    public interface ISettings
    {
        public string SingingKey { get; }
        public string postgresPort { get; }
        public string PostgresServer { get; }
        public string PostgresUser { get; }
        public string PostgresPassword { get; }
        public string PostgresDb { get; }
    }
}