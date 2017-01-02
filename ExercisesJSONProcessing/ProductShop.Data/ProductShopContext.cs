using ProductsShop.Models;

namespace ProductShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductShopContext : DbContext
    {
        // Your context has been configured to use a 'ProductShopContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProductShop.Data.ProductShopContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProductShopContext' 
        // connection string in the application configuration file.
        public ProductShopContext()
            : base("ProductShopContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<User>Users { get; set; }
        public virtual DbSet<Product>Products { get; set; }
        public virtual DbSet<Category>Categories { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Categories)
                .Map(cp => cp.ToTable("CategoryProduct")
                    .MapLeftKey("Category_Id")
                    .MapRightKey("Product_Id"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(uf => uf.ToTable("UserFriends")
                    .MapLeftKey("UserId")
                    .MapRightKey("FriendId"));

            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}


}