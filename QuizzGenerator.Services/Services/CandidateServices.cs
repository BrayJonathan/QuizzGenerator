using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizzGenerator.Domain.Entities;
using QuizzGenerator.Domain.ViewModels;
using QuizzGenerator.Domain.ViewModels.Mapping;


namespace QuizzGenerator.Services.Services
{
    public class CandidateServices
    {
        /// <summary>
        /// Add new Candidate
        /// </summary>
        /// <param name="model"></param>
        public void AddNewCandidate(CandidateViewModels candidateViewModel)
        {
            using (QuizContext db = new QuizContext())
            {
                var candidate = candidateViewModel.MapToCandidate();
                db.Candidates.Add(candidate);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// return all candidate liste
        /// </summary>
        /// <returns>Listes des candidates</returns>
        public List<CandidateViewModels> GetCandidates()
        {
            List<CandidateViewModels> candidates = new List<CandidateViewModels>();
            try
            {
                using (QuizContext db = new QuizContext())
                {
                    foreach (Candidate c in db.Candidates)
                    {
                        candidates.Add(c.MapToCandidateViewModels());
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return candidates;
        }

        /// <summary>
        /// return a candidate by id's
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CandidateViewModels GetCandidateById(int id)
        {
            CandidateViewModels candidate = new CandidateViewModels();
            try
            {
                using (QuizContext db = new QuizContext())
                {
                    candidate = db.Candidates.Find(id).MapToCandidateViewModels();
                }
            }
            catch (Exception ex)
            {

            }
            return candidate;
        }

        /// <summary>
        /// Edit Candidate
        /// </summary>
        /// <param name="candidateViewModel"></param>
        public void EditCandidate(CandidateViewModels candidateVM)
        {
            using (QuizContext db = new QuizContext())
            {
                var candidate = db.Candidates.Where(c => c.CandidateID == candidateVM.CandidateID).SingleOrDefault();
                candidate.LastName = candidateVM.LastName;
                candidate.FirstName = candidateVM.FirstName;
                candidate.PhoneNumber = candidateVM.PhoneNumber;
                candidate.Email = candidateVM.Email;
                candidate.EmployeeId = candidateVM.EmployeeId;
                db.Entry(candidate).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
