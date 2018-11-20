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
    class Question
    {
        #region Properties
        //Fields
        private int _QuestionId;
        private String _QuestionLabel;
        private QuestionTypeEnum _QuestionType;

        //Relations

        //Variables
        #endregion

        #region Accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get => _QuestionId; set => _QuestionId = value; }
        public string QuestionLabel { get => _QuestionLabel; set => _QuestionLabel = value; }
        public QuestionTypeEnum QuestionType { get => _QuestionType; set => _QuestionType = value; }
        #endregion
    }
}
