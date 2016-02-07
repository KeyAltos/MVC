namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        DeathDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppreiserId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        GradeValue = c.Byte(nullable: false),
                        Comment = c.String(),
                        IsBookHadRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.AppreiserId)
                .ForeignKey("dbo.Book", t => t.BookId)
                .Index(t => t.AppreiserId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(),
                        Description = c.String(),
                        RoleId = c.Int(nullable: false),
                        BirthDate = c.DateTime(),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Friendship",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FriendOneId = c.Int(nullable: false),
                        FriendTwoId = c.Int(nullable: false),
                        ApprovedByFriendOne = c.Boolean(nullable: false),
                        ApprovedByFriendTwo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.FriendOneId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.FriendTwoId)
                .Index(t => t.FriendOneId)
                .Index(t => t.FriendTwoId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        MessageSendingTime = c.DateTime(nullable: false),
                        MessageText = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.ReceiverId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookGenres",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Genre_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Genre_Id })
                .ForeignKey("dbo.Book", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.Genre_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Genre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "AuthorId", "dbo.Author");
            DropForeignKey("dbo.Grade", "BookId", "dbo.Book");
            DropForeignKey("dbo.User", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Message", "SenderId", "dbo.User");
            DropForeignKey("dbo.Message", "ReceiverId", "dbo.User");
            DropForeignKey("dbo.Grade", "AppreiserId", "dbo.User");
            DropForeignKey("dbo.Friendship", "FriendTwoId", "dbo.User");
            DropForeignKey("dbo.Friendship", "FriendOneId", "dbo.User");
            DropForeignKey("dbo.BookGenres", "Genre_Id", "dbo.Genre");
            DropForeignKey("dbo.BookGenres", "Book_Id", "dbo.Book");
            DropIndex("dbo.BookGenres", new[] { "Genre_Id" });
            DropIndex("dbo.BookGenres", new[] { "Book_Id" });
            DropIndex("dbo.Message", new[] { "ReceiverId" });
            DropIndex("dbo.Message", new[] { "SenderId" });
            DropIndex("dbo.Friendship", new[] { "FriendTwoId" });
            DropIndex("dbo.Friendship", new[] { "FriendOneId" });
            DropIndex("dbo.User", new[] { "RoleId" });
            DropIndex("dbo.Grade", new[] { "BookId" });
            DropIndex("dbo.Grade", new[] { "AppreiserId" });
            DropIndex("dbo.Book", new[] { "AuthorId" });
            DropTable("dbo.BookGenres");
            DropTable("dbo.Role");
            DropTable("dbo.Message");
            DropTable("dbo.Friendship");
            DropTable("dbo.User");
            DropTable("dbo.Grade");
            DropTable("dbo.Genre");
            DropTable("dbo.Book");
            DropTable("dbo.Author");
        }
    }
}
