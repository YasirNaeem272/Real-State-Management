namespace RSM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePropertySell : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PropertySells", "Onbooking", c => c.String(nullable: false));
            AlterColumn("dbo.PropertySells", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.PropertySells", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.PropertySells", "PossessionDate", c => c.String(nullable: false));
            AlterColumn("dbo.PropertySells", "CareOf", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PropertySells", "CareOf", c => c.String());
            AlterColumn("dbo.PropertySells", "PossessionDate", c => c.String());
            AlterColumn("dbo.PropertySells", "Date", c => c.String());
            AlterColumn("dbo.PropertySells", "Type", c => c.String());
            AlterColumn("dbo.PropertySells", "Onbooking", c => c.String());
        }
    }
}
