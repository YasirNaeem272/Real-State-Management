namespace RSM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabseUpdateAfterSync : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertySells",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(nullable: false),
                        Onbooking = c.String(nullable: false),
                        PossessionCharges = c.Int(nullable: false),
                        TotalCostOfLand = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        CornerCharges = c.Int(nullable: false),
                        DevelopmentCharges = c.Int(nullable: false),
                        Balance = c.Int(nullable: false),
                        Date = c.String(nullable: false),
                        PossessionDate = c.String(nullable: false),
                        TotalInsMonth = c.Int(nullable: false),
                        Recived = c.Int(nullable: false),
                        CareOf = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Properties", t => t.PropertyID, cascadeDelete: true)
                .Index(t => t.PropertyID);
            
            AddColumn("dbo.Properties", "ProjectName", c => c.String(nullable: false));
            AddColumn("dbo.Properties", "Block", c => c.String(nullable: false));
            AddColumn("dbo.Properties", "Size", c => c.Int(nullable: false));
            AddColumn("dbo.Properties", "North", c => c.String(nullable: false));
            AddColumn("dbo.Properties", "East", c => c.String(nullable: false));
            AddColumn("dbo.Properties", "West", c => c.String(nullable: false));
            AddColumn("dbo.Properties", "South", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertySells", "PropertyID", "dbo.Properties");
            DropIndex("dbo.PropertySells", new[] { "PropertyID" });
            DropColumn("dbo.Properties", "South");
            DropColumn("dbo.Properties", "West");
            DropColumn("dbo.Properties", "East");
            DropColumn("dbo.Properties", "North");
            DropColumn("dbo.Properties", "Size");
            DropColumn("dbo.Properties", "Block");
            DropColumn("dbo.Properties", "ProjectName");
            DropTable("dbo.PropertySells");
        }
    }
}
