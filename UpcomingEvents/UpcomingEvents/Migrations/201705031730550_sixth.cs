namespace UpcomingEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventModels", "description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventModels", "description", c => c.String(nullable: false));
        }
    }
}
