namespace FormManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Forms_1_1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "NextQuestionId", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "NextQuestionId" });
            AddColumn("dbo.Answers", "Question_Id", c => c.Int());
            CreateIndex("dbo.Answers", "Question_Id");
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropColumn("dbo.Answers", "Question_Id");
            CreateIndex("dbo.Answers", "NextQuestionId");
            AddForeignKey("dbo.Answers", "NextQuestionId", "dbo.Questions", "Id", cascadeDelete: true);
        }
    }
}
