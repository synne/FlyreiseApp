using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FlyreiserApp.Models
{    
    public class FlyreiserContext : DbContext
    {
        public FlyreiserContext() : base("name=Flyreiser")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DbInit());
        }
        public DbSet<Kunder> Kunder { get; set; }
        public DbSet<Reise> Reise { get; set; }
        public DbSet<Strekning> Strekning { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }
         
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
    


    
}