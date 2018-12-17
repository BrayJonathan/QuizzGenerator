using QuizzGenerator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.ViewModels.Mapping
{
    public static class Map
    {
        
        public static QuizViewModels MapToQuizViewmodel(this Quiz quiz)
        {
            var quizVM = new QuizViewModels();

            if (quiz == null)
            {
                return quizVM;
            }

            quizVM = new QuizViewModels()
            {
                QuizId = quiz.QuizId,
                CreationDate = quiz.CreationDate,
                Duration = quiz.Duration,
                QuestionNumber = quiz.QuestionNumber,
                IsRealized = quiz.IsRealized,
                CurrentQuestion = quiz.CurrentQuestion,
                URL = quiz.URL,
                LevelId = quiz.LevelId,
                LevelName = quiz.Level.Name,
                LanguageId = quiz.LanguageId,
                LanguageName = quiz.Language.Label,
                EmployeeId = quiz.EmployeeId,
                EmployeeName = $"{quiz.EmployeeCreator.FirstName} {quiz.EmployeeCreator.LastName}",
                CandidateViewModels = quiz.Candidate.MapToCandidateViewModels()
            };
           
            return quizVM;
        }

        public static CandidateViewModels MapToCandidateViewModels(this Candidate candidate)
        {
            var candidateVM = new CandidateViewModels();

            if (candidate == null)
            {
                return candidateVM;
            }

            candidateVM = new CandidateViewModels()
            {
                CandidateID = candidate.CandidateID,
                LastName = candidate.LastName,
                FirstName = candidate.FirstName,
                PhoneNumber = candidate.PhoneNumber,
                Email = candidate.Email,
                EmployeeId = candidate.EmployeeId
            };
            return candidateVM;
        }

        public static Candidate MapToCandidate(this CandidateViewModels candidateVM)
        {
            var candidate = new Candidate();

            if (candidateVM == null)
            {
                return candidate;
            }

            candidate = new Candidate()
            {
                CandidateID = candidateVM.CandidateID,
                LastName = candidateVM.LastName,
                FirstName = candidateVM.FirstName,
                PhoneNumber = candidateVM.PhoneNumber,
                Email = candidateVM.Email,
                EmployeeId = candidateVM.EmployeeId
            };

            return candidate;
        }


    }
}
