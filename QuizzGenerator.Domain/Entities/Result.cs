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
    [Table("Result")]
    class Result
    {
        #region Properties
        //Fields
        private int _ResultId;
        private AnswerStateEnum _AnsweState;
        private string _Comment;

        //Relations

        //Variables
        #endregion

        #region Accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultId { get => _ResultId; set => _ResultId = value; }
        public AnswerStateEnum AnsweState { get => _AnsweState; set => _AnsweState = value; }
        public string Comment { get => _Comment; set => _Comment = value; }
        #endregion
    }
}
