using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizzGenerator.Domain.Entities;
using QuizzGenerator.Services.Interfaces;

namespace QuizzGenerator.Services.Services
{
    public class QuizService : IQuizService
    {
        /// <summary>
        /// Création d'un quiz avec les information du candidat
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewBaseQuiz(Candidate model)
        {
            return 0;
        }

        /// <summary>
        /// Mise a jour des réponses du candidat
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateQuizAnswer(Quiz model)
        {
            return false;
        }

        /// <summary>
        /// Permet d'afficher la dropdownlist concérnant le choix de la techno
        /// </summary>
        /// <param name="includeDisabled"></param>
        /// <returns></returns>
        public Dictionary<int, string> GetTechnologies(bool includeDisabled)
        {
            return new Dictionary<int, string>();
        }

        /// <summary>
        /// Permet d'afficher la dropdownlist concérnant le choix du niveau du candidat
        /// </summary>
        /// <param name="includeDisabled"></param>
        /// <returns></returns>
        public Dictionary<int, string> GetSkills(bool includeDisabled)
        {
            return new Dictionary<int, string>();
        }


        /// <summary>
        /// Initialistation de quiz afin de récupérer une liste aléatoire des questions 
        /// </summary>
        /// <param name="quizId"></param>
        /// <param name="technologyId"></param>
        /// <param name="skillLevelId"></param>
        /// <param name="quizQuestioncount"></param>
        public void InitQuizQuestionList(int quizId, int technologyId, int skillLevelId, int quizQuestionCount)
        {

        }

        /// <summary>
        /// Récuperation des quetions du quiz
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Quiz GetQuizQuestions(int id)
        {
            return new Quiz();
        }

        /// <summary>
        /// Récuperation de tout les quizes
        /// </summary>
        /// <returns></returns>
        // public List<QuizSummaryViewModel> GetSummaryQuizes() 

        /// <summary>
        /// Récuperation de tout les quizs avec les questions
        /// </summary>
        /// <returns></returns>
        public List<Quiz> GetQuizes()
        {
            return new List<Quiz>();
        }




    }
}
