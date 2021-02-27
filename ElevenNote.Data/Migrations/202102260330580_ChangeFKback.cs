namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFKback : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "NoteId", "dbo.Note");
            DropIndex("dbo.Category", new[] { "NoteId" });
            AddColumn("dbo.Note", "CategoryId", c => c.Int(nullable: true));
            CreateIndex("dbo.Note", "CategoryId");
            AddForeignKey("dbo.Note", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.Category", "NoteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "NoteId", c => c.Int(nullable: true));
            DropForeignKey("dbo.Note", "CategoryId", "dbo.Category");
            DropIndex("dbo.Note", new[] { "CategoryId" });
            DropColumn("dbo.Note", "CategoryId");
            CreateIndex("dbo.Category", "NoteId");
            AddForeignKey("dbo.Category", "NoteId", "dbo.Note", "NoteId", cascadeDelete: true);
        }
    }
}
