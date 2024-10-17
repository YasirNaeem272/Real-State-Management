namespace RSM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "Status", c => c.String(nullable: false));
            DropColumn("dbo.Properties", "Statu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Properties", "Statu", c => c.String(nullable: false));
            DropColumn("dbo.Properties", "Status");
        }
    }
}
