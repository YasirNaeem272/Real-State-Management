namespace RSM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlotNo = c.String(nullable: false),
                        ProjectName = c.String(nullable: false),
                        Block = c.String(nullable: false),
                        Size = c.String(nullable: false),
                        PropertyType = c.String(nullable: false),
                        North = c.String(nullable: false),
                        East = c.String(nullable: false),
                        West = c.String(nullable: false),
                        South = c.String(nullable: false),
                        StreetNo = c.Int(nullable: false),
                        OpenSide = c.String(nullable: false),
                        OwnerID = c.Int(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Owners", t => t.OwnerID, cascadeDelete: true)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CNIC = c.String(),
                        CellNo = c.String(),
                    })
                .PrimaryKey(t => t.OwnerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Properties", "OwnerID", "dbo.Owners");
            DropIndex("dbo.Properties", new[] { "OwnerID" });
            DropTable("dbo.Owners");
            DropTable("dbo.Properties");
        }
    }
}
