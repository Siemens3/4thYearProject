namespace ReptileManager.Migrations.ReptileMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reptilesImagesInBlob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reptiles", "imageURL", c => c.String());
            AddColumn("dbo.Reptiles", "imageURLOne", c => c.String());
            AddColumn("dbo.Reptiles", "imageURLTwo", c => c.String());
            AddColumn("dbo.Reptiles", "imageURLThree", c => c.String());
            AddColumn("dbo.Reptiles", "imageURLFour", c => c.String());
            AddColumn("dbo.Reptiles", "imageURLFive", c => c.String());
            AddColumn("dbo.Reptiles", "imageURLSix", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reptiles", "imageURLSix");
            DropColumn("dbo.Reptiles", "imageURLFive");
            DropColumn("dbo.Reptiles", "imageURLFour");
            DropColumn("dbo.Reptiles", "imageURLThree");
            DropColumn("dbo.Reptiles", "imageURLTwo");
            DropColumn("dbo.Reptiles", "imageURLOne");
            DropColumn("dbo.Reptiles", "imageURL");
        }
    }
}
