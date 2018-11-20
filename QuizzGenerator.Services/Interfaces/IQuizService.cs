using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizzGenerator.Domain.Entities;


namespace QuizzGenerator.Services.Interfaces
{
    interface IQuizService
    {
        int AddNewBaseQuiz(Candidate model);
        bool UpdateQuizAnswer(Quiz model);
        Dictionary<int, string> GetTechnologies(bool includeDisabled);
        Dictionary<int, string> GetSkills(bool includeDisabled);
        void InitQuizQuestionList(int quizId, int technologyId, int skillLevelId, int quizQuestionCount);
        Quiz GetQuizQuestions(int id);
        //List<QuizSummaryViewModel> GetSummaryQuizes()
        List<Quiz> GetQuizes();
    }
}
