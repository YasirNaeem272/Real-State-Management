namespace RSM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPaymentTypeInPropertySellTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertySells", "PaymentType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PropertySells", "PaymentType");
        }
    }
}
