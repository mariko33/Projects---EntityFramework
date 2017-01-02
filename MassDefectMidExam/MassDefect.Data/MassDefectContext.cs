using System.Data.Entity.ModelConfiguration.Conventions;
using MassDefect.Models;

namespace MassDefect.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MassDefectContext : DbContext
    {
       
        public MassDefectContext()
            : base("name=MassDefectContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Anomaly>Anomalies { get; set; }
        public virtual DbSet<Person>Persons { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<SolarSystem> SolarSystems { get; set; }
        public virtual DbSet<Star> Stars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anomaly>()
                .HasMany(a => a.Victims)
                .WithMany(v => v.Anomalies)
                .Map(av => av.MapLeftKey("AnomalyId")
                    .MapRightKey("PersonId")
                    .ToTable("AnomalyVictims"));

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }

    
}