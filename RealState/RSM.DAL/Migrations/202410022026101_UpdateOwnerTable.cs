namespace RSM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOwnerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Owners", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Owners", "CNIC", c => c.String(nullable: false));
            AddColumn("dbo.Owners", "CellNo", c => c.String(nullable: false));
            AddColumn("dbo.Owners", "Gender", c => c.String(nullable: false));
            AddColumn("dbo.Owners", "ContactNo", c => c.String());
            AddColumn("dbo.Owners", "Address", c => c.String());
            AddColumn("dbo.Owners", "ImagePath", c => c.String());
            AddColumn("dbo.Owners", "FingerPrint", c => c.Binary());
            AddColumn("dbo.Owners", "SODOWO", c => c.String(nullable: false));
            AddColumn("dbo.Owners", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Owners", "OwnerType", c => c.String(nullable: false));
            AlterColumn("dbo.Owners", "FirstName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Owners", "FirstName", c => c.String());
            DropColumn("dbo.Owners", "OwnerType");
            DropColumn("dbo.Owners", "DOB");
            DropColumn("dbo.Owners", "SODOWO");
            DropColumn("dbo.Owners", "FingerPrint");
            DropColumn("dbo.Owners", "ImagePath");
            DropColumn("dbo.Owners", "Address");
            DropColumn("dbo.Owners", "ContactNo");
            DropColumn("dbo.Owners", "Gender");
            DropColumn("dbo.Owners", "CellNo");
            DropColumn("dbo.Owners", "CNIC");
            DropColumn("dbo.Owners", "LastName");
        }
    }
}
