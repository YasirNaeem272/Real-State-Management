namespace RSM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyAndNomineeTablesAndUpdateOwner : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.Owners");
            RenameColumn("dbo.Owners", "ID", "OwnerId");
            CreateTable(
                "dbo.Nominees",
                c => new
                    {
                        NomineeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CNIC = c.String(nullable: false),
                        Relation = c.Int(nullable: false),
                        SODOWO = c.String(nullable: false),
                        DOB = c.String(nullable: false),
                        CellNo = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Address = c.String(),
                        ImagePath = c.String(),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NomineeId)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        PropertyID = c.Int(nullable: false, identity: true),
                        PlotNo = c.String(nullable: false),
                        PropertyType = c.Int(nullable: false),
                        PropertyStatus = c.Int(nullable: false),
                        OwnerId = c.Int(),
                    })
                .PrimaryKey(t => t.PropertyID)
                .ForeignKey("dbo.Owners", t => t.OwnerId)
                .Index(t => t.OwnerId);

            //AddColumn("dbo.Owners", "OwnerId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Owners", "DOB", c => c.String(nullable: false));
            //AddPrimaryKey("dbo.Owners", "OwnerId");
            //DropColumn("dbo.Owners", "ID");
            DropColumn("dbo.Owners", "EntryTime");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Owners", "OwnerId", "ID");

            AddColumn("dbo.Owners", "EntryTime", c => c.DateTime(nullable: false));
            //AddColumn("dbo.Owners", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Nominees", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Properties", "OwnerId", "dbo.Owners");
            DropIndex("dbo.Properties", new[] { "OwnerId" });
            DropIndex("dbo.Nominees", new[] { "OwnerId" });
            //DropPrimaryKey("dbo.Owners");
            AlterColumn("dbo.Owners", "DOB", c => c.DateTime(nullable: false));
            //DropColumn("dbo.Owners", "OwnerId");
            DropTable("dbo.Properties");
            DropTable("dbo.Nominees");
            //AddPrimaryKey("dbo.Owners", "ID");
        }
    }
}
