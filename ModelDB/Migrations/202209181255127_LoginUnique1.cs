namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginUnique1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.User", "Login", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "Login" });
        }
    }
}
