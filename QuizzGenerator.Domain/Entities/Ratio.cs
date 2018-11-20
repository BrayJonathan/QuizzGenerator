using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.Entities
{
    [Table("Ratio")]
    public class Ratio
    {
        #region properties
        //Fields
        private int _RatioId;
        private int _Junior;
        private int __Confirmed;
        private int _Expert;

        //Relations

        //Variables
        #endregion

        #region accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatioId { get => _RatioId; set => _RatioId = value; }
        public int Junior { get => _Junior; set => _Junior = value; }
        public int Confirmed { get => __Confirmed; set => __Confirmed = value; }
        public int Expert { get => _Expert; set => _Expert = value; }


        #endregion
    }
}
