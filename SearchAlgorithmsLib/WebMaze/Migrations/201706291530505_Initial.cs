namespace WebMaze.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsersClassModels",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Win = c.Int(nullable: false),
                        Lose = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UsersClassModels");
        }
    }
}
