namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.AddressID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Pesel = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Position = c.String(),
                        Phone = c.Int(nullable: false),
                        Email = c.String(),
                        AddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Addresses", t => t.AddressID)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.Borrows",
                c => new
                    {
                        BorrowId = c.Int(nullable: false, identity: true),
                        BorrowDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        BookCopyID = c.Int(nullable: false),
                        ReaderID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BorrowId)
                .ForeignKey("dbo.BookCopies", t => t.BookCopyID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID)
                .ForeignKey("dbo.Readers", t => t.ReaderID)
                .Index(t => t.BookCopyID)
                .Index(t => t.ReaderID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.BookCopies",
                c => new
                    {
                        BookCopyID = c.Int(nullable: false, identity: true),
                        PublishYear = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookCopyID)
                .ForeignKey("dbo.Books", t => t.BookID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        ISBN = c.Int(nullable: false),
                        Title = c.String(),
                        Destription = c.String(),
                        PublisherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Publishers", t => t.PublisherID)
                .Index(t => t.PublisherID);
            
            CreateTable(
                "dbo.Authorships",
                c => new
                    {
                        AuthorshipID = c.Int(nullable: false, identity: true),
                        AuthorID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorshipID)
                .ForeignKey("dbo.Authors", t => t.AuthorID)
                .ForeignKey("dbo.Books", t => t.BookID)
                .Index(t => t.AuthorID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                        AuthorSurname = c.String(),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.BookSubjects",
                c => new
                    {
                        BookSubjectID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookSubjectID)
                .ForeignKey("dbo.Books", t => t.BookID)
                .ForeignKey("dbo.Subjects", t => t.SubjectID)
                .Index(t => t.BookID)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherID = c.Int(nullable: false, identity: true),
                        PublisherName = c.String(),
                        AddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PublisherID)
                .ForeignKey("dbo.Addresses", t => t.AddressID)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.BookKeyWords",
                c => new
                    {
                        BookKeyWordID = c.Int(nullable: false, identity: true),
                        BookCopyID = c.Int(nullable: false),
                        KeyWordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookKeyWordID)
                .ForeignKey("dbo.BookCopies", t => t.BookCopyID)
                .ForeignKey("dbo.KeyWords", t => t.KeyWordID)
                .Index(t => t.BookCopyID)
                .Index(t => t.KeyWordID);
            
            CreateTable(
                "dbo.KeyWords",
                c => new
                    {
                        KeyWordID = c.Int(nullable: false, identity: true),
                        KeyWordName = c.String(),
                    })
                .PrimaryKey(t => t.KeyWordID);
            
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        ReaderID = c.Int(nullable: false, identity: true),
                        Pesel = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        AddressID = c.Int(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ReaderID)
                .ForeignKey("dbo.Addresses", t => t.AddressID)
                .Index(t => t.AddressID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Borrows", "ReaderID", "dbo.Readers");
            DropForeignKey("dbo.Readers", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Borrows", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Borrows", "BookCopyID", "dbo.BookCopies");
            DropForeignKey("dbo.BookKeyWords", "KeyWordID", "dbo.KeyWords");
            DropForeignKey("dbo.BookKeyWords", "BookCopyID", "dbo.BookCopies");
            DropForeignKey("dbo.Books", "PublisherID", "dbo.Publishers");
            DropForeignKey("dbo.Publishers", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.BookSubjects", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.BookSubjects", "BookID", "dbo.Books");
            DropForeignKey("dbo.BookCopies", "BookID", "dbo.Books");
            DropForeignKey("dbo.Authorships", "BookID", "dbo.Books");
            DropForeignKey("dbo.Authorships", "AuthorID", "dbo.Authors");
            DropForeignKey("dbo.Employees", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Readers", new[] { "AddressID" });
            DropIndex("dbo.BookKeyWords", new[] { "KeyWordID" });
            DropIndex("dbo.BookKeyWords", new[] { "BookCopyID" });
            DropIndex("dbo.Publishers", new[] { "AddressID" });
            DropIndex("dbo.BookSubjects", new[] { "SubjectID" });
            DropIndex("dbo.BookSubjects", new[] { "BookID" });
            DropIndex("dbo.Authorships", new[] { "BookID" });
            DropIndex("dbo.Authorships", new[] { "AuthorID" });
            DropIndex("dbo.Books", new[] { "PublisherID" });
            DropIndex("dbo.BookCopies", new[] { "BookID" });
            DropIndex("dbo.Borrows", new[] { "EmployeeID" });
            DropIndex("dbo.Borrows", new[] { "ReaderID" });
            DropIndex("dbo.Borrows", new[] { "BookCopyID" });
            DropIndex("dbo.Employees", new[] { "AddressID" });
            DropTable("dbo.Readers");
            DropTable("dbo.KeyWords");
            DropTable("dbo.BookKeyWords");
            DropTable("dbo.Publishers");
            DropTable("dbo.Subjects");
            DropTable("dbo.BookSubjects");
            DropTable("dbo.Authors");
            DropTable("dbo.Authorships");
            DropTable("dbo.Books");
            DropTable("dbo.BookCopies");
            DropTable("dbo.Borrows");
            DropTable("dbo.Employees");
            DropTable("dbo.Addresses");
        }
    }
}
