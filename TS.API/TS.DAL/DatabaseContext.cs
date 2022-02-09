using Microsoft.EntityFrameworkCore;
using System;
using TS.DAL.DataContext;
using TS.DAL.Entities;

namespace TS.DAL
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                opsBuilder.UseSqlServer(settings.ConnectionString).UseLazyLoadingProxies();
                dbOptions = opsBuilder.Options;
            }

            public DbContextOptionsBuilder<DatabaseContext> opsBuilder { get; set; }

            public DbContextOptions<DatabaseContext> dbOptions { get; set; }

            private AppConfiguration settings { get; set; }
        }

        public static OptionsBuild ops = new OptionsBuild();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}