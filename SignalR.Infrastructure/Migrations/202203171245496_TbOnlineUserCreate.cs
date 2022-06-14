namespace SignalR.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TbOnlineUserCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TbOnlineUsers", "OutDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TbOnlineUsers", "OutDate", c => c.DateTime(nullable: false));
        }
    }
}
