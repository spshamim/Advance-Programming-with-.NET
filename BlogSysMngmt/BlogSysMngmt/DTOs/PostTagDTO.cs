using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSysMngmt.DTOs
{
    public class PostTagDTO
    {
        public int post_tag_id { get; set; }
        public int post_id { get; set; }
        public int tag_id { get; set; }
        public string tag_name { get; set; }
    }
}