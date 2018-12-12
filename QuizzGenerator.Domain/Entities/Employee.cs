using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.Entities
{
    [Table("Employee")]
    public class Employee
    {
        #region Properties
        //Fields
        private int _EmployeeId;
        private string _LastName;
        private string _FirstName;
        private DateTime _BirthDate;
        private string _Email;
        private int _ProfileId;

        //Relations
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Ratio> RatiosCreated { get; set; }
        public virtual ICollection<Level> LevelsCreated { get; set; }
        public virtual ICollection<Language> LanguagesCreated { get; set; }
        public virtual ICollection<Candidate> CandidatesCreated { get; set; } 
        public virtual ICollection<Question> QuestionsCreated { get; set; }
        public virtual ICollection<QuestionOption> QuestionOptionsCreated { get; set; }
        public virtual ICollection<Quiz> QuizzesCreated { get; set; }
        #endregion


        #region Accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public DateTime BirthDate { get => _BirthDate; set => _BirthDate = value; }
        public string Email { get => _Email; set => _Email = value; }
        [ForeignKey("Profile")]
        public int ProfileId { get => _ProfileId; set => _ProfileId = value; }
        #endregion
    }
}
