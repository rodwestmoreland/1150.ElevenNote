namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Note", "CategoryId", "dbo.Category");
            DropIndex("dbo.Note", new[] { "CategoryId" });
            AddColumn("dbo.Category", "NoteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Category", "NoteId");
            AddForeignKey("dbo.Category", "NoteId", "dbo.Note", "NoteId", cascadeDelete: true);
            DropColumn("dbo.Note", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Note", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Category", "NoteId", "dbo.Note");
            DropIndex("dbo.Category", new[] { "NoteId" });
            DropColumn("dbo.Category", "NoteId");
            CreateIndex("dbo.Note", "CategoryId");
            AddForeignKey("dbo.Note", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
        }
    }
}
