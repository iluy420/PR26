namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "RoleId", "dbo.Role");
            DropPrimaryKey("dbo.Role");
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.Role", "RoleId", c => c.Guid(nullable: false));
            AlterColumn("dbo.User", "UserId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Role", "RoleId");
            AddPrimaryKey("dbo.User", "UserId");
            AddForeignKey("dbo.User", "RoleId", "dbo.Role", "RoleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "RoleId", "dbo.Role");
            DropPrimaryKey("dbo.User");
            DropPrimaryKey("dbo.Role");
            AlterColumn("dbo.User", "UserId", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Role", "RoleId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.User", "UserId");
            AddPrimaryKey("dbo.Role", "RoleId");
            AddForeignKey("dbo.User", "RoleId", "dbo.Role", "RoleId", cascadeDelete: true);
        }
    }
}
