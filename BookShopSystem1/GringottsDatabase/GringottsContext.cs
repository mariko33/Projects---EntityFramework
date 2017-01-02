using GringottsDatabase.Models;

namespace GringottsDatabase
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GringottsContext : DbContext
    {
        // Your context has been configured to use a 'GringottsContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GringottsDatabase.GringottsContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GringottsContext' 
        // connection string in the application configuration file.
        public GringottsContext()
            : base("data source=DESKTOP-9MG3OMM\\SQLEXPRESS;initial catalog=GringDb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<WizardDeposit> WizardDeposits { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(uf =>
                {
                    uf.MapLeftKey("UserId");
                    uf.MapRightKey("FriendId");
                    uf.ToTable("UserFriend");
                });

            
            base.OnModelCreating(modelBuilder);
        }
    }

    
}