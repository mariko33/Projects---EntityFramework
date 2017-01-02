using HotelDatabase.Models;

namespace HotelDatabase
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HotelContext : DbContext
    {
        // Your context has been configured to use a 'HotelContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HotelDatabase.HotelContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HotelContext' 
        // connection string in the application configuration file.
        public HotelContext()
            : base("name=HotelContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Customer>Customers { get; set; }
        public virtual DbSet<RoomStatus>RoomStatuses { get; set; }
        public virtual DbSet<RoomType>RoomTypes { get; set; }
        public virtual DbSet<BedType>BedTypes { get; set; }
        public virtual DbSet<Room>Rooms { get; set; }
        public virtual DbSet<Payment>Payments { get; set; }
        public virtual DbSet<Occupancy>Occupancies { get; set; }
    }

    

}