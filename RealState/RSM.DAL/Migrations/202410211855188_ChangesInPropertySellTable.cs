namespace RSM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInPropertySellTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertySells", "PaymentOnBooking", c => c.Int(nullable: false));
            AddColumn("dbo.PropertySells", "TotalCostOfProperty", c => c.Int(nullable: false));
            AddColumn("dbo.PropertySells", "PaymentPlan", c => c.Int(nullable: false));
            AddColumn("dbo.PropertySells", "SoldDate", c => c.String(nullable: false));
            AddColumn("dbo.PropertySells", "NumberOfInstallments", c => c.Int(nullable: false));
            AddColumn("dbo.PropertySells", "EntryByUser", c => c.Int(nullable: false));
            AlterColumn("dbo.PropertySells", "CareOf", c => c.Int(nullable: false));
            DropColumn("dbo.PropertySells", "Onbooking");
            DropColumn("dbo.PropertySells", "TotalCostOfLand");
            DropColumn("dbo.PropertySells", "Type");
            DropColumn("dbo.PropertySells", "Date");
            DropColumn("dbo.PropertySells", "TotalInsMonth");
            DropColumn("dbo.PropertySells", "Recived");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PropertySells", "Recived", c => c.Int(nullable: false));
            AddColumn("dbo.PropertySells", "TotalInsMonth", c => c.Int(nullable: false));
            AddColumn("dbo.PropertySells", "Date", c => c.String(nullable: false));
            AddColumn("dbo.PropertySells", "Type", c => c.String(nullable: false));
            AddColumn("dbo.PropertySells", "TotalCostOfLand", c => c.Int(nullable: false));
            AddColumn("dbo.PropertySells", "Onbooking", c => c.String(nullable: false));
            AlterColumn("dbo.PropertySells", "CareOf", c => c.String(nullable: false));
            DropColumn("dbo.PropertySells", "EntryByUser");
            DropColumn("dbo.PropertySells", "NumberOfInstallments");
            DropColumn("dbo.PropertySells", "SoldDate");
            DropColumn("dbo.PropertySells", "PaymentPlan");
            DropColumn("dbo.PropertySells", "TotalCostOfProperty");
            DropColumn("dbo.PropertySells", "PaymentOnBooking");
        }
    }
}
