using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomValidation.Models
{
    public class Login
    {
        //[Required(ErrorMessage ="Username field can't be empty!")]
        [Required]
        [DisplayName("UserName")]
        [StringLength(10, MinimumLength = 3)]
        public string Uname { get; set; }

        //[Required(ErrorMessage = "Password field can't be empty!")] //custom msg
        [Required]
        [DisplayName("Password")]
        [StringLength(10, MinimumLength = 4)]
        public string Pass { get; set; }
    }
}