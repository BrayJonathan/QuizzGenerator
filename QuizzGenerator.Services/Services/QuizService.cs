using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizzGenerator.Domain.Entities;
using QuizzGenerator.Services.Interfaces;
using QuizzGenerator.Domain.ViewModels;
using QuizzGenerator.Domain.ViewModels.Mapping;
using QuizzGenerator.Domain.ExtensionMethods;

namespace QuizzGenerator.Services.Services
{
    public class QuizService : IQuizService
    {
        /// <summary>
        /// Création d'un quiz avec les informations du candidat
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewBaseQuiz(QuizViewModels quiz)
        {
            try
            {
                using (QuizContext db = new QuizContext())
                {
                    db.Quizzes.Add(quiz.MapToQuiz());
                    InitQuizQuestionList(quiz.QuizId, quiz.LanguageId, quiz.LevelId, quiz.QuestionNumber);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// Mise a jour des réponses du candidat
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateQuizAnswer(QuizViewModels model)
        {
            List<Result> results = new List<Result>();
            model.ResultViewModels.ToList().ForEach(x => results.Add(x.MapToResult()));
            try
            {
                using (QuizContext db = new QuizContext())
                {

                    Quiz quizToUpdate = db.Quizzes.Find(model.QuizId);
                    quizToUpdate.LanguageId = model.LanguageId;
                    quizToUpdate.LevelId = model.LevelId;
                    quizToUpdate.IsRealized = model.IsRealized;
                    quizToUpdate.CurrentQuestion = model.CurrentQuestion;
                    quizToUpdate.Duration = model.Duration;
                    quizToUpdate.URL = model.URL;
                    quizToUpdate.QuestionNumber = model.QuestionNumber;
                    quizToUpdate.Results = results;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Permet d'afficher la dropdownlist concérnant le choix de la techno
        /// </summary>
        /// <param name="includeDisabled">Inclure techno supprimer</param>
        /// <returns></returns>
        public Dictionary<int, string> GetTechnologies(bool includeDisabled)
        {
            Dictionary<int, string> technos = new Dictionary<int, string>();
            try
            {
                using (QuizContext db = new QuizContext())
                {
                    foreach (Language l in db.Languages.ToList())
                    {
                        technos.Add(l.LanguageID, l.LanguageName);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return technos;
        }

        /// <summary>
        /// Permet d'afficher la dropdownlist concérnant le choix du niveau du candidat
        /// </summary>
        /// <param name="includeDisabled">Inclure les Level supprimer</param>
        /// <returns></returns>
        public Dictionary<int, string> GetLevel(bool includeDisabled)
        {
            Dictionary<int, string> levels = new Dictionary<int, string>();
            try

            {
                using (QuizContext db = new QuizContext())
                {
                    foreach (Level level in db.Levels.ToList())
                    {
                        levels.Add(level.LevelID, level.Name);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return levels;
        }


        /// <summary>
        /// Initialistation de quiz afin de récupérer une liste aléatoire des questions 
        /// </summary>
        /// <param name="quizId"></param>
        /// <param name="technologyId"></param>
        /// <param name="skillLevelId"></param>
        /// <param name="quizQuestioncount"></param>
        public void InitQuizQuestionList(int quizId, int languageId, int levelId, int quizQuestionCount)
        {
            List<Question> questions = new List<Question>();
            try
            {
                using (QuizContext db = new QuizContext())
                {
                    Quiz quiz = db.Quizzes.Find(quizId);
                    if (quiz != null)
                    {
                        //Get ratios from Level
                        Level level = quiz.Level;


                        List<Question> temp = db.Questions.Where(q => q.LanguageId == languageId).ToList();

                        //shuffle list with extension methods
                        temp.Shuffle();
                        //foreach ratioLevel take question by ratio

                        foreach (Ratio r in level.Ratios.ToList())
                        {
                            int questionNumber = (int)Math.Ceiling(quizQuestionCount * r.Percent);
                            questions = temp.Where(q => q.LevelId == r.LevelRatioId).Take(questionNumber).ToList();
                            quiz.Results.ToList().AddRange(questions.Select(q => new Result()
                            {
                                QuestionId = q.QuestionId,
                                AnsweState = Domain.Enum.AnswerStateEnum.None,
                                QuizId = quizId
                            }));
                            questions.Clear();
                        }

                        if (quiz.Results.Count > quizQuestionCount)
                        {
                            int delta = quiz.Results.Count - quizQuestionCount;

                            for (int i = 0; i < delta; i++)
                            {
                                var resultToDelete = quiz.Results.Where(r => r.Question.LevelId == levelId).FirstOrDefault();
                                if (resultToDelete != null)
                                {
                                    quiz.Results.Remove(resultToDelete);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }


        }

        /// <summary>
        /// Récuperation des quetions du quiz
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Quiz GetQuizQuestions(int id)
        {
            try
            {
                using (QuizContext db = new QuizContext())
                {
                    return db.Quizzes.Where(q => q.QuizId == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                return new Quiz();
            }
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
            List<Quiz> quizzes = new List<Quiz>();
            try
            {
                using (QuizContext db = new QuizContext())
                {
                    quizzes = db.Quizzes.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return quizzes;
        }
    }
}
