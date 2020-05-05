using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace AppCMS.Models
{
    public class SignupNewMemberModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string LoginName { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordRepeat { get; set; }

    }
}