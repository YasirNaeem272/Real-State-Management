namespace RSM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseUpdateAfterMerge : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Properties", "ID", "PropertyID");
            DropForeignKey("dbo.Properties", "OwnerID", "dbo.Owners");
            DropForeignKey("dbo.PropertySells", "PropertyID", "dbo.Properties");
            DropIndex("dbo.Properties", new[] { "OwnerID" });
           // DropPrimaryKey("dbo.Properties");
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
            
            //AddColumn("dbo.Properties", "PropertyID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Properties", "PropertyStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Owners", "Gender", c => c.String(nullable: false));
            AddColumn("dbo.Owners", "ContactNo", c => c.String());
            AddColumn("dbo.Owners", "Address", c => c.String());
            AddColumn("dbo.Owners", "ImagePath", c => c.String());
            AddColumn("dbo.Owners", "FingerPrint", c => c.Binary());
            AddColumn("dbo.Owners", "SODOWO", c => c.String(nullable: false));
            AddColumn("dbo.Owners", "DOB", c => c.String(nullable: false));
            AddColumn("dbo.Owners", "OwnerType", c => c.Int(nullable: false));
            AlterColumn("dbo.Properties", "Size", c => c.Int(nullable: false));
            AlterColumn("dbo.Properties", "PropertyType", c => c.Int(nullable: false));
            AlterColumn("dbo.Properties", "OwnerId", c => c.Int());
            AlterColumn("dbo.Owners", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Owners", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Owners", "CNIC", c => c.String(nullable: false));
            AlterColumn("dbo.Owners", "CellNo", c => c.String(nullable: false));
            //AddPrimaryKey("dbo.Properties", "PropertyID");
            CreateIndex("dbo.Properties", "OwnerId");
            AddForeignKey("dbo.Properties", "OwnerId", "dbo.Owners", "OwnerID");
            AddForeignKey("dbo.PropertySells", "PropertyID", "dbo.Properties", "PropertyID", cascadeDelete: true);
            //DropColumn("dbo.Properties", "ID");
            DropColumn("dbo.Properties", "StreetNo");
            DropColumn("dbo.Properties", "Status");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Properties", "PropertyID", "ID");
            AddColumn("dbo.Properties", "Status", c => c.String(nullable: false));
            AddColumn("dbo.Properties", "StreetNo", c => c.Int(nullable: false));
            //AddColumn("dbo.Properties", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.PropertySells", "PropertyID", "dbo.Properties");
            DropForeignKey("dbo.Properties", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Nominees", "OwnerId", "dbo.Owners");
            DropIndex("dbo.Properties", new[] { "OwnerId" });
            DropIndex("dbo.Nominees", new[] { "OwnerId" });
            //DropPrimaryKey("dbo.Properties");
            AlterColumn("dbo.Owners", "CellNo", c => c.String());
            AlterColumn("dbo.Owners", "CNIC", c => c.String());
            AlterColumn("dbo.Owners", "LastName", c => c.String());
            AlterColumn("dbo.Owners", "FirstName", c => c.String());
            AlterColumn("dbo.Properties", "OwnerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Properties", "PropertyType", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "Size", c => c.String(nullable: false));
            DropColumn("dbo.Owners", "OwnerType");
            DropColumn("dbo.Owners", "DOB");
            DropColumn("dbo.Owners", "SODOWO");
            DropColumn("dbo.Owners", "FingerPrint");
            DropColumn("dbo.Owners", "ImagePath");
            DropColumn("dbo.Owners", "Address");
            DropColumn("dbo.Owners", "ContactNo");
            DropColumn("dbo.Owners", "Gender");
            DropColumn("dbo.Properties", "PropertyStatus");
           // DropColumn("dbo.Properties", "PropertyID");
            DropTable("dbo.Nominees");
            //AddPrimaryKey("dbo.Properties", "ID");
            CreateIndex("dbo.Properties", "OwnerID");
            AddForeignKey("dbo.PropertySells", "PropertyID", "dbo.Properties", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Properties", "OwnerID", "dbo.Owners", "OwnerID", cascadeDelete: true);
        }
    }
}
