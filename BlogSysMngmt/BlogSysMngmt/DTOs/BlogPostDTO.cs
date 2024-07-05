using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSysMngmt.DTOs
{
    public class BlogPostDTO
    {
        [Required]
        [MinLength(10)]
        [DisplayName("Title")]
        public string title { get; set; }
        
        [Required]
        [DisplayName("Blog Content")]
        [MinLength(100)]
        public string p_content { get; set; }
        [Required]
        public string tag_name { get; set; }
    }
}