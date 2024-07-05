using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSysMngmt.DTOs
{
    public class BlogDTO
    {
        public int post_id { get; set; }
        public int user_id { get; set; }
        public string title { get; set; }
        public string p_content { get; set; }
        public System.DateTime pub_date { get; set; }
    }
}