using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSysMngmt.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "Name must be between 7 and 20 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9]{7,20}$", ErrorMessage = "Name can contain letters and numbers only, no special characters or spaces.")]
        [DisplayName("User Name")]
        public string Uname { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one number, and one special character.")]
        public string Password { get; set; }
    }
}