using System.Data.Entity.ModelConfiguration.Conventions;

namespace Photography.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographyContext : DbContext
    {
        
        public PhotographyContext()
            : base("name=PhotographyContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Accessory>Accessories { get; set; }
        public virtual DbSet<Camera>Cameras { get; set; }
        public virtual DbSet<Len>Lens { get; set; }
        public virtual DbSet<Photographer>Photographers { get; set; }
        public virtual DbSet<WorkShop>WorkShops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DSLRCamera>().ToTable("DSLRCameras");
            modelBuilder.Entity<MirrorlessCamera>().ToTable("MirrorlessCameras");

            //  modelBuilder.Ignore<Camera>();

            //modelBuilder.Entity<DSLRCamera>().Map(configuration =>
            //{
            //    configuration.MapInheritedProperties();
            //    configuration.ToTable("DSLRCameras");
            //});
            //modelBuilder.Entity<MirrorlessCamera>().Map(configurateion =>
            //{
            //    configurateion.MapInheritedProperties();
            //    configurateion.ToTable("MirrorlessCameras");
            //});

            modelBuilder.Entity<Photographer>()
                .HasMany(p => p.ParticipantsWorkShops)
                .WithMany(w => w.Participants)
                .Map(pw =>
                {
                    pw.MapLeftKey("ParticipantId")
                        .MapRightKey("WorkShopId")
                        .ToTable("ParticipantWorkshop");
                });

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();



            base.OnModelCreating(modelBuilder);
        }
    }
}