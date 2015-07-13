namespace FormManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Forms_1_0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Form_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forms", t => t.Form_Id)
                .Index(t => t.Form_Id);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        NextQuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.NextQuestionId, cascadeDelete: true)
                .Index(t => t.NextQuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Form_Id", "dbo.Forms");
            DropForeignKey("dbo.Answers", "NextQuestionId", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "NextQuestionId" });
            DropIndex("dbo.Questions", new[] { "Form_Id" });
            DropTable("dbo.Answers");
            DropTable("dbo.Questions");
        }
    }
}
