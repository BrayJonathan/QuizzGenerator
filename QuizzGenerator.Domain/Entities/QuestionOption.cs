﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.Entities
{
    [Table("QuestionOption")]
    public class QuestionOption
    {
        #region 
        //Fields
        private int _AnswerId;
        private string _Label;
        private bool _IsGood;
        private int _EmployeeId;
        //Relations
        public virtual Employee EmployeeCreator { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        //Variables
        #endregion

        #region accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get => _AnswerId; set => _AnswerId = value; }
        public string Label { get => _Label; set => _Label = value; }
        public bool IsGood { get => _IsGood; set => _IsGood = value; }
        [ForeignKey("EmployeeCreator"), Column("EmployeeId")]
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        #endregion
    }
}
