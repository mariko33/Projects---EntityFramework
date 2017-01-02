using BillsPaymentSystem.Models;

namespace BillsPaymentSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TptBillsContext : DbContext
    {
        // Your context has been configured to use a 'TptBillsContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BillsPaymentSystem.TptBillsContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TptBillsContext' 
        // connection string in the application configuration file.
        public TptBillsContext()
            : base("name=TptBillsContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual  DbSet<User>Users{ get; set; }
        public virtual  DbSet<BillingDetail>BillingDetails{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>().ToTable("BankAccount");
            modelBuilder.Entity<CreditCard>().ToTable("CreditCard");
            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}