namespace BookShopSystem1.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using BookShopSystem1.Models;

    public class BookShopContext : DbContext
    {
        // Your context has been configured to use a 'BookShopContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BookShopSystem1.Data.BookShopContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BookShopContext' 
        // connection string in the application configuration file.
        public BookShopContext()
            : base("BookShopContext")
        {
            //Database.SetInitializer<BookShopContext>(new DropCreateDatabaseIfModelChanges<BookShopContext>());
            //Pick the migration startegy

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}


}