using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzGenerator.Domain.Entities
{
    [Table("Profile")]
    class Profile
    {
        #region Properties
        private int _ProfileId;
        private string _Label;
        private bool _HasRightToCreate;
        #endregion

        #region Accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfileId { get => _ProfileId; set => _ProfileId = value; }
        public string Label { get => _Label; set => _Label = value; }
        public bool HasRightToCreate { get => _HasRightToCreate; set => _HasRightToCreate = value; }
        #endregion
    }
}
