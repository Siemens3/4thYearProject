namespace ReptileManager.Migrations.ReptileMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BreedingCycles",
                c => new
                    {
                        BreedingCycleId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        BreedStage = c.Int(nullable: false),
                        Notes = c.String(),
                        ReptileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BreedingCycleId)
                .ForeignKey("dbo.Reptiles", t => t.ReptileId)
                .Index(t => t.ReptileId);
            
            CreateTable(
                "dbo.Reptiles",
                c => new
                    {
                        ReptileId = c.String(nullable: false, maxLength: 128),
                        QRCode = c.Binary(),
                        Gender = c.Int(nullable: false),
                        SpeciesName = c.String(),
                        ScientificName = c.String(),
                        CommonName = c.String(),
                        Born = c.DateTime(precision: 7, storeType: "datetime2"),
                        Morph = c.String(),
                        Venomous = c.Boolean(nullable: false),
                        Weight = c.Double(nullable: false),
                        WeightProgress = c.Int(nullable: false),
                        Origin = c.String(),
                        Food = c.String(),
                        FeedingType = c.Int(nullable: false),
                        AdultSize = c.Double(nullable: false),
                        Habitat = c.String(),
                        Breeder = c.String(),
                        BreederEmail = c.String(),
                        Cities = c.String(),
                        ClutchID = c.String(),
                        ForSale = c.Boolean(nullable: false),
                        Price = c.String(),
                        NickName = c.String(),
                        LicenseNumber = c.String(),
                        ChipNumber = c.String(),
                        SpeciesNumber = c.String(),
                        FatherNotInDb = c.String(),
                        MotherNotInDb = c.String(),
                        FeedInterval = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DueDate = c.DateTime(nullable: false),
                        TubeBoxNumber = c.String(),
                        Note = c.String(),
                        SalesCardComment = c.String(),
                    })
                .PrimaryKey(t => t.ReptileId);
            
            CreateTable(
                "dbo.Cleanings",
                c => new
                    {
                        CleaningId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Cleanings = c.Int(nullable: false),
                        Notes = c.String(),
                        ReptileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CleaningId)
                .ForeignKey("dbo.Reptiles", t => t.ReptileId)
                .Index(t => t.ReptileId);
            
            CreateTable(
                "dbo.Defications",
                c => new
                    {
                        DeficationId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Defications = c.String(),
                        Notes = c.String(),
                        ReptileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DeficationId)
                .ForeignKey("dbo.Reptiles", t => t.ReptileId)
                .Index(t => t.ReptileId);
            
            CreateTable(
                "dbo.Feedings",
                c => new
                    {
                        FeedingId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Feedings = c.Int(nullable: false),
                        FoodSize = c.Int(nullable: false),
                        NumItemsFed = c.Int(nullable: false),
                        Notes = c.String(),
                        ReptileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FeedingId)
                .ForeignKey("dbo.Reptiles", t => t.ReptileId)
                .Index(t => t.ReptileId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        ReptileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Reptiles", t => t.ReptileId)
                .Index(t => t.ReptileId);
            
            CreateTable(
                "dbo.Lengths",
                c => new
                    {
                        LengthId = c.Int(nullable: false, identity: true),
                        Lengths = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ReptileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LengthId)
                .ForeignKey("dbo.Reptiles", t => t.ReptileId)
                .Index(t => t.ReptileId);
            
            CreateTable(
                "dbo.Matings",
                c => new
                    {
                        MatingId = c.Int(nullable: false, identity: true),
                        Event = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        mateID = c.String(),
                        ReptileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MatingId)
                .ForeignKey("dbo.Reptiles", t => t.ReptileId)
                .Index(t => t.ReptileId);
            
            CreateTable(
                "dbo.Medications",
                c => new
                    {
                        MedicationId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        MedicationField = c.String(),
                        Notes = c.String(),
                        ReptileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MedicationId)
                .ForeignKey("dbo.Reptiles", t => t.ReptileId)
                .Index(t => t.ReptileId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        Notes = c.String(),
                        CategNote = c.Int(nullable: false),
                        ReptileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("dbo.Reptiles", t => t.ReptileId)
                .Index(t => t.ReptileId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Message = c.String(),
                        SendAt = c.DateTime(nullable: false),
                        ReptileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.Reptiles", t => t.ReptileId)
                .Index(t => t.ReptileId);
            
            CreateTable(
                "dbo.Other",
                c => new
                    {
                        OtherId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Newaction = c.String(),
                        Notes = c.String(),
                        ReptileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OtherId)
                .ForeignKey("dbo.Reptiles", t => t.ReptileId)
                .Index(t => t.ReptileId);
            
            CreateTable(
                "dbo.Sheds",
                c => new
                    {
                        ShedId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Sheds = c.Int(nullable: false),
                        Notes = c.String(),
                        ReptileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ShedId)
                .ForeignKey("dbo.Reptiles", t => t.ReptileId)
                .Index(t => t.ReptileId);
            
            CreateTable(
                "dbo.Ultrasounds",
                c => new
                    {
                        UltrasoundId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Ultrasounds = c.String(),
                        Count = c.Short(nullable: false),
                        FollicleSize = c.Double(nullable: false),
                        Notes = c.String(),
                        ReptileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UltrasoundId)
                .ForeignKey("dbo.Reptiles", t => t.ReptileId)
                .Index(t => t.ReptileId);
            
            CreateTable(
                "dbo.Weights",
                c => new
                    {
                        WeightId = c.Int(nullable: false, identity: true),
                        Weights = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ReptileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.WeightId)
                .ForeignKey("dbo.Reptiles", t => t.ReptileId)
                .Index(t => t.ReptileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weights", "ReptileId", "dbo.Reptiles");
            DropForeignKey("dbo.Ultrasounds", "ReptileId", "dbo.Reptiles");
            DropForeignKey("dbo.Sheds", "ReptileId", "dbo.Reptiles");
            DropForeignKey("dbo.Other", "ReptileId", "dbo.Reptiles");
            DropForeignKey("dbo.Notifications", "ReptileId", "dbo.Reptiles");
            DropForeignKey("dbo.Notes", "ReptileId", "dbo.Reptiles");
            DropForeignKey("dbo.Medications", "ReptileId", "dbo.Reptiles");
            DropForeignKey("dbo.Matings", "ReptileId", "dbo.Reptiles");
            DropForeignKey("dbo.Lengths", "ReptileId", "dbo.Reptiles");
            DropForeignKey("dbo.Files", "ReptileId", "dbo.Reptiles");
            DropForeignKey("dbo.Feedings", "ReptileId", "dbo.Reptiles");
            DropForeignKey("dbo.Defications", "ReptileId", "dbo.Reptiles");
            DropForeignKey("dbo.Cleanings", "ReptileId", "dbo.Reptiles");
            DropForeignKey("dbo.BreedingCycles", "ReptileId", "dbo.Reptiles");
            DropIndex("dbo.Weights", new[] { "ReptileId" });
            DropIndex("dbo.Ultrasounds", new[] { "ReptileId" });
            DropIndex("dbo.Sheds", new[] { "ReptileId" });
            DropIndex("dbo.Other", new[] { "ReptileId" });
            DropIndex("dbo.Notifications", new[] { "ReptileId" });
            DropIndex("dbo.Notes", new[] { "ReptileId" });
            DropIndex("dbo.Medications", new[] { "ReptileId" });
            DropIndex("dbo.Matings", new[] { "ReptileId" });
            DropIndex("dbo.Lengths", new[] { "ReptileId" });
            DropIndex("dbo.Files", new[] { "ReptileId" });
            DropIndex("dbo.Feedings", new[] { "ReptileId" });
            DropIndex("dbo.Defications", new[] { "ReptileId" });
            DropIndex("dbo.Cleanings", new[] { "ReptileId" });
            DropIndex("dbo.BreedingCycles", new[] { "ReptileId" });
            DropTable("dbo.Weights");
            DropTable("dbo.Ultrasounds");
            DropTable("dbo.Sheds");
            DropTable("dbo.Other");
            DropTable("dbo.Notifications");
            DropTable("dbo.Notes");
            DropTable("dbo.Medications");
            DropTable("dbo.Matings");
            DropTable("dbo.Lengths");
            DropTable("dbo.Files");
            DropTable("dbo.Feedings");
            DropTable("dbo.Defications");
            DropTable("dbo.Cleanings");
            DropTable("dbo.Reptiles");
            DropTable("dbo.BreedingCycles");
        }
    }
}
