namespace Photography.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photographers", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Photographers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(),
                        PrimaryCameraId = c.Int(nullable: false),
                        SecondaryCameraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cameras", t => t.PrimaryCameraId)
                .ForeignKey("dbo.Cameras", t => t.SecondaryCameraId)
                .Index(t => t.PrimaryCameraId)
                .Index(t => t.SecondaryCameraId);
            
            CreateTable(
                "dbo.Lenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        FocalLength = c.Int(),
                        MaxAperture = c.Single(),
                        CompatibleWith = c.String(),
                        OwnerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photographers", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.WorkShops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Location = c.String(nullable: false),
                        PricePerParticipant = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TrainerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photographers", t => t.TrainerId)
                .Index(t => t.TrainerId);
            
            CreateTable(
                "dbo.Cameras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        IsFullFrameOrNot = c.Boolean(nullable: false),
                        MinISO = c.Int(nullable: false),
                        MaxISO = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParticipantWorkshop",
                c => new
                    {
                        ParticipantId = c.Int(nullable: false),
                        WorkShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ParticipantId, t.WorkShopId })
                .ForeignKey("dbo.Photographers", t => t.ParticipantId, cascadeDelete: true)
                .ForeignKey("dbo.WorkShops", t => t.WorkShopId, cascadeDelete: true)
                .Index(t => t.ParticipantId)
                .Index(t => t.WorkShopId);
            
            CreateTable(
                "dbo.DSLRCameras",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MaxShutterSpeed = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cameras", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.MirrorlessCameras",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MaxVideoResolution = c.String(),
                        MaxFrameRate = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cameras", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MirrorlessCameras", "Id", "dbo.Cameras");
            DropForeignKey("dbo.DSLRCameras", "Id", "dbo.Cameras");
            DropForeignKey("dbo.Photographers", "SecondaryCameraId", "dbo.Cameras");
            DropForeignKey("dbo.Photographers", "PrimaryCameraId", "dbo.Cameras");
            DropForeignKey("dbo.ParticipantWorkshop", "WorkShopId", "dbo.WorkShops");
            DropForeignKey("dbo.ParticipantWorkshop", "ParticipantId", "dbo.Photographers");
            DropForeignKey("dbo.WorkShops", "TrainerId", "dbo.Photographers");
            DropForeignKey("dbo.Lenses", "OwnerId", "dbo.Photographers");
            DropForeignKey("dbo.Accessories", "OwnerId", "dbo.Photographers");
            DropIndex("dbo.MirrorlessCameras", new[] { "Id" });
            DropIndex("dbo.DSLRCameras", new[] { "Id" });
            DropIndex("dbo.ParticipantWorkshop", new[] { "WorkShopId" });
            DropIndex("dbo.ParticipantWorkshop", new[] { "ParticipantId" });
            DropIndex("dbo.WorkShops", new[] { "TrainerId" });
            DropIndex("dbo.Lenses", new[] { "OwnerId" });
            DropIndex("dbo.Photographers", new[] { "SecondaryCameraId" });
            DropIndex("dbo.Photographers", new[] { "PrimaryCameraId" });
            DropIndex("dbo.Accessories", new[] { "OwnerId" });
            DropTable("dbo.MirrorlessCameras");
            DropTable("dbo.DSLRCameras");
            DropTable("dbo.ParticipantWorkshop");
            DropTable("dbo.Cameras");
            DropTable("dbo.WorkShops");
            DropTable("dbo.Lenses");
            DropTable("dbo.Photographers");
            DropTable("dbo.Accessories");
        }
    }
}
