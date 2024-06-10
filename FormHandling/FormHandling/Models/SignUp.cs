using FormHandling.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormHandling.Models
{
    public class SignUp
    {
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        
        public string Profession { get; set; }

        [AtLeastOneItem(ErrorMessage = "At least one hobby must be selected.")]
        public List<string> Hobbies { get; set; } = new List<string>();
    }
}