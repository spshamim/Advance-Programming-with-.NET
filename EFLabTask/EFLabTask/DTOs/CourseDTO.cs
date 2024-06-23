using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFLabTask.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [RegularExpression("^(1|2|3)$", ErrorMessage = "Credit Hour must be 1, 2, or 3.")]
        public string CrdtHr { get; set; }
        [Required]
        [RegularExpression("^(Lab|Theory/Lab)$", ErrorMessage = "Type must be 'Lab' or 'Theory/Lab'.")]
        public string Type { get; set; }
    }
}