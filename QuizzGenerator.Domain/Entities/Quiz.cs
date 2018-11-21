﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.Entities
{
    [Table("Quiz")]
    public class Quiz
    {
        #region Properties
        //Fields
        private int _QuizId;
        private DateTime _CreationDate;
        private double _Duration;
        private int _QuestionNumber;
        private bool _IsRealized;
        private int _CurrentQuestion;
        private string _URL;
        private int _CreatedBy;
        //Relations
        public virtual Employee EmployeeCreator { get; set; }

        //Variables
        #endregion

        #region Accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizId { get => _QuizId; set => _QuizId = value; }
        public DateTime CreationDate { get => _CreationDate; set => _CreationDate = value; }
        public double Duration { get => _Duration; set => _Duration = value; }
        public int QuestionNumber { get => _QuestionNumber; set => _QuestionNumber = value; }
        public bool IsRealized { get => _IsRealized; set => _IsRealized = value; }
        public int CurrentQuestion { get => _CurrentQuestion; set => _CurrentQuestion = value; }
        public string URL { get => _URL; set => _URL = value; }
        [ForeignKey("EmployeeCreator"), Column("CreatedBy")]
        public int CreatedBy { get => _CreatedBy; set => _CreatedBy = value; }
        #endregion
    }
}
