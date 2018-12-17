using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RandevuSistemiGüncel.Models.Managers
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Migrations.Configuration>());
        }
        public DbSet<Doktorlar> Doktorlar { get; set; }
        public DbSet<Hastalar> Hastalar { get; set; }
        public DbSet<RandevuListesi> RandevuListesi { get; set; }
        public DbSet<Kullanıcılar> Kullanıcılar { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}


    }
}