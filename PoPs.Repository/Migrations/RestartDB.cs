using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Migrations;

namespace PoPs.Repository.Migrations
{
    public static class RestartDB
    {
        private static void UpDataBase()
        {
            var configuration = new Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

        private static void DownDataBase()
        {
            var configuration = new Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update("0");
        }

        public static void RestartDataBase()
        {
            DownDataBase();
            UpDataBase();
        }
    }
}
