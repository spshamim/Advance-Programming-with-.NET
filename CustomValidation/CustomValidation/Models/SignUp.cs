using CustomValidation.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomValidation.Models
{
    public class SignUp
    {
        [Required]
        [DisplayName("AIUB ID")]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "The ID must be in XX-YYYYY-Z pattern.")]
        public string Id { get; set; }
        [Required]
        [DisplayName("AIUB Email")]
        [IdEmailSameCheck]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]

        public string Profession { get; set; }

        [AtLeastOneItem(ErrorMessage = "At least one hobby must be selected.")]
        public List<string> Hobbies { get; set; } = new List<string>();
    }
}