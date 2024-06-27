using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductMgmtSys.DTOs
{
    public class LoginDTO
    {
        [Required]
        [DisplayName("User Name")]
        public string Uname { get; set; }
        [Required]
        public string Password { get; set; }
    }
}