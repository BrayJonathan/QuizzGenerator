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
    class Employee
    {
        #region Properties
        private int _EmployeeId;
        private string _LastName;
        private string _FirstName;
        private DateTime _BirthDate;
        private string _Email;
        private string _Login;
        private string _Password;
        #endregion

        #region Accessors
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public DateTime BirthDate { get => _BirthDate; set => _BirthDate = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Login { get => _Login; set => _Login = value; }
        public string Password { get => _Password; set => _Password = value; }
        #endregion
    }
}
