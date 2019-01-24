namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authorships", "AuthorID", "dbo.Authors");
            DropForeignKey("dbo.Authorships", "BookID", "dbo.Books");
            DropIndex("dbo.Authorships", new[] { "AuthorID" });
            DropIndex("dbo.Authorships", new[] { "BookID" });
            AddColumn("dbo.Books", "AuthorID", c => c.Int(nullable: false));
            DropTable("dbo.Authorships");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Authorships",
                c => new
                    {
                        AuthorshipID = c.Int(nullable: false, identity: true),
                        AuthorID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorshipID);
            
            DropColumn("dbo.Books", "AuthorID");
            CreateIndex("dbo.Authorships", "BookID");
            CreateIndex("dbo.Authorships", "AuthorID");
            AddForeignKey("dbo.Authorships", "BookID", "dbo.Books", "BookID");
            AddForeignKey("dbo.Authorships", "AuthorID", "dbo.Authors", "AuthorID");
        }
    }
}
