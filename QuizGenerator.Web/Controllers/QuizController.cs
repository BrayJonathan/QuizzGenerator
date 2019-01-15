using QuizzGenerator.Domain.Entities;
using QuizzGenerator.Domain.ViewModels;
using QuizzGenerator.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizGenerator.Web.Controllers
{
    public class QuizController : Controller
    {
        QuizService quizService = new QuizService();

        // GET: Quiz
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            QuizContext db = new QuizContext();
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "LastName");
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageID", "LanguageName");
            ViewBag.CandidateId = new SelectList(db.Candidates, "CandidateID", "LastName");
            ViewBag.LevelId = new SelectList(db.Levels, "LevelID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuizViewModels viewModel)
        {
            var newQuiz = quizService.AddNewBaseQuiz(viewModel);
            return RedirectToAction("Index");
        }

        //Get : Maj Quiz
        public ActionResult Edit()
        {
            QuizContext db = new QuizContext();
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "LastName");
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageID", "LanguageName");
            ViewBag.CandidateId = new SelectList(db.Candidates, "CandidateID", "LastName");
            ViewBag.LevelId = new SelectList(db.Levels, "LevelID", "Name");
            return View();
        }

       
        [HttpPost]
        public ActionResult Edit (QuizViewModels viewModel)
        {
            QuizContext db = new QuizContext();
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "LastName");
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageID", "LanguageName");
            ViewBag.CandidateId = new SelectList(db.Candidates, "CandidateID", "LastName");
            ViewBag.LevelId = new SelectList(db.Levels, "LevelID", "Name");
            var majQuizAnswer = quizService.UpdateQuizAnswer(viewModel);
            return RedirectToAction("Index");
        }
        

        //Get : Technologies


        public ActionResult GetTechno()
        {
            var getTechno = quizService.GetTechnologies(false);
            return RedirectToAction("Index");
        }

        //Get : Level



        public ActionResult GetNiveau()
        {
            var getNiveau = quizService.GetLevel(false);
            return RedirectToAction("Index");
        }

        // Get : QuizQuestionList

        public ActionResult QuizQuestionList()

        {
            return View();
        }

        public ActionResult GetQuizQuestionList(int quizId, int languageId, int levelId, int quizQuestionCount)
        {
            quizService.InitQuizQuestionList(quizId, languageId, levelId, quizQuestionCount);
            return RedirectToAction("Index");
        }


        // Get : QuizQuestion

        public ActionResult GetQuizQuestion(int id)
        {
            var getQuizQuestion = quizService.GetQuizQuestions(id);
            return RedirectToAction("Index");
        }

        //Get : Quizes


        public ActionResult Quizes()
        {
            var getQuizes = quizService.GetQuizes();
            return RedirectToAction("Index");
        }





    }
}