using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizzGenerator.Domain.Entities;
using QuizzGenerator.Services.

namespace QuizzGenerator.Services.Services
{
    class CandidateServices
    {
        /// <summary>
        /// Add new Candidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewCandidate(Candidate model)
        {
            return 0;
        }

        /// <summary>
        /// return all candidate liste
        /// </summary>
        /// <returns></returns>
        public List<Candidate> GetCandidates()
        {
            return new List<Candidate>();
        }

        /// <summary>
        /// return a candidate by id's
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Candidate GetCandidateById(int id)
        {
            return new Candidate();
        }

    }
}
