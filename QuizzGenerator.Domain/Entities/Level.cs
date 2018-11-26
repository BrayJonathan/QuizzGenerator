using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.Entities
{
    [Table("Level")]
    public class Level
    {
        #region Properties
        //Fields
        private int _LevelID;
        private string _Name;
        private int _EmployeeId;

        //Relations
        public virtual Employee EmployeeCreator { get; set; }
        public virtual ICollection<Candidate> Candidates {get;set;}
        //Variables
        #endregion

        #region Accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LevelID { get => _LevelID; set => _LevelID = value; }
        public string Name { get => _Name; set => _Name = value; }
        [ForeignKey("EmployeeCreator"), Column("CreatedBy")]
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        #endregion
    }
}
