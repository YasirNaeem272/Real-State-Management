namespace RSM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertySellC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertySells",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(nullable: false),
                        Onbooking = c.String(),
                        PossessionCharges = c.Int(nullable: false),
                        TotalCostOfLand = c.Int(nullable: false),
                        Type = c.String(),
                        CornerCharges = c.Int(nullable: false),
                        DevelopmentCharges = c.Int(nullable: false),
                        Balance = c.Int(nullable: false),
                        Date = c.String(),
                        PossessionDate = c.String(),
                        TotalInsMonth = c.Int(nullable: false),
                        Recived = c.Int(nullable: false),
                        CareOf = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Properties", t => t.PropertyID, cascadeDelete: true)
                .Index(t => t.PropertyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertySells", "PropertyID", "dbo.Properties");
            DropIndex("dbo.PropertySells", new[] { "PropertyID" });
            DropTable("dbo.PropertySells");
        }
    }
}
