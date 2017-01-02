using HospitalSystem.Models;

namespace HospitalSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HospitalDatabse : DbContext
    {
        // Your context has been configured to use a 'HospitalDatabse' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HospitalSystem.HospitalDatabse' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HospitalDatabse' 
        // connection string in the application configuration file.
        public HospitalDatabse()
            : base("name=HospitalDatabse")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<Patient>Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Visitation>Visitations { get; set; }
        public DbSet<Diagnose>Diagnoses  { get; set; }
        public DbSet<Doctor> Doctors { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}