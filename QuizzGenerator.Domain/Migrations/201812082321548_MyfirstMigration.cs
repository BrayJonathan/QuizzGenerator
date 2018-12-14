namespace QuizzGenerator.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyfirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidate",
                c => new
                    {
                        CandidateID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateID)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Profile", t => t.ProfileId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        LanguageID = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LanguageID)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Quiz",
                c => new
                    {
                        QuizId = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Duration = c.Double(nullable: false),
                        QuestionNumber = c.Int(nullable: false),
                        IsRealized = c.Boolean(nullable: false),
                        CurrentQuestion = c.Int(nullable: false),
                        URL = c.String(),
                        LevelId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        CandidateId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuizId)
                .ForeignKey("dbo.Candidate", t => t.CandidateId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.Language", t => t.LanguageId)
                .ForeignKey("dbo.Level", t => t.LevelId)
                .Index(t => t.LevelId)
                .Index(t => t.EmployeeId)
                .Index(t => t.CandidateId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Level",
                c => new
                    {
                        LevelID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LevelID)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Ratio",
                c => new
                    {
                        RatioId = c.Int(nullable: false, identity: true),
                        Junior = c.Int(nullable: false),
                        Confirmed = c.Int(nullable: false),
                        Expert = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatioId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionLabel = c.String(),
                        QuestionType = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.QuestionOption",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        IsGood = c.Boolean(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        HasRightToCreate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProfileId);
            
            CreateTable(
                "dbo.Result",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        AnsweState = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ResultId);
            
            CreateTable(
                "dbo.LanguageCandidates",
                c => new
                    {
                        Language_LanguageID = c.Int(nullable: false),
                        Candidate_CandidateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Language_LanguageID, t.Candidate_CandidateID })
                .ForeignKey("dbo.Language", t => t.Language_LanguageID)
                .ForeignKey("dbo.Candidate", t => t.Candidate_CandidateID)
                .Index(t => t.Language_LanguageID)
                .Index(t => t.Candidate_CandidateID);
            
            CreateTable(
                "dbo.LevelCandidates",
                c => new
                    {
                        Level_LevelID = c.Int(nullable: false),
                        Candidate_CandidateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Level_LevelID, t.Candidate_CandidateID })
                .ForeignKey("dbo.Level", t => t.Level_LevelID)
                .ForeignKey("dbo.Candidate", t => t.Candidate_CandidateID)
                .Index(t => t.Level_LevelID)
                .Index(t => t.Candidate_CandidateID);
            
            CreateTable(
                "dbo.RatioLevels",
                c => new
                    {
                        Ratio_RatioId = c.Int(nullable: false),
                        Level_LevelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ratio_RatioId, t.Level_LevelID })
                .ForeignKey("dbo.Ratio", t => t.Ratio_RatioId)
                .ForeignKey("dbo.Level", t => t.Level_LevelID)
                .Index(t => t.Ratio_RatioId)
                .Index(t => t.Level_LevelID);
            
            CreateTable(
                "dbo.QuestionOptionQuestions",
                c => new
                    {
                        QuestionOption_AnswerId = c.Int(nullable: false),
                        Question_QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionOption_AnswerId, t.Question_QuestionId })
                .ForeignKey("dbo.QuestionOption", t => t.QuestionOption_AnswerId)
                .ForeignKey("dbo.Question", t => t.Question_QuestionId)
                .Index(t => t.QuestionOption_AnswerId)
                .Index(t => t.Question_QuestionId);
            
            CreateTable(
                "dbo.QuestionQuizs",
                c => new
                    {
                        Question_QuestionId = c.Int(nullable: false),
                        Quiz_QuizId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_QuestionId, t.Quiz_QuizId })
                .ForeignKey("dbo.Question", t => t.Question_QuestionId)
                .ForeignKey("dbo.Quiz", t => t.Quiz_QuizId)
                .Index(t => t.Question_QuestionId)
                .Index(t => t.Quiz_QuizId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidate", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "ProfileId", "dbo.Profile");
            DropForeignKey("dbo.QuestionQuizs", "Quiz_QuizId", "dbo.Quiz");
            DropForeignKey("dbo.QuestionQuizs", "Question_QuestionId", "dbo.Question");
            DropForeignKey("dbo.QuestionOptionQuestions", "Question_QuestionId", "dbo.Question");
            DropForeignKey("dbo.QuestionOptionQuestions", "QuestionOption_AnswerId", "dbo.QuestionOption");
            DropForeignKey("dbo.QuestionOption", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Question", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Quiz", "LevelId", "dbo.Level");
            DropForeignKey("dbo.RatioLevels", "Level_LevelID", "dbo.Level");
            DropForeignKey("dbo.RatioLevels", "Ratio_RatioId", "dbo.Ratio");
            DropForeignKey("dbo.Ratio", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Level", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.LevelCandidates", "Candidate_CandidateID", "dbo.Candidate");
            DropForeignKey("dbo.LevelCandidates", "Level_LevelID", "dbo.Level");
            DropForeignKey("dbo.Quiz", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.Quiz", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Quiz", "CandidateId", "dbo.Candidate");
            DropForeignKey("dbo.Language", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.LanguageCandidates", "Candidate_CandidateID", "dbo.Candidate");
            DropForeignKey("dbo.LanguageCandidates", "Language_LanguageID", "dbo.Language");
            DropIndex("dbo.QuestionQuizs", new[] { "Quiz_QuizId" });
            DropIndex("dbo.QuestionQuizs", new[] { "Question_QuestionId" });
            DropIndex("dbo.QuestionOptionQuestions", new[] { "Question_QuestionId" });
            DropIndex("dbo.QuestionOptionQuestions", new[] { "QuestionOption_AnswerId" });
            DropIndex("dbo.RatioLevels", new[] { "Level_LevelID" });
            DropIndex("dbo.RatioLevels", new[] { "Ratio_RatioId" });
            DropIndex("dbo.LevelCandidates", new[] { "Candidate_CandidateID" });
            DropIndex("dbo.LevelCandidates", new[] { "Level_LevelID" });
            DropIndex("dbo.LanguageCandidates", new[] { "Candidate_CandidateID" });
            DropIndex("dbo.LanguageCandidates", new[] { "Language_LanguageID" });
            DropIndex("dbo.QuestionOption", new[] { "EmployeeId" });
            DropIndex("dbo.Question", new[] { "EmployeeId" });
            DropIndex("dbo.Ratio", new[] { "EmployeeId" });
            DropIndex("dbo.Level", new[] { "EmployeeId" });
            DropIndex("dbo.Quiz", new[] { "LanguageId" });
            DropIndex("dbo.Quiz", new[] { "CandidateId" });
            DropIndex("dbo.Quiz", new[] { "EmployeeId" });
            DropIndex("dbo.Quiz", new[] { "LevelId" });
            DropIndex("dbo.Language", new[] { "EmployeeId" });
            DropIndex("dbo.Employee", new[] { "ProfileId" });
            DropIndex("dbo.Candidate", new[] { "EmployeeId" });
            DropTable("dbo.QuestionQuizs");
            DropTable("dbo.QuestionOptionQuestions");
            DropTable("dbo.RatioLevels");
            DropTable("dbo.LevelCandidates");
            DropTable("dbo.LanguageCandidates");
            DropTable("dbo.Result");
            DropTable("dbo.Profile");
            DropTable("dbo.QuestionOption");
            DropTable("dbo.Question");
            DropTable("dbo.Ratio");
            DropTable("dbo.Level");
            DropTable("dbo.Quiz");
            DropTable("dbo.Language");
            DropTable("dbo.Employee");
            DropTable("dbo.Candidate");
        }
    }
}
