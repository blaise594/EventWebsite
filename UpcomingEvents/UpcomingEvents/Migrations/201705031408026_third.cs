namespace UpcomingEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventModels", "title", c => c.String(nullable: false));
            AlterColumn("dbo.EventModels", "description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventModels", "description", c => c.String());
            AlterColumn("dbo.EventModels", "title", c => c.String());
        }
    }
}
