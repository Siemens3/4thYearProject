namespace ReptileManager.Migrations.ReptileMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFartherMotherImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reptiles", "FatherId", c => c.String());
            AddColumn("dbo.Reptiles", "FartherImage", c => c.String());
            AddColumn("dbo.Reptiles", "MotherImage", c => c.String());
            AlterColumn("dbo.Reptiles", "ScientificName", c => c.String(nullable: false));
            AlterColumn("dbo.Reptiles", "Born", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reptiles", "Born", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Reptiles", "ScientificName", c => c.String());
            DropColumn("dbo.Reptiles", "MotherImage");
            DropColumn("dbo.Reptiles", "FartherImage");
            DropColumn("dbo.Reptiles", "FatherId");
        }
    }
}
