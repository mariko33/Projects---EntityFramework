using System.Data.Entity.Migrations.Infrastructure;
using BookShopSystem.Models;

namespace BookShopSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookShopSystemContext : DbContext
    {
        // Your context has been configured to use a 'BookShopSystemContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BookShopSystem.Data.BookShopSystemContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BookShopSystemContext' 
        // connection string in the application configuration file.
        public BookShopSystemContext()
            : base("BookShopContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Book>Books { get; set; }
        public virtual DbSet<Author>Authors { get; set; }
        public virtual DbSet<Category>Categories { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(c => c.Categories)
                .WithMany(b => b.Books)
                .Map(con => con.ToTable("CategoryBooks")
                    .MapLeftKey("Category_Id")
                    .MapRightKey("Book_Id"));
            
            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedBooks)
                .WithMany()
                .Map(b =>
                {
                        b.ToTable("RelatedBooks");
                        b.MapLeftKey("BookId");
                       b.MapRightKey("RelatedId");
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