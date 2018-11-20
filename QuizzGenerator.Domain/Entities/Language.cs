using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.Entities
{
    [Table("Language")]
    public class Language

    {
        #region properties
        private int _LanguageID;
        private string _Label;
        #endregion

        #region accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LanguageID { get => _LanguageID; set => _LanguageID = value; }
        public string Label { get => _Label; set => _Label = value; }
        #endregion



    }
}



