namespace RSM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOpenSide : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Properties", "OpenSide");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Properties", "OpenSide", c => c.String(nullable: false));
        }
    }
}
