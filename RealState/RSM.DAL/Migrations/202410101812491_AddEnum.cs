namespace RSM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Properties", "Size", c => c.Int(nullable: false));
            AlterColumn("dbo.Properties", "PropertyType", c => c.Int(nullable: false));
            AlterColumn("dbo.Properties", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Properties", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "PropertyType", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "Size", c => c.String(nullable: false));
        }
    }
}
