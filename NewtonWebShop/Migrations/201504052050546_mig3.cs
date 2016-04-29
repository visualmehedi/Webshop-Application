namespace NewtonWebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        IrderItemID = c.Int(nullable: false, identity: true),
                        OrderItemProductNumber = c.String(),
                        OrderItemName = c.String(),
                        OrderItemDescription = c.String(),
                        OrderItemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderCount = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IrderItemID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderRef = c.String(),
                        OrderPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "OrderID" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
        }
    }
}
