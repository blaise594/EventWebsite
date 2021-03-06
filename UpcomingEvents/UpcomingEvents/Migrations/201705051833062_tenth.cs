namespace UpcomingEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BarCode = c.Guid(nullable: false),
                        DatePurchased = c.DateTime(),
                        PurchasedPrice = c.Double(nullable: false),
                        WasUsed = c.Boolean(nullable: false),
                        EventId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventModels", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.OrderModels", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.OrderModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeCreated = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.EventModels", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderModels", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TicketModels", "OrderId", "dbo.OrderModels");
            DropForeignKey("dbo.TicketModels", "EventId", "dbo.EventModels");
            DropIndex("dbo.OrderModels", new[] { "UserId" });
            DropIndex("dbo.TicketModels", new[] { "OrderId" });
            DropIndex("dbo.TicketModels", new[] { "EventId" });
            DropColumn("dbo.EventModels", "Price");
            DropTable("dbo.OrderModels");
            DropTable("dbo.TicketModels");
        }
    }
}
