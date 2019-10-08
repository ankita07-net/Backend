using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrialProject.Entities
{
    public class User
    {
        [Key]
        public int UId { get; set; }
       
        public string Uname { get; set; }
        public int Password { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
    }
}