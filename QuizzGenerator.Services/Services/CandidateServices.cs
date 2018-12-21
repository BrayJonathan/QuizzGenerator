using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizzGenerator.Domain.Entities;


namespace QuizzGenerator.Services.Services
{
    class CandidateServices
    {
        /// <summary>
        /// Add new Candidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewCandidate(Candidate candidateViewModel)
        {
            try
            {
                using (QuizContext db = new QuizContext())
                {
                    //var model = candidateViewModel.MapViewModelToCandidate();// à faire: remplacer par la methode mapping de amine
                    db.Candidates.Add(candidateViewModel);
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
        /// return all candidate liste
        /// </summary>
        /// <returns></returns>
        public List<Candidate> GetCandidates() //mettre candidateviewmodel apres
        {
            List<Candidate> candidates = new List<Candidate>(); 
            
            try
            {
                using (QuizContext db = new QuizContext())
                {
                    //candidates = db.Candidates.ToList().ForEach(x => x.MapToCandidateViewModel());
                   
                }
            }
            catch (Exception ex)
            {
                
            }

            return candidates;

            //return new List<Candidate>();
        }

        /// <summary>
        /// return a candidate by id's
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Candidate GetCandidateById(int id)
        {
            Candidate candidate = new Candidate(); 
            try
            {
                using (QuizContext db = new QuizContext())
                {
                   //candidate =  db.Candidates.Find(id).MapViewModelToCandidate());

                }
            }
            catch (Exception ex)
            {
                
            }

            return candidate;

        }


    }
}
