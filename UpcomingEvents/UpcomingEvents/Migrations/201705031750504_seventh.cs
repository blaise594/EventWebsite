namespace UpcomingEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventh : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventModels", "starttime", c => c.DateTime());
            AlterColumn("dbo.EventModels", "endtime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventModels", "endtime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EventModels", "starttime", c => c.DateTime(nullable: false));
        }
    }
}
