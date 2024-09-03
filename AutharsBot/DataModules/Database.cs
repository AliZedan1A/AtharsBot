using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AtharsBot.DataModules
{
    internal class Database:DbContext
    {
        public string DbPath { get; }

        public DbSet<AthrModel> AtherTable { get; set; }
        public DbSet<ServerSetting> ServersTable { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}");
        public Database()
        {
            //var folder = Directory.GetCurrentDirectory();
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(folder, "IslamResearchDB.db");
        }

    }


}
