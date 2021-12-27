using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using TS.DAL.DataContext;

namespace TS.DAL
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfig = new AppConfiguration();

            var opsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            opsBuilder.UseSqlServer(appConfig.ConnectionString);

            return new DatabaseContext(opsBuilder.Options);
        }
    }
}
