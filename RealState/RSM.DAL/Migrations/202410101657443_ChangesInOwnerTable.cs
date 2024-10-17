namespace RSM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInOwnerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Owners", "EntryTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Owners", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Owners", "OwnerType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Owners", "OwnerType", c => c.String(nullable: false));
            AlterColumn("dbo.Owners", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Owners", "EntryTime");
        }
    }
}
