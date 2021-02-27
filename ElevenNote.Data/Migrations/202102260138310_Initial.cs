namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                {
                    CategoryId = c.Int(nullable: false, identity: true),
                    OwnerId = c.Guid(nullable: false),
                    Title = c.String(),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.CategoryId);

            CreateTable(
                "dbo.Note",
                c => new
                {
                    NoteId = c.Int(nullable: false, identity: true),
                    OwnerId = c.Guid(nullable: false),
                    CategoryId = c.Int(nullable: false),
                    Title = c.String(nullable: false),
                    Content = c.String(nullable: false),
                    CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifiedUtc = c.DateTimeOffset(precision: 7),
                })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
        }
            
            
        
        public override void Down()
        {
            
            DropForeignKey("dbo.Note", "CategoryId", "dbo.Category");
            DropIndex("dbo.Note", new[] { "CategoryId" });
            DropTable("dbo.Note");
            DropTable("dbo.Category");
        }
    }
}
