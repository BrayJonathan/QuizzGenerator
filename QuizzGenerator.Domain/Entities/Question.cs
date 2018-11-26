using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizzGenerator.Domain.Enum;

namespace QuizzGenerator.Domain.Entities
{
    [Table("Question")]
    public class Question
    {
        #region Properties
        //Fields
        private int _QuestionId;
        private String _QuestionLabel;
        private QuestionTypeEnum _QuestionType;
        private int _CreatedBy;
        //Relations
        public virtual Employee EmployeeCreator { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
        //Variables
        #endregion

        #region Accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get => _QuestionId; set => _QuestionId = value; }
        public string QuestionLabel { get => _QuestionLabel; set => _QuestionLabel = value; }
        public QuestionTypeEnum QuestionType { get => _QuestionType; set => _QuestionType = value; }
        [ForeignKey("EmployeeCreator"),Column("CreatedBy")]
        public int CreatedBy { get => _CreatedBy; set => _CreatedBy = value; }
        #endregion
    }
}
