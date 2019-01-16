using QuizzGenerator.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizzGenerator.Domain.Entities;
using QuizzGenerator.Domain.ViewModels;
using QuizzGenerator.Services.Services;
using System.Data.Entity;
using System.Net;

namespace QuizGenerator.Web.Controllers
{
    public class CandidateController : Controller
    {
        CandidateServices candidateService = new CandidateServices();

        // GET: Candidate
        public ActionResult Index()
        {
            var candidates = candidateService.GetCandidates();
            return View(candidates);
        }

        // GET: Candidate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateViewModels candidate = candidateService.GetCandidateById((int)id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // GET: Candidate/Create
        public ActionResult Create()
        {
            QuizContext db = new QuizContext();
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "LastName");
            return View();
        }

        // POST: Candidate/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CandidateViewModels candidateViewModels)
        {
            if (ModelState.IsValid)
            {
                candidateService.AddNewCandidate(candidateViewModels);
                return RedirectToAction("Index");
            }

            QuizContext db = new QuizContext();
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "LastName", candidateViewModels.EmployeeId);
            return View(candidateViewModels);
        }

        // GET: Candidate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateViewModels candidate = candidateService.GetCandidateById((int)id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            QuizContext db = new QuizContext();
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "LastName", candidate.EmployeeId);
            return View(candidate);
        }

        // POST: Candidate/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CandidateViewModels candidateViewModels)
        {
            if (ModelState.IsValid)
            {
                candidateService.EditCandidate(candidateViewModels);
                return RedirectToAction("Index");
            }
            QuizContext db = new QuizContext();
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "LastName", candidateViewModels.EmployeeId);
            return View(candidateViewModels);
        }













    }
}