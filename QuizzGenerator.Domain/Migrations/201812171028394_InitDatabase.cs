namespace QuizzGenerator.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Quiz", "ResultId", "dbo.Result");
            DropForeignKey("dbo.Question", "ResultId", "dbo.Result");
            DropIndex("dbo.Question", new[] { "ResultId" });
            DropIndex("dbo.Quiz", new[] { "ResultId" });
            AddColumn("dbo.Result", "QuizId", c => c.Int(nullable: false));
            AddColumn("dbo.Result", "QuestionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Result", "QuizId");
            CreateIndex("dbo.Result", "QuestionId");
            AddForeignKey("dbo.Result", "QuestionId", "dbo.Question", "QuestionId");
            AddForeignKey("dbo.Result", "QuizId", "dbo.Quiz", "QuizId");
            DropColumn("dbo.Question", "ResultId");
            DropColumn("dbo.Quiz", "ResultId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quiz", "ResultId", c => c.Int(nullable: false));
            AddColumn("dbo.Question", "ResultId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Result", "QuizId", "dbo.Quiz");
            DropForeignKey("dbo.Result", "QuestionId", "dbo.Question");
            DropIndex("dbo.Result", new[] { "QuestionId" });
            DropIndex("dbo.Result", new[] { "QuizId" });
            DropColumn("dbo.Result", "QuestionId");
            DropColumn("dbo.Result", "QuizId");
            CreateIndex("dbo.Quiz", "ResultId");
            CreateIndex("dbo.Question", "ResultId");
            AddForeignKey("dbo.Question", "ResultId", "dbo.Result", "ResultId");
            AddForeignKey("dbo.Quiz", "ResultId", "dbo.Result", "ResultId");
        }
    }
}
