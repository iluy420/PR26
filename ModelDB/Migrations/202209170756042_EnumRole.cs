namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumRole : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "RoleId", "dbo.Role");
            DropIndex("dbo.User", new[] { "RoleId" });
            AddColumn("dbo.User", "UserRole", c => c.Int(nullable: false));
            DropColumn("dbo.User", "RoleId");
            DropTable("dbo.Role");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.User", "RoleId", c => c.Guid(nullable: false));
            DropColumn("dbo.User", "UserRole");
            CreateIndex("dbo.User", "RoleId");
            AddForeignKey("dbo.User", "RoleId", "dbo.Role", "RoleId", cascadeDelete: true);
        }
    }
}
