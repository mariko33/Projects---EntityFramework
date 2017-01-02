using UniversitySystem.Models;

namespace UniversitySystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TptUniversitySystemContext : DbContext
    {
        // Your context has been configured to use a 'TptUniversitySystemContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'UniversitySystem.TptUniversitySystemContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TptUniversitySystemContext' 
        // connection string in the application configuration file.
        public TptUniversitySystemContext()
            : base("name=TptUniversitySystemContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Course>Courses { get; set; }
        public virtual DbSet<People>Peoples { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}