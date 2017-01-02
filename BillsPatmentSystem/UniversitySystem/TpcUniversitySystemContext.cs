using UniversitySystem.Models;

namespace UniversitySystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TpcUniversitySystemContext : DbContext
    {
        // Your context has been configured to use a 'TpcUniversitySystemContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'UniversitySystem.TpcUniversitySystemContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TpcUniversitySystemContext' 
        // connection string in the application configuration file.
        public TpcUniversitySystemContext()
            : base("name=TpcUniversitySystemContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Course>Courses { get; set; }
        public virtual DbSet<People> Peoples { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<People>();
            modelBuilder.Entity<Student>().Map(configuration =>
            {
                configuration.MapInheritedProperties();
                configuration.ToTable("Students");
            });
            modelBuilder.Entity<Teacher>().Map(cofiguration =>
            {
                cofiguration.MapInheritedProperties();
                cofiguration.ToTable("Teachers");
            });
            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}