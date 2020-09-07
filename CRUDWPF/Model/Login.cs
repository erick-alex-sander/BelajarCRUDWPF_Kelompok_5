using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWPF.Model
{
    [Table("Tb_M_User")]
    public class Login
    {
        [Key]
        public int ID { get; set; }
        [EmailAddress]
        [Index(IsUnique =true)]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsForgot { get; set; }

        public Login()
        {

        }

        public Login (string email, string password, bool isforgot)
        {
            Email = email;
            Password = password;
            IsForgot = isforgot;
        }

        public Login(bool isforgot)
        {
            IsForgot = isforgot;
        }
    }
}
