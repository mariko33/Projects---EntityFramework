using StudentSystemData.Migrations;
using StudentSystemModels;

namespace StudentSystemData
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentSystem : DbContext
    {
        // Your context has been configured to use a 'StudentSystem' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'StudentSystemData.StudentSystem' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StudentSystem' 
        // connection string in the application configuration file.
        public StudentSystem()
            : base("StudentSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystem, Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Course>Courses { get; set; }
        public virtual DbSet<Homework>Homeworks { get; set; }
        public virtual DbSet<Resource>Resources { get; set; }
        public virtual DbSet<Student>Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s=>s.Courses)
                .WithMany(c => c.Students)
                .Map(cs =>
                {
                    cs.MapLeftKey("StudentId");
                    cs.MapRightKey("CourseId");
                    cs.ToTable("StudentCourse");

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