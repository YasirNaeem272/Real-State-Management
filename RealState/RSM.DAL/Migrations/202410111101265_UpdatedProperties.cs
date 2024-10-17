namespace RSM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "Statu", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "Size", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "PropertyType", c => c.String(nullable: false));
            DropColumn("dbo.Properties", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Properties", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Properties", "PropertyType", c => c.Int(nullable: false));
            AlterColumn("dbo.Properties", "Size", c => c.Int(nullable: false));
            DropColumn("dbo.Properties", "Statu");
        }
    }
}
